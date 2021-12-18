/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance.Bundle
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Replaces all bundle items in the target bundle (specified in the path) with all the bundle items of the source
  /// bundle (specified by the from_bundle_sid body param)
  /// </summary>
  public class CreateReplaceItemsOptions : IOptions<ReplaceItemsResource>
  {
    /// <summary>
    /// The unique string that identifies the Bundle where the item assignments are going to be replaced
    /// </summary>
    public string PathBundleSid { get; }
    /// <summary>
    /// The source bundle sid to copy the item assignments from
    /// </summary>
    public string FromBundleSid { get; }

    /// <summary>
    /// Construct a new CreateReplaceItemsOptions
    /// </summary>
    /// <param name="pathBundleSid"> The unique string that identifies the Bundle where the item assignments are going to
    ///                     be replaced </param>
    /// <param name="fromBundleSid"> The source bundle sid to copy the item assignments from </param>
    public CreateReplaceItemsOptions(string pathBundleSid, string fromBundleSid)
    {
      PathBundleSid = pathBundleSid;
      FromBundleSid = fromBundleSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (FromBundleSid != null)
      {
        p.Add(new KeyValuePair<string, string>("FromBundleSid", FromBundleSid.ToString()));
      }

      return p;
    }
  }

}