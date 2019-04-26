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
   
    

    public UpgradePage()
    {
      InitializeComponent();
      CheckList.IsPullToRefreshEnabled = true;
      //Navigation.RemovePage(Navigation.NavigationStack[0]);
     
      //CheckList.ItemsSource = _UpgradeInfoList;
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      //_StorageList.CategoryName = "STORAGE";
     
      UpgradeInfo info = new UpgradeInfo();
      info.Status = UpgradeStatusEnum.NotStart;
      info.StatusInfo = "Not started";
      info.UpgradeItemName = "Inicializace aktualizace 3";
      //_StorageList.UpgradeItem.Add(info);
      //_UpgradeInfoList.Add(_StorageList);
      //CheckList.ItemsSource = checkItemList;
      RunUpgrade();
    }

    private async void RunUpgrade()
    {

      for (int i = 3; i < 5; i++)
      {
        CheckList.BeginRefresh();
        UpgradeInfo info = new UpgradeInfo();
        info.Status = UpgradeStatusEnum.NotStart;
        info.StatusInfo = "Not started";
        info.UpgradeItemName = $"Inicializace aktualizace {i}";
        
        //_StorageList.UpgradeItem.Add(info);
        CheckList.EndRefresh();
        //await System.Threading.Thread.Sleep(1000);
        await Task.Delay(1000);
      }

      //_DatabaseList.CategoryName = "DATABASE";
     // _UpgradeInfoList.Add(_DatabaseList);

      for (int i = 1; i < 5; i++)
      {
        CheckList.BeginRefresh();
        UpgradeInfo info = new UpgradeInfo();
        info.Status = UpgradeStatusEnum.NotStart;
        info.StatusInfo = "Not started";
        info.UpgradeItemName = $"Inicializace database {i}";

       // _DatabaseList.UpgradeItem.Add(info);
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