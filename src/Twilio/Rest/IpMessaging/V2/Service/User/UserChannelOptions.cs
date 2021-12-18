/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.IpMessaging.V2.Service.User
{

  /// <summary>
  /// ReadUserChannelOptions
  /// </summary>
  public class ReadUserChannelOptions : ReadOptions<UserChannelResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The user_sid
    /// </summary>
    public string PathUserSid { get; }

    /// <summary>
    /// Construct a new ReadUserChannelOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathUserSid"> The user_sid </param>
    public ReadUserChannelOptions(string pathServiceSid, string pathUserSid)
    {
      PathServiceSid = pathServiceSid;
      PathUserSid = pathUserSid;
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
  /// FetchUserChannelOptions
  /// </summary>
  public class FetchUserChannelOptions : IOptions<UserChannelResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The user_sid
    /// </summary>
    public string PathUserSid { get; }
    /// <summary>
    /// The channel_sid
    /// </summary>
    public string PathChannelSid { get; }

    /// <summary>
    /// Construct a new FetchUserChannelOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathUserSid"> The user_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    public FetchUserChannelOptions(string pathServiceSid, string pathUserSid, string pathChannelSid)
    {
      PathServiceSid = pathServiceSid;
      PathUserSid = pathUserSid;
      PathChannelSid = pathChannelSid;
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
  /// DeleteUserChannelOptions
  /// </summary>
  public class DeleteUserChannelOptions : IOptions<UserChannelResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The user_sid
    /// </summary>
    public string PathUserSid { get; }
    /// <summary>
    /// The channel_sid
    /// </summary>
    public string PathChannelSid { get; }

    /// <summary>
    /// Construct a new DeleteUserChannelOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathUserSid"> The user_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    public DeleteUserChannelOptions(string pathServiceSid, string pathUserSid, string pathChannelSid)
    {
      PathServiceSid = pathServiceSid;
      PathUserSid = pathUserSid;
      PathChannelSid = pathChannelSid;
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
  /// UpdateUserChannelOptions
  /// </summary>
  public class UpdateUserChannelOptions : IOptions<UserChannelResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The user_sid
    /// </summary>
    public string PathUserSid { get; }
    /// <summary>
    /// The channel_sid
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The notification_level
    /// </summary>
    public UserChannelResource.NotificationLevelEnum NotificationLevel { get; set; }
    /// <summary>
    /// The last_consumed_message_index
    /// </summary>
    public int? LastConsumedMessageIndex { get; set; }
    /// <summary>
    /// The last_consumption_timestamp
    /// </summary>
    public DateTime? LastConsumptionTimestamp { get; set; }

    /// <summary>
    /// Construct a new UpdateUserChannelOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathUserSid"> The user_sid </param>
    /// <param name="pathChannelSid"> The channel_sid </param>
    public UpdateUserChannelOptions(string pathServiceSid, string pathUserSid, string pathChannelSid)
    {
      PathServiceSid = pathServiceSid;
      PathUserSid = pathUserSid;
      PathChannelSid = pathChannelSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (NotificationLevel != null)
      {
        p.Add(new KeyValuePair<string, string>("NotificationLevel", NotificationLevel.ToString()));
      }

      if (LastConsumedMessageIndex != null)
      {
        p.Add(new KeyValuePair<string, string>("LastConsumedMessageIndex", LastConsumedMessageIndex.ToString()));
      }

      if (LastConsumptionTimestamp != null)
      {
        p.Add(new KeyValuePair<string, string>("LastConsumptionTimestamp", Serializers.DateTimeIso8601(LastConsumptionTimestamp)));
      }

      return p;
    }
  }

}