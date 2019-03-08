using MyTagPocket.Storage.Entities.Themes;

namespace MyTagPocket.Storage.Repository.Interface
{
  /// <summary>
  /// Interface theme repository
  /// </summary>
  public interface IThemeRepository
  {
    /// <summary>
    /// Save theme
    /// </summary>
    /// <param name="theme"></param>
    bool Save(Theme theme);

    bool Load(Theme theme);
  }
}
