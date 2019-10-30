using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository;
using MyTagPocket.UWP.Library.CoreUtil;
using MyTagPocket.UWP.Test.Mocks;
using Unity;
using Xamarin.Forms;
using Xunit;
using static MyTagPocket.UWP.TEST.Xamarin.Forms.Mocks.MockForms;
using MyTagPocket.Repository.File.DiffMatchPatch;

namespace MyTagPocket.UWP.TEST.Repository.File
{
  /// <summary>
  /// Test diff match patch
  /// </summary>
  public class DiffMatchPatchTest
  {
    [Fact]
    public void Diff()
    {
      var t1 = "ahoj jedna";
      var t2 = "ahoj jedna dva";
      var t3 = "ahoj tri dva";

      var dmp = new diff_match_patch();
      var patchT2toT1 = dmp.patch_make(t2, t1);
      var patchT2toT1text = dmp.patch_toText(patchT2toT1);//persist
      var patchT3toT2 = dmp.patch_make(t3, t2);
      var patchT3toT2text = dmp.patch_toText(patchT3toT2);//persist

      //restore
      var altT3ToT2Patch = dmp.patch_fromText(patchT3toT2text);
      var altT2 = dmp.patch_apply(altT3ToT2Patch, t3)[0].ToString(); // .get(0) in Java I think           
      Assert.Equal(t2, altT2);

      var altT2ToT1Patch = dmp.patch_fromText(patchT2toT1text);
      var altT1 = dmp.patch_apply(altT2ToT1Patch, altT2)[0].ToString();
      Assert.Equal(t1, altT1);

      var dif = dmp.diff_main(t1, t2);
      var difhtml = dmp.diff_prettyHtml(dif);
      var diftext = dmp.diff_text2(dif);
    }
  }
}
