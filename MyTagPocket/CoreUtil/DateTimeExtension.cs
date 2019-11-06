using System;
using System.Globalization;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Extension for object DateTime
  /// </summary>
  public static class DateTimeExtension
  {
    private const string dateFormat = "yyyyMMddHHmmssff";
    private const string dateFormatOffset = "yyyyMMddHHmmssffzzz";
    /// <summary>
    /// Convert date time to standard text
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ConvertToText(this DateTime obj)
    {
      return obj.ToString(dateFormat);
    }

    /// <summary>
    /// Convert date time to standard text
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ConvertToText(this DateTimeOffset obj)
    {
      return obj.ToString(dateFormatOffset);
    }

    /// <summary>
    /// Convert standar text [yyyyMMddHHmmssff] to DateTime
    /// </summary>
    /// <param name="obj">DateTime string</param>
    /// <returns></returns>
    public static DateTime ConvertToDateTime(this string obj)
    {
      if (obj == null || obj.Length != 16)
        throw new Exception("Corupt convert string to date time");
      return DateTime.ParseExact(obj, dateFormat, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Convert standar text [yyyyMMddHHmmssffzzz] to DateTime
    /// </summary>
    /// <param name="obj">DataTimeOffset string</param>
    /// <returns></returns>
    public static DateTimeOffset ConvertToDateTimeOffset(this string obj)
    {
      if (obj == null || obj.Length != 19)
        throw new Exception("Corupt convert string to date time offset");
      return DateTimeOffset.ParseExact(obj, dateFormatOffset, CultureInfo.InvariantCulture);
    }
  }
}
