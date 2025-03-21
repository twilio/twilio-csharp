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


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Conversations.V1.Service.Configuration
{
    public class NotificationResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchNotificationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Configuration/Notifications";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch push notification service settings </summary>
        /// <param name="options"> Fetch Notification parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Notification </returns>
        public static NotificationResource Fetch(FetchNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch push notification service settings </summary>
        /// <param name="options"> Fetch Notification parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Notification </returns>
        public static async System.Threading.Tasks.Task<NotificationResource> FetchAsync(FetchNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch push notification service settings </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Configuration applies to. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Notification </returns>
        public static NotificationResource Fetch(
                                         string pathChatServiceSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchNotificationOptions(pathChatServiceSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch push notification service settings </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Configuration applies to. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Notification </returns>
        public static async System.Threading.Tasks.Task<NotificationResource> FetchAsync(string pathChatServiceSid, ITwilioRestClient client = null)
        {
            var options = new FetchNotificationOptions(pathChatServiceSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateNotificationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Configuration/Notifications";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update push notification service settings </summary>
        /// <param name="options"> Update Notification parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Notification </returns>
        public static NotificationResource Update(UpdateNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update push notification service settings </summary>
        /// <param name="options"> Update Notification parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Notification </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<NotificationResource> UpdateAsync(UpdateNotificationOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update push notification service settings </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Configuration applies to. </param>
        /// <param name="logEnabled"> Weather the notification logging is enabled. </param>
        /// <param name="newMessageEnabled"> Whether to send a notification when a new message is added to a conversation. The default is `false`. </param>
        /// <param name="newMessageTemplate"> The template to use to create the notification text displayed when a new message is added to a conversation and `new_message.enabled` is `true`. </param>
        /// <param name="newMessageSound"> The name of the sound to play when a new message is added to a conversation and `new_message.enabled` is `true`. </param>
        /// <param name="newMessageBadgeCountEnabled"> Whether the new message badge is enabled. The default is `false`. </param>
        /// <param name="addedToConversationEnabled"> Whether to send a notification when a participant is added to a conversation. The default is `false`. </param>
        /// <param name="addedToConversationTemplate"> The template to use to create the notification text displayed when a participant is added to a conversation and `added_to_conversation.enabled` is `true`. </param>
        /// <param name="addedToConversationSound"> The name of the sound to play when a participant is added to a conversation and `added_to_conversation.enabled` is `true`. </param>
        /// <param name="removedFromConversationEnabled"> Whether to send a notification to a user when they are removed from a conversation. The default is `false`. </param>
        /// <param name="removedFromConversationTemplate"> The template to use to create the notification text displayed to a user when they are removed from a conversation and `removed_from_conversation.enabled` is `true`. </param>
        /// <param name="removedFromConversationSound"> The name of the sound to play to a user when they are removed from a conversation and `removed_from_conversation.enabled` is `true`. </param>
        /// <param name="newMessageWithMediaEnabled"> Whether to send a notification when a new message with media/file attachments is added to a conversation. The default is `false`. </param>
        /// <param name="newMessageWithMediaTemplate"> The template to use to create the notification text displayed when a new message with media/file attachments is added to a conversation and `new_message.attachments.enabled` is `true`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Notification </returns>
        public static NotificationResource Update(
                                          string pathChatServiceSid,
                                          bool? logEnabled = null,
                                          bool? newMessageEnabled = null,
                                          string newMessageTemplate = null,
                                          string newMessageSound = null,
                                          bool? newMessageBadgeCountEnabled = null,
                                          bool? addedToConversationEnabled = null,
                                          string addedToConversationTemplate = null,
                                          string addedToConversationSound = null,
                                          bool? removedFromConversationEnabled = null,
                                          string removedFromConversationTemplate = null,
                                          string removedFromConversationSound = null,
                                          bool? newMessageWithMediaEnabled = null,
                                          string newMessageWithMediaTemplate = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateNotificationOptions(pathChatServiceSid){ LogEnabled = logEnabled, NewMessageEnabled = newMessageEnabled, NewMessageTemplate = newMessageTemplate, NewMessageSound = newMessageSound, NewMessageBadgeCountEnabled = newMessageBadgeCountEnabled, AddedToConversationEnabled = addedToConversationEnabled, AddedToConversationTemplate = addedToConversationTemplate, AddedToConversationSound = addedToConversationSound, RemovedFromConversationEnabled = removedFromConversationEnabled, RemovedFromConversationTemplate = removedFromConversationTemplate, RemovedFromConversationSound = removedFromConversationSound, NewMessageWithMediaEnabled = newMessageWithMediaEnabled, NewMessageWithMediaTemplate = newMessageWithMediaTemplate };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update push notification service settings </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Configuration applies to. </param>
        /// <param name="logEnabled"> Weather the notification logging is enabled. </param>
        /// <param name="newMessageEnabled"> Whether to send a notification when a new message is added to a conversation. The default is `false`. </param>
        /// <param name="newMessageTemplate"> The template to use to create the notification text displayed when a new message is added to a conversation and `new_message.enabled` is `true`. </param>
        /// <param name="newMessageSound"> The name of the sound to play when a new message is added to a conversation and `new_message.enabled` is `true`. </param>
        /// <param name="newMessageBadgeCountEnabled"> Whether the new message badge is enabled. The default is `false`. </param>
        /// <param name="addedToConversationEnabled"> Whether to send a notification when a participant is added to a conversation. The default is `false`. </param>
        /// <param name="addedToConversationTemplate"> The template to use to create the notification text displayed when a participant is added to a conversation and `added_to_conversation.enabled` is `true`. </param>
        /// <param name="addedToConversationSound"> The name of the sound to play when a participant is added to a conversation and `added_to_conversation.enabled` is `true`. </param>
        /// <param name="removedFromConversationEnabled"> Whether to send a notification to a user when they are removed from a conversation. The default is `false`. </param>
        /// <param name="removedFromConversationTemplate"> The template to use to create the notification text displayed to a user when they are removed from a conversation and `removed_from_conversation.enabled` is `true`. </param>
        /// <param name="removedFromConversationSound"> The name of the sound to play to a user when they are removed from a conversation and `removed_from_conversation.enabled` is `true`. </param>
        /// <param name="newMessageWithMediaEnabled"> Whether to send a notification when a new message with media/file attachments is added to a conversation. The default is `false`. </param>
        /// <param name="newMessageWithMediaTemplate"> The template to use to create the notification text displayed when a new message with media/file attachments is added to a conversation and `new_message.attachments.enabled` is `true`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Notification </returns>
        public static async System.Threading.Tasks.Task<NotificationResource> UpdateAsync(
                                                                              string pathChatServiceSid,
                                                                              bool? logEnabled = null,
                                                                              bool? newMessageEnabled = null,
                                                                              string newMessageTemplate = null,
                                                                              string newMessageSound = null,
                                                                              bool? newMessageBadgeCountEnabled = null,
                                                                              bool? addedToConversationEnabled = null,
                                                                              string addedToConversationTemplate = null,
                                                                              string addedToConversationSound = null,
                                                                              bool? removedFromConversationEnabled = null,
                                                                              string removedFromConversationTemplate = null,
                                                                              string removedFromConversationSound = null,
                                                                              bool? newMessageWithMediaEnabled = null,
                                                                              string newMessageWithMediaTemplate = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateNotificationOptions(pathChatServiceSid){ LogEnabled = logEnabled, NewMessageEnabled = newMessageEnabled, NewMessageTemplate = newMessageTemplate, NewMessageSound = newMessageSound, NewMessageBadgeCountEnabled = newMessageBadgeCountEnabled, AddedToConversationEnabled = addedToConversationEnabled, AddedToConversationTemplate = addedToConversationTemplate, AddedToConversationSound = addedToConversationSound, RemovedFromConversationEnabled = removedFromConversationEnabled, RemovedFromConversationTemplate = removedFromConversationTemplate, RemovedFromConversationSound = removedFromConversationSound, NewMessageWithMediaEnabled = newMessageWithMediaEnabled, NewMessageWithMediaTemplate = newMessageWithMediaTemplate };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns>
        public static NotificationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The unique ID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this configuration. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Configuration applies to. </summary> 
        [JsonProperty("chat_service_sid")]
        public string ChatServiceSid { get; private set; }

        ///<summary> The Push Notification configuration for New Messages. </summary> 
        [JsonProperty("new_message")]
        public object NewMessage { get; private set; }

        ///<summary> The Push Notification configuration for being added to a Conversation. </summary> 
        [JsonProperty("added_to_conversation")]
        public object AddedToConversation { get; private set; }

        ///<summary> The Push Notification configuration for being removed from a Conversation. </summary> 
        [JsonProperty("removed_from_conversation")]
        public object RemovedFromConversation { get; private set; }

        ///<summary> Weather the notification logging is enabled. </summary> 
        [JsonProperty("log_enabled")]
        public bool? LogEnabled { get; private set; }

        ///<summary> An absolute API resource URL for this configuration. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private NotificationResource() {

        }
    }
}

