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




namespace Twilio.Rest.Conversations.V1.Service.Conversation.Message
{
    /// <summary> Fetch the delivery and read receipts of the conversation message </summary>
    public class FetchDeliveryReceiptOptions : IOptions<DeliveryReceiptResource>
    {
    
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Message resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        public string PathConversationSid { get; }

        ///<summary> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </summary> 
        public string PathMessageSid { get; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceConversationMessageReceiptOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Message resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathMessageSid"> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>

        public FetchDeliveryReceiptOptions(string pathChatServiceSid, string pathConversationSid, string pathMessageSid, string pathSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            PathConversationSid = pathConversationSid;
            PathMessageSid = pathMessageSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all delivery and read receipts of the conversation message </summary>
    public class ReadDeliveryReceiptOptions : ReadOptions<DeliveryReceiptResource>
    {
    
        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Message resource is associated with. </summary> 
        public string PathChatServiceSid { get; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        public string PathConversationSid { get; }

        ///<summary> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </summary> 
        public string PathMessageSid { get; }



        /// <summary> Construct a new ListServiceConversationMessageReceiptOptions </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Message resource is associated with. </param>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathMessageSid"> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </param>

        public ReadDeliveryReceiptOptions(string pathChatServiceSid, string pathConversationSid, string pathMessageSid)
        {
            PathChatServiceSid = pathChatServiceSid;
            PathConversationSid = pathConversationSid;
            PathMessageSid = pathMessageSid;
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

