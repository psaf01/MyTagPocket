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
      var device = new MyTagPocket.Repository.File.Entities.Devices.Device();
      device.Name = "Test device";
      device.FolderId = "2d2740d9ac634bed83050879ce0a1018";

      repository.SaveAsync(device, null).Wait();
      MyTagPocket.Repository.File.Entities.Devices.Device testDevice = repository.LoadAsync(device).Result;

      Assert.Equal(device.Hash, testDevice.Hash);
      Assert.Equal(device.EntityId, testDevice.EntityId);
      Assert.Equal(device.CreatedWhen, testDevice.CreatedWhen);
      Assert.Equal(device.CommitId, testDevice.CommitId);
      Assert.Equal(device.Name, testDevice.Name);
      Assert.Equal(device.Version, testDevice.Version);

      repository.DeleteAsync(device).Wait();
      logManager.FlushBuffer();
    }


  }
}
