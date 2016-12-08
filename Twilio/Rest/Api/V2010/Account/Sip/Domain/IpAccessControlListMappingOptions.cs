using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class FetchIpAccessControlListMappingOptions : IOptions<IpAccessControlListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchIpAccessControlListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchIpAccessControlListMappingOptions(string domainSid, string sid)
        {
            DomainSid = domainSid;
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

    public class CreateIpAccessControlListMappingOptions : IOptions<IpAccessControlListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string IpAccessControlListSid { get; }
    
        /// <summary>
        /// Construct a new CreateIpAccessControlListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        public CreateIpAccessControlListMappingOptions(string domainSid, string ipAccessControlListSid)
        {
            DomainSid = domainSid;
            IpAccessControlListSid = ipAccessControlListSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (IpAccessControlListSid != null)
            {
                p.Add(new KeyValuePair<string, string>("IpAccessControlListSid", IpAccessControlListSid.ToString()));
            }
            
            return p;
        }
    }

    public class ReadIpAccessControlListMappingOptions : ReadOptions<IpAccessControlListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
    
        /// <summary>
        /// Construct a new ReadIpAccessControlListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        public ReadIpAccessControlListMappingOptions(string domainSid)
        {
            DomainSid = domainSid;
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

    public class DeleteIpAccessControlListMappingOptions : IOptions<IpAccessControlListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteIpAccessControlListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteIpAccessControlListMappingOptions(string domainSid, string sid)
        {
            DomainSid = domainSid;
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