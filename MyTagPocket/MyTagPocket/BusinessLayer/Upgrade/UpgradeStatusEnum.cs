using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.BusinessLayer.Upgrade
{
  /// <summary>
  /// Update progress enumerator
  /// /// </summary>
  public enum UpgradeStatusEnum
  {
    NotStart,
    Stop,
    Progress,
    EndSucces,
    EndError
  }
}
