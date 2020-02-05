using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MyTagPocket.Repository
{
  class ResourceRepository
  {
    public void Test()
    {
      var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ResourceRepository)).Assembly;
      Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.LibTextResource.txt");
      string text = "";
      using (var reader = new System.IO.StreamReader(stream))
      {
        text = reader.ReadToEnd();
      }
    }
  }
}
