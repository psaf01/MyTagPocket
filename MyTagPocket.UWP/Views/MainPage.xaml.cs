using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Library.ViewModel.App;
using MyTagPocket.UWP.Library.Views.App;
using Prism;
using Prism.Events;
using Prism.Ioc;
using System;

namespace MyTagPocket.UWP
{
  public sealed partial class MainPage
  {

    public MainPage()
    {
      this.InitializeComponent();
      LoadApplication(new MyTagPocket.App(new UwpInitializer()));
      InitApp();

    }

    /// <summary>
    /// Initialize UWP application
    /// </summary>
    private void InitApp()
    {
      //_eventAggregator.GetEvent<ImDoneEvent>().Subscribe((ImDoneEventArgs args) => {

        // do stuff with args
       // _navigationService.NavigateAsync($"{nameof(Views.ResultsPage)}");
      //});
    }
  }
  public class UwpInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      RegisterFunctions(containerRegistry);
      RegisterPages(containerRegistry);
    }

    /// <summary>
    /// Register application views
    /// </summary>
    /// <param name="containerRegistry"></param>
    private void RegisterPages(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterForNavigation<PackageListPage, PackageListPageViewModel>();
    }

    /// <summary>
    /// Register main applications functions
    /// </summary>
    /// <param name="containerRegistry"></param>
    private void RegisterFunctions(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<ILogManager, LogManager_UWP>();
      containerRegistry.Register<IFileHelper, FileHelper_UWP>();
    }
  }
}
