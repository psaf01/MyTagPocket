using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Entities;
using System;

namespace MyTagPocket.Test.Repository.File.Entities
{
  public class FileEntityBaseTest
  {
    /// <summary>
    /// Test initialize basic theme in application
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public ResultTest InitializeContentsFileEntityBase()
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
  }
}
