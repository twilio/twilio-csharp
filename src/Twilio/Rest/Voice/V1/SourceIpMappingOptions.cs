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
  /// CreateSourceIpMappingOptions
  /// </summary>
  public class CreateSourceIpMappingOptions : IOptions<SourceIpMappingResource>
  {
    /// <summary>
    /// The unique string that identifies an IP Record
    /// </summary>
    public string IpRecordSid { get; }
    /// <summary>
    /// The unique string that identifies a SIP Domain
    /// </summary>
    public string SipDomainSid { get; }

    /// <summary>
    /// Construct a new CreateSourceIpMappingOptions
    /// </summary>
    /// <param name="ipRecordSid"> The unique string that identifies an IP Record </param>
    /// <param name="sipDomainSid"> The unique string that identifies a SIP Domain </param>
    public CreateSourceIpMappingOptions(string ipRecordSid, string sipDomainSid)
    {
      IpRecordSid = ipRecordSid;
      SipDomainSid = sipDomainSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (IpRecordSid != null)
      {
        p.Add(new KeyValuePair<string, string>("IpRecordSid", IpRecordSid.ToString()));
      }

      if (SipDomainSid != null)
      {
        p.Add(new KeyValuePair<string, string>("SipDomainSid", SipDomainSid.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// FetchSourceIpMappingOptions
  /// </summary>
  public class FetchSourceIpMappingOptions : IOptions<SourceIpMappingResource>
  {
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchSourceIpMappingOptions
    /// </summary>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public FetchSourceIpMappingOptions(string pathSid)
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
  /// ReadSourceIpMappingOptions
  /// </summary>
  public class ReadSourceIpMappingOptions : ReadOptions<SourceIpMappingResource>
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
  /// UpdateSourceIpMappingOptions
  /// </summary>
  public class UpdateSourceIpMappingOptions : IOptions<SourceIpMappingResource>
  {
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// The unique string that identifies a SIP Domain
    /// </summary>
    public string SipDomainSid { get; }

    /// <summary>
    /// Construct a new UpdateSourceIpMappingOptions
    /// </summary>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="sipDomainSid"> The unique string that identifies a SIP Domain </param>
    public UpdateSourceIpMappingOptions(string pathSid, string sipDomainSid)
    {
      PathSid = pathSid;
      SipDomainSid = sipDomainSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (SipDomainSid != null)
      {
        p.Add(new KeyValuePair<string, string>("SipDomainSid", SipDomainSid.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// DeleteSourceIpMappingOptions
  /// </summary>
  public class DeleteSourceIpMappingOptions : IOptions<SourceIpMappingResource>
  {
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteSourceIpMappingOptions
    /// </summary>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public DeleteSourceIpMappingOptions(string pathSid)
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