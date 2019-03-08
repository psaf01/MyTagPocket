using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Xamarin;

namespace MyTagPocket.UWP.Test.Gui
{
  [TestClass]
  public class ThemeTest
  {
    [TestMethod]
    public void LoadFromResourcesOkTest()
    {
      var result = new MyTagPocket.Test.Gui.ThemeTest().LoadFromResourcesTest();
      Assert.IsTrue(result.Result, result.Message);
    }
  }
}
