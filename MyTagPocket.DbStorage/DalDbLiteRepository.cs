using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyTagPocket.DbStorage
{
  /// <summary>
  /// DbLite repository for basic operation
  /// </summary>
  public class DalDbLiteRepository : IDalDbLiteRepository
  {
    public static AsyncLock lockObject = new AsyncLock();
    /// <summary>
    /// Database helper instance
    /// </summary>
    public static IDbLiteHelper DalHelper { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dalHelper">Database layer helper</param>
    public DalDbLiteRepository(IDbLiteHelper dalHelper)
    {
      DalHelper = dalHelper;
    }

    #region Basic operation database
    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="fileName">File name</param>
    /// <param name="stream">IO stream file content</param>
    public async Task SaveFileAsync(string idFile, string fileName, Stream stream)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            if (string.IsNullOrEmpty(idFile))
              throw new Exception("idFile is null or empty");

            if (string.IsNullOrEmpty(fileName))
              throw new Exception("fileName is null or empty");

            db.FileStorage.Upload(idFile, fileName, stream);
          }
        }
      });
    }

    /// <summary>
    /// Save file to repository
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    public async Task SaveFileAsync(string idFile, string filePath)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            db.FileStorage.Upload(idFile, filePath);
          }
        }
      });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idFile">Identification file</param>
    /// <param name="filePath">Full path to file on system</param>
    /// <param name="stream">IO stream file content</param>

    public void GetFile(string idFile, string filePath, Stream stream)
    {
      throw new NotImplementedException();
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

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    public async Task SaveAsync<T>(T entity)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            dbCol.Upsert((T)entity);
          }
        }
      });
    }

    /// <summary>
    /// Save entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <param name="collectionName">Specific collection name</param>
    /// <returns>Task</returns>
    public async Task SaveAsync<T>(T entity, string collectionName)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>(collectionName);
            dbCol.Upsert((T)entity);
          }
        }
      });
    }

    /// <summary>
    /// Insert new entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <returns>Task</returns>
    public async Task InsertAsync<T>(T entity)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            dbCol.Insert((T)entity);
          }
        }
      });
    }

    /// <summary>
    /// Insert new entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="entity">Entity</param>
    /// <param name="collectionName">Specific collection name</param>
    /// <returns>Task</returns>
    public async Task InsertAsync<T>(T entity, string collectionName)
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>(collectionName);
            dbCol.Insert((T)entity);
          }
        }
      });
    }

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="id">ID entity</param>
    /// <returns>Entity</returns>
    public async Task<T> FindById<T>(int id)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            return dbCol.FindById(id);
          }
        }
      });
    }

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <param name="nameCollection">Name collection</param>
    /// <param name="skip">Skip records</param>
    /// <param name="limit">Return max records</param>
    /// <returns>List Entities</returns>
    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, string nameCollection, int skip = 0, int limit = int.MaxValue)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>(nameCollection);
            return dbCol.Find(predicate, skip, limit).ToList();
          }
        }
      });
    }

    /// <summary>
    /// Find entity
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <param name="skip">Skip records</param>
    /// <param name="limit">Return max records</param>
    /// <returns>List Entities</returns>
    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            return dbCol.Find(predicate, skip, limit).ToList();
          }
        }
      });
    }

    /// <summary>
    /// Find one object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="predicate">Predicate for search entity</param>
    /// <returns>Object</returns>
    public async Task<T> FindOneAsync<T>(Expression<Func<T, bool>> predicate)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            T result = dbCol.FindOne(predicate);
            return result;
          }
        }
      });
    }

    /// <summary>
    /// Find first object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <returns>Object</returns>
    public async Task<T> FindFirstAsync<T>()
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            T result = dbCol.FindOne(Query.All(-1));
            return result;
          }
        }
      });
    }

    /// <summary>
    /// Find last object in database
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <returns>Object</returns>
    public async Task<T> FindLastAsync<T>()
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            T result = dbCol.FindOne(Query.All(1));
            return result;
          }
        }
      });
    }


    /// <summary>
    /// Count entities
    /// </summary>
    /// <param name="collectionName">Collection name</param>
    /// <returns>Count</returns>
    public async Task<int> CountAsync(string collectionName)
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection(collectionName);
            return dbCol.Count();
          }
        }
      });
    }

    /// <summary>
    /// Count entities
    /// </summary>
    /// <typeparam name="T">Type entity</typeparam>
    /// <returns>Count</returns>
    public async Task<int> CountAsync<T>()
    {
      return await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = DalHelper.OpenDB())
          {
            var dbCol = db.GetCollection<T>();
            return dbCol.Count();
          }
        }
      });
    }

    #endregion Basic operation database

    #region specific function
    /// <summary>
    /// Actual version Audit database
    /// </summary>
    /// <returns>Version</returns>
    public int GetVersionDb()
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          var dbVersion = db.Pragma("USER_VERSION");
          if (dbVersion == null)
            return 0;
          else
            return dbVersion.AsInt32;
        }
      }
    }

    /// <summary>
    /// Set new user version LiteDb
    /// </summary>
    /// <param name="newVersion">Number new version</param>
    public void SetVersionDb(int newVersion)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          db.Pragma("USER_VERSION", newVersion);
        }
      }
    }

    /// <summary>
    /// Create new collection in LiteDb
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="name">Name collection</param>
    /// <param name="indexColumns">Column [name, is unique]</param>
    public void CreateNewCollection<T>(string name, IDictionary<string, bool> indexColumns)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          var col = db.GetCollection<T>(name);

          foreach (var colItem in indexColumns)
          {
            col.EnsureIndex(colItem.Key, colItem.Value);
          }
        }
      }
    }

    /// <summary>
    /// Delete collection
    /// </summary>
    /// <typeparam name="T">Type object</typeparam>
    /// <param name="name">Name collection</param>
    public void DeleteCollection(string name)
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          var col = db.DropCollection(name);
        }
      }
    }

    /// <summary>
    /// Check exist collection
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool IsExistCollection(string name)
    {
      if (string.IsNullOrWhiteSpace(name))
        return false;

      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          return db.CollectionExists(name);
        }
      }
    }

    /// <summary>
    /// First time initialize database
    /// </summary>
    public void InitDatabase()
    {
      using (lockObject.Lock())
      {
        using (var db = DalHelper.OpenDB())
        {
          db.Pragma("UTC_DATE", true);
        }
      }
    }
    #endregion specific function
  }
}
