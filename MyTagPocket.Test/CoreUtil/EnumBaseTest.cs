using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Test.CoreUtil
{
  public class EnumBaseTest
  {
    /// <summary>
    /// Test on same enumeration object
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public ResultTest ObjectSameTest()
    {
      var testValue = MyTagPocket.CoreUtil.DataTypeEnum.SETTINGS;
      var expextedValue = MyTagPocket.CoreUtil.DataTypeEnum.SETTINGS;

      if (testValue == expextedValue)
        return new ResultTest(true);
      else
        return new ResultTest(false, $"Objects not diferent. testValue=[{testValue}] expextedValue=[{expextedValue}]");
    }

    /// <summary>
    /// Test on diferent object
    /// </summary>
    /// <returns></returns>
    public ResultTest ObjectDiferentTest()
    {
      var testValue = MyTagPocket.CoreUtil.DataTypeEnum.SETTINGS;
      var expextedValue = MyTagPocket.CoreUtil.DataTypeEnum.THEMES;

      if (testValue != expextedValue)
        return new ResultTest(true);
      else
        return new ResultTest(false, $"Objects not same. testValue=[{testValue}] expextedValue=[{expextedValue}]");
    }

    /// <summary>
    /// Test on enumeration convert to list
    /// </summary>
    /// <returns></returns>
    public ResultTest ObjectListTest()
    {
      var testValue = MyTagPocket.CoreUtil.DataTypeEnum.ToList();
      if (testValue == null || testValue.Count < 1)
        return new ResultTest(false, $"Objects not list teestValue=[{testValue}]");
      else
        return new ResultTest(true);
    }

    /// <summary>
    /// Test to find an object in a  list
    /// </summary>
    /// <returns></returns>
    public ResultTest ObjectSearchInList()
    {
      var testResult = MyTagPocket.CoreUtil.DataTypeEnum.ValueOf("SETTINGS");
      var testExpected = MyTagPocket.CoreUtil.DataTypeEnum.SETTINGS;
      if (testResult == testExpected)
        return new ResultTest(true);
      else
        return new ResultTest(false, $"Objects searched in list. testExpected=[{testExpected}] testResult=[{testResult}] ");
    }
  }
}
