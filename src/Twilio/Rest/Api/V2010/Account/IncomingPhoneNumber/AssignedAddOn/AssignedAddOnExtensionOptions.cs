using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber.AssignedAddOn 
{

    /// <summary>
    /// Fetch an instance of an Extension for the Assigned Add-on.
    /// </summary>
    public class FetchAssignedAddOnExtensionOptions : IOptions<AssignedAddOnExtensionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The resource_sid
        /// </summary>
        public string ResourceSid { get; }
        /// <summary>
        /// The assigned_add_on_sid
        /// </summary>
        public string AssignedAddOnSid { get; }
        /// <summary>
        /// The unique Extension Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchAssignedAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        /// <param name="assignedAddOnSid"> The assigned_add_on_sid </param>
        /// <param name="sid"> The unique Extension Sid </param>
        public FetchAssignedAddOnExtensionOptions(string resourceSid, string assignedAddOnSid, string sid)
        {
            ResourceSid = resourceSid;
            AssignedAddOnSid = assignedAddOnSid;
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
    /// Retrieve a list of Extensions for the Assigned Add-on.
    /// </summary>
    public class ReadAssignedAddOnExtensionOptions : ReadOptions<AssignedAddOnExtensionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The resource_sid
        /// </summary>
        public string ResourceSid { get; }
        /// <summary>
        /// The assigned_add_on_sid
        /// </summary>
        public string AssignedAddOnSid { get; }
    
        /// <summary>
        /// Construct a new ReadAssignedAddOnExtensionOptions
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        /// <param name="assignedAddOnSid"> The assigned_add_on_sid </param>
        public ReadAssignedAddOnExtensionOptions(string resourceSid, string assignedAddOnSid)
        {
            ResourceSid = resourceSid;
            AssignedAddOnSid = assignedAddOnSid;
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