using MyTagPocket.CoreUtil.Exceptions;
using MyTagPocket.CoreUtil.Interfaces;
using MyTagPocket.Repository.Interfaces;
using MyTagPocket.Repository.Secure;
using MyTagPocket.Resources;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// Secure storage repository
  /// </summary>
  public class SecureRepository : ISecureRepository
  {
    /// <summary>
    /// Identifikation class for localization code
    /// <see cref="_ClassCodeLast.cs"/>
    /// </summary>
    const string classCode = "C10031";
    /// <summary>
    /// Logger instance
    /// </summary>
    public static ILogger Log;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logManager">Log manager</param>
    /// <param name="fileHelper">File helper</param>
    public SecureRepository(ILogManager logManager)
    {
      Log = logManager.GetLog(classCode);
    }

    /// <summary>
    /// Get value from secure storage
    /// </summary>
    /// <param name="item">Secure item</param>
    /// <returns>Value secure item</returns>
    public async Task<string> GetSecureValueAsync(SecureItemEnum item)
    {
      const string methodCode = "M01";
      try
      {
        Log.Trace(methodCode, "Read secure item={@SecureItem} from secure storage.", item.LocalizedName);
        return await SecureStorage.GetAsync(item.Name);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Cant read secure item={@SecureItem} from secure storage.", item.LocalizedName);
        throw new ErrorException(ResourceApp.ErrorCantReadSecure);
      }
    }

    /// <summary>
    /// Save value to secure storage
    /// </summary>
    /// <param name="item">Secure item</param>
    /// <param name="value">Value secure item</param>
    /// <returns></returns>
    public async Task SaveSecureValueAsync(SecureItemEnum item, string value)
    {
      const string methodCode = "M02";
      try
      {
        Log.Trace(methodCode, "Save secure item={@SecureItem} to secure storage.", item.LocalizedName);
        await SecureStorage.SetAsync(item.Name, value);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Cant read secure item={@SecureItem} from secure storage.", item.LocalizedName);
        var str = ResourceApp.ErrorCantSaveSecure;
        throw new ErrorException(ResourceApp.ErrorCantSaveSecure);
      }
    }

    /// <summary>
    /// Delete item from secure storage
    /// </summary>
    /// <param name="item">Secure item</param>
    public void DeleteSecureValue(SecureItemEnum item)
    {
      const string methodCode = "M03";
      try
      {
        Log.Trace(methodCode, "Delete secure item={@SecureItem} from secure storage.", item.LocalizedName);
        SecureStorage.Remove(item.Name);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Cant delete secure item={@SecureItem} from secure storage.", item.LocalizedName);
        throw new ErrorException(ResourceApp.ErrorDeleteItemSecure);
      }
    }

    /// <summary>
    /// Delete all items from secure storage
    /// </summary>
    public void DeleteAllSecureValue()
    {
      const string methodCode = "M04";
      try
      {
        Log.Trace(methodCode, "Delete secure items from secure storage.");
        SecureStorage.RemoveAll();
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, "Cant delete secure items from secure storage.");
        throw new ErrorException(ResourceApp.ErrorDeleteAllItemSecure);
      }
    }
  }
}
