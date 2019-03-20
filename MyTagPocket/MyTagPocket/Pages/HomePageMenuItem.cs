using System;

namespace MyTagPocket.Pages
{

  /// <summary>
  /// Menu item
  /// </summary>
  public class HomePageMenuItem
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public HomePageMenuItem()
    {
      TargetType = typeof(HomePageDetail);
    }

    /// <summary>
    /// ID menu 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title menu
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Target type
    /// </summary>
    public Type TargetType { get; set; }
  }
}