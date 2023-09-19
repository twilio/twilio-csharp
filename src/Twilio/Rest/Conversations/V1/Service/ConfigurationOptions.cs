/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Conversations
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




namespace Twilio.Rest.Conversations.V1.Service
{
    /// <summary> Fetch the configuration of a conversation service </summary>
    public class FetchConfigurationOptions : IOptions<ConfigurationResource>
    {
    
        ///<summary> The SID of the Service configuration resource to fetch. </summary> 
        public string PathChatServiceSid { get; }



        /// <summary> Construct a new FetchServiceConfigurationOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the Service configuration resource to fetch. </param>
        public FetchConfigurationOptions(string pathChatServiceSid)
        {
            PathChatServiceSid = pathChatServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Update configuration settings of a conversation service </summary>
    public class UpdateConfigurationOptions : IOptions<ConfigurationResource>
    {
    
        ///<summary> The SID of the Service configuration resource to update. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The conversation-level role assigned to a conversation creator when they join a new conversation. See [Conversation Role](https://www.twilio.com/docs/conversations/api/role-resource) for more info about roles. </summary> 
        public string DefaultConversationCreatorRoleSid { get; set; }

        ///<summary> The conversation-level role assigned to users when they are added to a conversation. See [Conversation Role](https://www.twilio.com/docs/conversations/api/role-resource) for more info about roles. </summary> 
        public string DefaultConversationRoleSid { get; set; }

        ///<summary> The service-level role assigned to users when they are added to the service. See [Conversation Role](https://www.twilio.com/docs/conversations/api/role-resource) for more info about roles. </summary> 
        public string DefaultChatServiceRoleSid { get; set; }

        ///<summary> Whether the [Reachability Indicator](https://www.twilio.com/docs/conversations/reachability) is enabled for this Conversations Service. The default is `false`. </summary> 
        public bool? ReachabilityEnabled { get; set; }



        /// <summary> Construct a new UpdateServiceConfigurationOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the Service configuration resource to update. </param>
        public UpdateConfigurationOptions(string pathChatServiceSid)
        {
            PathChatServiceSid = pathChatServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DefaultConversationCreatorRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultConversationCreatorRoleSid", DefaultConversationCreatorRoleSid));
            }
            if (DefaultConversationRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultConversationRoleSid", DefaultConversationRoleSid));
            }
            if (DefaultChatServiceRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChatServiceRoleSid", DefaultChatServiceRoleSid));
            }
            if (ReachabilityEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityEnabled", ReachabilityEnabled.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


}

