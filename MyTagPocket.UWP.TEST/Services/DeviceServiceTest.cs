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
      myContainer.RegisterType<IFileHelper, FileHelper_UWP>();
      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      var fileHelper = myContainer.Resolve<FileHelper_UWP>();
      fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      MockFileSystemStorage.InitMockFileSystem();
      var mockSetting = new MockSettingRepository();
      mockSetting.InitializeTestDataBasic();
      AppGlobal.Init(mockSetting);
      logManager.AuditLogger.InitializeAuditLogAsync();

      var fileRepository = new FileRepository(logManager, fileHelper);
      //var dalRepository = new DalRepository(logManager, fileHelper);
      //DeviceService deviceService = new DeviceService(logManager, fileRepository, dalRepository);
      //var device = deviceService.CreateNewDevice(DeviceTypeEnum.Uwp).Result;
    }
  }
}
