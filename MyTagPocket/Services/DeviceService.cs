using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Models.Devices;
using MyTagPocket.Repository.Audit;
using MyTagPocket.Repository.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyTagPocket.Services
{
  /// <summary>
  /// Device management Service
  /// </summary>
  public class DeviceService
  {
    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10032";

    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// File repository
    /// </summary>
    public static IFileRepository fileRepo;

    /// <summary>
    /// Dal repository
    /// </summary>
    public static IDalRepository dalRepo;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fileRepository">File repository</param>
    public DeviceService(ILogManager logManager, IFileRepository fileRepository, IDalRepository dalRepository)
    {
      Log = logManager.GetLog(classCode);
      fileRepo = fileRepository;
      dalRepo = dalRepository;
    }

    /// <summary>
    /// Create new local device. Initialize device
    /// </summary>
    /// <param name="deviceType">The type of device on which the new record is created</param>
    /// <returns>New device definition</returns>
    public async Task<Device> CreateDevice(DeviceTypeEnum deviceType)
    {
      const string methodCode = "M01";

      Device device = new Device();
      device.DeviceId = ShortGuid.NewGuid().Value;
      device.Name = $"{deviceType.LocalizedName}";
      device.FolderId = Guid.NewGuid().ToString("N");
      device.CreatedWhen = DateTimeOffset.Now;

      Log.Trace(methodCode, "Create Device {@DeviceType}", deviceType.LocalizedName);
      await dalRepo.SaveAsync(device);
      await Log.AuditAsync(AuditCodes.CreateDevice, DataTypeEnum.Device, device.DeviceId, SystemEntityGuidConst.UserSystem);

      /*
      if(string.IsNullOrEmpty(app.ActualFoderDevices))
        app.ActualFoderDevices = Guid.NewGuid().ToString("N");
      
      device.FolderId = app.ActualFoderDevices;
      device.CreatedWhen = DateTimeOffset.Now;
      device.UpdatedWhen = device.CreatedWhen;
      return device; 
      */
      return null;
    }
  }
}
