/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Preview.BulkExports
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Fetch a specific Export Configuration.
  /// </summary>
  public class FetchExportConfigurationOptions : IOptions<ExportConfigurationResource>
  {
    /// <summary>
    /// The type of communication – Messages, Calls, Conferences, and Participants
    /// </summary>
    public string PathResourceType { get; }

    /// <summary>
    /// Construct a new FetchExportConfigurationOptions
    /// </summary>
    /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
    public FetchExportConfigurationOptions(string pathResourceType)
    {
      PathResourceType = pathResourceType;
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
  /// Update a specific Export Configuration.
  /// </summary>
  public class UpdateExportConfigurationOptions : IOptions<ExportConfigurationResource>
  {
    /// <summary>
    /// The type of communication – Messages, Calls, Conferences, and Participants
    /// </summary>
    public string PathResourceType { get; }
    /// <summary>
    /// Whether files are automatically generated
    /// </summary>
    public bool? Enabled { get; set; }
    /// <summary>
    /// URL targeted at export
    /// </summary>
    public Uri WebhookUrl { get; set; }
    /// <summary>
    /// Whether to GET or POST to the webhook url
    /// </summary>
    public string WebhookMethod { get; set; }

    /// <summary>
    /// Construct a new UpdateExportConfigurationOptions
    /// </summary>
    /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
    public UpdateExportConfigurationOptions(string pathResourceType)
    {
      PathResourceType = pathResourceType;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Enabled != null)
      {
        p.Add(new KeyValuePair<string, string>("Enabled", Enabled.Value.ToString().ToLower()));
      }

      if (WebhookUrl != null)
      {
        p.Add(new KeyValuePair<string, string>("WebhookUrl", Serializers.Url(WebhookUrl)));
      }

      if (WebhookMethod != null)
      {
        p.Add(new KeyValuePair<string, string>("WebhookMethod", WebhookMethod));
      }

      return p;
    }
  }

}