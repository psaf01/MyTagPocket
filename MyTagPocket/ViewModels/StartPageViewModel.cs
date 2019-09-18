using MyTagPocket.CoreUtil.Interface;
using Prism.Mvvm;
using Prism.Navigation;

namespace MyTagPocket.ViewModels
{
  public class StartPageViewModel : BaseViewModel, IConfirmNavigation
  {
    /// <summary>
    /// Class code
    /// </summary>
    private const string ClassCode = "[1002800]";

    /// <summary>
    /// Nvigation service
    /// </summary>
    INavigationService _navigationService;

    /// <summary>
    /// If navigate on other pages
    /// </summary>
    bool _canNavigate;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="navigationService">Navigation service</param>
    public StartPageViewModel(INavigationService navigationService, ILogManager logManager ) : base(logManager, ClassCode)
    {
      const string methodCode = "[1002801]";
      Log.Trace(methodCode, $"Init");
      var testA = "testvalue";
      var testB = 100;
      Log.Debug(methodCode, $"Init debug testA=[{testA}] testB=[{testB}]", testA, testB);
      Log.Info(methodCode, $"Init debug testA=[{testA}] testB=[{testB}]", testA, testB);

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
