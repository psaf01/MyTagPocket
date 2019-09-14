using System;
using System.Globalization;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Extension for object DateTime
  /// </summary>
  public static class DateTimeExtension
  {
    private const string DATEFORMAT = "yyyyMMddHHmmssff";
    /// <summary>
    /// Convert date time to standard text
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ConvertToText(this DateTime obj)
    {
      return obj.ToString(DATEFORMAT);
    }

    /// <summary>
    /// Convert standar text [yyyyMMddHHmmssff] to DateTime
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static DateTime ConvertToDateTime(this string obj)
    {
      if (obj == null || obj.Length != 16)
        throw new Exception("Corupt convert string to date time");
      return DateTime.ParseExact(obj, DATEFORMAT, CultureInfo.InvariantCulture);
    }
  }
}
