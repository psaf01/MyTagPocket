using MyTagPocket.Exceptions;
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
        MainPage = new Pages.HomePage();
      }
      catch(FatalErrorException ex)
      {
        Log.Fatal(methodCode, "Init app", ex);
        MainPage = new Pages.FatalError(ex);
      }
      catch (Exception ex)
      {
        Log.Fatal(methodCode, "Init app", ex);
        MainPage = new Pages.FatalError(MyTagPocket.Resources.ResourceApp.FatalErrorUnexpected);
      }
     
    }

    public App(bool test)
    {
      InitializeComponent();
      MainPage = new Pages.HomePage();
     
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
