using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms;

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
      InitCouchBase();
    }

    public void InitCouchBase()
    {
      const string methodCode = "[2000201]";
      Log.Trace(methodCode, "Init CouchBase");
    }
  }
}
