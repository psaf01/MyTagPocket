using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTagPocket.UWP.Test.Repository.File.Entities
{
  [TestClass]
  public class FileEntityBaseTest
  {
    private MyTagPocket.Test.Repository.File.Entities.FileEntityBaseTest _FileEntityBaseTest;

    [TestInitialize]
    public void InitTest()
    {
      _FileEntityBaseTest = new MyTagPocket.Test.Repository.File.Entities.FileEntityBaseTest();
    }

    [TestMethod]
    public void InitializeContentsFileEntityBase()
    {
      var result = _FileEntityBaseTest.InitializeContentsFileEntityBase();
      Assert.IsTrue(result.Result, result.Message);
    }
  }
}
