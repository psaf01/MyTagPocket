using MyTagPocket.Storage.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Storage.Repository.Interface
{
  /// <summary>
  /// Interface settings repository
  /// </summary>
  public interface ISettingsRespository
  {
    /// <summary>
    /// Save application global settings
    /// </summary>
    /// <param name="appGlobal">Application global settings</param>
    void AppGlobalSave(AppGlobal appGlobal);
  }
}
