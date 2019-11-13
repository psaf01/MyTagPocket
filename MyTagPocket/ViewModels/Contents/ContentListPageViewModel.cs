using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository;
using Prism.Navigation;

namespace MyTagPocket.ViewModels.Contents
{
  public class ContentListPageViewModel : BaseViewModel
  {
    /// <summary>
    /// Class code
    /// </summary>
    private const string ClassCode = "C10030";

    /// <summary>
    /// Navigation service
    /// </summary>
    INavigationService _navigationService;

    /// <summary>
    /// If navigate on other pages
    /// </summary>
    bool _canNavigate;
    private IFileHelper _fileHelper;

    public ContentListPageViewModel(INavigationService navigationService, ILogManager logManager, IFileHelper fileHelper) : base(logManager, ClassCode)
    {
      const string METHODCODE = "M01";
      Log.Info(METHODCODE, "Show first page");
      var repository = new FileRepository(logManager, fileHelper);
      //repository.SaveAsync(new MyTagPocket.Repository.File.Entities.Settings.Version(), false);
      _fileHelper = fileHelper;
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
