/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Serverless.V1.Service
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Retrieve a list of all environments.
  /// </summary>
  public class ReadEnvironmentOptions : ReadOptions<EnvironmentResource>
  {
    /// <summary>
    /// The SID of the Service to read the Environment resources from
    /// </summary>
    public string PathServiceSid { get; }

    /// <summary>
    /// Construct a new ReadEnvironmentOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to read the Environment resources from </param>
    public ReadEnvironmentOptions(string pathServiceSid)
    {
      PathServiceSid = pathServiceSid;
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
  /// Retrieve a specific environment.
  /// </summary>
  public class FetchEnvironmentOptions : IOptions<EnvironmentResource>
  {
    /// <summary>
    /// The SID of the Service to fetch the Environment resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID of the Environment resource to fetch
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchEnvironmentOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to fetch the Environment resource from </param>
    /// <param name="pathSid"> The SID of the Environment resource to fetch </param>
    public FetchEnvironmentOptions(string pathServiceSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
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
  /// Create a new environment.
  /// </summary>
  public class CreateEnvironmentOptions : IOptions<EnvironmentResource>
  {
    /// <summary>
    /// The SID of the Service to create the Environment resource under
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// A user-defined string that uniquely identifies the Environment resource
    /// </summary>
    public string UniqueName { get; }
    /// <summary>
    /// A URL-friendly name that represents the environment
    /// </summary>
    public string DomainSuffix { get; set; }

    /// <summary>
    /// Construct a new CreateEnvironmentOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to create the Environment resource under </param>
    /// <param name="uniqueName"> A user-defined string that uniquely identifies the Environment resource </param>
    public CreateEnvironmentOptions(string pathServiceSid, string uniqueName)
    {
      PathServiceSid = pathServiceSid;
      UniqueName = uniqueName;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (UniqueName != null)
      {
        p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
      }

      if (DomainSuffix != null)
      {
        p.Add(new KeyValuePair<string, string>("DomainSuffix", DomainSuffix));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Delete a specific environment.
  /// </summary>
  public class DeleteEnvironmentOptions : IOptions<EnvironmentResource>
  {
    /// <summary>
    /// The SID of the Service to delete the Environment resource from
    /// </summary>
    public string PathServiceSid { get; }
    /// <summary>
    /// The SID that identifies the Environment resource to delete
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteEnvironmentOptions
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the Service to delete the Environment resource from </param>
    /// <param name="pathSid"> The SID that identifies the Environment resource to delete </param>
    public DeleteEnvironmentOptions(string pathServiceSid, string pathSid)
    {
      PathServiceSid = pathServiceSid;
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