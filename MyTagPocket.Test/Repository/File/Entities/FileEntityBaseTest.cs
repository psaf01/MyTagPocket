using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File.Entities;
using System;
using System.Text;
using Xamarin.Forms;

namespace MyTagPocket.Test.Repository.File.Entities
{
  public class FileEntityBaseTest
  {
    /// <summary>
    /// Test Serilization and deserilization JSON text
    /// </summary>
    /// <returns>Result</returns>
    public ResultTest SerilizationDeserializationJsonTest()
    {
      try
      {
        int testValue = 5;
        var testEntity = new MyTagPocket.Repository.File.Entities.Contents.Version();
        testEntity.Version = testValue;
        string testJson = testEntity.SerializeJson();
        var resultTest = new MyTagPocket.Repository.File.Entities.Contents.Version();
        var test = resultTest.DeserializeJson(testJson);
        bool result = false;
        if (test.Version == testEntity.Version)
          result = true;
        //var entity = new FileEntityBase(dataType, id, encrypt);
        return new ResultTest(result);

      }
      catch (Exception ex)
      {
        return new ResultTest(false, ex.Message);

      }
    }

    /// <summary>
    /// Test compress and decompress string in archive file
    /// </summary>
    /// <returns>Result</returns>
    public ResultTest SaveCompressDecompresTest()
    {
      string filePath = @"c:\MyTagPocket\test.arc";
      return SaveCompressDecompresTest(filePath);
    }

    /// <summary>
    /// Test compress and decompress string in archive file
    /// </summary>
    /// <returns>Result</returns>
    public ResultTest SaveCompressDecompresTest(string filePath)
    {
      Encoding encoding = Encoding.UTF8;
      string content1 = @"There are lots of ways in which you can cause yourself problems with async code, and so its worth investing time to deepen your understanding of threading. In this article I've just picked out a few of the problems I see most frequently, but I'm sure there are plenty more that could be added. Let me know in the comments what advice you'd add to this list.

If you'd like to learn more about threading in C#, a few resources I can recommend are Bill Wagner's recent NDC talk The promise of an async future awaits, Filip Ekberg's Pluralsight course Getting Started with Asynchronous Programming in .NET, and of course anything written by renowned async expert Stephen Cleary.";
      int content1Length = 0;
      string content2 = "+ěščřžýáíé";
      int content2Length = 0;
      string content3 = "text specific ,ů§ú)ŘŤ;.,><";
      int content3Length = 0;
      string content4 = "text \nextreme\nupsa";
      int content4Length = 0;
      string resultContent = string.Empty;
      var fileHelper = DependencyService.Get<IFileHelper>();
      var filePath2 = System.IO.Path.ChangeExtension(filePath, "ar2");

      //save
      byte[] compress = Text.Compress(content1, encoding);
      content1Length = compress.Length;
      fileHelper.SaveAppendToFile(filePath, compress);
      fileHelper.SaveAppendToFile(filePath2, content1);

      compress = Text.Compress(content2, encoding);
      content2Length = compress.Length;
      fileHelper.SaveAppendToFile(filePath, compress);
      fileHelper.SaveAppendToFile(filePath2, content2);

      compress = Text.Compress(content3, encoding);
      content3Length = compress.Length;
      fileHelper.SaveAppendToFile(filePath, compress);
      fileHelper.SaveAppendToFile(filePath2, content3);

      compress = Text.Compress(content4, encoding);
      content4Length = compress.Length;
      fileHelper.SaveAppendToFile(filePath, compress);
      fileHelper.SaveAppendToFile(filePath2, content4);

      //load
      compress = fileHelper.LoadContentFromFile(filePath, content1Length, content2Length);
      resultContent = Text.DecompressToString(compress, encoding);
      if (content2 != resultContent)
        return new ResultTest(false, "Error save and load text to archive");

      return new ResultTest(true);
    }
  }
}
