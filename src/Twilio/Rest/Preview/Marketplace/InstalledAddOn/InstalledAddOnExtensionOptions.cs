using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Marketplace.InstalledAddOn 
{

    /// <summary>
    /// Fetch an instance of an Extension for the Installed Add-on.
    /// </summary>
    public class FetchInstalledAddOnExtensionOptions : IOptions<InstalledAddOnExtensionResource> 
    {
        /// <summary>
        /// The installed_add_on_sid
        /// </summary>
        public string InstalledAddOnSid { get; }
        /// <summary>
        /// The unique Extension Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchInstalledAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="installedAddOnSid"> The installed_add_on_sid </param>
        /// <param name="sid"> The unique Extension Sid </param>
        public FetchInstalledAddOnExtensionOptions(string installedAddOnSid, string sid)
        {
            InstalledAddOnSid = installedAddOnSid;
            Sid = sid;
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
    /// Update an Extension for an Add-on installation.
    /// </summary>
    public class UpdateInstalledAddOnExtensionOptions : IOptions<InstalledAddOnExtensionResource> 
    {
        /// <summary>
        /// The installed_add_on_sid
        /// </summary>
        public string InstalledAddOnSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// A Boolean indicating if the Extension will be invoked
        /// </summary>
        public bool? Enabled { get; }
    
        /// <summary>
        /// Construct a new UpdateInstalledAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="installedAddOnSid"> The installed_add_on_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="enabled"> A Boolean indicating if the Extension will be invoked </param>
        public UpdateInstalledAddOnExtensionOptions(string installedAddOnSid, string sid, bool? enabled)
        {
            InstalledAddOnSid = installedAddOnSid;
            Sid = sid;
            Enabled = enabled;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Enabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Enabled", Enabled.Value.ToString()));
            }
            
            return p;
        }
    }

    /// <summary>
    /// Retrieve a list of Extensions for the Installed Add-on.
    /// </summary>
    public class ReadInstalledAddOnExtensionOptions : ReadOptions<InstalledAddOnExtensionResource> 
    {
        /// <summary>
        /// The installed_add_on_sid
        /// </summary>
        public string InstalledAddOnSid { get; }
    
        /// <summary>
        /// Construct a new ReadInstalledAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="installedAddOnSid"> The installed_add_on_sid </param>
        public ReadInstalledAddOnExtensionOptions(string installedAddOnSid)
        {
            InstalledAddOnSid = installedAddOnSid;
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