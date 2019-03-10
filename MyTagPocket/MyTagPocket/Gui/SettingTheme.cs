using System;
using Xamarin.Forms;

namespace MyTagPocket.Gui.Themes
{
  /// <summary>
  /// Setting GUI theme application
  /// </summary>
  public class SettingTheme
  {
    const string classCode = "[1001800]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);


    /// <summary>
    /// Initialize actual theme 
    /// </summary>
    public void InitializeTheme()
    {
      Storage.Entities.Themes.Theme theme = new Storage.Entities.Themes.Theme
      {
        FileNameTeheme = ""
      };
      new Storage.Repository.ThemeRepository().Load(theme);

      ErrorLabelStyle(theme);
    }

    /// <summary>
    /// Create sample theme and save to Storage
    /// </summary>
    public bool CreateSampleTheme()
    {
      const string methodCode = "[1001802]";
      Log.Trace(methodCode, "Create sample theme");
      Storage.Entities.Themes.Theme theme = new Storage.Entities.Themes.Theme
      {
        Description = Resources.ResourceApp.ThemeDescriptionExample,
        Name = "SampleTheme"
      };
      return new Storage.Repository.ThemeRepository().Save(theme);
    }
    /// <summary>
    /// Save theme to actual resources of application
    /// </summary>
    /// <param name="theme">Theme for setting</param>
    public void SaveToResource(Storage.Entities.Themes.Theme theme)
    {
      ErrorLabelStyle(theme);
    }

    /// <summary>
    /// Error label style
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="setFromResources">True = Load from Resources and set to object, False = Load from object and set to Resources</param>
    private void ErrorLabelStyle(Storage.Entities.Themes.Theme theme)
    {
      const string methodCode = "[1001801]";
      string styleName = "ErrorLabelStyle";
      try
      {
        Style style = new Style(typeof(Label));
        style.Setters.Add(new Setter() { Property = Label.TextColorProperty, Value = Color.FromHex(theme.BasicSetting.ErrorLabelColor) });
        Application.Current.Resources[styleName] = style;
      }
      catch (Exception)
      {
        Log.Error(methodCode, "Definition style Error label");
      }
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
