namespace MyTagPocket.Test.CoreUtil
{
  /// <summary>
  /// Text test
  /// </summary>
  public class TextTest
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public ResultTest ConvertAsciiOkTest()
    {
      string testText = "Jedna očo řed 123";
      string expextedText = "Jedna_o_o__ed_123";
      string resultText = MyTagPocket.CoreUtil.Text.ConvertAscii(testText);
      if (expextedText == resultText)
        return new ResultTest(true);
      else
        return new ResultTest(false, $"testText=[{testText}] expectedText=[{expextedText}] resultText=[{resultText}]");
    }
  }
}
