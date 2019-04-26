using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTagPocket.CoreUtil
{
  /// <summary>
  /// Process staus enumerator
  /// </summary>
  public sealed class ProcessStatusEnum
  {
    #region This code never needs to change.
    private static List<ProcessStatusEnum> _List { get; set; } = null;

    public readonly string Name;
    /// <summary>
    /// Process status value
    /// </summary>
    public readonly ProcessStatus Value;
    /// <summary>
    /// Localized name
    /// </summary>
    public readonly string LocalizedName;

    /// <summary>
    /// Define process status enum
    /// </summary>
    /// <param name="ProcessStatus">Type process status enum</param>
    /// <param name="name">Process name</param>
    /// <param name="localizedName">Localized process name </param>
    private ProcessStatusEnum(ProcessStatus ProcessStatus, String name, String localizedName)
    {
      this.Name = name;
      this.Value = ProcessStatus;
      this.LocalizedName= localizedName;
    }

    /// <summary>
    /// Convert Process status to list
    /// </summary>
    /// <returns></returns>
    public static List<ProcessStatusEnum> ToList()
    {
      if (_List == null)
      {
        _List = typeof(ProcessStatusEnum).GetFields().Where(x => x.IsStatic && x.IsPublic && x.FieldType == typeof(ProcessStatusEnum))
            .Select(x => x.GetValue(null)).OfType<ProcessStatusEnum>().ToList();
      }

      return _List;
    }

    /// <summary>
    /// Process status list
    /// </summary>
    /// <returns></returns>
    public static List<ProcessStatusEnum> Values()
    {
      return ToList();
    }

    /// <summary>
    /// Returns the enum value based on the matching Name of the enum. Case-insensitive search.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static ProcessStatusEnum ValueOf(string name)
    {
      return ToList().FirstOrDefault(x => string.Compare(x.Name, name, true) == 0);
    }

    /// <summary>
    /// Base name type file name
    /// </summary>
    /// <returns></returns>
    public override String ToString()
    {
      return Name;
    }

    /// <summary>
    /// Equals obejct
    /// </summary>
    /// <param name="obj">Check object</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
        return false;

      ProcessStatusEnum fooItem = obj as ProcessStatusEnum;

      return fooItem.Value == this.Value;
    }

    /// <summary>
    /// Object hash code
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return string.Format("{0}_{1}", Name, Value).GetHashCode();
    }

    public static bool operator ==(ProcessStatusEnum a, ProcessStatusEnum b)
    {
      return a.Value == b.Value;
    }
    public static bool operator !=(ProcessStatusEnum a, ProcessStatusEnum b)
    {
      return a.Value != b.Value;
    }
    #endregion

    /// <summary>
    /// Status process
    /// </summary>
    public enum ProcessStatus
    {
      Idle,
      Runnig,
      Error,
      Paused,
    }
  }
}
