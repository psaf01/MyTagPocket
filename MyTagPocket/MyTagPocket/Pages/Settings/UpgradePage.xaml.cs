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
  }
}