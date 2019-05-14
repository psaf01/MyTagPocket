using System.ComponentModel;

namespace MyTagPocket.CoreUtil.Interface
{

  /// <summary>
  /// Interface upgrade
  /// </summary>
  public interface IProcess : INotifyPropertyChanged
  {
    /// <summary>
    /// Process code for internal processing
    /// </summary>
    string ProcessCode { get; }

    /// <summary>
    /// Process name
    /// </summary>
    string ProcessName { get;}

    /// <summary>
    /// Process description
    /// </summary>
    string ProcessDescription { get;}

    /// <summary>
    /// if the process can start
    /// </summary>
    bool CanRunProcess { get; }

    /// <summary>
    /// Info about result upgrade process
    /// </summary>
    string ResultProcess { get; }

    /// <summary>
    /// Status process
    /// </summary>
    ProcessStatusEnum StatusProcess { get; }

    /// <summary>
    /// Gets or sets the value of the process for the progres bar.
    /// 1.0 = 100%
    /// </summary>
    double Progress { get; }

    /// <summary>
    /// Run process
    /// </summary>
    void Start();
  }
}
