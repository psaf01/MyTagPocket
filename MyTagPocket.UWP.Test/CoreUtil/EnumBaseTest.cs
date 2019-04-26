using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTagPocket.UWP.Test.CoreUtil
{
  [TestClass]
  public class EnumBaseTest 
  {
    [TestMethod]
    public void TestOnSameObject()
    {
      var result = new MyTagPocket.Test.CoreUtil.EnumBaseTest().ObjectSameTest();
      Assert.IsTrue(result.Result, result.Message);
    }

    [TestMethod]
    public void TestOnDiferentObject()
    {
      var result = new MyTagPocket.Test.CoreUtil.EnumBaseTest().ObjectDiferentTest();
      Assert.IsTrue(result.Result, result.Message);
    }

    [TestMethod]
    public void TestListObject()
    {
      var result = new MyTagPocket.Test.CoreUtil.EnumBaseTest().ObjectListTest();
      Assert.IsTrue(result.Result, result.Message);
    }

    [TestMethod]
    public void ObjectSearchInList()
    {
      var result = new MyTagPocket.Test.CoreUtil.EnumBaseTest().ObjectSearchInList();
      Assert.IsTrue(result.Result, result.Message);
    }
  }
}