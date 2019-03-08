using MyTagPocket.CoreUtil.Upgrade;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyTagPocket
{
  public partial class App : Application
  {
    const string classCode = "[1001200]";
    public static Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<Interface.ILogManager>().GetLog(classCode);

    public App()
    {
      const string methodCode = "[1001201]";
      Log.Info(methodCode, "Init app");
      InitializeComponent();
      try
      {
        var upgradeApp = new UpgradeApp();
        upgradeApp.CheckAndUpgradeStorage();
        upgradeApp.CheckAndUpgradeDal();
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, "Init app", ex);
      }
      if (Device.RuntimePlatform == Device.UWP)
      {
        MainPage = new Pages.MainPageUwp();
      }
      else
      {
        MainPage = new Pages.MainPage();
      }
    }

    public App(bool test)
    {
      InitializeComponent();

      if (Device.RuntimePlatform == Device.UWP)
      {
        MainPage = new Pages.MainPageUwp();
      }
      else
      {
        MainPage = new Pages.MainPage();
      }
    }
    protected override void OnStart()
    {
      
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
