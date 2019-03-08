using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTagPocket.UWP.Test.CoreUtil
{
  [TestClass]
  public class TextTest
  {
    [TestMethod]
    public void ConvertAsciiOkTest()
    {
      var result = new MyTagPocket.Test.CoreUtil.TextTest().ConvertAsciiOkTest();
      Assert.IsTrue(result.Result, result.Message);
    }
  }
}
