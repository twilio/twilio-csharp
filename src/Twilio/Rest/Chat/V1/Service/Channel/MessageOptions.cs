/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Chat.V1.Service.Channel
{

  /// <summary>
  /// FetchMessageOptions
  /// </summary>
  public class FetchMessageOptions : IOptions<MessageResource>
  {
    /// <summary>
    /// The SID of the Service to fetch the resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The unique ID of the Channel the message to fetch belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchMessageOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
    /// <param name="pathChannelSid"> The unique ID of the Channel the message to fetch belongs to </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public FetchMessageOptions(string pathServiceSid, string pathChannelSid, string pathSid)
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
  /// CreateMessageOptions
  /// </summary>
  public class CreateMessageOptions : IOptions<MessageResource>
  {
    /// <summary>
    /// The SID of the Service to create the resource under
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The unique ID of the channel the new resource belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The message to send to the channel
    /// </summary>
    public string Body { get; }
    /// <summary>
    /// The identity of the new message's author
    /// </summary>
    public string From { get; set; }
    /// <summary>
    /// A valid JSON string that contains application-specific data
    /// </summary>
    public string Attributes { get; set; }

    /// <summary>
    /// Construct a new CreateMessageOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to create the resource under </param>
    /// <param name="pathChannelSid"> The unique ID of the channel the new resource belongs to </param>
    /// <param name="body"> The message to send to the channel </param>
    public CreateMessageOptions(string pathServiceSid, string pathChannelSid, string body)
    {
      PathServiceSid = pathServiceSid;
      PathChannelSid = pathChannelSid;
      Body = body;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Body != null)
      {
        p.Add(new KeyValuePair<string, string>("Body", Body));
      }

      if (From != null)
      {
        p.Add(new KeyValuePair<string, string>("From", From));
      }

      if (Attributes != null)
      {
        p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
      }

      return p;
    }
  }

  /// <summary>
  /// ReadMessageOptions
  /// </summary>
  public class ReadMessageOptions : ReadOptions<MessageResource>
  {
    /// <summary>
    /// The SID of the Service to read the resources from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The unique ID of the Channel the message to read belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The sort order of the returned messages
    /// </summary>
    public MessageResource.OrderTypeEnum Order { get; set; }

    /// <summary>
    /// Construct a new ReadMessageOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to read the resources from </param>
    /// <param name="pathChannelSid"> The unique ID of the Channel the message to read belongs to </param>
    public ReadMessageOptions(string pathServiceSid, string pathChannelSid)
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
      if (Order != null)
      {
        p.Add(new KeyValuePair<string, string>("Order", Order.ToString()));
      }

      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// DeleteMessageOptions
  /// </summary>
  public class DeleteMessageOptions : IOptions<MessageResource>
  {
    /// <summary>
    /// The SID of the Service to delete the resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The unique ID of the channel the message to delete belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteMessageOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to delete the resource from </param>
    /// <param name="pathChannelSid"> The unique ID of the channel the message to delete belongs to </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public DeleteMessageOptions(string pathServiceSid, string pathChannelSid, string pathSid)
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
  /// UpdateMessageOptions
  /// </summary>
  public class UpdateMessageOptions : IOptions<MessageResource>
  {
    /// <summary>
    /// The SID of the Service to update the resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// he unique ID of the Channel the message belongs to
    /// </summary>
    public string PathChannelSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// The message to send to the channel
    /// </summary>
    public string Body { get; set; }
    /// <summary>
    /// A valid JSON string that contains application-specific data
    /// </summary>
    public string Attributes { get; set; }

    /// <summary>
    /// Construct a new UpdateMessageOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to update the resource from </param>
    /// <param name="pathChannelSid"> he unique ID of the Channel the message belongs to </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public UpdateMessageOptions(string pathServiceSid, string pathChannelSid, string pathSid)
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
      if (Body != null)
      {
        p.Add(new KeyValuePair<string, string>("Body", Body));
      }

      if (Attributes != null)
      {
        p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
      }

      return p;
    }
  }

}