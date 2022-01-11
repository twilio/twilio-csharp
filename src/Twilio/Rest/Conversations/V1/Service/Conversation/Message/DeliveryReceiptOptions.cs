/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Conversations.V1.Service.Conversation.Message
{

  /// <summary>
  /// Fetch the delivery and read receipts of the conversation message
  /// </summary>
  public class FetchDeliveryReceiptOptions : IOptions<DeliveryReceiptResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }
    /// <summary>
    /// The unique ID of the Conversation for this delivery receipt.
    /// </summary>
    public string PathConversationSid { get; }
    /// <summary>
    /// The SID of the message the delivery receipt belongs to.
    /// </summary>
    public string PathMessageSid { get; }
    /// <summary>
    /// A 34 character string that uniquely identifies this resource.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchDeliveryReceiptOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this delivery receipt. </param>
    /// <param name="pathMessageSid"> The SID of the message the delivery receipt belongs to. </param>
    /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
    public FetchDeliveryReceiptOptions(string pathChatServiceSid,
                                       string pathConversationSid,
                                       string pathMessageSid,
                                       string pathSid)
    {
      PathChatServiceSid = pathChatServiceSid;
      PathConversationSid = pathConversationSid;
      PathMessageSid = pathMessageSid;
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
  /// Retrieve a list of all delivery and read receipts of the conversation message
  /// </summary>
  public class ReadDeliveryReceiptOptions : ReadOptions<DeliveryReceiptResource>
  {
    /// <summary>
    /// The SID of the Conversation Service that the resource is associated with.
    /// </summary>
    public string PathChatServiceSid { get; }
    /// <summary>
    /// The unique ID of the Conversation for this delivery receipt.
    /// </summary>
    public string PathConversationSid { get; }
    /// <summary>
    /// The SID of the message the delivery receipt belongs to.
    /// </summary>
    public string PathMessageSid { get; }

    /// <summary>
    /// Construct a new ReadDeliveryReceiptOptions
    /// </summary>
    /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with. </param>
    /// <param name="pathConversationSid"> The unique ID of the Conversation for this delivery receipt. </param>
    /// <param name="pathMessageSid"> The SID of the message the delivery receipt belongs to. </param>
    public ReadDeliveryReceiptOptions(string pathChatServiceSid, string pathConversationSid, string pathMessageSid)
    {
      PathChatServiceSid = pathChatServiceSid;
      PathConversationSid = pathConversationSid;
      PathMessageSid = pathMessageSid;
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