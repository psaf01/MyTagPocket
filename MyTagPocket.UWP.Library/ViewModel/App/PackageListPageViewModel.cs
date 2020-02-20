using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository;
using MyTagPocket.ViewModels;
using Prism.Navigation;

namespace MyTagPocket.UWP.Library.ViewModel.App
{
  /// <summary>
  /// Page show list packages
  /// </summary>
  public class PackageListPageViewModel : BaseViewModel
  {
    private const string ClassCode = "C11002";

    /// <summary>
    /// Navigation service
    /// </summary>
    INavigationService _navigationService;


    /// <summary>
    /// If navigate on other pages
    /// </summary>
    bool _canNavigate;

    public PackageListPageViewModel(INavigationService navigationService, ILogManager logManager) : base(logManager, ClassCode)
    {
      const string METHODCODE = "M01";
      Log.Info(METHODCODE, "Show first page");
      _navigationService = navigationService;
      _canNavigate = false;
    }

    /// <summary>
    /// whether it is possible to navigate to other pages
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>True - can navigate</returns>
    public bool CanNavigate(INavigationParameters parameters)
    {
      return _canNavigate;
    }
  }
}