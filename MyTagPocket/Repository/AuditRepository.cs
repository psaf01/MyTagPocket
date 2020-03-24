using LiteDB;
using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Audit;
using MyTagPocket.Repository.Interfaces;
using NeoSmart.AsyncLock;
using System;
using System.Collections.Generic;
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
            if (GetVersionDb(db) == 0)
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
          CheckAuditCollection(db, audit);
          DateTimeOffset dateTime = DateTimeOffset.Now;
          var audits = db.GetCollection<Entity.Audit>(audit.GetNameCollection);
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
          var audits = db.GetCollection<Entity.Audit>(Entity.Audit.GenerateNameCollection(year, month));
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
          var audits = db.GetCollection<Entity.Audit>(Entity.Audit.GenerateNameCollection(year, month));
          return audits.Count();
        }
      }
    }

    #region Update database
    private void InitializeAuditLogVer1(LiteDatabase db)
    {
      DatabaseSetUtcData(db);
      
      var dateTime = DateTimeOffset.Now;
      //First audit log
      Entity.Audit audit = new Entity.Audit();
      audit.Code = AuditCodes.InitAuditDb;
      audit.CreatedWhen = dateTime;
      audit.UserGuid = AppGlobal.UserSystem.UserGuid;
      audit.DeviceGuid = AppGlobal.Device.DeviceGuid;
      audit.DataType = DataTypeEnum.Audit;
      audit.Parameters = new string[] { dateTime.Year.ToString(), dateTime.Month.ToString() };
      
      CreateIndexAuditCollection(db, audit);
      CreateIndexAuditDbCollection(db);
      
      var colAudit = db.GetCollection<Entity.Audit>(audit.GetNameCollection);
      colAudit.Insert(audit);
      CheckAuditCollection(db, audit);
      SetVersionDb(db, 1);
    }

    #endregion Update database

    #region Private method
    /// <summary>
    /// Check audit collection exist and create new collection for audit if not exists
    /// </summary>
    /// <param name="db">Database</param>
    /// <param name="audit">Audit record</param>
    private void CheckAuditCollection(LiteDatabase db, Entity.Audit audit)
    {
      if (db.CollectionExists(audit.GetNameCollection))
        return;

      //First audit collection
      var col = new Entity.AuditDbCollection();
      col.CollectionName = audit.GetNameCollection;
      col.CreatedWhen = audit.CreatedWhen;
      var colDb = db.GetCollection<Entity.AuditDbCollection>(col.GetNameCollection);
      colDb.Insert(col);
      if (!(colDb.Count() > AppGlobal.Log.MaxAuditCollection))
        return;

      var deleteCol = colDb.FindOne(Query.All(-1));
      if (deleteCol == null)
        return;

      db.DropCollection(deleteCol.CollectionName);
    }
    /// <summary>
    /// Create new definition audit index collection
    /// </summary>
    /// <param name="db">Database</param>
    private void CreateIndexAuditDbCollection(LiteDatabase db)
    {
      var colDbDef = new Entity.AuditDbCollection();
      var colDb = db.GetCollection<Entity.AuditDbCollection>(colDbDef.GetNameCollection);
      colDb.EnsureIndex(nameof(colDbDef.CollectionName), true);
    }

    /// <summary>
    /// Create new audit index collection
    /// </summary>
    /// <param name="db">Database</param>
    /// <param name="audit">Audit</param>
    private void CreateIndexAuditCollection(LiteDatabase db, Entity.Audit audit)
    {
      var colAudit = db.GetCollection<Entity.Audit>(audit.GetNameCollection);
      colAudit.EnsureIndex(nameof(audit.CreatedWhen), false);
      colAudit.EnsureIndex(nameof(audit.DataType), false);
    }

    /// <summary>
    /// Set UTC datetime in LiteDB
    /// </summary>
    /// <param name="db"></param>
    private void DatabaseSetUtcData(LiteDatabase db)
    {
      db.Pragma("UTC_DATE", true);
    }

    /// <summary>
    /// Actual version Audit database
    /// </summary>
    /// <returns>Version</returns>
    private int GetVersionDb(LiteDatabase db)
    {
      int ver = 0;
      var dbVersion = db.Pragma("USER_VERSION");
      if (dbVersion == null)
        return ver;

      ver = dbVersion.AsInt32;
      return ver;
    }

    /// <summary>
    /// Set new user version LiteDb
    /// </summary>
    /// <param name="db"LiteDb session></param>
    /// <param name="newVersion">Number new version</param>
    private void SetVersionDb(LiteDatabase db, int newVersion)
    {
      db.Pragma("USER_VERSION", newVersion);
    }
    #endregion
  }
}
