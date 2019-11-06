using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket
{
  /// <summary>
  /// Application global variables
  /// </summary>
  public static class AppGlobal
  {
    private static string userSystem;

    /// <summary>
    /// System user
    /// </summary>
    public static string UserSystem
    {
      get
      {
        if (string.IsNullOrEmpty(userSystem))
        {
          return "d26664dc8361432693b235f97707ca9f";
        }
        return userSystem;
      }
      set
      {
        userSystem = value;
      }
    }
  }
}
