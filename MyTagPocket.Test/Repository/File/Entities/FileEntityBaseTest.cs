using MyTagPocket.CoreUtil;
using MyTagPocket.Repository.File.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        DataTypeEnum dataType = DataTypeEnum.CONTENTS;
        string id = null;
        EncryptTypeEnum encrypt = EncryptTypeEnum.NONE;
        var entity = new FileEntityBase(dataType, id, encrypt);
        return new ResultTest(true);

      }
      catch (Exception ex)
      {
        return new ResultTest(false, ex.Message);

      }
    }
  }
}
