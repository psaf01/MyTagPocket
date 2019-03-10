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
    /// Test initialize basic theme in application
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public ResultTest LoadFromResourcesTest()
    {
      try
      {
        var repository = new MyTagPocket.Gui.Themes.SettingTheme();
        repository.InitializeTheme();
        return new ResultTest(true);

      }
      catch (Exception ex)
      {
        return new ResultTest(false, ex.Message);

      }
    }

    /// <summary>
    /// Test save sample theme
    /// </summary>
    /// <returns></returns>
    public ResultTest CreateThemeSample()
    {
      try
      {
        var repository = new MyTagPocket.Gui.Themes.SettingTheme();
        var result = repository.CreateSampleTheme();
        if(result)
          return new ResultTest(true, "OK create sample tmeme");
        else
          return new ResultTest(false, "ERROR create sample tmeme");
      }
      catch(Exception ex)
      {
        return new ResultTest(false, ex.Message);
      }
     

    }
  }
}
