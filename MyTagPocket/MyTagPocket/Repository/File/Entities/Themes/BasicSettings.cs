using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Storage.Entities.Themes
{
  /// <summary>
  /// Basic properties theme settings 
  /// </summary>
  public class BasicSettings : FileEntityBase
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public BasicSettings () : base(CoreUtil.DataTypeEnum.SETTINGS)
    {}

    /// <summary>
    /// Default baground page color
    /// </summary>
    public string DefaultBackgroundPageColor { get; set; } = "#336699";

    /// <summary>
    /// Default error label text color
    /// </summary>
    public string ErrorLabelColor { get; set; } = "#A54440";
  }
}
