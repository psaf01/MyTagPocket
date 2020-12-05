namespace MyTagPocket.Repository.Audit
{
  /// <summary>
  /// Codes for audit log
  /// </summary>
  public static class AuditCodes
  {
    #region Audit
    /// <summary>
    /// Initialize audit databaze
    /// </summary>
    public static readonly string InitAuditDb = "iadb";
    public static readonly string InitAuditDb_year = "y";
    public static readonly string InitAuditDb_month = "m";
    #endregion Audit

    #region Device
    public static readonly string CreateDevice = "dccr";
    public static readonly string CreateDevice_user = "u";
    #endregion Device
  }
}
