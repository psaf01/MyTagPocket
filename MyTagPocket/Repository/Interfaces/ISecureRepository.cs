using MyTagPocket.Repository.Secure;
using System.Threading.Tasks;

namespace MyTagPocket.Repository.Interfaces
{
  /// <summary>
  /// Interface Serure storage repository
  /// </summary>
  public interface ISecureRepository
  {
    /// <summary>
    /// Get value from secure storage
    /// </summary>
    /// <param name="item">Secure item</param>
    /// <returns>Value secure item</returns>
    Task<string> GetSecureValueAsync(SecureItemEnum item);

    /// <summary>
    /// Save value to secure storage
    /// </summary>
    /// <param name="item">Secure item</param>
    /// <param name="value">Value secure item</param>
    /// <returns></returns>
    Task SaveSecureValueAsync(SecureItemEnum item, string value);

    /// <summary>
    /// Delete item from secure storage
    /// </summary>
    /// <param name="item">Secure item</param>
    void DeleteSecureValue(SecureItemEnum item);

    /// <summary>
    /// Delete all items from secure storage
    /// </summary>
    void DeleteAllSecureValue();
  }
}
