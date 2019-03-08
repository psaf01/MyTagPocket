using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Test.Gui
{
  /// <summary>
  /// Theme test
  /// </summary>
  public class ThemeTest
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public ResultTest LoadFromResourcesTest()
    {
      string  expectedValue = "#A14265";
      var repository = new MyTagPocket.Gui.Themes.Theme();
      var  resultTheme = repository.LoadFromResources();

      if (resultTheme.BasicSetting.ErrorLabelColor == expectedValue)
        return new ResultTest(true);
      else
        return new ResultTest(false, $"expectedValue=[{expectedValue}] ErrorLabelColor=[{resultTheme.BasicSetting.ErrorLabelColor}]");
    }
  }
}
