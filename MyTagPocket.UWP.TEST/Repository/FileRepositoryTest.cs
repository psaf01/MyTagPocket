using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository;
using MyTagPocket.Repository.Files;
using MyTagPocket.Repository.Files.Interfaces;
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

      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      NLog.GlobalDiagnosticsContext.Set("user", "UnitTest");
      //fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      Windows.Storage.StorageFolder appDataFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
      var repository = new FileRepository(logManager, MockFileSystemStorage.MockFileSystem, appDataFolder.Path);
      var device = new MyTagPocket.Repository.Files.Entities.Devices.Device();
      device.Name = "Test device ěščřžýáíé";
      device.FolderId = "2d2740d9ac634bed83050879ce0a1018";

      repository.SaveAsync(device).Wait();
      MyTagPocket.Repository.Files.Entities.Devices.Device testDevice = repository.LoadAsync(device).Result;

      Assert.Equal(device.Hash, testDevice.Hash);
      Assert.Equal(device.EntityId, testDevice.EntityId);
      Assert.Equal(device.CreatedWhen, testDevice.CreatedWhen);
      Assert.Equal(device.CommitId, testDevice.CommitId);
      Assert.Equal(device.Name, testDevice.Name);
      Assert.Equal(device.Version, testDevice.Version);

      repository.DeleteAsync(device).Wait();
      logManager.FlushBuffer();
    }

    /// <summary>
    /// Save a load entity history
    /// </summary>
    [Fact]
    public void SaveLoadHistoryAsyncTest()
    {
      Device.Info = new MockDeviceInfo();
      Device.PlatformServices = new MockPlatformServices();

      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<MockResourcesProvider>();
      myContainer.RegisterType<MockDeserializer>();

      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      NLog.GlobalDiagnosticsContext.Set("user", "UnitTest");
      Windows.Storage.StorageFolder appDataFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
      var repository = new FileRepository(logManager, MockFileSystemStorage.MockFileSystem, appDataFolder.Path);
      var device1 = new MyTagPocket.Repository.Files.Entities.Devices.Device();
      device1.Name = "1 Test device ěščřžýáíé";
      device1.FolderId = "2d2740d9ac634bed83050879ce0a1018";
      device1.UpdatedWho = new MyTagPocket.Repository.Files.Entities.Users.UserBasicInfo()
      {
        Email = "1test@test.com",
        EntityId = "1",
        FullName = "1 test name ěščřžýáíé"
      };
      repository.SaveAsync(device1).Wait();

      var device2 = repository.LoadAsync(device1).Result;
      Assert.True(device1.Name == device2.Name, "Object not same");
      device2.Name = "2 Test device";
      device2.UpdatedWho = new MyTagPocket.Repository.Files.Entities.Users.UserBasicInfo()
      {
        Email = "2test@test.com",
        EntityId = "2",
        FullName = "2 test name"
      };
      repository.SaveAsync(device2).Wait();

      var device3 = repository.LoadAsync(device2).Result;
      Assert.True(device2.Name == device3.Name, "Object not same");

      device3.Name = "3 Test device";
      device3.UpdatedWho = new MyTagPocket.Repository.Files.Entities.Users.UserBasicInfo()
      {
        Email = "3test@test.cz",
        EntityId = "3",
        FullName = "3 None"
      };
      repository.SaveAsync(device3).Wait();

      var device4 = repository.LoadAsync(device2).Result;
      Assert.True(device3.Name == device4.Name, "Object not same");
/*
      device4.Name = "4 Test device";
      device3.UpdatedWho = new MyTagPocket.Repository.Files.Entities.Users.UserBasicInfo()
      {
        Email = "4test@test.cz",
        EntityId = "4",
        FullName = "4 None"
      };
      repository.SaveAsync(device4).Wait();

      var history = repository.LoadHistoryAsync(device4).Result;
      IFileHistoryInfo restore1 = new FileHistoryInfo();
      IFileHistoryInfo restore2 = new FileHistoryInfo(); 
      IFileHistoryInfo restore3 = new FileHistoryInfo();
      int count = 1;
      foreach (var item in history)
      {
        switch (count)
        {
          case 1:
            restore1 = item;
            break;
          case 2:
            restore2 = item;
            break;
          case 3:
            restore3 = item;
            break;
          default:
            break;
        }
        count++;
      }

      var restoreDevice1 = repository.LoadFromArchivAsync<MyTagPocket.Repository.Files.Entities.Devices.Device>(restore1).Result;
      Assert.Equal(device1.Name, restoreDevice1.Name);
      var restoreDevice2 = repository.LoadFromArchivAsync<MyTagPocket.Repository.Files.Entities.Devices.Device>(restore2).Result;
      Assert.Equal(device2.Name, restoreDevice2.Name);
      var restoreDevice3 = repository.LoadFromArchivAsync<MyTagPocket.Repository.Files.Entities.Devices.Device>(restore3).Result;
      Assert.Equal(device3.Name, restoreDevice3.Name);
*/
    }
  }
}
