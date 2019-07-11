using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace MyTagPocket.UWP.Test.CoreUtil
{
  /// <summary>
  /// Mock file system storage for test
  /// </summary>
  public static class MockFileSystemStorage
  {
    private static MockFileSystem _MockFileSystem;

    /// <summary>
    /// How use file system. True= MockFileSystem, False = FileSystem
    /// </summary>
    public static bool UseMockFileSystem { get; set; } = true;

    /// <summary>
    /// Reinitialize mock file system
    /// </summary>
    public static void InitMockFileSystem()
    {
      _MockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>());
      _MockFileSystem.AddDirectory(@"c:\MyTagPocket");
      _MockFileSystem.AddDirectory(@"c:\MyTagPocket\settings");
      _MockFileSystem.AddDirectory(@"c:\MyTagPocket\contents");
      _MockFileSystem.AddDirectory(@"c:\MyTagPocket\temp");
    }

    /// <summary>
    /// Mock file system
    /// </summary>
    public static MockFileSystem MockFileSystem
    {
      get
      {
        if (_MockFileSystem == null)
        {
          InitMockFileSystem();
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
