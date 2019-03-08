using MyTagPocket.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public FatalError ()
		{
			InitializeComponent ();
		}
	}
}