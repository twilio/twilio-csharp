/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Messaging.V1.Service
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// CreateUsAppToPersonOptions
  /// </summary>
  public class CreateUsAppToPersonOptions : IOptions<UsAppToPersonResource>
  {
    /// <summary>
    /// The SID of the Messaging Service to create the resource from
    /// </summary>
    public string PathMessagingServiceSid { get; }
    /// <summary>
    /// A2P Brand Registration SID
    /// </summary>
    public string BrandRegistrationSid { get; }
    /// <summary>
    /// A short description of what this SMS campaign does
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// Message samples
    /// </summary>
    public List<string> MessageSamples { get; }
    /// <summary>
    /// A2P Campaign Use Case.
    /// </summary>
    public string UsAppToPersonUsecase { get; }
    /// <summary>
    /// Indicates that this SMS campaign will send messages that contain links
    /// </summary>
    public bool? HasEmbeddedLinks { get; }
    /// <summary>
    /// Indicates that this SMS campaign will send messages that contain phone numbers
    /// </summary>
    public bool? HasEmbeddedPhone { get; }

    /// <summary>
    /// Construct a new CreateUsAppToPersonOptions
    /// </summary>
    /// <param name="pathMessagingServiceSid"> The SID of the Messaging Service to create the resource from </param>
    /// <param name="brandRegistrationSid"> A2P Brand Registration SID </param>
    /// <param name="description"> A short description of what this SMS campaign does </param>
    /// <param name="messageSamples"> Message samples </param>
    /// <param name="usAppToPersonUsecase"> A2P Campaign Use Case. </param>
    /// <param name="hasEmbeddedLinks"> Indicates that this SMS campaign will send messages that contain links </param>
    /// <param name="hasEmbeddedPhone"> Indicates that this SMS campaign will send messages that contain phone numbers
    ///                        </param>
    public CreateUsAppToPersonOptions(string pathMessagingServiceSid,
                                      string brandRegistrationSid,
                                      string description,
                                      List<string> messageSamples,
                                      string usAppToPersonUsecase,
                                      bool? hasEmbeddedLinks,
                                      bool? hasEmbeddedPhone)
    {
      PathMessagingServiceSid = pathMessagingServiceSid;
      BrandRegistrationSid = brandRegistrationSid;
      Description = description;
      MessageSamples = messageSamples;
      UsAppToPersonUsecase = usAppToPersonUsecase;
      HasEmbeddedLinks = hasEmbeddedLinks;
      HasEmbeddedPhone = hasEmbeddedPhone;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (BrandRegistrationSid != null)
      {
        p.Add(new KeyValuePair<string, string>("BrandRegistrationSid", BrandRegistrationSid.ToString()));
      }

      if (Description != null)
      {
        p.Add(new KeyValuePair<string, string>("Description", Description));
      }

      if (MessageSamples != null)
      {
        p.AddRange(MessageSamples.Select(prop => new KeyValuePair<string, string>("MessageSamples", prop)));
      }

      if (UsAppToPersonUsecase != null)
      {
        p.Add(new KeyValuePair<string, string>("UsAppToPersonUsecase", UsAppToPersonUsecase));
      }

      if (HasEmbeddedLinks != null)
      {
        p.Add(new KeyValuePair<string, string>("HasEmbeddedLinks", HasEmbeddedLinks.Value.ToString().ToLower()));
      }

      if (HasEmbeddedPhone != null)
      {
        p.Add(new KeyValuePair<string, string>("HasEmbeddedPhone", HasEmbeddedPhone.Value.ToString().ToLower()));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// DeleteUsAppToPersonOptions
  /// </summary>
  public class DeleteUsAppToPersonOptions : IOptions<UsAppToPersonResource>
  {
    /// <summary>
    /// The SID of the Messaging Service to delete the resource from
    /// </summary>
    public string PathMessagingServiceSid { get; }
    /// <summary>
    /// The SID that identifies the US A2P Compliance resource to delete
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteUsAppToPersonOptions
    /// </summary>
    /// <param name="pathMessagingServiceSid"> The SID of the Messaging Service to delete the resource from </param>
    /// <param name="pathSid"> The SID that identifies the US A2P Compliance resource to delete </param>
    public DeleteUsAppToPersonOptions(string pathMessagingServiceSid, string pathSid)
    {
      PathMessagingServiceSid = pathMessagingServiceSid;
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
  /// ReadUsAppToPersonOptions
  /// </summary>
  public class ReadUsAppToPersonOptions : ReadOptions<UsAppToPersonResource>
  {
    /// <summary>
    /// The SID of the Messaging Service to fetch the resource from
    /// </summary>
    public string PathMessagingServiceSid { get; }

    /// <summary>
    /// Construct a new ReadUsAppToPersonOptions
    /// </summary>
    /// <param name="pathMessagingServiceSid"> The SID of the Messaging Service to fetch the resource from </param>
    public ReadUsAppToPersonOptions(string pathMessagingServiceSid)
    {
      PathMessagingServiceSid = pathMessagingServiceSid;
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
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// FetchUsAppToPersonOptions
  /// </summary>
  public class FetchUsAppToPersonOptions : IOptions<UsAppToPersonResource>
  {
    /// <summary>
    /// The SID of the Messaging Service to fetch the resource from
    /// </summary>
    public string PathMessagingServiceSid { get; }
    /// <summary>
    /// The SID that identifies the US A2P Compliance resource to fetch
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchUsAppToPersonOptions
    /// </summary>
    /// <param name="pathMessagingServiceSid"> The SID of the Messaging Service to fetch the resource from </param>
    /// <param name="pathSid"> The SID that identifies the US A2P Compliance resource to fetch </param>
    public FetchUsAppToPersonOptions(string pathMessagingServiceSid, string pathSid)
    {
      PathMessagingServiceSid = pathMessagingServiceSid;
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