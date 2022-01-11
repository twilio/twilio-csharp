/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account.Usage.Record
{

  /// <summary>
  /// ReadMonthlyOptions
  /// </summary>
  public class ReadMonthlyOptions : ReadOptions<MonthlyResource>
  {
    /// <summary>
    /// The SID of the Account that created the resources to read
    /// </summary>
    public string PathAccountSid { get; set; }
    /// <summary>
    /// The usage category of the UsageRecord resources to read
    /// </summary>
    public MonthlyResource.CategoryEnum Category { get; set; }
    /// <summary>
    /// Only include usage that has occurred on or after this date
    /// </summary>
    public DateTime? StartDate { get; set; }
    /// <summary>
    /// Only include usage that occurred on or before this date
    /// </summary>
    public DateTime? EndDate { get; set; }
    /// <summary>
    /// Whether to include usage from the master account and all its subaccounts
    /// </summary>
    public bool? IncludeSubaccounts { get; set; }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public override List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Category != null)
      {
        p.Add(new KeyValuePair<string, string>("Category", Category.ToString()));
      }

      if (StartDate != null)
      {
        p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd")));
      }

      if (EndDate != null)
      {
        p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd")));
      }

      if (IncludeSubaccounts != null)
      {
        p.Add(new KeyValuePair<string, string>("IncludeSubaccounts", IncludeSubaccounts.Value.ToString().ToLower()));
      }

      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

}