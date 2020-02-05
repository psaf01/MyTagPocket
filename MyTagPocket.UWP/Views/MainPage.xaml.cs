using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.UWP.Library.CoreUtil;
using Prism;
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
    }
  }
  public class UwpInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<ILogManager, LogManager_UWP>();
      containerRegistry.Register<IFileHelper, FileHelper_UWP>();
    }
  }
}
