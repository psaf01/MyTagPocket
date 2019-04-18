using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTagPocket.BusinessLayer.Upgrade;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTagPocket.Pages.Settings
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class UpgradePage : ContentPage
  {
    ObservableCollection<UpgradeInfo> checkItemList;

    public UpgradePage()
    {
      InitializeComponent();
      CheckList.IsPullToRefreshEnabled = true;
      //Navigation.RemovePage(Navigation.NavigationStack[0]);
      checkItemList = new ObservableCollection<UpgradeInfo>();
      CheckList.ItemsSource = checkItemList;
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      UpgradeInfo info = new UpgradeInfo();
      info.Status = UpgradeStatusEnum.NotStart;
      info.StatusInfo = "Not started";
      info.NameUpgradeItem = "Inicializace aktualizace 3";
      checkItemList.Add(info);
      //CheckList.ItemsSource = checkItemList;
      RunUpgrade();
    }

    private async void RunUpgrade()
    {

      for (int i = 3; i < 10; i++)
      {
        CheckList.BeginRefresh();
        UpgradeInfo info = new UpgradeInfo();
        info.Status = UpgradeStatusEnum.NotStart;
        info.StatusInfo = "Not started";
        info.NameUpgradeItem = $"Inicializace aktualizace {i}";
        checkItemList.Add(info);
        CheckList.EndRefresh();
        //await System.Threading.Thread.Sleep(1000);
        await Task.Delay(1000);
      }
    }

    private StackLayout AddCheck(int i)
    {

      var stack = new StackLayout
      {
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Children =
        {
          new Label
          {
            Text  = $"TEST {i}"
          }
        }
      };
      return stack;
    }
  }
}