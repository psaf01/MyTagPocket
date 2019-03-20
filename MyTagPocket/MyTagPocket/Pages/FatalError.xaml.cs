using MyTagPocket.Exceptions;
using MyTagPocket.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTagPocket.Pages
{
  /// <summary>
  /// Fatal Error page for all aplication 
  /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FatalError : ContentPage
	{
    const string classCode = "[1001500]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    /// <summary>
    /// Constructor
    /// </summary>
    public FatalError ()
		{
			InitializeComponent ();
		}

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="userMessage">User message</param>
    public FatalError(string userMessage)
    {
      InitializeComponent();
      ErrorText.Text = userMessage;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ex">Fatl error exception</param>
    public FatalError(FatalErrorException ex)
    {
      InitializeComponent();
      ErrorText.Text = ex.UserMessage;
    }
  }
}