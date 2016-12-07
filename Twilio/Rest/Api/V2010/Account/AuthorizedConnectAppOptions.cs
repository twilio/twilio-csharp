using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchAuthorizedConnectAppOptions : IOptions<AuthorizedConnectAppResource> 
    {
        public string AccountSid { get; set; }
        public string ConnectAppSid { get; }
    
        /// <summary>
        /// Construct a new FetchAuthorizedConnectAppOptions
        /// </summary>
        ///
        /// <param name="connectAppSid"> The connect_app_sid </param>
        public FetchAuthorizedConnectAppOptions(string connectAppSid)
        {
            ConnectAppSid = connectAppSid;
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

    public class ReadAuthorizedConnectAppOptions : ReadOptions<AuthorizedConnectAppResource> 
    {
        public string AccountSid { get; set; }
    
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