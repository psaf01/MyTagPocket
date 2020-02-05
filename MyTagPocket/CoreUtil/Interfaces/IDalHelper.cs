﻿using LiteDB;

namespace MyTagPocket.CoreUtil.Interfaces
{
  /// <summary>
  ///  Interface helper for database system on device
  /// </summary>
  public interface IDalHelper
  {
    LiteDatabase OpenDB();
  }
}
