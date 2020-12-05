using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Exceptions;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Files.Interfaces;
using MyTagPocket.Repository.Interfaces;
using MyTagPocket.Resources;
using System;
using System.IO.Abstractions;
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

    /// <summary>
    /// Root path for application file data
    /// </summary>
    private string applicationDataPath;

    /// <summary>
    /// File storage
    /// </summary>
    private FileStorage.FileSystem fs;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="storage">Path to folder for data</param>
    public FileRepository(ILogManager logManager, string dataPath)
    {
      Log = logManager.GetLog(classCode);
      applicationDataPath = dataPath;

      fs = new FileStorage.FileSystem(new FileSystem());
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fileSystem">File system</param>
    /// <param name="dataPath">Path to folder for data</param>
    public FileRepository(ILogManager logManager, IFileSystem fileSystem, string dataPath)
    {
      Log = logManager.GetLog(classCode);
      applicationDataPath = dataPath;
      fs = new FileStorage.FileSystem(fileSystem);
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
         string path = GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);

         string jsonString = fs.File.ReadFile(path);
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
    /*
        /// <summary>
        /// Load entity file from archive
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="fileInfo">Fistory file to restore</param>
        /// <param name="fileHistory">File with full history</param>
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
              string path = GetLocalFilePath(entityType, fileInfo.FolderId, fileInfo.FileId);
              string archivePath = System.IO.Path.ChangeExtension(path, DataTypeEnum.Archive.LocalizedName);
              string historyPath = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
              var archives = LoadHistoryFile(historyPath);
              var dmp = new diff_match_patch();
              bool readPatch = false;
              List<string> patches = new List<string>();
              long startPosition = 0;
              using (BinaryReader b = new BinaryReader(storage.File.Open(archivePath, FileMode.Open)))
              {
                foreach (var archiv in archives)
                {
                  //var  = dmp.patch_fromText(patch);
                  if (archiv.CommitId == fileInfo.CommitId)
                    readPatch = true;
                  if (!readPatch)
                  {
                    startPosition += archiv.LengthContent;
                    continue;
                  }
                  // Seek to our required position.
                  b.BaseStream.Seek(startPosition, SeekOrigin.Begin);
                  byte[] contentBytes = b.ReadBytes(archiv.LengthContent);
                  startPosition += archiv.LengthContent;
                  var patch = Text.DecompressToString(contentBytes, Encoding.UTF8);
                  patches.Add(patch);
                }
              }
              string restore = storage.File.ReadAllText(path);
              //restore old file
              string restoreContent = (string)restore.Clone();
              for (int i = patches.Count - 1; i >= 0; i--)
              {
                var restorePatch = dmp.patch_fromText(patches[i]);
                restoreContent = dmp.patch_apply(restorePatch, restoreContent)[0].ToString();
              }

              IFileEntityBase<T> entity;
              switch (entityType.Value)
              {
                case DataTypeEnum.DataType.Package:
                  entity = (IFileEntityBase<T>)new Package();
                  break;
                case DataTypeEnum.DataType.Device:
                  entity = (IFileEntityBase<T>)new Files.Entities.Devices.Device();
                  break;
                default:
                  Log.Error(methodCode, "Cant recognize type file for load from archive type={@FileType} file ID={@FileId}", fileInfo.FileType, fileInfo.FileId);
                  throw new ErrorException(ResourceApp.ExceptionCantLoadFileFromArchive);
              }
              T result = entity.DeserializeJson(restoreContent);//contentJson);
              return result;
            }
            catch (Exception ex)
            {
              Log.Error(ex, methodCode, "Cant load file from archive type={@FileType} file ID {@FileId}", fileInfo.FileType, fileInfo.FileId);
              throw new Exception(ResourceApp.ExceptionCantLoadFileFromArchive);
            }
          });
        }
    */

    /*    
        /// <summary>
        /// Load history save of file entity
        /// </summary>
        /// <typeparam name="T">Type File entity</typeparam>
        /// <param name="entity">Entity object</param>
        /// <returns>List of file entity history</returns>
        public async Task<IEnumerable<IFileHistoryInfo>> LoadHistoryAsync<T>(IFileEntityBase<T> entity)
        {
          return await Task.Run(() =>
          {
            const string methodCode = "M05";
            try
            {
              Log.Trace(methodCode, "Load history Entity={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
              string path = GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);
              var pathHistory = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
              return LoadHistoryFile(pathHistory).AsEnumerable();
            }
            catch (Exception ex)
            {
              Log.Error(ex, methodCode, "Cant load type={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
              throw new ErrorException(ResourceApp.ExceptionCantLoadFileHistory);
            }
          });
        }
    */
    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    /// <param name="toArchive">Save entity to archive too</param>
    public async Task SaveAsync<T>(IFileEntityBase<T> entityNew)
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
          string path = GetLocalFilePath(entityNew.TypeEntity, entityNew.FolderId, entityNew.EntityId);
          fs.File.SaveFile(path, jsonStringNew);
          entityNew.FullPathFile = path;
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, "Cant Save Entity={@TypeEntity} ID={@EntityId}", entityNew.TypeEntity.Name, entityNew.EntityId);
          throw ex;
        }
      });
    }
    /*
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
              string path = GetLocalFilePath(entityNew.TypeEntity, entityNew.FolderId, entityNew.EntityId);
              fs.File.SaveFile(path, jsonStringNew);
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
              infoSave.CreatedWhoFullname = entityNew.UpdatedWho?.FullName;
              infoSave.CreatedWhoEmail = entityNew.UpdatedWho?.Email;
              infoSave.CreatedWhoId = entityNew.UpdatedWho?.EntityId;
              infoSave.CreatedOnDeviceName = entityNew.UpdatedDevice?.Name;
              infoSave.CreatedOnDeviceId = entityNew.UpdatedDevice?.EntityId;
              infoSave.LengthContent = compress.Length;
              infoSave.FileType = entityNew.TypeEntity.Name;
              string jsonHistory = infoSave.SerializeJson();
              int h = jsonHistory.Length;
              var historyFile = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
              var archiveFile = System.IO.Path.ChangeExtension(path, DataTypeEnum.Archive.LocalizedName);
              //TODO: Refactoring - transaction
              fs.File.SaveAppendToFile(historyFile, jsonHistory);
              fileHelper.SaveAppendToFile(historyFile, Environment.NewLine);
              fileHelper.SaveAppendToFile(archiveFile, compress);
            }
            catch (Exception ex)
            {
              Log.Error(ex, methodCode, "Cant Save Entity={@TypeEntity} ID={@EntityId}", entityNew.TypeEntity.Name, entityNew.EntityId);
              throw ex;
            }
          });
        }
    */

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
          string path = GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);
          fs.File.Delete(path);
        }
        catch (Exception ex)
        {
          Log.Error(ex, methodCode, "Cant Delete={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
          throw new ErrorException(ResourceApp.ExceptionCantDeleteFile);
        }
      });
    }

    /// <summary>
    /// Delete entity 
    /// </summary>
    /// <param name="entity">Entity</param>
    /*public async Task DeleteAsync<T>(IFileEntityBase<T> entity)
    {
      await Task.Run(() =>
      {
        const string methodCode = "M03";
        try
        {
          Log.Trace(methodCode, "Delete Entity={@TypeEntity} ID={@EntityId}", entity.TypeEntity.Name, entity.EntityId);
          string path = GetLocalFilePath(entity.TypeEntity, entity.FolderId, entity.EntityId);
          fs.File.Delete(path);
          //Delete the archive
          switch (entity.TypeEntity.Value)
          {
            case DataTypeEnum.DataType.Package:
            case DataTypeEnum.DataType.Tag:
              var pathArchive = System.IO.Path.ChangeExtension(path, DataTypeEnum.Archive.LocalizedName);
              fs.File.Delete(pathArchive);
              var pathHistory = System.IO.Path.ChangeExtension(path, DataTypeEnum.History.LocalizedName);
              fs.File.Delete(pathHistory);
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
*/
    /// <summary>
    /// Load entity from archive
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<IFileEntityBase<T>> LoadArchiveAsync<T>(IFileEntityBase<T> entity)
    {
      throw new NotImplementedException();
    }
    /*
        /// <summary>
        /// Load history file
        /// </summary>
        /// <param name="path">Full path to history</param>
        /// <returns>List history</returns>
        private List<IFileHistoryInfo> LoadHistoryFile(string path)
        {
          var historyJson = fs.LoadFileLines(path);

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
          return result;
        }
    */
    #region Basic file/directory operation
    /// <summary>
    /// Get path for file 
    /// </summary>
    /// <param name="typeEntity"></param>
    /// <param name="folderId"></param>
    /// <param name="entityId"></param>
    /// <returns></returns>
    public string GetLocalFilePath(DataTypeEnum typeEntity, string folderId, string entityId)
    {
      //AppGlobal.Folders.
      throw new NotImplementedException();
    }


    /*
    /// <summary>
    /// Add binary data to file 
    /// </summary>
    /// <param name="path">Full path to file</param>
    /// <param name="content">Content</param>
    public void SaveAppendToFile(string path, byte[] content)
    {
      using (var FS = fileSystemStorage.FileStream.Create(path, fileSystemStorage.File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write))
      {
        FS.Write(content, 0, content.Length);
        FS.Close();
      }
    }
    */

    /*
        /// <summary>
        /// Load contet from file
        /// </summary>
        /// <param name="path">Full path to file</param>
        /// <param name="startPosition">Position from where to start reading</param>
        /// <param name="lengthContent">Length of content to be read</param>
        /// <returns></returns>
        public byte[] LoadContentFromFile(string path, int startPosition, int lengthContent)
        {
          byte[] result;
          using (BinaryReader b = new BinaryReader(fileSystemStorage.File.Open(path, FileMode.Open)))
          {
            // Seek to our required position.
            b.BaseStream.Seek(startPosition, SeekOrigin.Begin);
            result = b.ReadBytes(lengthContent);
          }

          return result;
        }
    */
    #endregion Basic file/directory operation
  }
}
