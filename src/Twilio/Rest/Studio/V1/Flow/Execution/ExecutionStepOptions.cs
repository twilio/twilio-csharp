/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Studio.V1.Flow.Execution
{

  /// <summary>
  /// Retrieve a list of all Steps for an Execution.
  /// </summary>
  public class ReadExecutionStepOptions : ReadOptions<ExecutionStepResource>
  {
    /// <summary>
    /// The SID of the Flow
    /// </summary>
    public string PathFlowSid { get; }
    /// <summary>
    /// The SID of the Execution
    /// </summary>
    public string PathExecutionSid { get; }

    /// <summary>
    /// Construct a new ReadExecutionStepOptions
    /// </summary>
    /// <param name="pathFlowSid"> The SID of the Flow </param>
    /// <param name="pathExecutionSid"> The SID of the Execution </param>
    public ReadExecutionStepOptions(string pathFlowSid, string pathExecutionSid)
    {
      PathFlowSid = pathFlowSid;
      PathExecutionSid = pathExecutionSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public override List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// Retrieve a Step.
  /// </summary>
  public class FetchExecutionStepOptions : IOptions<ExecutionStepResource>
  {
    /// <summary>
    /// The SID of the Flow
    /// </summary>
    public string PathFlowSid { get; }
    /// <summary>
    /// The SID of the Execution
    /// </summary>
    public string PathExecutionSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchExecutionStepOptions
    /// </summary>
    /// <param name="pathFlowSid"> The SID of the Flow </param>
    /// <param name="pathExecutionSid"> The SID of the Execution </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public FetchExecutionStepOptions(string pathFlowSid, string pathExecutionSid, string pathSid)
    {
      PathFlowSid = pathFlowSid;
      PathExecutionSid = pathExecutionSid;
      PathSid = pathSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      return p;
    }
  }

}