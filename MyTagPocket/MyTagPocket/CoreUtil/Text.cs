using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Operation with strings
  /// </summary>
  public static class Text
  {
    const string classCode = "[1001700]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);

    /// <summary>
    /// Convert string to Ascii text
    /// </summary>
    /// <param name="text">Input string</param>
    /// <returns>Ascii text</returns>
    public static string ConvertAscii(string text)
    {
      return ConvertAsciiFilenName(text, 0);
    }

    /// <summary>
    /// Convert string to Ascii text for filename
    /// </summary>
    /// <param name="text">Input string</param>
    /// <param name="length">How long should the text be returned. 0 = The text will not be truncated</param>
    /// <returns>Ascii text</returns>
    public static string ConvertAsciiFilenName(string text, int length)
    {
      const string methodCode = "[1001701]";

      string str = text;
      bool is_find = false;
      char ch;
      int ich = 0;
      try
      {
        char[] schar = str.ToCharArray();
        for (int i = 0; i < schar.Length; i++)
        {
          ch = schar[i];
          ich = (int)ch;

          if (ich== 32 || ich > 127) // not ascii or extended ascii, or SPACE
          {
            is_find = true;
            schar[i] = '_';
          }
        }
        if (is_find)
          str = new string(schar);

        if (length < 1)
          return str;
        return str.Substring(0, length);

      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, $"Convert text [{text}] length [{length}]");
        return string.Empty;
      }
    }
  }
}
