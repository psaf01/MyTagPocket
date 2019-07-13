using System.Text;

namespace MyTagPocket.Test.CoreUtil
{
  /// <summary>
  /// Text test
  /// </summary>
  public class TextTest
  {
    /// <summary>
    /// Test convert text to ASCII
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

    /// <summary>
    /// Test 
    /// </summary>
    /// <returns></returns>
    public ResultTest CompressDecompressStringTest()
    {
      string testText = "+ěščřžýáíéůúĚŘŠĎŽČÉÚÍÁ!@#$%^&*().,?<>;";
      string resultText = string.Empty;
      byte[] resultCompress = null;
      Encoding encoding = Encoding.UTF8; 

      resultCompress = MyTagPocket.CoreUtil.Text.Compress(testText,encoding);
      resultText = MyTagPocket.CoreUtil.Text.DecompressToString(resultCompress, encoding);
      if (testText == resultText)
        return new ResultTest(true);
      else
        return new ResultTest(false, "Decompress text was failed");
    }
  }
}
