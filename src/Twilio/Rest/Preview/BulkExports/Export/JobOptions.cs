/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Preview.BulkExports.Export
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// FetchJobOptions
  /// </summary>
  public class FetchJobOptions : IOptions<JobResource>
  {
    /// <summary>
    /// The unique string that that we created to identify the Bulk Export job
    /// </summary>
    public string PathJobSid { get; }

    /// <summary>
    /// Construct a new FetchJobOptions
    /// </summary>
    /// <param name="pathJobSid"> The unique string that that we created to identify the Bulk Export job </param>
    public FetchJobOptions(string pathJobSid)
    {
      PathJobSid = pathJobSid;
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

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// DeleteJobOptions
  /// </summary>
  public class DeleteJobOptions : IOptions<JobResource>
  {
    /// <summary>
    /// The unique string that that we created to identify the Bulk Export job
    /// </summary>
    public string PathJobSid { get; }

    /// <summary>
    /// Construct a new DeleteJobOptions
    /// </summary>
    /// <param name="pathJobSid"> The unique string that that we created to identify the Bulk Export job </param>
    public DeleteJobOptions(string pathJobSid)
    {
      PathJobSid = pathJobSid;
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