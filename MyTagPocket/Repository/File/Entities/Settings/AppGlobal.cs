﻿using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Entities;

namespace MyTagPocket.Storage.Entities.Settings
{
  /// <summary>
  /// Global setting application
  /// </summary>
  public class AppGlobal : FileEntityBase<AppGlobal>
  {

    /// <summary>
    /// Constructor
    /// </summary>
    public AppGlobal() : base(CoreUtil.DataTypeEnum.Settings, SystemEntityGuidConst.AppGlobal, EncryptTypeEnum.None)
    { }

    /// <summary>
    /// Version application
    /// </summary>
    public string Version { get; set; }
  }
}
