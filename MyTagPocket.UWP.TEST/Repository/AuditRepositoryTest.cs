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
      myContainer.RegisterType<IFileHelper, FileHelper_UWP>();
      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      var fileHelper = myContainer.Resolve<FileHelper_UWP>();
      fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      MockFileSystemStorage.InitMockFileSystem();
     
      mockSetting.InitializeTestDataBasic();

     
      logManager.AuditLogger.InitializeAuditLogAsync().Wait();

      var log = logManager.GetLog("C00000");
      var deviceGuid = Guid.NewGuid().ToString("N");
      var userGuid = Guid.NewGuid().ToString("N");

      log.Audit("CODE1", DataTypeEnum.Audit, deviceGuid, userGuid, null);
      log.Audit("CODE2", DataTypeEnum.Audit, deviceGuid, userGuid, null);
      log.Audit("CODE3", DataTypeEnum.Audit, deviceGuid, userGuid, null);
      log.Audit("CODE4", DataTypeEnum.Audit, deviceGuid, userGuid, null);


      var dateTime = DateTimeOffset.Now;
      var audits = logManager.AuditLogger.GetAudits(dateTime.Year, dateTime.Month);
      var count = logManager.AuditLogger.Count(dateTime.Year, dateTime.Month);
      Assert.True(count == 5);
      Assert.True(count == audits.ToList().Count());
    }
  }
}
