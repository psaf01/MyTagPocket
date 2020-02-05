using MyTagPocket.CoreUtil;
using System;
using Xunit;

namespace MyTagPocket.UWP.TEST.CoreUtil
{
  public class ShortGuidTest
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GuidToShortTest()
    {
      Guid guidTest = Guid.Parse("8f055c81-54b6-4aaf-845d-aaeee4e0dc19");
      ShortGuid shortGuidTest = new ShortGuid(guidTest);
      var shortGuid = shortGuidTest.Guid;
      Assert.Equal(guidTest, shortGuid);
      ShortGuid shortGuidConvert = new ShortGuid("gVwFj7ZUr0qEXaru5ODcGQ");
      Assert.Equal(guidTest, shortGuidConvert.Guid);
    }
  }
}
