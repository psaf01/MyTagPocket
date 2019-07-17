using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File.Interface;
using MyTagPocket.Repository.Interface;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Text;
using MyTagPocket.Repository.File;
using System.Collections.Generic;
using System.Linq;
using MyTagPocket.Repository.File.Entities;
using MyTagPocket.Repository.File.Entities.Contents;

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
         throw new Exception($"Cant load file type");
       }
     });
    }

    /// <summary>
    /// Load entity file from archive
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="fileInfo">Info about file from history</param>
    public Task<T> LoadFromArchivAsync<T>(IFileHistoryInfo fileInfo)
    {
      return Task.Run(() =>
      {
        const string methodCode = "[1002404]";
        try
        {
          if (string.IsNullOrEmpty(fileInfo.CommitId))
          {
            throw new Exception("Cant load file from archive becouse CommitId is empty");
          }

          Log.Trace(methodCode, $"Load feom archive [{fileInfo.FileType}] ID [{fileInfo.FileId}] commit [{fileInfo.CommitId}]");
          var entityType = DataTypeEnum.ValueOf(fileInfo.FileType);
          string path = _FileHelper.GetLocalFilePath(entityType, fileInfo.FileId);
          string archivePath = System.IO.Path.ChangeExtension(path, DataTypeEnum.ARCHIVE.LocalizedName);
          var archiveContent = _FileHelper.LoadContentFromFile(archivePath, fileInfo.StartPosition, fileInfo.LengthContent);

          var contentJson = Text.DecompressToString(archiveContent, Encoding.UTF8);
          IFileEntityBase<T> entity;
          switch(entityType.Value)
          {
            case DataTypeEnum.DataType.Contents:
              entity = (IFileEntityBase<T>)new Content();
              break;
            default:
              Log.Error(methodCode, $"Cant recognize type file for load from archive type [{fileInfo.FileType}] file ID [{fileInfo.FileId}]");
              throw new Exception($"Cant load file from archive");
          }
          T result = entity.DeserializeJson(contentJson);
          return result;
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, $"Cant load file from archive type [{fileInfo.FileId}] file ID [{fileInfo.FileId}]");
          throw new Exception($"Cant load file from archive");
        }
      });
    }

    /// <summary>
    /// Load history save of file entity
    /// </summary>
    /// <typeparam name="T">Type File entity</typeparam>
    /// <param name="entity">Entity object</param>
    /// <returns>List of file entity history</returns>
    public async Task<IEnumerable<IFileHistoryInfo>> LoadHistory<T>(IFileEntityBase<T> entity)
    {
      return await Task.Run(() =>
      {
        const string methodCode = "[1002405]";
        try
        {
          Log.Trace(methodCode, $"Load history file [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
          string path = _FileHelper.GetLocalFilePath(entity.TypeEntity, entity.EntityId);
          var pathHistory = System.IO.Path.ChangeExtension(path, DataTypeEnum.HISTORY.LocalizedName);
          var historyJson = _FileHelper.LoadFileLines(pathHistory);
          var result = new List<IFileHistoryInfo>();
          int startPosition = 0;
          foreach (var str in historyJson)
          {
            var info = new FileHistoryInfo();
            info = info.DeserializeJson(str);
            info.StartPosition = startPosition;
            result.Add(info);
            startPosition += info.LengthContent;
          }
          return result.AsEnumerable();
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, $"Cant Save  [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
          throw new Exception("Cant load histor filey");
        }
      });
    }

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    /// <param name="toArchive">Save entity to archive too</param>
    public async Task SaveAsync<T>(IFileEntityBase<T> entity, bool toArchive)
    {
      await Task.Run(() =>
      {
        const string methodCode = "[1002401]";
        try
        {
          Log.Trace(methodCode, $"Save file [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
          entity.UpdatedWhen = DateTime.UtcNow;
          entity.CommitId = Guid.NewGuid().ToString("N");
          string jsonString = entity.SerializeJson();
          string path = _FileHelper.GetLocalFilePath(entity.TypeEntity, entity.EntityId);
          _FileHelper.SaveFile(path, jsonString);
          if (!toArchive)
            return;

          var compress = Text.Compress(jsonString, Encoding.UTF8);
          var infoSave = new FileHistoryInfo();
          infoSave.FileId = entity.EntityId;
          infoSave.CommitId = entity.CommitId;
          infoSave.CreateDate = entity.UpdatedWhen.ConvertToText();
          infoSave.CreatedWho = entity.UpdatedWho;
          infoSave.LengthContent = compress.Length;
          infoSave.FileType = entity.TypeEntity.Name;
          string jsonHistory = Newtonsoft.Json.JsonConvert.SerializeObject(infoSave);
          var historyFile = System.IO.Path.ChangeExtension(path, DataTypeEnum.HISTORY.LocalizedName);
          var archiveFile = System.IO.Path.ChangeExtension(path, DataTypeEnum.ARCHIVE.LocalizedName);
          //TODO: Refactoring - transaction
          if (_FileHelper.FileExists(historyFile))
            jsonHistory = string.Concat("\n", jsonHistory);

          _FileHelper.SaveAppendToFile(historyFile, jsonHistory);
          _FileHelper.SaveAppendToFile(archiveFile, compress);
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, $"Cant Save  [{entity.TypeEntity.Name}] ID [{entity.EntityId}]");
          throw ex;
        }
      });
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
          //Delete the archive
          switch (entity.TypeEntity.Value)
          {
            case DataTypeEnum.DataType.Contents:
            case DataTypeEnum.DataType.Tag:
              var pathArchive = System.IO.Path.ChangeExtension(path, DataTypeEnum.ARCHIVE.LocalizedName);
              _FileHelper.DeleteFile(pathArchive);
              var pathHistory = System.IO.Path.ChangeExtension(path, DataTypeEnum.HISTORY.LocalizedName);
              _FileHelper.DeleteFile(pathHistory);
              break;
            default:
              break;
          }
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
