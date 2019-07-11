using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Interface;
using System;

namespace MyTagPocket.Repository.File.Upgrade
{
  /// <summary>
  /// Base class for upgrade file
  /// </summary>
  public class UpgradeFileBase
  {
    /// <summary>
    /// Get version file from Entity class
    /// </summary>
    /// <param name="t">Entity file class</param>
    /// <returns>Version actual file entity</returns>
    public int GetVersionFileFromEntity(IVersion t)
    {
      // Get instance of the attribute.
      FileVersionAttribute MyAttribute =
          (FileVersionAttribute)Attribute.GetCustomAttribute(t.GetType(), typeof(FileVersionAttribute));

      if (MyAttribute == null)
      {
        return 0;
      }
      else
      {
        return MyAttribute.Version;
      }
    }

    /// <summary>
    /// Check version  
    /// </summary>
    /// <param name="ver">Check files on version</param>
    /// <returns>True - actual version</returns>
    public bool IsActualVersion(IVersion ver)
    {
      var version = GetVersionFileFromEntity(ver);
      if (version == ver.Version)
        return true;

      return false;
    }
  }
}
