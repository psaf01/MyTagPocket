namespace MyTagPocket.UWP.Test
{
  public sealed partial class TestPage
  {
    public TestPage()
    {
      this.InitializeComponent();

      LoadApplication(new MyTagPocket.App(true));
    }
 
  }
}
