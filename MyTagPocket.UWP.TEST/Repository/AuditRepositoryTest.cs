using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Test.Mocks;
using MyTagPocket.UWP.TEST.Mocks;
using System;
using System.Linq;
using Unity;
using Xunit;

namespace MyTagPocket.UWP.TEST.Repository
{
  /// <summary>
  /// Test audit log repository
  /// </summary>
  public class AuditRepositoryTest
  {
    [Fact]
    public void SaveGetTest()
    {
      var mockSetting = new MockSettingRepository();
      AppGlobal.Init(mockSetting);
      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      //fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      MockFileSystemStorage.InitMockFileSystem();
     
      mockSetting.InitializeTestDataBasic();

     
      logManager.AuditLogger.InitializeAuditLogAsync().Wait();

      var log = logManager.GetLog("C00000");
      var deviceGuid = Guid.NewGuid().ToString("N");
      var userGuid = Guid.NewGuid().ToString("N");

      log.AuditAsync("CODE1", DataTypeEnum.Audit, deviceGuid, userGuid, new System.Collections.Generic.Dictionary<string, string>(){ { "ke1", "value1" }, { "key2", "value2" } }).Wait();
      log.AuditAsync("CODE2", DataTypeEnum.Audit, deviceGuid, userGuid, null).Wait();
      log.AuditAsync("CODE3", DataTypeEnum.Audit, deviceGuid, userGuid, null).Wait();
      log.AuditAsync("CODE4", DataTypeEnum.Audit, deviceGuid, userGuid, null).Wait();


      var dateTime = DateTimeOffset.Now;
      var audits = logManager.AuditLogger.GetAuditsAsync(dateTime.Year, dateTime.Month).Result;
      var count = logManager.AuditLogger.CountAsync(dateTime.Year, dateTime.Month).Result;
      Assert.True(count == 5);
      Assert.True(count == audits.ToList().Count());
      logManager.FlushBuffer();
    }
  }
}
