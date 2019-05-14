using MyTagPocket.BusinessLayer.Upgrade;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTagPocket.Pages.Settings
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class UpgradePage : ContentPage
  {

    private bool _PageIsInitialize = false;
    /// <summary>
    /// Constructor
    /// </summary>
    public UpgradePage()
    {
      InitializeComponent();
      CheckList.IsPullToRefreshEnabled = true;
      _PageIsInitialize = false;
      //Navigation.RemovePage(Navigation.NavigationStack[0]);

      //CheckList.ItemsSource = _UpgradeInfoList;
    }

    /// <summary>
    /// Page upgrade is prepared 
    /// </summary>
    protected override async void OnAppearing()
    {
      base.OnAppearing();
      if (_PageIsInitialize)
        return;

      var upgradeApp = new UpgradeApp();
      upgradeApp.InitUpgrade(); 
      CheckList.ItemsSource = upgradeApp.UpgradeList;
      await Task.Yield();
      _ = StartUpgrade(upgradeApp);
      _PageIsInitialize = true;
    }

    private async Task StartUpgrade(UpgradeApp upgradeApp)
    {
      await Task.Run(() =>
      {
        _ = upgradeApp.StartAsync();
      });
    }
    /// <summary>
    /// Run upgrade application
    /// </summary>
    private async void RunUpgrade()
    {

      for (int i = 3; i < 5; i++)
      {
        CheckList.BeginRefresh();
        UpgradeInfo info = new UpgradeInfo();
        info.Status = UpgradeStatusEnum.NOTSTART;
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
        info.Status = UpgradeStatusEnum.NOTSTART;
        info.StatusInfo = "Not started";
        info.UpgradeItemName = $"Inicializace database {i}";

        //_DatabaseList.UpgradeItem.Add(info);
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