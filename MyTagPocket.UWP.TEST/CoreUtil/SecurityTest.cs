using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.UWP.Library.CoreUtil;
using Unity;
using Xunit;

namespace MyTagPocket.UWP.TEST.CoreUtil
{
  /// <summary>
  /// Security test
  /// </summary>
  public class SecurityTest
  {
    /// <summary>
    /// Lorem ipsum
    /// </summary>
    private string LoremIpsum = @"<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. In rutrum. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Maecenas lorem. Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer tempor. Nulla pulvinar eleifend sem. Donec ipsum massa, ullamcorper in, auctor et, scelerisque sed, est. Duis risus. Integer pellentesque quam vel velit. Morbi leo mi, nonummy eget tristique non, rhoncus non leo. Integer pellentesque quam vel velit. Fusce suscipit libero eget elit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed convallis magna eu sem.</p>
      <p>Maecenas aliquet accumsan leo. Integer lacinia. Curabitur ligula sapien, pulvinar a vestibulum quis, facilisis vel sapien. Fusce wisi. Etiam commodo dui eget wisi. Fusce consectetuer risus a nunc. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Mauris metus. Maecenas sollicitudin.</p>
      <p>Mauris dictum facilisis augue. Vestibulum erat nulla, ullamcorper nec, rutrum non, nonummy ac, erat. Vivamus porttitor turpis ac leo. Etiam quis quam. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. In rutrum. Fusce consectetuer risus a nunc. Maecenas ipsum velit, consectetuer eu lobortis ut, dictum at dui. Etiam posuere lacus quis dolor. Nulla quis diam. Vestibulum fermentum tortor id mi. Etiam bibendum elit eget erat. Phasellus et lorem id felis nonummy placerat. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin mattis lacinia justo. Aenean placerat.</p>
      <p>Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Donec quis nibh at felis congue commodo. Mauris metus. Cras pede libero, dapibus nec, pretium sit amet, tempor quis. Quisque porta. Sed ac dolor sit amet purus malesuada congue. Aliquam ante. Etiam egestas wisi a erat. Donec quis nibh at felis congue commodo. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Praesent id justo in neque elementum ultrices. Nunc dapibus tortor vel mi dapibus sollicitudin. Nullam sit amet magna in magna gravida vehicula. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aliquam erat volutpat. Cras elementum. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Curabitur bibendum justo non orci. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam.</p>";

    /// <summary>
    /// Encrypt decrtypt text
    /// </summary>
    [Fact]
    public void EncryptDecryptTextTest()
    {
      IUnityContainer myContainer = new UnityContainer();
      myContainer.RegisterType<ILogManager, LogManager_UWP>();
      var logManager = myContainer.Resolve<LogManager_UWP>();
      NLog.GlobalDiagnosticsContext.Set("user", "UnitTest");

      string passwordTest = "Test";
      string textTest = LoremIpsum;
      var crypt = MyTagPocket.CoreUtil.Security.Encrypt(textTest, passwordTest);
      var decrypt = MyTagPocket.CoreUtil.Security.Decrypt(crypt, passwordTest);
      Assert.Equal(textTest, decrypt);
    }

  }
}
