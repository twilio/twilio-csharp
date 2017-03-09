using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    /// <summary>
    /// Create a new token
    /// </summary>
    public class CreateTokenOptions : IOptions<TokenResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The duration in seconds the credentials are valid
        /// </summary>
        public int? Ttl { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.Value.ToString()));
            }

            return p;
        }
    }

}