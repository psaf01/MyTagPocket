using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.About
{
  public class About
  {
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog();

    public About()
    {
    }
  }
}
