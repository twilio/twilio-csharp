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




namespace Twilio.Rest.Conversations.V1.Conversation
{

    /// <summary> Add a new participant to the conversation </summary>
    public class CreateParticipantOptions : IOptions<ParticipantResource>
    {
        
        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </summary> 
        public string PathConversationSid { get; }

        ///<summary> The X-Twilio-Webhook-Enabled HTTP request header </summary> 
        public ParticipantResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

        ///<summary> A unique string identifier for the conversation participant as [Conversation User](https://www.twilio.com/docs/conversations/api/user-resource). This parameter is non-null if (and only if) the participant is using the Conversations SDK to communicate. Limited to 256 characters. </summary> 
        public string Identity { get; set; }

        ///<summary> The address of the participant's device, e.g. a phone or WhatsApp number. Together with the Proxy address, this determines a participant uniquely. This field (with proxy_address) is only null when the participant is interacting from an SDK endpoint (see the 'identity' field). </summary> 
        public string MessagingBindingAddress { get; set; }

        ///<summary> The address of the Twilio phone number (or WhatsApp number) that the participant is in contact with. This field, together with participant address, is only null when the participant is interacting from an SDK endpoint (see the 'identity' field). </summary> 
        public string MessagingBindingProxyAddress { get; set; }

        ///<summary> The date that this resource was created. </summary> 
        public DateTime? DateCreated { get; set; }

        ///<summary> The date that this resource was last updated. </summary> 
        public DateTime? DateUpdated { get; set; }

        ///<summary> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </summary> 
        public string Attributes { get; set; }

        ///<summary> The address of the Twilio phone number that is used in Group MMS. Communication mask for the Conversation participant with Identity. </summary> 
        public string MessagingBindingProjectedAddress { get; set; }

        ///<summary> The SID of a conversation-level [Role](https://www.twilio.com/docs/conversations/api/role-resource) to assign to the participant. </summary> 
        public string RoleSid { get; set; }


        /// <summary> Construct a new CreateConversationParticipantOptions </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </param>

        public CreateParticipantOptions(string pathConversationSid)
        {
            PathConversationSid = pathConversationSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            if (MessagingBindingAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingBindingAddress", MessagingBindingAddress));
            }
            if (MessagingBindingProxyAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingBindingProxyAddress", MessagingBindingProxyAddress));
            }
            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", Serializers.DateTimeIso8601(DateCreated)));
            }
            if (DateUpdated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateUpdated", Serializers.DateTimeIso8601(DateUpdated)));
            }
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            if (MessagingBindingProjectedAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingBindingProjectedAddress", MessagingBindingProjectedAddress));
            }
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid));
            }
            return p;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (XTwilioWebhookEnabled != null)
        {
            p.Add(new KeyValuePair<string, string>("X-Twilio-Webhook-Enabled", XTwilioWebhookEnabled.ToString()));
        }
        return p;
    }

    }
    /// <summary> Remove a participant from the conversation </summary>
    public class DeleteParticipantOptions : IOptions<ParticipantResource>
    {
        
        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </summary> 
        public string PathConversationSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }

        ///<summary> The X-Twilio-Webhook-Enabled HTTP request header </summary> 
        public ParticipantResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }



        /// <summary> Construct a new DeleteConversationParticipantOptions </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public DeleteParticipantOptions(string pathConversationSid, string pathSid)
        {
            PathConversationSid = pathConversationSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (XTwilioWebhookEnabled != null)
        {
            p.Add(new KeyValuePair<string, string>("X-Twilio-Webhook-Enabled", XTwilioWebhookEnabled.ToString()));
        }
        return p;
    }

    }


    /// <summary> Fetch a participant of the conversation </summary>
    public class FetchParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </summary> 
        public string PathConversationSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchConversationParticipantOptions </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public FetchParticipantOptions(string pathConversationSid, string pathSid)
        {
            PathConversationSid = pathConversationSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all participants of the conversation </summary>
    public class ReadParticipantOptions : ReadOptions<ParticipantResource>
    {
    
        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for participants. </summary> 
        public string PathConversationSid { get; }



        /// <summary> Construct a new ListConversationParticipantOptions </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for participants. </param>

        public ReadParticipantOptions(string pathConversationSid)
        {
            PathConversationSid = pathConversationSid;
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

    /// <summary> Update an existing participant in the conversation </summary>
    public class UpdateParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </summary> 
        public string PathConversationSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }

        ///<summary> The X-Twilio-Webhook-Enabled HTTP request header </summary> 
        public ParticipantResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

        ///<summary> The date that this resource was created. </summary> 
        public DateTime? DateCreated { get; set; }

        ///<summary> The date that this resource was last updated. </summary> 
        public DateTime? DateUpdated { get; set; }

        ///<summary> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </summary> 
        public string Attributes { get; set; }

        ///<summary> The SID of a conversation-level [Role](https://www.twilio.com/docs/conversations/api/role-resource) to assign to the participant. </summary> 
        public string RoleSid { get; set; }

        ///<summary> The address of the Twilio phone number that the participant is in contact with. 'null' value will remove it. </summary> 
        public string MessagingBindingProxyAddress { get; set; }

        ///<summary> The address of the Twilio phone number that is used in Group MMS. 'null' value will remove it. </summary> 
        public string MessagingBindingProjectedAddress { get; set; }

        ///<summary> A unique string identifier for the conversation participant as [Conversation User](https://www.twilio.com/docs/conversations/api/user-resource). This parameter is non-null if (and only if) the participant is using the Conversations SDK to communicate. Limited to 256 characters. </summary> 
        public string Identity { get; set; }

        ///<summary> Index of last “read” message in the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for the Participant. </summary> 
        public int? LastReadMessageIndex { get; set; }

        ///<summary> Timestamp of last “read” message in the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for the Participant. </summary> 
        public string LastReadTimestamp { get; set; }



        /// <summary> Construct a new UpdateConversationParticipantOptions </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this participant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public UpdateParticipantOptions(string pathConversationSid, string pathSid)
        {
            PathConversationSid = pathConversationSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", Serializers.DateTimeIso8601(DateCreated)));
            }
            if (DateUpdated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateUpdated", Serializers.DateTimeIso8601(DateUpdated)));
            }
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid));
            }
            if (MessagingBindingProxyAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingBindingProxyAddress", MessagingBindingProxyAddress));
            }
            if (MessagingBindingProjectedAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingBindingProjectedAddress", MessagingBindingProjectedAddress));
            }
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            if (LastReadMessageIndex != null)
            {
                p.Add(new KeyValuePair<string, string>("LastReadMessageIndex", LastReadMessageIndex.ToString()));
            }
            if (LastReadTimestamp != null)
            {
                p.Add(new KeyValuePair<string, string>("LastReadTimestamp", LastReadTimestamp));
            }
            return p;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (XTwilioWebhookEnabled != null)
        {
            p.Add(new KeyValuePair<string, string>("X-Twilio-Webhook-Enabled", XTwilioWebhookEnabled.ToString()));
        }
        return p;
    }

    }


}

