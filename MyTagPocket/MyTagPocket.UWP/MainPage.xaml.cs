namespace MyTagPocket.UWP
{
  public sealed partial class MainPage
  {
    const string classCode = "[2000200]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    public MainPage()
    {
      this.InitializeComponent();

      LoadApplication(new MyTagPocket.App());
    }
 
  }
}
