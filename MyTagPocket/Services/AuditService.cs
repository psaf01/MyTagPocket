using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Interfaces;

namespace MyTagPocket.Services
{
  /// <summary>
  /// Application audit log management service 
  /// </summary>
  public class AuditService
  {
    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10033";

    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// File repository
    /// </summary>
    public static IFileRepository fileRepo;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fileRepository">File repository</param>
    public AuditService(ILogManager logManager, IFileRepository fileRepository)
    {
      Log = logManager.GetLog(classCode);
      fileRepo = fileRepository;
    }
  }
}
