namespace MyTagPocket.Test
{
  /// <summary>
  /// Result test
  /// </summary>
  public class ResultTest
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public ResultTest()
    {
      Result = false;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="result">Result finish test</param>
    public ResultTest(bool result)
    {
      Result = result;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="result">Result finish test</param>
    /// <param name="message">Description of the test result</param>
    public ResultTest(bool result, string message)
    {
      Result = result;
      Message = message;
    }

    /// <summary>
    /// Result finisch test.
    /// </summary>
    public bool Result { get; set; }

    /// <summary>
    /// Description of the test result
    /// </summary>
    public string Message { get; set; }
  }
}
