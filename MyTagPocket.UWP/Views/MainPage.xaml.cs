using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.UWP.CoreUtil;
using Prism;
using Prism.Ioc;

namespace MyTagPocket.UWP
{
  public sealed partial class MainPage
  {

    public MainPage()
    {
      this.InitializeComponent();

      LoadApplication(new MyTagPocket.App(new UwpInitializer()));
    }
  }

  public class UwpInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register(typeof(ILogManager), typeof(LogManager_UWP));
    }
  }
}
