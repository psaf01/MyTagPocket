using MyTagPocket.ViewModels;
using MyTagPocket.Views;
using Prism;
using Prism.Ioc;
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
      Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjAzMTI5QDMxMzcyZTMzMmUzMG82VDd3RGJMTnJMUEd1NDg3N2pxMDFGeFIwUDI5Wjl0bXh0SHEwa2NLcEk9");
      InitializeComponent();
      //var ea = Container.Resolve<IEventAggregator>();
      //ea.GetEvent<ShowPackagesListPageEvent>().Publish();
      await NavigationService.NavigateAsync("MainPage");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<NavigationPage>();
      //containerRegistry.RegisterForNavigation<MainMasterDetailPage, MainMasterDetailPageViewModel>();
      containerRegistry.RegisterForNavigation<Views.Contents.ContentListPage, ViewModels.Contents.ContentListPageViewModel>();
      containerRegistry.RegisterForNavigationOnIdiom<MainPage, MainPageViewModel>();
      /*containerRegistry.RegisterForNavigationOnIdiom<MainPage, MainPageViewModel>(
        phoneView: typeof(MainPage),
         desktopView: typeof(MainPageDesktop),
         //desktopView: typeof(MainMasterDetailPage),
          tabletView: typeof(MainPage)
      );
      */
      //containerRegistry.RegisterForNavigation<NavigationPage, NavigationPageViewModel>();
      containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
    }
  }
}
