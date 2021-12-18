/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow
{

  /// <summary>
  /// FetchWorkflowStatisticsOptions
  /// </summary>
  public class FetchWorkflowStatisticsOptions : IOptions<WorkflowStatisticsResource>
  {
    /// <summary>
    /// The SID of the Workspace with the Workflow to fetch
    /// </summary>
    public string PathWorkspaceSid { get; }
    /// <summary>
    /// Returns the list of Tasks that are being controlled by the Workflow with the specified SID value
    /// </summary>
    public string PathWorkflowSid { get; }
    /// <summary>
    /// Only calculate statistics since this many minutes in the past
    /// </summary>
    public int? Minutes { get; set; }
    /// <summary>
    /// Only calculate statistics from on or after this date
    /// </summary>
    public DateTime? StartDate { get; set; }
    /// <summary>
    /// Only calculate statistics from this date and time and earlier
    /// </summary>
    public DateTime? EndDate { get; set; }
    /// <summary>
    /// Only calculate real-time statistics on this TaskChannel.
    /// </summary>
    public string TaskChannel { get; set; }
    /// <summary>
    /// A comma separated list of values that describes the thresholds to calculate statistics on
    /// </summary>
    public string SplitByWaitTime { get; set; }

    /// <summary>
    /// Construct a new FetchWorkflowStatisticsOptions
    /// </summary>
    /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Workflow to fetch </param>
    /// <param name="pathWorkflowSid"> Returns the list of Tasks that are being controlled by the Workflow with the
    ///                       specified SID value </param>
    public FetchWorkflowStatisticsOptions(string pathWorkspaceSid, string pathWorkflowSid)
    {
      PathWorkspaceSid = pathWorkspaceSid;
      PathWorkflowSid = pathWorkflowSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Minutes != null)
      {
        p.Add(new KeyValuePair<string, string>("Minutes", Minutes.ToString()));
      }

      if (StartDate != null)
      {
        p.Add(new KeyValuePair<string, string>("StartDate", Serializers.DateTimeIso8601(StartDate)));
      }

      if (EndDate != null)
      {
        p.Add(new KeyValuePair<string, string>("EndDate", Serializers.DateTimeIso8601(EndDate)));
      }

      if (TaskChannel != null)
      {
        p.Add(new KeyValuePair<string, string>("TaskChannel", TaskChannel));
      }

      if (SplitByWaitTime != null)
      {
        p.Add(new KeyValuePair<string, string>("SplitByWaitTime", SplitByWaitTime));
      }

      return p;
    }
  }

}