/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Media.V1
{

  /// <summary>
  /// Returns a single PlayerStreamer resource identified by a SID.
  /// </summary>
  public class FetchPlayerStreamerOptions : IOptions<PlayerStreamerResource>
  {
    /// <summary>
    /// The SID that identifies the resource to fetch
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchPlayerStreamerOptions
    /// </summary>
    /// <param name="pathSid"> The SID that identifies the resource to fetch </param>
    public FetchPlayerStreamerOptions(string pathSid)
    {
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
  /// CreatePlayerStreamerOptions
  /// </summary>
  public class CreatePlayerStreamerOptions : IOptions<PlayerStreamerResource>
  {
    /// <summary>
    /// Whether the PlayerStreamer is configured to stream video
    /// </summary>
    public bool? Video { get; set; }
    /// <summary>
    /// The URL to which Twilio will send PlayerStreamer event updates
    /// </summary>
    public Uri StatusCallback { get; set; }
    /// <summary>
    /// The HTTP method Twilio should use to call the `status_callback` URL
    /// </summary>
    public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Video != null)
      {
        p.Add(new KeyValuePair<string, string>("Video", Video.Value.ToString().ToLower()));
      }

      if (StatusCallback != null)
      {
        p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
      }

      if (StatusCallbackMethod != null)
      {
        p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// Updates a PlayerStreamer resource identified by a SID.
  /// </summary>
  public class UpdatePlayerStreamerOptions : IOptions<PlayerStreamerResource>
  {
    /// <summary>
    /// The SID that identifies the resource to update
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// The status the PlayerStreamer should be transitioned to
    /// </summary>
    public PlayerStreamerResource.UpdateStatusEnum Status { get; }

    /// <summary>
    /// Construct a new UpdatePlayerStreamerOptions
    /// </summary>
    /// <param name="pathSid"> The SID that identifies the resource to update </param>
    /// <param name="status"> The status the PlayerStreamer should be transitioned to </param>
    public UpdatePlayerStreamerOptions(string pathSid, PlayerStreamerResource.UpdateStatusEnum status)
    {
      PathSid = pathSid;
      Status = status;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Status != null)
      {
        p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// Returns a list of PlayerStreamers.
  /// </summary>
  public class ReadPlayerStreamerOptions : ReadOptions<PlayerStreamerResource>
  {
    /// <summary>
    /// The sort order of the list
    /// </summary>
    public PlayerStreamerResource.OrderEnum Order { get; set; }
    /// <summary>
    /// Status to filter by
    /// </summary>
    public PlayerStreamerResource.StatusEnum Status { get; set; }

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

      if (Status != null)
      {
        p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
      }

      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

}