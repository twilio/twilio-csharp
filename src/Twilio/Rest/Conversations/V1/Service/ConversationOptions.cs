/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Conversations.V1.Service
{

  /// <summary>
  /// Create a new conversation in your service
  /// </summary>
  public class CreateConversationOptions : IOptions<ConversationResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }
    /// <summary>
    /// The human-readable name of this conversation.
    /// </summary>
    public string FriendlyName { get; set; }
    /// <summary>
    /// An application-defined string that uniquely identifies the resource
    /// </summary>
    public string UniqueName { get; set; }
    /// <summary>
    /// An optional string metadata field you can use to store any data you wish.
    /// </summary>
    public string Attributes { get; set; }
    /// <summary>
    /// The unique ID of the Messaging Service this conversation belongs to.
    /// </summary>
    public string MessagingServiceSid { get; set; }
    /// <summary>
    /// The date that this resource was created.
    /// </summary>
    public DateTime? DateCreated { get; set; }
    /// <summary>
    /// The date that this resource was last updated.
    /// </summary>
    public DateTime? DateUpdated { get; set; }
    /// <summary>
    /// Current state of this conversation.
    /// </summary>
    public ConversationResource.StateEnum State { get; set; }
    /// <summary>
    /// ISO8601 duration when conversation will be switched to `inactive` state.
    /// </summary>
    public string TimersInactive { get; set; }
    /// <summary>
    /// ISO8601 duration when conversation will be switched to `closed` state.
    /// </summary>
    public string TimersClosed { get; set; }
    /// <summary>
    /// The X-Twilio-Webhook-Enabled HTTP request header
    /// </summary>
    public ConversationResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

    /// <summary>
    /// Construct a new CreateConversationOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    public CreateConversationOptions(string pathChatServiceSid)
    {
      PathChatServiceSid = pathChatServiceSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (FriendlyName != null)
      {
        p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
      }

      if (UniqueName != null)
      {
        p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
      }

      if (Attributes != null)
      {
        p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
      }

      if (MessagingServiceSid != null)
      {
        p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid.ToString()));
      }

      if (DateCreated != null)
      {
        p.Add(new KeyValuePair<string, string>("DateCreated", Serializers.DateTimeIso8601(DateCreated)));
      }

      if (DateUpdated != null)
      {
        p.Add(new KeyValuePair<string, string>("DateUpdated", Serializers.DateTimeIso8601(DateUpdated)));
      }

      if (State != null)
      {
        p.Add(new KeyValuePair<string, string>("State", State.ToString()));
      }

      if (TimersInactive != null)
      {
        p.Add(new KeyValuePair<string, string>("Timers.Inactive", TimersInactive));
      }

      if (TimersClosed != null)
      {
        p.Add(new KeyValuePair<string, string>("Timers.Closed", TimersClosed));
      }

      return p;
    }

    /// <summary>
    /// Generate the necessary header parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (XTwilioWebhookEnabled != null)
      {
        p.Add(new KeyValuePair<string, string>("X-Twilio-Webhook-Enabled", XTwilioWebhookEnabled.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// Update an existing conversation in your service
  /// </summary>
  public class UpdateConversationOptions : IOptions<ConversationResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }
    /// <summary>
    /// A 34 character string that uniquely identifies this resource.
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// The human-readable name of this conversation.
    /// </summary>
    public string FriendlyName { get; set; }
    /// <summary>
    /// The date that this resource was created.
    /// </summary>
    public DateTime? DateCreated { get; set; }
    /// <summary>
    /// The date that this resource was last updated.
    /// </summary>
    public DateTime? DateUpdated { get; set; }
    /// <summary>
    /// An optional string metadata field you can use to store any data you wish.
    /// </summary>
    public string Attributes { get; set; }
    /// <summary>
    /// The unique ID of the Messaging Service this conversation belongs to.
    /// </summary>
    public string MessagingServiceSid { get; set; }
    /// <summary>
    /// Current state of this conversation.
    /// </summary>
    public ConversationResource.StateEnum State { get; set; }
    /// <summary>
    /// ISO8601 duration when conversation will be switched to `inactive` state.
    /// </summary>
    public string TimersInactive { get; set; }
    /// <summary>
    /// ISO8601 duration when conversation will be switched to `closed` state.
    /// </summary>
    public string TimersClosed { get; set; }
    /// <summary>
    /// An application-defined string that uniquely identifies the resource
    /// </summary>
    public string UniqueName { get; set; }
    /// <summary>
    /// The X-Twilio-Webhook-Enabled HTTP request header
    /// </summary>
    public ConversationResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

    /// <summary>
    /// Construct a new UpdateConversationOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    public UpdateConversationOptions(string pathChatServiceSid, string pathSid)
    {
      PathChatServiceSid = pathChatServiceSid;
      PathSid = pathSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (FriendlyName != null)
      {
        p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
      }

      if (DateCreated != null)
      {
        p.Add(new KeyValuePair<string, string>("DateCreated", Serializers.DateTimeIso8601(DateCreated)));
      }

      if (DateUpdated != null)
      {
        p.Add(new KeyValuePair<string, string>("DateUpdated", Serializers.DateTimeIso8601(DateUpdated)));
      }

      if (Attributes != null)
      {
        p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
      }

      if (MessagingServiceSid != null)
      {
        p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid.ToString()));
      }

      if (State != null)
      {
        p.Add(new KeyValuePair<string, string>("State", State.ToString()));
      }

      if (TimersInactive != null)
      {
        p.Add(new KeyValuePair<string, string>("Timers.Inactive", TimersInactive));
      }

      if (TimersClosed != null)
      {
        p.Add(new KeyValuePair<string, string>("Timers.Closed", TimersClosed));
      }

      if (UniqueName != null)
      {
        p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
      }

      return p;
    }

    /// <summary>
    /// Generate the necessary header parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (XTwilioWebhookEnabled != null)
      {
        p.Add(new KeyValuePair<string, string>("X-Twilio-Webhook-Enabled", XTwilioWebhookEnabled.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// Remove a conversation from your service
  /// </summary>
  public class DeleteConversationOptions : IOptions<ConversationResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }
    /// <summary>
    /// A 34 character string that uniquely identifies this resource.
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// The X-Twilio-Webhook-Enabled HTTP request header
    /// </summary>
    public ConversationResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

    /// <summary>
    /// Construct a new DeleteConversationOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    public DeleteConversationOptions(string pathChatServiceSid, string pathSid)
    {
      PathChatServiceSid = pathChatServiceSid;
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

    /// <summary>
    /// Generate the necessary header parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (XTwilioWebhookEnabled != null)
      {
        p.Add(new KeyValuePair<string, string>("X-Twilio-Webhook-Enabled", XTwilioWebhookEnabled.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// Fetch a conversation from your service
  /// </summary>
  public class FetchConversationOptions : IOptions<ConversationResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }
    /// <summary>
    /// A 34 character string that uniquely identifies this resource.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchConversationOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    public FetchConversationOptions(string pathChatServiceSid, string pathSid)
    {
      PathChatServiceSid = pathChatServiceSid;
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
  /// Retrieve a list of conversations in your service
  /// </summary>
  public class ReadConversationOptions : ReadOptions<ConversationResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }

    /// <summary>
    /// Construct a new ReadConversationOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    public ReadConversationOptions(string pathChatServiceSid)
    {
      PathChatServiceSid = pathChatServiceSid;
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

}