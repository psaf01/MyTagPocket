using System;
using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Test.Mocks;
using MyTagPocket.UWP.TEST.Mocks;
using Entity = MyTagPocket.Repository.Dal.Entities;
using System.Linq;
using Unity;
using Xunit;
using MyTagPocket.Repository;

namespace MyTagPocket.UWP.TEST.Repository
{
  /// <summary>
  /// Test database repository
  /// </summary>
  public class DalRepositoryTest
  {
    [Fact]
    public void SaveFindDeviceTest()
    {
      var mockSetting = new MockSettingRepository();
      mockSetting.InitializeTestDataBasic();
      AppGlobal.Init(mockSetting);

      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManagerMemory>();

      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      //fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      
      MockFileSystemStorage.InitMockFileSystem();
     
      logManager.AuditLogger.InitializeAuditLogAsync().Wait();
     
      var dalRepository = new DalRepository(logManager);
      dalRepository.InitilizeDbAsync().Wait();

      var dateTime = DateTimeOffset.Now;

      var device1 = new Entity.Devices.Device();
      
      device1.DeviceId = "173bc09720324709a5f34359d66328e8";
      device1.Name = "Device 1";

      dalRepository.SaveAsync(device1).Wait();

      var count = dalRepository.CountAsync<Entity.Devices.Device>().Result;

      Assert.True(count == 1);
      var device1Result = dalRepository.FindAsync<Entity.Devices.Device>(x => x.DeviceId == device1.DeviceId).Result;//.ToList();
      var list = device1Result.ToList();
      Assert.True(device1Result.Count() == 1);
      Assert.True(device1.Name == list[0].Name);
    }

    [Fact]
    public void SaveFindOneDeviceTest()
    {
      var mockSetting = new MockSettingRepository();
      mockSetting.InitializeTestDataBasic();
      AppGlobal.Init(mockSetting);

      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      //fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;

      MockFileSystemStorage.InitMockFileSystem();

      logManager.AuditLogger.InitializeAuditLogAsync().Wait();

      var dalRepository = new DalRepository(logManager);
      dalRepository.InitilizeDbAsync().Wait();

      var dateTime = DateTimeOffset.Now;

      var device1 = new Entity.Devices.Device();

      device1.DeviceId = "173bc09720324709a5f34359d66328e8";
      device1.Name = "Device 2";

      dalRepository.SaveAsync(device1).Wait();

      var count = dalRepository.CountAsync<Entity.Devices.Device>().Result;

      Assert.True(count == 1);
      var device1Result = dalRepository.FindOneAsync<Entity.Devices.Device>(x => x.DeviceId == device1.DeviceId).Result;
      Assert.True(device1.Name == device1Result.Name);

      var device2Resutl = dalRepository.FindOneAsync<Entity.Devices.Device>(x => x.DeviceId == "XXXX").Result;
      Assert.True(device2Resutl == null);
    }
  }
}
