/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Fax.V1.Fax
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Fetch a specific fax media instance.
  /// </summary>
  public class FetchFaxMediaOptions : IOptions<FaxMediaResource>
  {
    /// <summary>
    /// The SID of the fax with the FaxMedia resource to fetch
    /// </summary>
    public string PathFaxSid { get; }
    /// <summary>
    /// The unique string that identifies the resource to fetch
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchFaxMediaOptions
    /// </summary>
    /// <param name="pathFaxSid"> The SID of the fax with the FaxMedia resource to fetch </param>
    /// <param name="pathSid"> The unique string that identifies the resource to fetch </param>
    public FetchFaxMediaOptions(string pathFaxSid, string pathSid)
    {
      PathFaxSid = pathFaxSid;
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
  /// Retrieve a list of all fax media instances for the specified fax.
  /// </summary>
  public class ReadFaxMediaOptions : ReadOptions<FaxMediaResource>
  {
    /// <summary>
    /// The SID of the fax with the FaxMedia resources to read
    /// </summary>
    public string PathFaxSid { get; }

    /// <summary>
    /// Construct a new ReadFaxMediaOptions
    /// </summary>
    /// <param name="pathFaxSid"> The SID of the fax with the FaxMedia resources to read </param>
    public ReadFaxMediaOptions(string pathFaxSid)
    {
      PathFaxSid = pathFaxSid;
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
  /// Delete a specific fax media instance.
  /// </summary>
  public class DeleteFaxMediaOptions : IOptions<FaxMediaResource>
  {
    /// <summary>
    /// The SID of the fax with the FaxMedia resource to delete
    /// </summary>
    public string PathFaxSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteFaxMediaOptions
    /// </summary>
    /// <param name="pathFaxSid"> The SID of the fax with the FaxMedia resource to delete </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public DeleteFaxMediaOptions(string pathFaxSid, string pathSid)
    {
      PathFaxSid = pathFaxSid;
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