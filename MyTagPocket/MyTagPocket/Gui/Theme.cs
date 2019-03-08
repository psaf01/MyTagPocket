using System;
using Xamarin.Forms;

namespace MyTagPocket.Gui.Themes
{
  /// <summary>
  /// Actual theme application for GUI
  /// </summary>
  public class Theme
  {
    const string classCode = "[1001800]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);


    /// <summary>
    /// Load actual theme from resources of application
    /// </summary>
    /// <returns>Actual theme in application</returns>
    public Storage.Entities.Themes.Theme LoadFromResources()
    {
      Storage.Entities.Themes.Theme theme = new Storage.Entities.Themes.Theme();
      TextBlockStyle(theme, true);
      return theme;
    }

    /// <summary>
    /// Save theme to actual resources of application
    /// </summary>
    /// <param name="theme">Theme for setting</param>
    public void SaveToResource(Storage.Entities.Themes.Theme theme)
    {
      TextBlockStyle(theme);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="setFromResources">True = Load from Resources and set to object, False = Load from object and set to Resources</param>
    private void TextBlockStyle(Storage.Entities.Themes.Theme theme, bool setFromResources = false)
    {
      const string methodCode = "[1001801]";
      string styleName = "ErrorLabelStyle";
      Style style;
      try
      {
        style = (Style)App.Current.Resources[styleName];
        if (style == null)
          throw new Exception($"Style [{styleName}] not found in Resources");

      }
      catch (Exception ex)
      {
        Log.Error(methodCode, "Theme", ex);
        return;
      }

      if (setFromResources)
      {

        foreach (var prop in style.Setters)
        {
          if (prop.Property.PropertyName == "TextColor")
            theme.BasicSetting.ErrorLabelColor = GetHexString((Color)prop.Value);
        }
        //typeof(Label)
        return;
      }

      //Set resource from theme

      Application.Current.Resources["TextBlockStyle"] = style;

    }

    /// <summary>
    /// Transform Color definition to HEX definition
    /// </summary>
    /// <param name="color">Color object</param>
    /// <returns>Hex string</returns>
    private string GetHexString(Xamarin.Forms.Color color)
    {
      var red = (int)(color.R * 255);
      var green = (int)(color.G * 255);
      var blue = (int)(color.B * 255);
      //var alpha = (int)(color.A * 255);
      //var hex = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";
      //without alpha
      var hex = $"#{red:X2}{green:X2}{blue:X2}";

      return hex;
    }
  }
}
