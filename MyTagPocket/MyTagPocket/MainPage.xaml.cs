using Xamarin.Forms;

namespace MyTagPocket
{
  /// <summary>
  /// Main page cross platform
  /// </summary>
  public partial class MainPage : ContentPage
  {
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog();

    /// <summary>
    /// Concstructor
    /// </summary>
    public MainPage()
    {
      InitializeComponent();
      InitCouchBase();
    }

    public void InitCouchBase()
    {
      Log.Trace("Init Couchbase Core");
    }
  }
}
