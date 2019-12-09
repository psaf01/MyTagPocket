using LiteDB;
using MyTagPocket.CoreUtil.Interfaces;
using System;

namespace MyTagPocket.UWP.Library.CoreUtil
{
  /// <summary>
  /// Helper for database system in file on device UWP 
  /// </summary>
  public class DalHelper_UWP_file : IDalHelper
  {
    private string pathDb;
    /// <summary>
    /// Memory database
    /// </summary>
    /// <returns></returns>
    public LiteDatabase OpenDB()
    {
      if (string.IsNullOrEmpty(pathDb))
        pathDb = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\db\mytagpocket.db";
      return new LiteDatabase(pathDb);
    }
  }
}
