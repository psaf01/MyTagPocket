﻿using MyTagPocket.CoreUtil;

namespace MyTagPocket.Repository.File.Entities.Contents
{
  /// <summary>
  /// Version application
  /// </summary>
  [FileVersion(1)]
  public class Version : VersionBase<Version>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Version() : base(DataTypeEnum.CONTENTS, SystemEntityGuidConst.ContentsVersion)
    { }

    #region Public attributest
    #endregion Public atributes

    #region Public method
    #endregion Public method
  }
}
