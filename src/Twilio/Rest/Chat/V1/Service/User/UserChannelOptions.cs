/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Chat
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Chat.V1.Service.User
{
    /// <summary> List all Channels for a given User. </summary>
    public class ReadUserChannelOptions : ReadOptions<UserChannelResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to read the resources from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the [User](https://www.twilio.com/docs/api/chat/rest/users) to read the User Channel resources from. </summary> 
        public string PathUserSid { get; }



        /// <summary> Construct a new ListUserChannelOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to read the resources from. </param>
        /// <param name="pathUserSid"> The SID of the [User](https://www.twilio.com/docs/api/chat/rest/users) to read the User Channel resources from. </param>

        public ReadUserChannelOptions(string pathServiceSid, string pathUserSid)
        {
            PathServiceSid = pathServiceSid;
            PathUserSid = pathUserSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
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

