using MyTagPocket.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTagPocket.Pages
{
  /// <summary>
  /// Main page for Windows UWP
  /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageUwp : ContentPage, IMainPage
	{
    const string classCode = "[1001400]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    public MainPageUwp ()
		{
			InitializeComponent ();
		}
	}
}