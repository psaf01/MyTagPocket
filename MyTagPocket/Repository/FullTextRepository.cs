using LiteDB;
using MyTagPocket.CoreUtil.Exceptions;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.FullText.Entities;
using MyTagPocket.Repository.FullText.Interface;
using MyTagPocket.Repository.Interfaces;
using MyTagPocket.Resources;
using NeoSmart.AsyncLock;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// FullText repository
  /// </summary>
  public class FullTextRepository : IFullTextRepository
  {
    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10036";

    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// FullText helper instance
    /// </summary>
    public static IFullTextHelper FullTextHelper { get; set; }

    /// <summary>
    /// Lock object for async prosess
    /// </summary>
    AsyncLock lockObject = new AsyncLock();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fullTextHelper">FullText helper</param>
    public FullTextRepository(ILogManager logManager, IFullTextHelper fullTextHelper)
    {
      Log = logManager.GetLog(classCode);
      FullTextHelper = fullTextHelper;
    }

    /// <summary>
    /// Initialize fullText
    /// </summary>
    public async Task InitilizeFullTextAsync()
    {
      await Task.Run(() =>
      {
        using (lockObject.Lock())
        {
          using (var db = FullTextHelper.OpenDB())
          {
            //if (db.Engine.UserVersion == 0)
            //  InitializeMainDbVer1(db);
          }
        }
      });
    }

    #region Update fullText
    /// <summary>
    /// Initialize FullTet database
    /// </summary>
    private void InitializeMainDbVer1(LiteDatabase db)
    {
      const string methodCode = "M01";
      Log.Trace(methodCode, "Initialize fullText");
      /*
      var dbColl = db.Engine.GetCollectionNames();
      int dbCollCount = 0;
      var findWordIndexColl = false;
      var catalogIndexColl = false;
      var dateTime = DateTimeOffset.Now;
      var wordIndex = new WordIndex();
      var catalogIndex = new CatalogIndex();
      foreach (var collName in dbColl)
      {
        if (collName == wordIndex.GetNameCollection)
          findWordIndexColl = true;

        if (collName == catalogIndex.GetNameCollection)
          catalogIndexColl = true;
        dbCollCount++;
      }

      if (!findWordIndexColl)
      {
        db.Engine.EnsureIndex(wordIndex.GetNameCollection, nameof(wordIndex.LangId), true);
        db.Engine.EnsureIndex(wordIndex.GetNameCollection, nameof(wordIndex.Name), true);
      }

      if(!catalogIndexColl)
      {
        db.Engine.EnsureIndex(catalogIndex.GetNameCollection, nameof(catalogIndex.LangId), true);
        db.Engine.EnsureIndex(catalogIndex.GetNameCollection, nameof(catalogIndex.WordId), true);
      }
      db.Engine.UserVersion = 1;
      */
    }
    #endregion Update fullText
  }
}
