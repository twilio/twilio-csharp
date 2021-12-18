/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Supersim.V1.Sim
{

  /// <summary>
  /// Retrieve a list of Billing Periods for a Super SIM.
  /// </summary>
  public class ReadBillingPeriodOptions : ReadOptions<BillingPeriodResource>
  {
    /// <summary>
    /// The SID of the Super SIM to list Billing Periods for.
    /// </summary>
    public string PathSimSid { get; }

    /// <summary>
    /// Construct a new ReadBillingPeriodOptions
    /// </summary>
    /// <param name="pathSimSid"> The SID of the Super SIM to list Billing Periods for. </param>
    public ReadBillingPeriodOptions(string pathSimSid)
    {
      PathSimSid = pathSimSid;
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