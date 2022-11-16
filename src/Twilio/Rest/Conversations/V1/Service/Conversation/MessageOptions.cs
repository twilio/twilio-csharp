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




namespace Twilio.Rest.Conversations.V1.Service.Conversation
{

    /// <summary> Add a new message to the conversation in a specific service </summary>
    public class CreateMessageOptions : IOptions<MessageResource>
    {
        
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        public string PathConversationSid { get; }

        ///<summary> The X-Twilio-Webhook-Enabled HTTP request header </summary> 
        public MessageResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

        ///<summary> The channel specific identifier of the message's author. Defaults to `system`. </summary> 
        public string Author { get; set; }

        ///<summary> The content of the message, can be up to 1,600 characters long. </summary> 
        public string Body { get; set; }

        ///<summary> The date that this resource was created. </summary> 
        public DateTime? DateCreated { get; set; }

        ///<summary> The date that this resource was last updated. `null` if the message has not been edited. </summary> 
        public DateTime? DateUpdated { get; set; }

        ///<summary> A string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </summary> 
        public string Attributes { get; set; }

        ///<summary> The Media SID to be attached to the new Message. </summary> 
        public string MediaSid { get; set; }


        /// <summary> Construct a new CreateServiceConversationMessageOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>

        public CreateMessageOptions(string pathChatServiceSid, string pathConversationSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            PathConversationSid = pathConversationSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Author != null)
            {
                p.Add(new KeyValuePair<string, string>("Author", Author));
            }
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
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
            if (MediaSid != null)
            {
                p.Add(new KeyValuePair<string, string>("MediaSid", MediaSid));
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
    /// <summary> Remove a message from the conversation </summary>
    public class DeleteMessageOptions : IOptions<MessageResource>
    {
        
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        public string PathConversationSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }

        ///<summary> The X-Twilio-Webhook-Enabled HTTP request header </summary> 
        public MessageResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }



        /// <summary> Construct a new DeleteServiceConversationMessageOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public DeleteMessageOptions(string pathChatServiceSid, string pathConversationSid, string pathSid)
        {
            PathChatServiceSid = pathChatServiceSid;
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


    /// <summary> Fetch a message from the conversation </summary>
    public class FetchMessageOptions : IOptions<MessageResource>
    {
    
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        public string PathConversationSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceConversationMessageOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public FetchMessageOptions(string pathChatServiceSid, string pathConversationSid, string pathSid)
        {
            PathChatServiceSid = pathChatServiceSid;
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


    /// <summary> Retrieve a list of all messages in the conversation </summary>
    public class ReadMessageOptions : ReadOptions<MessageResource>
    {
    
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for messages. </summary> 
        public string PathConversationSid { get; }

        ///<summary> The sort order of the returned messages. Can be: `asc` (ascending) or `desc` (descending), with `asc` as the default. </summary> 
        public MessageResource.OrderTypeEnum Order { get; set; }



        /// <summary> Construct a new ListServiceConversationMessageOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for messages. </param>

        public ReadMessageOptions(string pathChatServiceSid, string pathConversationSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            PathConversationSid = pathConversationSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Order != null)
            {
                p.Add(new KeyValuePair<string, string>("Order", Order.ToString()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Update an existing message in the conversation </summary>
    public class UpdateMessageOptions : IOptions<MessageResource>
    {
    
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        public string PathConversationSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }

        ///<summary> The X-Twilio-Webhook-Enabled HTTP request header </summary> 
        public MessageResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; set; }

        ///<summary> The channel specific identifier of the message's author. Defaults to `system`. </summary> 
        public string Author { get; set; }

        ///<summary> The content of the message, can be up to 1,600 characters long. </summary> 
        public string Body { get; set; }

        ///<summary> The date that this resource was created. </summary> 
        public DateTime? DateCreated { get; set; }

        ///<summary> The date that this resource was last updated. `null` if the message has not been edited. </summary> 
        public DateTime? DateUpdated { get; set; }

        ///<summary> A string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </summary> 
        public string Attributes { get; set; }



        /// <summary> Construct a new UpdateServiceConversationMessageOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Participant resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public UpdateMessageOptions(string pathChatServiceSid, string pathConversationSid, string pathSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            PathConversationSid = pathConversationSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Author != null)
            {
                p.Add(new KeyValuePair<string, string>("Author", Author));
            }
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
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

