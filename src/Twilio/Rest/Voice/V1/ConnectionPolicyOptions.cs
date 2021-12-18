/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Voice.V1
{

  /// <summary>
  /// CreateConnectionPolicyOptions
  /// </summary>
  public class CreateConnectionPolicyOptions : IOptions<ConnectionPolicyResource>
  {
    /// <summary>
    /// A string to describe the resource
    /// </summary>
    public string FriendlyName { get; set; }

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

      return p;
    }
  }

  /// <summary>
  /// FetchConnectionPolicyOptions
  /// </summary>
  public class FetchConnectionPolicyOptions : IOptions<ConnectionPolicyResource>
  {
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchConnectionPolicyOptions
    /// </summary>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public FetchConnectionPolicyOptions(string pathSid)
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
  /// ReadConnectionPolicyOptions
  /// </summary>
  public class ReadConnectionPolicyOptions : ReadOptions<ConnectionPolicyResource>
  {
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
  /// UpdateConnectionPolicyOptions
  /// </summary>
  public class UpdateConnectionPolicyOptions : IOptions<ConnectionPolicyResource>
  {
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// A string to describe the resource
    /// </summary>
    public string FriendlyName { get; set; }

    /// <summary>
    /// Construct a new UpdateConnectionPolicyOptions
    /// </summary>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public UpdateConnectionPolicyOptions(string pathSid)
    {
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

      return p;
    }
  }

  /// <summary>
  /// DeleteConnectionPolicyOptions
  /// </summary>
  public class DeleteConnectionPolicyOptions : IOptions<ConnectionPolicyResource>
  {
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteConnectionPolicyOptions
    /// </summary>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public DeleteConnectionPolicyOptions(string pathSid)
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

}