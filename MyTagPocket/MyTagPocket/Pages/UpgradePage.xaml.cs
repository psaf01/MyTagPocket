using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.CoreUtil.Upgrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTagPocket.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpgradePage : ContentPage
	{
		public UpgradePage ()
		{
			InitializeComponent ();
      var upgradeApp = new UpgradeApp(DependencyService.Get<IFileHelper>().FileSystemStorage);
      if (!upgradeApp.ActualVersionApp())
      {
        //var upgradePage = new
        //upgradeApp.
        //upgradeApp.CheckAndUpgradeStorage();
        //upgradeApp.CheckAndUpgradeDal();
      }
    }
	}
}