using LiteDB;
using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Exceptions;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Audit;
using MyTagPocket.Repository.Interfaces;
using MyTagPocket.Resources;
using NeoSmart.AsyncLock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity = MyTagPocket.Repository.Audit.Entities;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// Audit repository
  /// </summary>
  public class AuditRepository : IAuditRepository
  {
    AsyncLock lockObject = new AsyncLock();

    /// <summary>
    /// Database helper instance
    /// </summary>
    public static IDalHelper DalHelper { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public AuditRepository(IDalHelper dalHelper)
    {
      DalHelper = dalHelper;
    }

    /// <summary>
    /// Initialize new audit log
    /// </summary>
    public async Task InitializeAuditLogAsync()
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            if (db.Engine.UserVersion == 0)
              InitializeAuditLogVer1(db);
          }
        }
      });
    }

    /// <summary>
    /// Save audit item
    /// </summary>
    /// <param name="audit">Audit item</param>
    public void Save(Entity.Audit audit)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          DateTimeOffset dateTime = DateTimeOffset.Now;
          var audits = db.GetCollection<Entity.Audit>($"audit{dateTime.Year.ToString("D4")}{dateTime.Month.ToString("D2")}");
          var x = audits.Insert(audit);
        }
      }
    }

    /// <summary>
    /// Delete audit items for year and month
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    public void DeleteAuditCollection(int year, int month)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          db.DropCollection($"audit{year.ToString("D4")}{month.ToString("D2")}");
        }
      }
    }

    /// <summary>
    /// Get audit items
    /// </summary>
    /// <param name="predicate">Filter predicate</param>
    /// <returns>Audits</returns>
    public IEnumerable<Entity.Audit> GetAudits(int year, int month, Expression<Func<Entity.Audit, bool>> predicate, int skip = 0, int limit = int.MaxValue)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          var audits = db.GetCollection<Entity.Audit>($"audit{year.ToString("D4")}{month.ToString("D2")}");
          return audits.Find(predicate, skip, limit);
        }
      }
    }

    /// <summary>
    /// Get audit items
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">Month</param>
    /// <param name="skip">Skip items</param>
    /// <param name="limit">Count return items</param>
    /// <returns>Audits</returns>
    public IEnumerable<Entity.Audit> GetAudits(int year, int month, int skip = 0, int limit = int.MaxValue)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          var audits = db.GetCollection<Entity.Audit>($"audit{year.ToString("D4")}{month.ToString("D2")}");
          return audits.Find(x => x.Id > 0, skip, limit);
        }
      }
    }

    /// <summary>
    /// Count audit items 
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">Month</param>
    /// <returns>Count audit items</returns>
    public int Count(int year, int month)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          var audits = db.GetCollection<Entity.Audit>($"audit{year.ToString("D4")}{month.ToString("D2")}");
          return audits.Count();
        }
      }
    }

    #region Update database
    private void InitializeAuditLogVer1(LiteDatabase db)
    {
      var dbColl = db.Engine.GetCollectionNames();
      int dbCollCount = 0;
      var findAuditDbColl = false;
      var findAudit = false;
      var dateTime = DateTimeOffset.Now;

      Entity.Audit a = new Entity.Audit();
      a.Code = AuditCodes.InitAuditDb;
      a.CreatedWhen = dateTime;
      a.UserGuid = AppGlobal.UserSystem.UserGuid;
      a.DeviceGuid = AppGlobal.Device.DeviceGuid;
      a.DataType = DataTypeEnum.Audit;
      a.Parameters = new string[] { dateTime.Year.ToString(), dateTime.Month.ToString() };

      var auditDbCollection = new Entity.AuditDbCollection();
      auditDbCollection.CollectionName = a.GetNameCollection;
      auditDbCollection.CreatedWhen = dateTime;

      foreach (var collName in dbColl)
      {
        if (collName == auditDbCollection.GetNameCollection)
          findAuditDbColl = true;

        if (collName == a.GetNameCollection)
          findAudit = true;

        dbCollCount++;
      }

      if (!findAuditDbColl)
      {
        db.Engine.EnsureIndex(auditDbCollection.GetNameCollection, nameof(auditDbCollection.CollectionName), false);
        var colAudit = db.GetCollection<Entity.AuditDbCollection>();
        colAudit.Insert(auditDbCollection);
      }

      if (!findAudit)
      {
        db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.Code), false);
        db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.CreatedWhen), false);
        db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.UserGuid), false);
        db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.DeviceGuid), false);
        db.Engine.EnsureIndex(a.GetNameCollection, nameof(a.DataType), false);
        var col = db.GetCollection<Entity.Audit>();
        col.Insert(a);
      }

      db.Engine.UserVersion = 1;
    }
    #endregion Update database
  }
}
