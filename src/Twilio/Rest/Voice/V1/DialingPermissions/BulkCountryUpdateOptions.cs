/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Voice.V1.DialingPermissions
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Create a bulk update request to change voice dialing country permissions of one or more countries identified by the
  /// corresponding [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
  /// </summary>
  public class CreateBulkCountryUpdateOptions : IOptions<BulkCountryUpdateResource>
  {
    /// <summary>
    /// URL encoded JSON array of update objects
    /// </summary>
    public string UpdateRequest { get; }

    /// <summary>
    /// Construct a new CreateBulkCountryUpdateOptions
    /// </summary>
    /// <param name="updateRequest"> URL encoded JSON array of update objects </param>
    public CreateBulkCountryUpdateOptions(string updateRequest)
    {
      UpdateRequest = updateRequest;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (UpdateRequest != null)
      {
        p.Add(new KeyValuePair<string, string>("UpdateRequest", UpdateRequest));
      }

      return p;
    }
  }

}