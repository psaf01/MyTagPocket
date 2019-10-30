namespace MyTagPocket.Repository
{
  using LiteDB;
  using MyTagPocket.CoreUtil.Exceptions;
  using MyTagPocket.Repository.Interface;
  using MyTagPocket.Resources;
  using System.IO;

  /// <summary>
  /// Database repository
  /// </summary>
  public class DalRepository : IDalRepository
  {
    /// <summary>
    /// LiteDb
    /// </summary>
    private LiteDatabase Db;

    public DalRepository(string pathDb)
    {
      Db = new LiteDatabase(pathDb);
    }

    public DalRepository(MemoryStream db)
    {
      Db = new LiteDatabase(db);
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

      Db.FileStorage.Upload(idFile, fileName, stream);
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    public void SaveFile(string idFile, string filePath)
    {
      var file = Db.FileStorage.Upload(idFile, filePath);
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
  }
}
