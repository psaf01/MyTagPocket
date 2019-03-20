using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTagPocket.UWP.Test.CoreUtil
{
  /// <summary>
  /// Mock file system storage for test
  /// </summary>
  public static class MockFileSystemStorage
  {
    private static MockFileSystem _MockFileSystem;

    /// <summary>
    /// Mock file system
    /// </summary>
    public static MockFileSystem MockFileSystem
    {
      get
      {
        if (MockFileSystem == null)
        {
         _MockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>());
        }
        return _MockFileSystem;
      }
      set
      {
        _MockFileSystem = value;
      }
    }

  }
}
