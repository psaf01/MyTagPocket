using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTagPocket.Storage.Upgrade;

namespace MyTagPocket.UWP.TEST
{
  [TestClass]
  public class UpgradeStorageSettingsTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      var testStorage = new UpgradeStorageSettings();
      testStorage.CheckAndUpgrade();
    }
  }
}
