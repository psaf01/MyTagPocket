using MyTagPocket.Interface;
using Xamarin.Forms;

namespace MyTagPocket.Pages
{
  /// <summary>
  /// Main page cross platform
  /// </summary>
  public partial class MainPage : ContentPage, IMainPage
  {
    const string classCode = "[1001100]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    /// <summary>
    /// Concstructor
    /// </summary>
    public MainPage()
    {
      InitializeComponent();
    }
  }
}
