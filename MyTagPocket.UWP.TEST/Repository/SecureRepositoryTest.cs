using MyTagPocket.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;
using Xunit;
using Unity;
using MyTagPocket.Repository.Interface;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.UWP.Library.CoreUtil;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static MyTagPocket.UWP.TEST.Xamarin.Forms.Mocks.MockForms;
using MyTagPocket.UWP.TEST.Mocks;
using System.IO.Abstractions;
using Moq;
using MyTagPocket.UWP.Test.Mocks;
using MyTagPocket.Repository.Secure;

namespace MyTagPocket.UWP.TEST.Repository
{
  /// <summary>
  /// Unit test Secure repository
  /// </summary>
  public class SecureRepositoryTest
  {

    [Theory]
    [InlineData("test1")]
    [InlineData("test one")]
    [InlineData("ěščř žýáíé")]
    [InlineData("@#$%^&*()<>?'|!")]
    public void SaveReadDeleteAsyncTest(string testValue)
    {
      var secureItem = SecureItemEnum.GlobalPassword;
      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManager_UWP>();
      var logManager = myContainer.Resolve<LogManager_UWP>();
      NLog.GlobalDiagnosticsContext.Set("user", "UnitTest");
      var testSecure = new SecureRepository(logManager);
      testSecure.SaveSecureValueAsync(secureItem, testValue).Wait();
      var result = testSecure.GetSecureValueAsync(secureItem).Result;
      Assert.Equal(testValue, result);
      testSecure.DeleteSecureValue(secureItem);
    }
  }
}
