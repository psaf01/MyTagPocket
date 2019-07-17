using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTagPocket.Test;
using MyTagPocket.UWP.Test.CoreUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTagPocket.UWP.Test.Repository
{
  /// <summary>
  /// Test file repository
  /// </summary>
  [TestClass]
  public class FileRepositoryTest
  {
    private MyTagPocket.Test.Repository.FileRepositoryTest _FileRepositoryTest;

    [TestInitialize]
    public void InitTest()
    {
      _FileRepositoryTest = new MyTagPocket.Test.Repository.FileRepositoryTest();
    }

    [TestMethod]
    public void FileSaveLoadDeleteTest()
    {
      var result = _FileRepositoryTest.FileSaveLoadDeleteTest();
      Assert.IsTrue(result.Result, result.Message);

    }

    [TestMethod]
    public void FileSaveLoadArchiveContentTest()
    {
      MockFileSystemStorage.UseMockFileSystem = false;
      var result = _FileRepositoryTest.FileSaveLoadArchiveContentTest();
      Assert.IsTrue(result.Result, result.Message);

    }
  }
}
