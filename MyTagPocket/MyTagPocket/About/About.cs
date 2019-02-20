using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.About
{
  public class About
  {
    const string classCode = "[1000200]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    public About()
    {
    }
  }
}
