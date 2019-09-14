using System;
using System.Collections.Generic;
using System.Linq; // for the .AsEnumerable() method call

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Enumerator base
  /// </summary>
  /// <typeparam name="N">Name enumerator</typeparam>
  /// <typeparam name="V">Value enumerator</typeparam>
  /// <typeparam name="L">Localized or extension</typeparam>
  public class EnumBase<E, N, V, L> where E : EnumBase<E, N, V, L>
  {
    /// <summary>
    /// Define process status enum
    /// </summary>
    /// <param name="N">Name enumerator</param>
    /// <param name="V">Value enumerator</param>
    /// <param name="L">Localized or extension</param>
    protected EnumBase(N name, V valueEnum, L localizedName)
    {
      this.Name = name;
      this.LocalizedName = localizedName;
      this.Value = valueEnum;
      //_List.Add(new EnumBase<E, N, V, L>())
    }

    private static List<E> _List { get; set; } = null;

    /// <summary>
    /// Name
    /// </summary>
    public readonly N Name;
    /// <summary>
    /// Value
    /// </summary>
    public readonly V Value;
    /// <summary>
    /// Localized name
    /// </summary>
    public readonly L LocalizedName;

   

    /// <summary>
    /// Convert enumerator to list
    /// </summary>
    /// <returns>List with enumerators</returns>
    public static List<E> ToList()
    {
      if (_List == null)
      {
        _List = typeof(E).GetFields().Where(x => x.IsStatic && x.IsPublic && x.FieldType == typeof(E))
            .Select(x => x.GetValue(null)).OfType<E>().ToList();
      }

      return _List;
    }

    /// <summary>
    /// Enumerator list
    /// </summary>
    /// <returns></returns>
    public static List<E> Values()
    {
      return ToList();
    }

    /// <summary>
    /// Returns the enum value based on the matching Name of the enum. Case-insensitive search.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static E ValueOf(string name)
    {
      return ToList().FirstOrDefault(x => string.Compare(x.Name.ToString(), name, true) == 0);
    }

    /// <summary>
    /// Base name type file name
    /// </summary>
    /// <returns></returns>
    public override String ToString()
    {
      return Name.ToString();
    }

    /// <summary>
    /// Compares based on the == method. Handles nulls gracefully.
    /// </summary>
    /// <param name="a">Object a</param>
    /// <param name="b">Object b</param>
    /// <returns></returns>
    public static bool operator !=(EnumBase<E, N, V, L> a, EnumBase<E, N, V, L> b)
    {
      return !(a?.ToString() == b?.ToString());
    }

    /// <summary>
    /// Compares based on the .Equals method. Handles nulls gracefully.
    /// </summary>
    /// <param name="a">Object a</param>
    /// <param name="b">Object b</param>
    /// <returns></returns>
    public static bool operator ==(EnumBase<E, N, V, L> a, EnumBase<E, N, V, L>  b)
    {
      return a?.ToString() == b?.ToString();
    }

    /// <summary>
    /// Compares based on the .ToString() method
    /// </summary>
    /// <param name="o">Compare object</param>
    /// <returns>True: same object</returns>
    public override bool Equals(object o)
    {
      return this.ToString() == o?.ToString();
    }

    /// <summary>
    /// Object hash code
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return string.Format("{0}_{1}", Name, Value).GetHashCode();
    }
  }
}