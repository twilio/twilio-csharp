using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.IpMessaging.V1.Service.User 
{

    /// <summary>
    /// ReadUserChannelOptions
    /// </summary>
    public class ReadUserChannelOptions : ReadOptions<UserChannelResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The user_sid
        /// </summary>
        public string PathUserSid { get; }
    
        /// <summary>
        /// Construct a new ReadUserChannelOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="userSid"> The user_sid </param>
        public ReadUserChannelOptions(string serviceSid, string userSid)
        {
            PathServiceSid = serviceSid;
            PathUserSid = userSid;
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