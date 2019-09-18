using MyTagPocket.CoreUtil.Interface;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;

namespace MyTagPocket.ViewModels.Contents
{
  public class Test
  {
    public string InfoA { get; set; }
    public int CisloB { get; set; }

    public Array PoleC { get; set; }
    public long CisloD { get; set; }
    public decimal CisloE { get; set; }
    public DateTime DatumF { get; set; }
    public double CisloG { get; set; }
    public float CisloH { get; set; }
    public List<Polozka> Polozky { get; set; }
  }
  public class Polozka
  {
    public int PoradiA { get; set; }
    public string Hodnota { get; set; }
  }
  public class ContentListPageViewModel : BaseViewModel
  {
    /// <summary>
    /// Class code
    /// </summary>
    private const string ClassCode = "C10030";

    /// <summary>
    /// Navigation service
    /// </summary>
    INavigationService _navigationService;

    /// <summary>
    /// If navigate on other pages
    /// </summary>
    bool _canNavigate;

    public ContentListPageViewModel(INavigationService navigationService, ILogManager logManager) : base(logManager, ClassCode)
    {
      const string METHODCODE = ClassCode + "M01";
      Log.Trace(METHODCODE, $"Init");
      var testA = "testvalue";
      var testB = 100;
      Log.Debug(METHODCODE, $"Log Debug testA=[{testA}] testB=[{testB}]", testA, testB);

      var t = new Test();
      t.InfoA = "ěščřžýáíéĚÉÁŽÝŘŠŤúůÚňŇČ";
      t.CisloB = 100;
      t.CisloD = 222222;
      t.CisloE = 33.33m;
      t.CisloG = 44.44;
      t.CisloH = 55.66f;
      t.DatumF = DateTime.Now.AddDays(5);
      var polozka1 = new Polozka() { Hodnota = "ahoj to jsem ja", PoradiA = 1 };
      var polozka2 = new Polozka() { Hodnota = "to jde ne řeřicho", PoradiA = 2};
      var polozka3 = new Polozka() { Hodnota = "šach mat žežulo", PoradiA = 3 };
      t.Polozky = new List<Polozka>();
      t.Polozky.Add(polozka1);
      t.Polozky.Add(polozka2);
      t.Polozky.Add(polozka3);
      Log.Info(METHODCODE, "Info 33 TestObject={@t}", t);
      Log.Info(METHODCODE, "Info 45 testB={@testB}", testB);

      Log.Trace("Log Trace testA={@testA} testB={testB}", testA, testB);
      Log.Error("Log Error testA={testA} testB={testB}", testA, testB);

      _navigationService = navigationService;
      _canNavigate = false;
    }

    /// <summary>
    /// whether it is possible to navigate to other pages
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns>True - can navigate</returns>
    public bool CanNavigate(INavigationParameters parameters)
    {
      return _canNavigate;
    }
  }
}
