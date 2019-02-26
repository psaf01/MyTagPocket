using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyTagPocket.Storage.Entities.Settings
{
  /// <summary>
  /// Version application
  /// </summary>
  public class Version
  {
    #region Public attributest
    /// <summary>
    /// Version
    /// </summary>
    public string Ver { get; set; }
    #endregion Public atributes

    #region Public method
    /// <summary>
    /// Actual version application asembly
    /// </summary>
    /// <returns></returns>
    public string GetActuaAssemblylVersion()
    {
      return $"{Assembly.GetExecutingAssembly().GetName().Version.Major}.{Assembly.GetExecutingAssembly().GetName().Version.Minor}";
    }
    #endregion Public method
  }
}
