namespace MyTagPocket.UWP
{
  public sealed partial class MainPage
  {
    /// <summary>
    /// Main page on Windows UWP
    /// </summary>
    public MainPage()
    {
      this.InitializeComponent();

      LoadApplication(new MyTagPocket.App());
    }
 
  }
}
