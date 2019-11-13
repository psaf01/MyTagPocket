using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository;
using MyTagPocket.Repository.Secure;
using MyTagPocket.UWP.Library.CoreUtil;
using Unity;
using Xunit;

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
