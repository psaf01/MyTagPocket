using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTagPocket.UWP.Test.Gui
{
  [TestClass]
  public class ThemeTest
  {

    private MyTagPocket.Test.Gui.ThemeTest _ThemeTest;

    [TestInitialize]
    public void InitTest()
    {
      _ThemeTest = new MyTagPocket.Test.Gui.ThemeTest();
    }

    [TestMethod]
    public void LoadFromResourcesOkTest()
    {
      var result = _ThemeTest.LoadFromResourcesTest();
      Assert.IsTrue(result.Result, result.Message);
    }

    [TestMethod]
    public void CreateThemeTestOk()
    {
      var result = _ThemeTest.CreateThemeSample();
      Assert.IsTrue(result.Result, result.Message);
    }
  }
}
