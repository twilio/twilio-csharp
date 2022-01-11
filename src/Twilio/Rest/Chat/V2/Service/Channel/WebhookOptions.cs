/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Chat.V2.Service.Channel
{

  /// <summary>
  /// ReadWebhookOptions
  /// </summary>
  public class ReadWebhookOptions : ReadOptions<WebhookResource>
  {
    /// <summary>
    /// The SID of the Service to read the resources from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the Channel the resources to read belong to
    /// </summary>
    public string PathChannelSid { get; }

    /// <summary>
    /// Construct a new ReadWebhookOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to read the resources from </param>
    /// <param name="pathChannelSid"> The SID of the Channel the resources to read belong to </param>
    public ReadWebhookOptions(string pathServiceSid, string pathChannelSid)
    {
      PathServiceSid = pathServiceSid;
      PathChannelSid = pathChannelSid;
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
  /// FetchWebhookOptions
  /// </summary>
  public class FetchWebhookOptions : IOptions<WebhookResource>
  {
    /// <summary>
    /// The SID of the Service with the Channel to fetch the Webhook resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the Channel the resource to fetch belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The SID of the Channel Webhook resource to fetch
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchWebhookOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service with the Channel to fetch the Webhook resource from </param>
    /// <param name="pathChannelSid"> The SID of the Channel the resource to fetch belongs to </param>
    /// <param name="pathSid"> The SID of the Channel Webhook resource to fetch </param>
    public FetchWebhookOptions(string pathServiceSid, string pathChannelSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathChannelSid = pathChannelSid;
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

  /// <summary>
  /// CreateWebhookOptions
  /// </summary>
  public class CreateWebhookOptions : IOptions<WebhookResource>
  {
    /// <summary>
    /// The SID of the Service with the Channel to create the resource under
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the Channel the new resource belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The type of webhook
    /// </summary>
    public WebhookResource.TypeEnum Type { get; }
    /// <summary>
    /// The URL of the webhook to call
    /// </summary>
    public string ConfigurationUrl { get; set; }
    /// <summary>
    /// The HTTP method used to call `configuration.url`
    /// </summary>
    public WebhookResource.MethodEnum ConfigurationMethod { get; set; }
    /// <summary>
    /// The events that cause us to call the Channel Webhook
    /// </summary>
    public List<string> ConfigurationFilters { get; set; }
    /// <summary>
    /// A string that will cause us to call the webhook when it is found in a message body
    /// </summary>
    public List<string> ConfigurationTriggers { get; set; }
    /// <summary>
    /// The SID of the Studio Flow to call when an event occurs
    /// </summary>
    public string ConfigurationFlowSid { get; set; }
    /// <summary>
    /// The number of times to retry the webhook if the first attempt fails
    /// </summary>
    public int? ConfigurationRetryCount { get; set; }

    /// <summary>
    /// Construct a new CreateWebhookOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service with the Channel to create the resource under </param>
    /// <param name="pathChannelSid"> The SID of the Channel the new resource belongs to </param>
    /// <param name="type"> The type of webhook </param>
    public CreateWebhookOptions(string pathServiceSid, string pathChannelSid, WebhookResource.TypeEnum type)
    {
      PathServiceSid = pathServiceSid;
      PathChannelSid = pathChannelSid;
      Type = type;
      ConfigurationFilters = new List<string>();
      ConfigurationTriggers = new List<string>();
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Type != null)
      {
        p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
      }

      if (ConfigurationUrl != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.Url", ConfigurationUrl));
      }

      if (ConfigurationMethod != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.Method", ConfigurationMethod.ToString()));
      }

      if (ConfigurationFilters != null)
      {
        p.AddRange(ConfigurationFilters.Select(prop => new KeyValuePair<string, string>("Configuration.Filters", prop)));
      }

      if (ConfigurationTriggers != null)
      {
        p.AddRange(ConfigurationTriggers.Select(prop => new KeyValuePair<string, string>("Configuration.Triggers", prop)));
      }

      if (ConfigurationFlowSid != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.FlowSid", ConfigurationFlowSid.ToString()));
      }

      if (ConfigurationRetryCount != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.RetryCount", ConfigurationRetryCount.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// UpdateWebhookOptions
  /// </summary>
  public class UpdateWebhookOptions : IOptions<WebhookResource>
  {
    /// <summary>
    /// The SID of the Service with the Channel that has the Webhook resource to update
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the Channel the resource to update belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The SID of the resource
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// The URL of the webhook to call
    /// </summary>
    public string ConfigurationUrl { get; set; }
    /// <summary>
    /// The HTTP method used to call `configuration.url`
    /// </summary>
    public WebhookResource.MethodEnum ConfigurationMethod { get; set; }
    /// <summary>
    /// The events that cause us to call the Channel Webhook
    /// </summary>
    public List<string> ConfigurationFilters { get; set; }
    /// <summary>
    /// A string that will cause us to call the webhook when it is found in a message body
    /// </summary>
    public List<string> ConfigurationTriggers { get; set; }
    /// <summary>
    /// The SID of the Studio Flow to call when an event occurs
    /// </summary>
    public string ConfigurationFlowSid { get; set; }
    /// <summary>
    /// The number of times to retry the webhook if the first attempt fails
    /// </summary>
    public int? ConfigurationRetryCount { get; set; }

    /// <summary>
    /// Construct a new UpdateWebhookOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service with the Channel that has the Webhook resource to update
    ///                      </param>
    /// <param name="pathChannelSid"> The SID of the Channel the resource to update belongs to </param>
    /// <param name="pathSid"> The SID of the resource </param>
    public UpdateWebhookOptions(string pathServiceSid, string pathChannelSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathChannelSid = pathChannelSid;
      PathSid = pathSid;
      ConfigurationFilters = new List<string>();
      ConfigurationTriggers = new List<string>();
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (ConfigurationUrl != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.Url", ConfigurationUrl));
      }

      if (ConfigurationMethod != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.Method", ConfigurationMethod.ToString()));
      }

      if (ConfigurationFilters != null)
      {
        p.AddRange(ConfigurationFilters.Select(prop => new KeyValuePair<string, string>("Configuration.Filters", prop)));
      }

      if (ConfigurationTriggers != null)
      {
        p.AddRange(ConfigurationTriggers.Select(prop => new KeyValuePair<string, string>("Configuration.Triggers", prop)));
      }

      if (ConfigurationFlowSid != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.FlowSid", ConfigurationFlowSid.ToString()));
      }

      if (ConfigurationRetryCount != null)
      {
        p.Add(new KeyValuePair<string, string>("Configuration.RetryCount", ConfigurationRetryCount.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// DeleteWebhookOptions
  /// </summary>
  public class DeleteWebhookOptions : IOptions<WebhookResource>
  {
    /// <summary>
    /// The SID of the Service with the Channel to delete the Webhook resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the channel the resource to delete belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The SID of the Channel Webhook resource to delete
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteWebhookOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service with the Channel to delete the Webhook resource from </param>
    /// <param name="pathChannelSid"> The SID of the channel the resource to delete belongs to </param>
    /// <param name="pathSid"> The SID of the Channel Webhook resource to delete </param>
    public DeleteWebhookOptions(string pathServiceSid, string pathChannelSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathChannelSid = pathChannelSid;
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