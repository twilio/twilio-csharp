/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Verify.V2.Service.Entity
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Delete a specific Factor.
  /// </summary>
  public class DeleteFactorOptions : IOptions<FactorResource>
  {
    /// <summary>
    /// Service Sid.
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// Unique external identifier of the Entity
    /// </summary>
    public string PathIdentity { get; }
    /// <summary>
    /// A string that uniquely identifies this Factor.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteFactorOptions
    /// </summary>
    /// <param name="pathServiceSid"> Service Sid. </param>
    /// <param name="pathIdentity"> Unique external identifier of the Entity </param>
    /// <param name="pathSid"> A string that uniquely identifies this Factor. </param>
    public DeleteFactorOptions(string pathServiceSid, string pathIdentity, string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathIdentity = pathIdentity;
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
  /// Fetch a specific Factor.
  /// </summary>
  public class FetchFactorOptions : IOptions<FactorResource>
  {
    /// <summary>
    /// Service Sid.
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// Unique external identifier of the Entity
    /// </summary>
    public string PathIdentity { get; }
    /// <summary>
    /// A string that uniquely identifies this Factor.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchFactorOptions
    /// </summary>
    /// <param name="pathServiceSid"> Service Sid. </param>
    /// <param name="pathIdentity"> Unique external identifier of the Entity </param>
    /// <param name="pathSid"> A string that uniquely identifies this Factor. </param>
    public FetchFactorOptions(string pathServiceSid, string pathIdentity, string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathIdentity = pathIdentity;
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
  /// Retrieve a list of all Factors for an Entity.
  /// </summary>
  public class ReadFactorOptions : ReadOptions<FactorResource>
  {
    /// <summary>
    /// Service Sid.
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// Unique external identifier of the Entity
    /// </summary>
    public string PathIdentity { get; }

    /// <summary>
    /// Construct a new ReadFactorOptions
    /// </summary>
    /// <param name="pathServiceSid"> Service Sid. </param>
    /// <param name="pathIdentity"> Unique external identifier of the Entity </param>
    public ReadFactorOptions(string pathServiceSid, string pathIdentity)
    {
      PathServiceSid = pathServiceSid;
      PathIdentity = pathIdentity;
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
  /// Update a specific Factor. This endpoint can be used to Verify a Factor if passed an `AuthPayload` param.
  /// </summary>
  public class UpdateFactorOptions : IOptions<FactorResource>
  {
    /// <summary>
    /// Service Sid.
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// Unique external identifier of the Entity
    /// </summary>
    public string PathIdentity { get; }
    /// <summary>
    /// A string that uniquely identifies this Factor.
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// Optional payload to verify the Factor for the first time
    /// </summary>
    public string AuthPayload { get; set; }
    /// <summary>
    /// The friendly name of this Factor
    /// </summary>
    public string FriendlyName { get; set; }
    /// <summary>
    /// For APN, the device token. For FCM, the registration token
    /// </summary>
    public string ConfigNotificationToken { get; set; }
    /// <summary>
    /// The Verify Push SDK version used to configure the factor
    /// </summary>
    public string ConfigSdkVersion { get; set; }
    /// <summary>
    /// How often, in seconds, are TOTP codes generated
    /// </summary>
    public int? ConfigTimeStep { get; set; }
    /// <summary>
    /// The number of past and future time-steps valid at a given time
    /// </summary>
    public int? ConfigSkew { get; set; }
    /// <summary>
    /// Number of digits for generated TOTP codes
    /// </summary>
    public int? ConfigCodeLength { get; set; }
    /// <summary>
    /// The algorithm used to derive the TOTP codes
    /// </summary>
    public FactorResource.TotpAlgorithmsEnum ConfigAlg { get; set; }
    /// <summary>
    /// The transport technology used to generate the Notification Token
    /// </summary>
    public string ConfigNotificationPlatform { get; set; }

    /// <summary>
    /// Construct a new UpdateFactorOptions
    /// </summary>
    /// <param name="pathServiceSid"> Service Sid. </param>
    /// <param name="pathIdentity"> Unique external identifier of the Entity </param>
    /// <param name="pathSid"> A string that uniquely identifies this Factor. </param>
    public UpdateFactorOptions(string pathServiceSid, string pathIdentity, string pathSid)
    {
      PathServiceSid = pathServiceSid;
      PathIdentity = pathIdentity;
      PathSid = pathSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (AuthPayload != null)
      {
        p.Add(new KeyValuePair<string, string>("AuthPayload", AuthPayload));
      }

      if (FriendlyName != null)
      {
        p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
      }

      if (ConfigNotificationToken != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.NotificationToken", ConfigNotificationToken));
      }

      if (ConfigSdkVersion != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.SdkVersion", ConfigSdkVersion));
      }

      if (ConfigTimeStep != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.TimeStep", ConfigTimeStep.ToString()));
      }

      if (ConfigSkew != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.Skew", ConfigSkew.ToString()));
      }

      if (ConfigCodeLength != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.CodeLength", ConfigCodeLength.ToString()));
      }

      if (ConfigAlg != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.Alg", ConfigAlg.ToString()));
      }

      if (ConfigNotificationPlatform != null)
      {
        p.Add(new KeyValuePair<string, string>("Config.NotificationPlatform", ConfigNotificationPlatform));
      }

      return p;
    }
  }

}