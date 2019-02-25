using MyTagPocket.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Dal.Upgrade.Interface
{
  /// <summary>
  /// Interface Check a upgrade database storage
  /// </summary>
  public interface IUpgradeDb
  {
    /// <summary>
    /// Check and upgrade TableVersion
    /// </summary>
    void CheckAndUpgradeTableVersion();
  }
}
