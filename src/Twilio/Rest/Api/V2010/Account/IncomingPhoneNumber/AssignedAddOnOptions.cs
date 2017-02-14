using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class FetchAssignedAddOnOptions : IOptions<AssignedAddOnResource> 
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
        /// The unique Installed Add-on Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchAssignedAddOnOptions
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        /// <param name="sid"> The unique Installed Add-on Sid </param>
        public FetchAssignedAddOnOptions(string resourceSid, string sid)
        {
            ResourceSid = resourceSid;
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

    public class ReadAssignedAddOnOptions : ReadOptions<AssignedAddOnResource> 
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
        /// Construct a new ReadAssignedAddOnOptions
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        public ReadAssignedAddOnOptions(string resourceSid)
        {
            ResourceSid = resourceSid;
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

    public class CreateAssignedAddOnOptions : IOptions<AssignedAddOnResource> 
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
        /// A string that uniquely identifies the Add-on installation
        /// </summary>
        public string InstalledAddOnSid { get; }
    
        /// <summary>
        /// Construct a new CreateAssignedAddOnOptions
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        /// <param name="installedAddOnSid"> A string that uniquely identifies the Add-on installation </param>
        public CreateAssignedAddOnOptions(string resourceSid, string installedAddOnSid)
        {
            ResourceSid = resourceSid;
            InstalledAddOnSid = installedAddOnSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (InstalledAddOnSid != null)
            {
                p.Add(new KeyValuePair<string, string>("InstalledAddOnSid", InstalledAddOnSid.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteAssignedAddOnOptions : IOptions<AssignedAddOnResource> 
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
        /// The Installed Add-on Sid to remove
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteAssignedAddOnOptions
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        /// <param name="sid"> The Installed Add-on Sid to remove </param>
        public DeleteAssignedAddOnOptions(string resourceSid, string sid)
        {
            ResourceSid = resourceSid;
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

}