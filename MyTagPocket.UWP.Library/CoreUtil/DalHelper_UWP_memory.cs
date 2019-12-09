﻿using LiteDB;
using MyTagPocket.CoreUtil.Interfaces;
using System.IO;

namespace MyTagPocket.UWP.Library.CoreUtil
{
  /// <summary>
  ///  Helper for database system in memory on device UWP
  /// </summary>
  public class DalHelper_UWP_memory : IDalHelper
  {
    private static MemoryStream memoryDb;
    /// <summary>
    /// Memory database
    /// </summary>
    /// <returns></returns>
    public LiteDatabase OpenDB()
    {
      if (memoryDb == null)
        memoryDb = new MemoryStream();

      return new LiteDatabase(memoryDb);
    }
  }
}
