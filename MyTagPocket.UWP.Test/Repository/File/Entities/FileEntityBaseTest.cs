using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTagPocket.UWP.Test.CoreUtil;
using System;
using System.IO;

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
      var result = _FileEntityBaseTest.SerilizationDeserializationJsonTest();
      Assert.IsTrue(result.Result, result.Message);
    }

    [TestMethod]
    public void SaveCompressDecompresTest()
    {
      MockFileSystemStorage.UseMockFileSystem = false;
      var xx = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

      xx = Path.Combine(xx, "test.arc");
      var result = _FileEntityBaseTest.SaveCompressDecompresTest(xx);
      Assert.IsTrue(result.Result, result.Message);
    }
  }
}
