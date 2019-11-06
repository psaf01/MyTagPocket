using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Exceptions;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File;
using MyTagPocket.Repository.File.DiffMatchPatch;
using MyTagPocket.Repository.File.Entities;
using MyTagPocket.Repository.File.Entities.Packages;
using MyTagPocket.Repository.File.Interface;
using MyTagPocket.Repository.Interface;
using MyTagPocket.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// File system repository
  /// </summary>
  public class FileRepository : IFileRepository
  {
    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10024";

    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    private IFileHelper fileHelper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fileHelper">File helper</param>
    public FileRepository(ILogManager logManager, IFileHelper fileHelper)
    {
      Log = logManager.GetLog(classCode);
      this.fileHelper = fileHelper;
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
       const string methodCode = "M02";
       try
       {
         Log.Trace(methodCode, "Load Entity={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
         string path = fileHelper.GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);

         string jsonString = fileHelper.LoadFile(path);
         int versionExpect = entity.Version;
         T result = entity.DeserializeJson(jsonString);

         if (result is IFileEntityBase<T>)
           return result;

         Log.Error(methodCode, "File is not compatible in format MyTagPocket. TypeEntity={@entity.TypeEntity.Name}] EntityId={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
         throw new ErrorException(ResourceApp.ExceptionCantLoadFile);
       }
       catch (Exception ex)
       {
         Log.Error(ex, methodCode, "Cant load file TypeEntity={@entity.TypeEntity.Name}] EntityId={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
         throw new ErrorException(ResourceApp.ExceptionCantLoadFile);
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
        const string methodCode = "M04";
        try
        {
          if (string.IsNullOrEmpty(fileInfo.CommitId))
          {
            throw new ErrorException(ResourceApp.ExceptionCantLoadFileFromArchive);
          }

          Log.Trace(methodCode, "Load from archive {@FileType} ID={@FileId} commit={@CommitId}", fileInfo.FileType, fileInfo.FileId, fileInfo.CommitId);
          var entityType = DataTypeEnum.ValueOf(fileInfo.FileType);
          string path = fileHelper.GetLocalFilePath(entityType, fileInfo.FolderId, fileInfo.FileId);
          string archivePath = System.IO.Path.ChangeExtension(path, DataTypeEnum.Archive.LocalizedName);
          var archiveContent = fileHelper.LoadContentFromFile(archivePath, fileInfo.StartPosition, fileInfo.LengthContent);

          var contentJson = Text.DecompressToString(archiveContent, Encoding.UTF8);
          IFileEntityBase<T> entity;
          switch (entityType.Value)
          {
            case DataTypeEnum.DataType.Package:
              entity = (IFileEntityBase<T>)new Package();
              break;
            default:
              Log.Error(methodCode, "Cant recognize type file for load from archive type={@FileType} file ID={@FileId}", fileInfo.FileType, fileInfo.FileId);
              throw new ErrorException(ResourceApp.ExceptionCantLoadFileFromArchive);
          }
          T result = entity.DeserializeJson(contentJson);
          return result;
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, "Cant load file from archive type={@FileType} file ID {@FileId}", fileInfo.FileType, fileInfo.FileId);
          throw new Exception(ResourceApp.ExceptionCantLoadFileFromArchive);
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
        const string methodCode = "M05";
        try
        {
          Log.Trace(methodCode, "Load history Entity={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
          string path = fileHelper.GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);
          var pathHistory = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
          var historyJson = fileHelper.LoadFileLines(pathHistory);
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
          Log.Error(ex, methodCode, "Cant Save={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
          throw new ErrorException(ResourceApp.ExceptionCantSaveFileToArchive);
        }
      });
    }

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    /// <param name="toArchive">Save entity to archive too</param>
    public async Task SaveAsync<T>(IFileEntityBase<T> entityNew, IFileEntityBase<T> entityOld)
    {
      await Task.Run(() =>
      {
        const string methodCode = "M01";
        try
        {
          Log.Trace(methodCode, "Save Entity={@TypeEntity} ID={@EntityId}", entityNew.TypeEntity.Name, entityNew.EntityId);
          entityNew.UpdatedWhen = DateTimeOffset.Now;
          entityNew.CommitId = Guid.NewGuid().ToString("N");
          entityNew.Hash = entityNew.GetHashCode().ToString();
          string jsonStringNew = entityNew.SerializeJson();
          string path = fileHelper.GetLocalFilePath(entityNew.TypeEntity, entityNew.FolderId, entityNew.EntityId);
          fileHelper.SaveFile(path, jsonStringNew);
          entityNew.FullPathFile = path;
          if (entityOld == null)
            return;

          var dmp = new diff_match_patch();
          string jsonStringOld = entityOld.SerializeJson();
          var newToOld = dmp.patch_make(jsonStringNew, jsonStringOld);
          var patch = dmp.patch_toText(newToOld);
          var compress = Text.Compress(patch, Encoding.UTF8);
          var infoSave = new FileHistoryInfo();
          infoSave.FileId = entityNew.EntityId;
          infoSave.FolderId = entityNew.FolderId;
          infoSave.CommitId = entityNew.CommitId;
          infoSave.CreatedDate = entityNew.UpdatedWhen.ConvertToText();
          infoSave.CreatedWhoFullname = entityNew.UpdatedWho.FullName;
          infoSave.CreatedWhoEmail = entityNew.UpdatedWho.Email;
          infoSave.CreatedWhoId = entityNew.UpdatedWho.EntityId;
          infoSave.CreatedOnDeviceName = entityNew.UpdatedDevice.Name;
          infoSave.CreatedOnDeviceId = entityNew.UpdatedDevice.EntityId;
          infoSave.LengthContent = compress.Length;
          infoSave.FileType = entityNew.TypeEntity.Name;
          string jsonHistory = Newtonsoft.Json.JsonConvert.SerializeObject(infoSave);
          var historyFile = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
          var archiveFile = System.IO.Path.ChangeExtension(path, DataTypeEnum.Archive.LocalizedName);
          //TODO: Refactoring - transaction
          if (fileHelper.FileExists(historyFile))
            jsonHistory = string.Concat("\n", jsonHistory);

          fileHelper.SaveAppendToFile(historyFile, jsonHistory);
          fileHelper.SaveAppendToFile(archiveFile, compress);
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, "Cant Save Entity={@TypeEntity} ID={@EntityId}", entityNew.TypeEntity.Name, entityNew.EntityId);
          throw ex;
        }
      });
    }

    /// <summary>
    /// Delete entity 
    /// </summary>
    /// <param name="entity">Entity</param>
    public async Task DeleteAsync<T>(IFileEntityBase<T> entity)
    {
      await Task.Run(() =>
      {
        const string methodCode = "M03";
        try
        {
          Log.Trace(methodCode, "Delete Entity={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
          string path = fileHelper.GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);
          fileHelper.DeleteFile(path);
          //Delete the archive
          switch (entity.TypeEntity.Value)
          {
            case DataTypeEnum.DataType.Package:
            case DataTypeEnum.DataType.Tag:
              var pathArchive = System.IO.Path.ChangeExtension(path, DataTypeEnum.Archive.LocalizedName);
              fileHelper.DeleteFile(pathArchive);
              var pathHistory = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
              fileHelper.DeleteFile(pathHistory);
              break;
            default:
              break;
          }
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, "Cant Delete={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
          throw new ErrorException(ResourceApp.ExceptionCantDeleteFile);
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
