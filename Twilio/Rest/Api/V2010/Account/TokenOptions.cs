using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CreateTokenOptions : IOptions<TokenResource> 
    {
        public string AccountSid { get; set; }
        public int? Ttl { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.ToString()));
            }
            
            return p;
        }
    }

}