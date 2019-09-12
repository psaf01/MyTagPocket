using Prism;
using Prism.Ioc;
using MyTagPocket.ViewModels;
using MyTagPocket.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyTagPocket
{
  public partial class App
  {
    /* 
     * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
     * This imposes a limitation in which the App class must have a default constructor. 
     * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
     */
    public App() : this(null) { }

    public App(IPlatformInitializer initializer) : base(initializer) { }

    protected override async void OnInitialized()
    {
      InitializeComponent();

      await NavigationService.NavigateAsync("MainNavigationPage/ContentListPage");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<MainNavigationPage, MainNavigationPageViewModel>();
      containerRegistry.RegisterForNavigation<StartPage, StartPageViewModel>();
      //containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
      containerRegistry.RegisterForNavigation<MainMasterDetailPage, MainMasterDetailPageViewModel>();
      containerRegistry.RegisterForNavigation<MainNavigationPage, MainNavigationPageViewModel>();
      containerRegistry.RegisterForNavigation<Views.Contents.ContentListPage, ViewModels.Contents.ContentListPageViewModel>();
    }
  }
}
