using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.About
{
  public class About
  {
    const string classCode = "[1000200]";
    public static Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<Interface.ILogManager>().GetLog(classCode);

    public About()
    {
    }
  }
}
