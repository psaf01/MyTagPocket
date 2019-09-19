﻿using MyTagPocket.CoreUtil.Interface;
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

    public ContentListPageViewModel(INavigationService navigationService, ILogManager logManager) : base(logManager, ClassCode)
    {
      const string METHODCODE = "M01";
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
