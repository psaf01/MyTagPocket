﻿using Xamarin.Forms;

namespace MyTagPocket
{
  /// <summary>
  /// Main page cross platform
  /// </summary>
  public partial class MainPage : ContentPage
  {
    const string classCode = "[1000100]";
    public static ILogger Log = Xamarin.Forms.DependencyService.Get<ILogManager>().GetLog(classCode);

    /// <summary>
    /// Concstructor
    /// </summary>
    public MainPage()
    {
      InitializeComponent();
    }
  }
}
