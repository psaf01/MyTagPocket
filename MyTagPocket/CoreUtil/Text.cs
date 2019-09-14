using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Operation with strings
  /// </summary>
  public static class Text
  {
    const string classCode = "[1001700]";
    public static Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<Interface.ILogManager>().GetLog(classCode);

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

          if (ich == 32 || ich > 127) // not ascii or extended ascii, or SPACE
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

    /// <summary>
    /// Compresses the specified string a byte array using the specified
    /// encoding.
    /// </summary>
    /// <param name="stringToCompress">The string to compress.</param>
    /// <param name="encoding">The encoding.</param>
    /// <returns>bytes array with compressed string</returns>
    public static byte[] Compress(string stringToCompress, Encoding encoding)
    {
      var stringAsBytes = encoding.GetBytes(stringToCompress);
      using (var memoryStream = new MemoryStream())
      {
        //using (var zipStream = new GZipStream(memoryStream, CompressionMode.Compress))
        using (var zipStream = new DeflateStream(memoryStream, CompressionMode.Compress))
        {
          zipStream.Write(stringAsBytes, 0, stringAsBytes.Length);
          zipStream.Close();
          return (memoryStream.ToArray());
        }
      }
    }

    /// <summary>
    /// Decompress an array of bytes to a string using the specified
    /// encoding
    /// </summary>
    /// <param name="compressedString">The compressed string.</param>
    /// <param name="encoding">The encoding.</param>
    /// <returns>Decompressed string</returns>
    public static string DecompressToString(byte[] compressedString, Encoding encoding)
    {
      const int bufferSize = 1024;
      using (var memoryStream = new MemoryStream(compressedString))
      {
        //using (var zipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
        using (var zipStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
        {
          // Memory stream for storing the decompressed bytes
          using (var outStream = new MemoryStream())
          {
            var buffer = new byte[bufferSize];
            var totalBytes = 0;
            int readBytes;
            while ((readBytes = zipStream.Read(buffer, 0, bufferSize)) > 0)
            {
              outStream.Write(buffer, 0, readBytes);
              totalBytes += readBytes;
            }
            return encoding.GetString(
             outStream.GetBuffer(), 0, totalBytes);
          }
        }
      }
    }
  }
}
