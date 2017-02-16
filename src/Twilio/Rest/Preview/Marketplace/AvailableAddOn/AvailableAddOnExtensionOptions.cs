using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Marketplace.AvailableAddOn 
{

    /// <summary>
    /// Fetch an instance of an Extension for the Available Add-on.
    /// </summary>
    public class FetchAvailableAddOnExtensionOptions : IOptions<AvailableAddOnExtensionResource> 
    {
        /// <summary>
        /// The available_add_on_sid
        /// </summary>
        public string AvailableAddOnSid { get; }
        /// <summary>
        /// The unique Extension Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchAvailableAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="availableAddOnSid"> The available_add_on_sid </param>
        /// <param name="sid"> The unique Extension Sid </param>
        public FetchAvailableAddOnExtensionOptions(string availableAddOnSid, string sid)
        {
            AvailableAddOnSid = availableAddOnSid;
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
    /// Retrieve a list of Extensions for the Available Add-on.
    /// </summary>
    public class ReadAvailableAddOnExtensionOptions : ReadOptions<AvailableAddOnExtensionResource> 
    {
        /// <summary>
        /// The available_add_on_sid
        /// </summary>
        public string AvailableAddOnSid { get; }
    
        /// <summary>
        /// Construct a new ReadAvailableAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="availableAddOnSid"> The available_add_on_sid </param>
        public ReadAvailableAddOnExtensionOptions(string availableAddOnSid)
        {
            AvailableAddOnSid = availableAddOnSid;
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