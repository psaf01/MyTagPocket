using LiteDB;
using MyTagPocket.CoreUtil.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyTagPocket.Repository.Dal
{
  /// <summary>
  ///  Helper for database system on device
  /// </summary>
  public class DalHelper : IDalHelper
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
