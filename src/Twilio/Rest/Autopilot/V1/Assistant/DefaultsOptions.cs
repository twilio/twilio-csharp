/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Autopilot.V1.Assistant
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// FetchDefaultsOptions
  /// </summary>
  public class FetchDefaultsOptions : IOptions<DefaultsResource>
  {
    /// <summary>
    /// The SID of the Assistant that is the parent of the resource to fetch
    /// </summary>
    public string PathAssistantSid { get; }

    /// <summary>
    /// Construct a new FetchDefaultsOptions
    /// </summary>
    /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the resource to fetch </param>
    public FetchDefaultsOptions(string pathAssistantSid)
    {
      PathAssistantSid = pathAssistantSid;
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
  /// UpdateDefaultsOptions
  /// </summary>
  public class UpdateDefaultsOptions : IOptions<DefaultsResource>
  {
    /// <summary>
    /// The SID of the Assistant that is the parent of the resource to update
    /// </summary>
    public string PathAssistantSid { get; }
    /// <summary>
    /// A JSON string that describes the default task links.
    /// </summary>
    public object Defaults { get; set; }

    /// <summary>
    /// Construct a new UpdateDefaultsOptions
    /// </summary>
    /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the resource to update </param>
    public UpdateDefaultsOptions(string pathAssistantSid)
    {
      PathAssistantSid = pathAssistantSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Defaults != null)
      {
        p.Add(new KeyValuePair<string, string>("Defaults", Serializers.JsonObject(Defaults)));
      }

      return p;
    }
  }

}