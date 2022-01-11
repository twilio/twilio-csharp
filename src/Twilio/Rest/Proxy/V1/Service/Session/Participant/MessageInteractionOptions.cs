/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Proxy.V1.Service.Session.Participant
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Create a new message Interaction to send directly from your system to one
  /// [Participant](https://www.twilio.com/docs/proxy/api/participant).  The `inbound` properties for the Interaction will
  /// always be empty.
  /// </summary>
  public class CreateMessageInteractionOptions : IOptions<MessageInteractionResource>
  {
    /// <summary>
    /// The SID of the parent Service resource
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the parent Session resource
    /// </summary>
    public string PathSessionSid { get; }
    /// <summary>
    /// The SID of the Participant resource
    /// </summary>
    public string PathParticipantSid { get; }
    /// <summary>
    /// Message body
    /// </summary>
    public string Body { get; set; }
    /// <summary>
    /// Reserved
    /// </summary>
    public List<Uri> MediaUrl { get; set; }

    /// <summary>
    /// Construct a new CreateMessageInteractionOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource </param>
    /// <param name="pathSessionSid"> The SID of the parent Session resource </param>
    /// <param name="pathParticipantSid"> The SID of the Participant resource </param>
    public CreateMessageInteractionOptions(string pathServiceSid, string pathSessionSid, string pathParticipantSid)
    {
      PathServiceSid = pathServiceSid;
      PathSessionSid = pathSessionSid;
      PathParticipantSid = pathParticipantSid;
      MediaUrl = new List<Uri>();
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

      if (MediaUrl != null)
      {
        p.AddRange(MediaUrl.Select(prop => new KeyValuePair<string, string>("MediaUrl", Serializers.Url(prop))));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// FetchMessageInteractionOptions
  /// </summary>
  public class FetchMessageInteractionOptions : IOptions<MessageInteractionResource>
  {
    /// <summary>
    /// The SID of the Service to fetch the resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the parent Session
    /// </summary>
    public string PathSessionSid { get; }
    /// <summary>
    /// The SID of the Participant resource
    /// </summary>
    public string PathParticipantSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchMessageInteractionOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
    /// <param name="pathSessionSid"> The SID of the parent Session </param>
    /// <param name="pathParticipantSid"> The SID of the Participant resource </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public FetchMessageInteractionOptions(string pathServiceSid,
                                          string pathSessionSid,
                                          string pathParticipantSid,
                                          string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathSessionSid = pathSessionSid;
      PathParticipantSid = pathParticipantSid;
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
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// ReadMessageInteractionOptions
  /// </summary>
  public class ReadMessageInteractionOptions : ReadOptions<MessageInteractionResource>
  {
    /// <summary>
    /// The SID of the Service to read the resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the parent Session
    /// </summary>
    public string PathSessionSid { get; }
    /// <summary>
    /// The SID of the Participant resource
    /// </summary>
    public string PathParticipantSid { get; }

    /// <summary>
    /// Construct a new ReadMessageInteractionOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to read the resource from </param>
    /// <param name="pathSessionSid"> The SID of the parent Session </param>
    /// <param name="pathParticipantSid"> The SID of the Participant resource </param>
    public ReadMessageInteractionOptions(string pathServiceSid, string pathSessionSid, string pathParticipantSid)
    {
      PathServiceSid = pathServiceSid;
      PathSessionSid = pathSessionSid;
      PathParticipantSid = pathParticipantSid;
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