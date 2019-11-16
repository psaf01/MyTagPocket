namespace MyTagPocket.Repository
{
  using LiteDB;
  using MyTagPocket.CoreUtil.Exceptions;
  using MyTagPocket.Repository.Dal.Entities.Devices;
  using MyTagPocket.Repository.Dal.Entities.Settings;
  using MyTagPocket.Repository.Dal.Entities.Users;
  using MyTagPocket.Repository.Dal.Interface;
  using MyTagPocket.Repository.Interfaces;
  using MyTagPocket.Resources;
  using System;
  using System.IO;
  using System.Threading.Tasks;

  /// <summary>
  /// Database repository
  /// </summary>
  public class DalRepository : IDalRepository
  {

    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10024";

    /// <summary>
    /// LiteDb
    /// </summary>
    private LiteDatabase liteDb;

    public DalRepository(string pathDb)
    {
      liteDb = new LiteDatabase(pathDb);
    }

    public DalRepository(MemoryStream db)
    {
      liteDb = new LiteDatabase(db);
    }

    /// <summary>
    /// Instance LiteDb
    /// </summary>
    public LiteDatabase Db
    {
      get
      {
        return liteDb;
      }
    }

    /// <summary>
    /// Initialize database
    /// </summary>
    public async Task InitilizeDbAsync()
    {
      await Task.Run(() =>
      {
        InitializeMainDb();
      });
    }

    /// <summary>
    /// Initialize MyTagPocket database
    /// </summary>
    private void InitializeMainDb()
    {
      var engine = liteDb.Engine;

      // database initialize
      if (engine.UserVersion == 0)
      {
        Setting setting = new Setting();
        engine.EnsureIndex(setting.GetNameCollection, nameof(setting.Name), true);
        Device device = new Device();
        engine.EnsureIndex(device.GetNameCollection, nameof(device.DeviceId), true);
        //User user
      }
    }
   
    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="fileName">File name</param>
    /// <param name="stream">IO stream file content</param>
    public void SaveFile(string idFile, string fileName, Stream stream)
    {
      if (string.IsNullOrEmpty(idFile))
        throw new ErrorException(ResourceApp.ExceptionDalRepositorySaveFileIdFileEmpty);

      if (string.IsNullOrEmpty(fileName))
        throw new ErrorException(ResourceApp.ExceptionDalRepositorySaveFileName);

      liteDb.FileStorage.Upload(idFile, fileName, stream);
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    public void SaveFile(string idFile, string filePath)
    {
      var file = liteDb.FileStorage.Upload(idFile, filePath);
    }

    public void GetFile(string idFile, string filePath, Stream stream)
    {
      /*
      var file = Db.FileStorage.Download(idFile, stream);
      {
        if (string.IsNullOrEmpty(idFile))
          throw new ArgumentNullException("id");
        if (stream == null) throw new ArgumentNullException("stream");

        using (var s = this.OpenRead(id))
        {
          if (s == null) throw new LiteException("File not found");

          s.CopyTo(stream);
        }
      }
      */
    }

    public void Save(IDalBase entity)
    {
      throw new NotImplementedException();
    }

    public IDalBase Load(string entityId)
    {
      throw new NotImplementedException();
    }
  }
}
