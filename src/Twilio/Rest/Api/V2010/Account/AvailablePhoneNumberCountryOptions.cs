/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account
{

  /// <summary>
  /// ReadAvailablePhoneNumberCountryOptions
  /// </summary>
  public class ReadAvailablePhoneNumberCountryOptions : ReadOptions<AvailablePhoneNumberCountryResource>
  {
    /// <summary>
    /// The SID of the Account requesting the available phone number Country resources
    /// </summary>
    public string PathAccountSid { get; set; }

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
  /// FetchAvailablePhoneNumberCountryOptions
  /// </summary>
  public class FetchAvailablePhoneNumberCountryOptions : IOptions<AvailablePhoneNumberCountryResource>
  {
    /// <summary>
    /// The SID of the Account requesting the available phone number Country resource
    /// </summary>
    public string PathAccountSid { get; set; }
    /// <summary>
    /// The ISO country code of the country to fetch available phone number information about
    /// </summary>
    public string PathCountryCode { get; }

    /// <summary>
    /// Construct a new FetchAvailablePhoneNumberCountryOptions
    /// </summary>
    /// <param name="pathCountryCode"> The ISO country code of the country to fetch available phone number information
    ///                       about </param>
    public FetchAvailablePhoneNumberCountryOptions(string pathCountryCode)
    {
      PathCountryCode = pathCountryCode;
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