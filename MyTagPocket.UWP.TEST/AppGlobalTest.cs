﻿using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Entities.Settings;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Test.Mocks;
using MyTagPocket.UWP.TEST.Mocks;
using Unity;
using Xunit;

namespace MyTagPocket.UWP.TEST
{
  /// <summary>
  /// Test global application variables
  /// </summary>
  public class AppGlobalTest
  {
    [Fact]
    public void BasicTest()
    {
      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManager_UWP_audit_memory>();
      var logManager = myContainer.Resolve<LogManager_UWP_audit_memory>();
      NLog.GlobalDiagnosticsContext.Set("user", "UnitTest");
      //fileHelper.FileSystemStorage = MockFileSystemStorage.MockFileSystem;
      var mockSetting = new MockSettingRepository();
      mockSetting.InitializeTestDataBasic();

      AppGlobal.Init(mockSetting);
      var testValue = AppGlobal.Device.DeviceFolderGuid;
      var expectValue = mockSetting.GetPersistText("CurrentFoldersDevicesGuid", "NONE");
      Assert.Equal(expectValue, testValue);
      logManager.FlushBuffer();
    }
  }
}
