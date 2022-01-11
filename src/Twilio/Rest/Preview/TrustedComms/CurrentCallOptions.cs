/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Preview.TrustedComms
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Retrieve a current call given the originating and terminating number via `X-XCNAM-Sensitive-Phone-Number-From` and
  /// `X-XCNAM-Sensitive-Phone-Number-To` headers.
  /// </summary>
  public class FetchCurrentCallOptions : IOptions<CurrentCallResource>
  {
    /// <summary>
    /// The originating Phone Number
    /// </summary>
    public string XXcnamSensitivePhoneNumberFrom { get; set; }
    /// <summary>
    /// The terminating Phone Number
    /// </summary>
    public string XXcnamSensitivePhoneNumberTo { get; set; }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      return p;
    }

    /// <summary>
    /// Generate the necessary header parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (XXcnamSensitivePhoneNumberFrom != null)
      {
        p.Add(new KeyValuePair<string, string>("X-Xcnam-Sensitive-Phone-Number-From", XXcnamSensitivePhoneNumberFrom));
      }

      if (XXcnamSensitivePhoneNumberTo != null)
      {
        p.Add(new KeyValuePair<string, string>("X-Xcnam-Sensitive-Phone-Number-To", XXcnamSensitivePhoneNumberTo));
      }

      return p;
    }
  }

}