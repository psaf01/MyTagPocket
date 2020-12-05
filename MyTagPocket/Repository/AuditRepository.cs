using LiteDB;
using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.DbStorage;
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
    private DalDbLiteRepository dbRepository;

    private string actualAuditCollection = "";

    /// <summary>
    /// Constructor
    /// </summary>
    public AuditRepository()
    {
      dbRepository = new DalDbLiteRepository(new DbLiteMemmoryHelper());
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fullPathToDb">Full path to audit database</param>
    public AuditRepository(string fullPathToDb)
    {
      dbRepository = new DalDbLiteRepository(new DbLiteFileHelper(fullPathToDb));
    }

    /// <summary>
    /// Initialize new audit log
    /// </summary>
    public async Task InitializeAuditLogAsync()
    {
      await Task.Run(() =>
      {
        if (dbRepository.GetVersionDb() == 0)
          InitializeAuditLogVer2();
      });
    }

    /// <summary>
    /// Save audit item
    /// </summary>
    /// <param name="audit">Audit item</param>
    public async Task SaveAsync(Entity.Audit audit)
    {
      if (audit.GetNameCollection() != actualAuditCollection)
      {
        CheckAuditCollection(audit);
        actualAuditCollection = audit.GetNameCollection();
      }

      DateTimeOffset dateTime = DateTimeOffset.Now;
      await dbRepository.InsertAsync(audit, audit.GetNameCollection());
    }

    /// <summary>
    /// Delete audit items for year and month
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">month</param>
    public async Task DeleteAuditCollectionAsync(int year, int month)
    {
      await Task.Run(() =>
      {
        dbRepository.DeleteCollection($"audit{year.ToString("D4")}{month.ToString("D2")}");
      });
    }

    /// <summary>
    /// Get audit items
    /// </summary>
    /// <param name="predicate">Filter predicate</param>
    /// <returns>Audits</returns>
    public async Task<IEnumerable<Entity.Audit>> GetAuditsAsync(int year, int month, Expression<Func<Entity.Audit, bool>> predicate, int skip = 0, int limit = int.MaxValue)
    {
      return await dbRepository.FindAsync<Entity.Audit>(predicate, Entity.Audit.GenerateNameCollection(year, month), skip, limit);
    }

    /// <summary>
    /// Get audit items
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">Month</param>
    /// <param name="skip">Skip items</param>
    /// <param name="limit">Count return items</param>
    /// <returns>Audits</returns>
    public async Task<IEnumerable<Entity.Audit>> GetAuditsAsync(int year, int month, int skip = 0, int limit = int.MaxValue)
    {
      return await dbRepository.FindAsync<Entity.Audit>(x => x.Id > 0, Entity.Audit.GenerateNameCollection(year, month), skip, limit);
    }

    /// <summary>
    /// Count audit items 
    /// </summary>
    /// <param name="year">Year</param>
    /// <param name="month">Month</param>
    /// <returns>Count audit items</returns>
    public async Task<int> CountAsync(int year, int month)
    {
      return await dbRepository.CountAsync(Entity.Audit.GenerateNameCollection(year, month));
    }

    #region Update database
    private void InitializeAuditLogVer2()
    {
      dbRepository.InitDatabase();
      dbRepository.SetVersionDb(1);
      var dateTime = DateTimeOffset.Now;
      //First audit log
      Entity.Audit audit = new Entity.Audit(Entity.Audit.GenerateNameCollection());
      audit.DataType = DataTypeEnum.Audit.Name;
      audit.Code = AuditCodes.InitAuditDb;
      audit.Parameters = new Dictionary<string, string>() { { AuditCodes.InitAuditDb_year, dateTime.Year.ToString() }, { AuditCodes.InitAuditDb_month, dateTime.Month.ToString() } };
      audit.CreatedWhen = dateTime;
      audit.UserGuid = AppGlobal.UserSystem.UserGuid;
      audit.DeviceGuid = AppGlobal.Device.DeviceGuid;

      var colDbDef = new Entity.AuditDbCollection();
      var cols = new Dictionary<string, bool>();
      cols.Add(nameof(colDbDef.CollectionName), true);
      dbRepository.CreateNewCollection<Entity.AuditDbCollection>(colDbDef.GetNameCollection(), cols);

      CheckAuditCollection(audit);

      dbRepository.InsertAsync(audit, audit.GetNameCollection()).Wait();

      dbRepository.SetVersionDb(2);
    }

    #endregion Update database

    #region Private method
    /// <summary>
    /// Check audit collection exist and create new collection for audit if not exists
    /// </summary>
    /// <param name="db">Database</param>
    /// <param name="audit">Audit record</param>
    private void CheckAuditCollection(Entity.Audit audit)
    {
      if (dbRepository.IsExistCollection(audit.GetNameCollection()))
        return;
      var cols = new Dictionary<string, bool>();
      cols.Add(nameof(Entity.Audit.CreatedWhen), false);
      cols.Add(nameof(Entity.Audit.DataType), false);

      //Create new collection audit periods
      dbRepository.CreateNewCollection<Entity.Audit>(audit.GetNameCollection(), cols);

      //First audit collection
      var newAuditCol = new Entity.AuditDbCollection();
      newAuditCol.CollectionName = audit.GetNameCollection();
      newAuditCol.CreatedWhen = audit.CreatedWhen;
      dbRepository.InsertAsync(newAuditCol).Wait();


      if (!(dbRepository.CountAsync<Entity.AuditDbCollection>().Result > AppGlobal.Log.MaxAuditCollection))
        return;

      var deleteCol = dbRepository.FindFirstAsync<Entity.AuditDbCollection>().Result;

      if (deleteCol == null)
        return;

      dbRepository.DeleteCollection(deleteCol.CollectionName);
    }

    #endregion
  }
}
