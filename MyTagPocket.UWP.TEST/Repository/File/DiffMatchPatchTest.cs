using MyTagPocket.Repository.Files.DiffMatchPatch;
using System.Collections.Generic;
using Xunit;

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
      List<string> patches = new List<string>();
      patches.Add(patchT2toT1text);
      var patchT3toT2 = dmp.patch_make(t3, t2);
      var patchT3toT2text = dmp.patch_toText(patchT3toT2);//persist
      patches.Add(patchT3toT2text);

      //restore
      var altT3ToT2Patch = dmp.patch_fromText(patchT3toT2text);
      var altT2 = dmp.patch_apply(altT3ToT2Patch, t3)[0].ToString();
      Assert.Equal(t2, altT2);

      var altT2ToT1Patch = dmp.patch_fromText(patchT2toT1text);
      var altT1 = dmp.patch_apply(altT2ToT1Patch, altT2)[0].ToString();
      Assert.Equal(t1, altT1);

      string restore = (string)t3.Clone();
      for (int i = patches.Count - 1; i >= 0; i--)
      {
        var restorePatch = dmp.patch_fromText(patches[i]);
        restore = dmp.patch_apply(restorePatch, restore)[0].ToString();
      }
      Assert.Equal(t1, restore);

    }
  }
}
