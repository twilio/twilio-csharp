using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class CreateCredentialListMappingOptions : IOptions<CredentialListMappingResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The domain_sid
        /// </summary>
        public string DomainSid { get; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("CredentialListSid", CredentialListSid.ToString()));
            }
            
            return p;
        }
    }

    public class ReadCredentialListMappingOptions : ReadOptions<CredentialListMappingResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The domain_sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The domain_sid
        /// </summary>
        public string DomainSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The domain_sid
        /// </summary>
        public string DomainSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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