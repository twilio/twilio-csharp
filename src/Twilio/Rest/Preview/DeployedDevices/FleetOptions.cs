/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Preview.DeployedDevices
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Fetch information about a specific Fleet in your account.
  /// </summary>
  public class FetchFleetOptions : IOptions<FleetResource>
  {
    /// <summary>
    /// A string that uniquely identifies the Fleet.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchFleetOptions
    /// </summary>
    /// <param name="pathSid"> A string that uniquely identifies the Fleet. </param>
    public FetchFleetOptions(string pathSid)
    {
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
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Delete a specific Fleet from your account, also destroys all nested resources: Devices, Deployments, Certificates,
  /// Keys.
  /// </summary>
  public class DeleteFleetOptions : IOptions<FleetResource>
  {
    /// <summary>
    /// A string that uniquely identifies the Fleet.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteFleetOptions
    /// </summary>
    /// <param name="pathSid"> A string that uniquely identifies the Fleet. </param>
    public DeleteFleetOptions(string pathSid)
    {
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
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Create a new Fleet for scoping of deployed devices within your account.
  /// </summary>
  public class CreateFleetOptions : IOptions<FleetResource>
  {
    /// <summary>
    /// A human readable description for this Fleet.
    /// </summary>
    public string FriendlyName { get; set; }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (FriendlyName != null)
      {
        p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Retrieve a list of all Fleets belonging to your account.
  /// </summary>
  public class ReadFleetOptions : ReadOptions<FleetResource>
  {
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
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// Update the friendly name property of a specific Fleet in your account.
  /// </summary>
  public class UpdateFleetOptions : IOptions<FleetResource>
  {
    /// <summary>
    /// A string that uniquely identifies the Fleet.
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// A human readable description for this Fleet.
    /// </summary>
    public string FriendlyName { get; set; }
    /// <summary>
    /// A default Deployment SID.
    /// </summary>
    public string DefaultDeploymentSid { get; set; }

    /// <summary>
    /// Construct a new UpdateFleetOptions
    /// </summary>
    /// <param name="pathSid"> A string that uniquely identifies the Fleet. </param>
    public UpdateFleetOptions(string pathSid)
    {
      PathSid = pathSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (FriendlyName != null)
      {
        p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
      }

      if (DefaultDeploymentSid != null)
      {
        p.Add(new KeyValuePair<string, string>("DefaultDeploymentSid", DefaultDeploymentSid.ToString()));
      }

      return p;
    }
  }

}