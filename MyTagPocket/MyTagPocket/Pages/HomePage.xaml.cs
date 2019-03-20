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
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HomePage : MasterDetailPage
  {
    const string classCode = "[1002000]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    public HomePage()
    {
      InitializeComponent();
      MasterPage.ListView.ItemSelected += ListView_ItemSelected;
      //Hamburger menu
      if (Device.RuntimePlatform == Device.UWP)
      {
        Master.Icon = "swap.png";
        MasterBehavior = MasterBehavior.Popover;
      }
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      var item = e.SelectedItem as HomePageMenuItem;
      if (item == null)
        return;

      var page = (Page)Activator.CreateInstance(item.TargetType);
      page.Title = item.Title;

      Detail = new NavigationPage(page);
      IsPresented = false;

      MasterPage.ListView.SelectedItem = null;
    }
  }
}