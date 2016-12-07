using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class CreateCredentialListMappingOptions : IOptions<CredentialListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string CredentialListSid { get; }
    
        /// <summary>
        /// Construct a new CreateCredentialListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        public CreateCredentialListMappingOptions(string domainSid, string credentialListSid)
        {
            DomainSid = domainSid;
            CredentialListSid = credentialListSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CredentialListSid != null)
            {
                p.Add(new KeyValuePair<string, string>("CredentialListSid", CredentialListSid));
            }
            
            return p;
        }
    }

    public class ReadCredentialListMappingOptions : ReadOptions<CredentialListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
    
        /// <summary>
        /// Construct a new ReadCredentialListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        public ReadCredentialListMappingOptions(string domainSid)
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

    public class FetchCredentialListMappingOptions : IOptions<CredentialListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchCredentialListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchCredentialListMappingOptions(string domainSid, string sid)
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

    public class DeleteCredentialListMappingOptions : IOptions<CredentialListMappingResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteCredentialListMappingOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteCredentialListMappingOptions(string domainSid, string sid)
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