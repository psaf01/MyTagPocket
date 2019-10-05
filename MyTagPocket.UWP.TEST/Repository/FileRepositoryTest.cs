using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Test.Mocks;
using Unity;
using Xamarin.Forms;
using Xunit;
using static MyTagPocket.UWP.TEST.Xamarin.Forms.Mocks.MockForms;

namespace MyTagPocket.UWP.TEST.Repository
{
  public class FileRepositoryTest
  {
     /// <summary>
    /// Save a load entity
    /// </summary>
    [Fact]
    public void SaveLoadAsyncTest()
    {
      Device.Info = new MockDeviceInfo();
      Device.PlatformServices = new MockPlatformServices();

      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<MockResourcesProvider>();
      myContainer.RegisterType<MockDeserializer>();

      myContainer.RegisterType<IFileHelper, FileHelper_UWP>();
      myContainer.RegisterType<ILogManager, LogManager_UWP>();
      var logManager = myContainer.Resolve<LogManager_UWP>();
      var fileHelper = myContainer.Resolve<FileHelper_UWP>();
      NLog.GlobalDiagnosticsContext.Set("user", "UnitTest");
      fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      var repository = new FileRepository(logManager, fileHelper);
      int testValue = 5;
      var version = new MyTagPocket.Repository.File.Entities.Settings.Version();
      var testVersion = new MyTagPocket.Repository.File.Entities.Settings.Version();

      version.Version = testValue;

      repository.SaveAsync(version, false).Wait();
      testVersion = repository.LoadAsync(testVersion).Result;

      Assert.True(version.Version == testVersion.Version, "Entity not identical");

      repository.DeleteAsync(testVersion).Wait();
      logManager.FlushBuffer();
    }


  }
}
