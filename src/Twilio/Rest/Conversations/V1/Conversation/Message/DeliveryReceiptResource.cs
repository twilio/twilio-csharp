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
using Twilio.Types;




namespace Twilio.Rest.Conversations.V1.Conversation.Message
{
    public class DeliveryReceiptResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class DeliveryStatusEnum : StringEnum
        {
            private DeliveryStatusEnum(string value) : base(value) {}
            public DeliveryStatusEnum() {}
            public static implicit operator DeliveryStatusEnum(string value)
            {
                return new DeliveryStatusEnum(value);
            }
            public static readonly DeliveryStatusEnum Read = new DeliveryStatusEnum("read");
            public static readonly DeliveryStatusEnum Failed = new DeliveryStatusEnum("failed");
            public static readonly DeliveryStatusEnum Delivered = new DeliveryStatusEnum("delivered");
            public static readonly DeliveryStatusEnum Undelivered = new DeliveryStatusEnum("undelivered");
            public static readonly DeliveryStatusEnum Sent = new DeliveryStatusEnum("sent");

        }

        
        private static Request BuildFetchRequest(FetchDeliveryReceiptOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations/{ConversationSid}/Messages/{MessageSid}/Receipts/{Sid}";

            string PathConversationSid = options.PathConversationSid;
            path = path.Replace("{"+"ConversationSid"+"}", PathConversationSid);
            string PathMessageSid = options.PathMessageSid;
            path = path.Replace("{"+"MessageSid"+"}", PathMessageSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch the delivery and read receipts of the conversation message </summary>
        /// <param name="options"> Fetch DeliveryReceipt parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DeliveryReceipt </returns>
        public static DeliveryReceiptResource Fetch(FetchDeliveryReceiptOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch the delivery and read receipts of the conversation message </summary>
        /// <param name="options"> Fetch DeliveryReceipt parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DeliveryReceipt </returns>
        public static async System.Threading.Tasks.Task<DeliveryReceiptResource> FetchAsync(FetchDeliveryReceiptOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch the delivery and read receipts of the conversation message </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathMessageSid"> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DeliveryReceipt </returns>
        public static DeliveryReceiptResource Fetch(
                                         string pathConversationSid, 
                                         string pathMessageSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchDeliveryReceiptOptions(pathConversationSid, pathMessageSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch the delivery and read receipts of the conversation message </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathMessageSid"> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DeliveryReceipt </returns>
        public static async System.Threading.Tasks.Task<DeliveryReceiptResource> FetchAsync(string pathConversationSid, string pathMessageSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchDeliveryReceiptOptions(pathConversationSid, pathMessageSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadDeliveryReceiptOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations/{ConversationSid}/Messages/{MessageSid}/Receipts";

            string PathConversationSid = options.PathConversationSid;
            path = path.Replace("{"+"ConversationSid"+"}", PathConversationSid);
            string PathMessageSid = options.PathMessageSid;
            path = path.Replace("{"+"MessageSid"+"}", PathMessageSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all delivery and read receipts of the conversation message </summary>
        /// <param name="options"> Read DeliveryReceipt parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DeliveryReceipt </returns>
        public static ResourceSet<DeliveryReceiptResource> Read(ReadDeliveryReceiptOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<DeliveryReceiptResource>.FromJson("delivery_receipts", response.Content);
            return new ResourceSet<DeliveryReceiptResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all delivery and read receipts of the conversation message </summary>
        /// <param name="options"> Read DeliveryReceipt parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DeliveryReceipt </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DeliveryReceiptResource>> ReadAsync(ReadDeliveryReceiptOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DeliveryReceiptResource>.FromJson("delivery_receipts", response.Content);
            return new ResourceSet<DeliveryReceiptResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all delivery and read receipts of the conversation message </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathMessageSid"> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DeliveryReceipt </returns>
        public static ResourceSet<DeliveryReceiptResource> Read(
                                                     string pathConversationSid,
                                                     string pathMessageSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadDeliveryReceiptOptions(pathConversationSid, pathMessageSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all delivery and read receipts of the conversation message </summary>
        /// <param name="pathConversationSid"> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </param>
        /// <param name="pathMessageSid"> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DeliveryReceipt </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DeliveryReceiptResource>> ReadAsync(
                                                                                             string pathConversationSid,
                                                                                             string pathMessageSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadDeliveryReceiptOptions(pathConversationSid, pathMessageSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<DeliveryReceiptResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<DeliveryReceiptResource>.FromJson("delivery_receipts", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<DeliveryReceiptResource> NextPage(Page<DeliveryReceiptResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DeliveryReceiptResource>.FromJson("delivery_receipts", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<DeliveryReceiptResource> PreviousPage(Page<DeliveryReceiptResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DeliveryReceiptResource>.FromJson("delivery_receipts", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a DeliveryReceiptResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeliveryReceiptResource object represented by the provided JSON </returns>
        public static DeliveryReceiptResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DeliveryReceiptResource>(json);
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

    
        ///<summary> The unique ID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this participant. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this message. </summary> 
        [JsonProperty("conversation_sid")]
        public string ConversationSid { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the message within a [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) the delivery receipt belongs to </summary> 
        [JsonProperty("message_sid")]
        public string MessageSid { get; private set; }

        ///<summary> A messaging channel-specific identifier for the message delivered to participant e.g. `SMxx` for SMS, `WAxx` for Whatsapp etc.  </summary> 
        [JsonProperty("channel_message_sid")]
        public string ChannelMessageSid { get; private set; }

        ///<summary> The unique ID of the participant the delivery receipt belongs to. </summary> 
        [JsonProperty("participant_sid")]
        public string ParticipantSid { get; private set; }

        
        [JsonProperty("status")]
        public DeliveryReceiptResource.DeliveryStatusEnum Status { get; private set; }

        ///<summary> The message [delivery error code](https://www.twilio.com/docs/sms/api/message-resource#delivery-related-errors) for a `failed` status,  </summary> 
        [JsonProperty("error_code")]
        public int? ErrorCode { get; private set; }

        ///<summary> The date that this resource was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated. `null` if the delivery receipt has not been updated. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> An absolute API resource URL for this delivery receipt. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private DeliveryReceiptResource() {

        }
    }
}

