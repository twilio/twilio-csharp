/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.IpMessaging.V2.Service
{

  /// <summary>
  /// ReadBindingOptions
  /// </summary>
  public class ReadBindingOptions : ReadOptions<BindingResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The binding_type
    /// </summary>
    public List<BindingResource.BindingTypeEnum> BindingType { get; set; }
    /// <summary>
    /// The identity
    /// </summary>
    public List<string> Identity { get; set; }

    /// <summary>
    /// Construct a new ReadBindingOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    public ReadBindingOptions(string pathServiceSid)
    {
      PathServiceSid = pathServiceSid;
      BindingType = new List<BindingResource.BindingTypeEnum>();
      Identity = new List<string>();
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public override List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (BindingType != null)
      {
        p.AddRange(BindingType.Select(prop => new KeyValuePair<string, string>("BindingType", prop.ToString())));
      }

      if (Identity != null)
      {
        p.AddRange(Identity.Select(prop => new KeyValuePair<string, string>("Identity", prop)));
      }

      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// FetchBindingOptions
  /// </summary>
  public class FetchBindingOptions : IOptions<BindingResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The sid
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchBindingOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathSid"> The sid </param>
    public FetchBindingOptions(string pathServiceSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
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
  /// DeleteBindingOptions
  /// </summary>
  public class DeleteBindingOptions : IOptions<BindingResource>
  {
    /// <summary>
    /// The service_sid
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The sid
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteBindingOptions
    /// </summary>
    /// <param name="pathServiceSid"> The service_sid </param>
    /// <param name="pathSid"> The sid </param>
    public DeleteBindingOptions(string pathServiceSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
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