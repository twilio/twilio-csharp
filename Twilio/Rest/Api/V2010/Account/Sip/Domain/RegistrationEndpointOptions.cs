using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class ReadRegistrationEndpointOptions : ReadOptions<RegistrationEndpointResource> 
    {
        public string AccountSid { get; set; }
        public string DomainSid { get; }
        public string Region { get; }
        public string Registrant { get; }
    
        /// <summary>
        /// Construct a new ReadRegistrationEndpointOptions
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="region"> The region </param>
        /// <param name="registrant"> The registrant </param>
        public ReadRegistrationEndpointOptions(string domainSid, string region, string registrant)
        {
            DomainSid = domainSid;
            Region = region;
            Registrant = registrant;
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