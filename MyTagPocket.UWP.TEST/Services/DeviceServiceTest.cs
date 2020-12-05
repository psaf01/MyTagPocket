using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Models.Devices;
using MyTagPocket.Repository;
using MyTagPocket.Services;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Test.Mocks;
using MyTagPocket.UWP.TEST.Mocks;
using System.IO;
using Unity;
using Xamarin.Forms;
using Xunit;

namespace MyTagPocket.UWP.TEST.Services
{
  /// <summary>
  /// Test device service
  /// </summary>
  public class DeviceServiceTest
  {

    /// <summary>
    /// Test create new device
    /// </summary>
    [Fact]
    public void CreateDeviceTest()
    {
      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      //fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      MockFileSystemStorage.InitMockFileSystem();
      var mockSetting = new MockSettingRepository();
      mockSetting.InitializeTestDataBasic();
      AppGlobal.Init(mockSetting);
      logManager.AuditLogger.InitializeAuditLogAsync();

      Windows.Storage.StorageFolder appDataFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
      var repository = new FileRepository(logManager, MockFileSystemStorage.MockFileSystem, appDataFolder.Path);

      //var dalRepository = new DalRepository(logManager, fileHelper);
      //DeviceService deviceService = new DeviceService(logManager, fileRepository, dalRepository);
      //var device = deviceService.CreateNewDevice(DeviceTypeEnum.Uwp).Result;
    }
  }
}
