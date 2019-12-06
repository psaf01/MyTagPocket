using LiteDB;
using MyTagPocket.CoreUtil.Interfaces;
using System;

namespace MyTagPocket.UWP.Library.CoreUtil
{
  /// <summary>
  /// Helper for audit database system in file on device UWP 
  /// </summary>
  public class DalAuditHelper_UWP_file : IDalHelper
  {
    private string pathDb;
    /// <summary>
    /// Memory database
    /// </summary>
    /// <returns></returns>
    public LiteDatabase OpenDB()
    {
      if (string.IsNullOrEmpty(pathDb))
        pathDb = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\db\audit.db";
      return new LiteDatabase(pathDb);
    }
  }
}
