using MyTagPocket.CoreUtil;
using MyTagPocket.Repository;
using MyTagPocket.Repository.File.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTagPocket.Test.Repository
{
  public class FileRepositoryTest
  {
    /// <summary>
    /// Test save file on the disk
    /// </summary>
    /// <returns></returns>
    public ResultTest FileSaveLoadDeleteTest()
    {
      try
      {
        int testValue = 5;
        var version = new MyTagPocket.Repository.File.Entities.Settings.Version();
        var testVersion = new MyTagPocket.Repository.File.Entities.Settings.Version();

        version.Version = testValue;
        var repository = new FileRepository();

        repository.SaveAsync(version).Wait();
        testVersion = repository.LoadAsync<MyTagPocket.Repository.File.Entities.Settings.Version>(testVersion).Result;

        bool result = false;
        if (version.Version == testVersion.Version)
          result = true;
        if(!result)
          return new ResultTest(result);

        repository.DeleteAsync<MyTagPocket.Repository.File.Entities.Settings.Version>(testVersion).Wait();
        return new ResultTest(result);

      }
      catch (Exception ex)
      {
        return new ResultTest(false, ex.Message);

      }
    }
  }
}
