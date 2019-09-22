using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;

namespace MyTagPocket.UWP.Test.Mocks
{
  /// <summary>
  /// Mock file system storage for test
  /// </summary>
  public static class MockFileSystemStorage
  {
    private static MockFileSystem mockFileSystem;

    /// <summary>
    /// How use file system. True= MockFileSystem, False = FileSystem
    /// </summary>
    public static bool UseMockFileSystem { get; set; } = true;

    /// <summary>
    /// Reinitialize mock file system
    /// </summary>
    public static void InitMockFileSystem()
    {
      mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>());
      Windows.Storage.StorageFolder appDataFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
      mockFileSystem.AddDirectory(appDataFolder.Path);
      mockFileSystem.AddDirectory(System.IO.Path.Combine(appDataFolder.Path, "log"));
      mockFileSystem.AddDirectory(System.IO.Path.Combine(appDataFolder.Path, "settings"));
      mockFileSystem.AddDirectory(System.IO.Path.Combine(appDataFolder.Path, "contents"));
      mockFileSystem.AddDirectory(System.IO.Path.Combine(appDataFolder.Path, "temp"));
    }

    /// <summary>
    /// Mock file system
    /// </summary>
    public static MockFileSystem MockFileSystem
    {
      get
      {
        if (mockFileSystem == null)
        {
          InitMockFileSystem();
        }
        return mockFileSystem;
      }
      set
      {
        mockFileSystem = value;
      }
    }

  }
}
