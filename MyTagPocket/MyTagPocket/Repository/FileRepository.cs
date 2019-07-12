using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File.Interface;
using MyTagPocket.Repository.Interface;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// File system repository
  /// </summary>
  public class FileRepository : IFileRepository
  {
    const string classCode = "[1002400]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);
    private IFileHelper _FileHelper;

    /// <summary>
    /// Constructor
    /// </summary>
    public FileRepository()
    {
      _FileHelper = DependencyService.Get<IFileHelper>();
    }

    /// <summary>
    /// Save entity to file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    public Task<T> LoadAsync<T>(IFileEntityBase<T> entity)
    {
      return Task.Run(() =>
     {

       const string methodCode = "[1002402]";
       try
       {
         Log.Trace(methodCode, $"Load [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
         string path = _FileHelper.GetLocalFilePath(entity.TypeEntity, entity.EntityId);
         string jsonString = _FileHelper.LoadFile(path);
         T result = entity.DeserializeJson(jsonString);
         return result;
       }
       catch (Exception ex)
       {
         Log.Error(ex, methodCode, $"Cant load file type [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
        throw new Exception("Cant load file");
       }
     });
    }

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    public async Task SaveAsync<T>(IFileEntityBase<T> entity)
    {
      await Task.Run(() =>
      {
        const string methodCode = "[1002401]";
        try
        {
          Log.Trace(methodCode, $"Save file [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
          string jsonString = entity.SerializeJson();
          string path = _FileHelper.GetLocalFilePath(entity.TypeEntity, entity.EntityId);
          _FileHelper.SaveFile(path, jsonString);
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, $"Cant Save  [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
        }
      });
    }

    /// <summary>
    /// Not implement
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Save to archive</returns>
    public Task SaveToArchiveAsync<T>(IFileEntityBase<T> entity)
    {
      //System.IO.Compression.ZipArchive()
      throw new NotImplementedException();
    }

    /// <summary>
    /// Not implement
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Delete entity</returns>
    public async Task DeleteAsync<T>(IFileEntityBase<T> entity)
    {
      await Task.Run(() =>
      {
        const string methodCode = "[1002403]";
        try
        {
          Log.Trace(methodCode, $"Delete file [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
          string path = _FileHelper.GetLocalFilePath(entity.TypeEntity, entity.EntityId);
          _FileHelper.DeleteFile(path);
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, $"Cant Delete  [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
        }
      });
    }

    /// <summary>
    /// Load entity from archive
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<IFileEntityBase<T>> LoadArchiveAsync<T>(IFileEntityBase<T> entity)
    {
      throw new NotImplementedException();
    }
  }
}
