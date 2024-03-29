/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Bulk Messaging and Broadcast
 * Bulk Sending is a public Twilio REST API for 1:Many Message creation up to 100 recipients. Broadcast is a public Twilio REST API for 1:Many Message creation up to 10,000 recipients via file upload.
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



namespace Twilio.Rest.PreviewMessaging.V1
{
    public class MessageResource : Resource
    {
    
        public class MessagingV1Message
        {
            [JsonConverter(typeof(PhoneNumberConverter))]
            [JsonProperty("To")]
            private Types.PhoneNumber To {get; set;}
            [JsonProperty("Body")]
            private string Body {get; set;}
            [JsonProperty("ContentVariables")]
            private Dictionary<string, string> ContentVariables {get; set;}
            public MessagingV1Message() { }
            public class Builder
            {
                private MessagingV1Message _messagingV1Message = new MessagingV1Message();
                public Builder()
                {
                }
                public Builder WithTo(Types.PhoneNumber to)
                {
                    _messagingV1Message.To= to;
                    return this;
                }
                public Builder WithBody(string body)
                {
                    _messagingV1Message.Body= body;
                    return this;
                }
                public Builder WithContentVariables(Dictionary<string, string> contentVariables)
                {
                    _messagingV1Message.ContentVariables= contentVariables;
                    return this;
                }
                public MessagingV1Message Build()
                {
                    return _messagingV1Message;
                }
            }
        }
        public class CreateMessagesRequest
        {
            [JsonProperty("Messages")]
            private List<MessagingV1Message> Messages {get; set;}
            [JsonConverter(typeof(PhoneNumberConverter))]
            [JsonProperty("From")]
            private Types.PhoneNumber From {get; set;}
            [JsonProperty("MessagingServiceSid")]
            private string MessagingServiceSid {get; set;}
            [JsonProperty("Body")]
            private string Body {get; set;}
            [JsonProperty("ContentSid")]
            private string ContentSid {get; set;}
            [JsonProperty("MediaUrl")]
            private List<Uri> MediaUrl {get; set;}
            [JsonProperty("StatusCallback")]
            private Uri StatusCallback {get; set;}
            [JsonProperty("ValidityPeriod")]
            private int? ValidityPeriod {get; set;}
            [JsonProperty("SendAt")]
            private string SendAt {get; set;}
            [JsonProperty("ScheduleType")]
            private string ScheduleType {get; set;}
            [JsonProperty("ShortenUrls")]
            private bool? ShortenUrls {get; set;}
            [JsonProperty("SendAsMms")]
            private bool? SendAsMms {get; set;}
            [JsonProperty("MaxPrice")]
            private decimal? MaxPrice {get; set;}
            [JsonProperty("Attempt")]
            private int? Attempt {get; set;}
            [JsonProperty("SmartEncoded")]
            private bool? SmartEncoded {get; set;}
            [JsonProperty("ForceDelivery")]
            private bool? ForceDelivery {get; set;}
            [JsonProperty("ApplicationSid")]
            private string ApplicationSid {get; set;}
            public CreateMessagesRequest() { }
            public class Builder
            {
                private CreateMessagesRequest _createMessagesRequest = new CreateMessagesRequest();
                public Builder()
                {
                }
                public Builder WithMessages(List<MessagingV1Message> messages)
                {
                    _createMessagesRequest.Messages= messages;
                    return this;
                }
                public Builder WithFrom(Types.PhoneNumber from)
                {
                    _createMessagesRequest.From= from;
                    return this;
                }
                public Builder WithMessagingServiceSid(string messagingServiceSid)
                {
                    _createMessagesRequest.MessagingServiceSid= messagingServiceSid;
                    return this;
                }
                public Builder WithBody(string body)
                {
                    _createMessagesRequest.Body= body;
                    return this;
                }
                public Builder WithContentSid(string contentSid)
                {
                    _createMessagesRequest.ContentSid= contentSid;
                    return this;
                }
                public Builder WithMediaUrl(List<Uri> mediaUrl)
                {
                    _createMessagesRequest.MediaUrl= mediaUrl;
                    return this;
                }
                public Builder WithStatusCallback(Uri statusCallback)
                {
                    _createMessagesRequest.StatusCallback= statusCallback;
                    return this;
                }
                public Builder WithValidityPeriod(int? validityPeriod)
                {
                    _createMessagesRequest.ValidityPeriod= validityPeriod;
                    return this;
                }
                public Builder WithSendAt(string sendAt)
                {
                    _createMessagesRequest.SendAt= sendAt;
                    return this;
                }
                public Builder WithScheduleType(string scheduleType)
                {
                    _createMessagesRequest.ScheduleType= scheduleType;
                    return this;
                }
                public Builder WithShortenUrls(bool? shortenUrls)
                {
                    _createMessagesRequest.ShortenUrls= shortenUrls;
                    return this;
                }
                public Builder WithSendAsMms(bool? sendAsMms)
                {
                    _createMessagesRequest.SendAsMms= sendAsMms;
                    return this;
                }
                public Builder WithMaxPrice(decimal? maxPrice)
                {
                    _createMessagesRequest.MaxPrice= maxPrice;
                    return this;
                }
                public Builder WithAttempt(int? attempt)
                {
                    _createMessagesRequest.Attempt= attempt;
                    return this;
                }
                public Builder WithSmartEncoded(bool? smartEncoded)
                {
                    _createMessagesRequest.SmartEncoded= smartEncoded;
                    return this;
                }
                public Builder WithForceDelivery(bool? forceDelivery)
                {
                    _createMessagesRequest.ForceDelivery= forceDelivery;
                    return this;
                }
                public Builder WithApplicationSid(string applicationSid)
                {
                    _createMessagesRequest.ApplicationSid= applicationSid;
                    return this;
                }
                public CreateMessagesRequest Build()
                {
                    return _createMessagesRequest;
                }
            }
        }
        public class MessagingV1MessageReceipt
        {
            [JsonProperty("to")]
            private string To {get; set;}
            [JsonProperty("sid")]
            private string Sid {get; set;}
            public MessagingV1MessageReceipt() { }
            public class Builder
            {
                private MessagingV1MessageReceipt _messagingV1MessageReceipt = new MessagingV1MessageReceipt();
                public Builder()
                {
                }
                public Builder WithTo(string to)
                {
                    _messagingV1MessageReceipt.To= to;
                    return this;
                }
                public Builder WithSid(string sid)
                {
                    _messagingV1MessageReceipt.Sid= sid;
                    return this;
                }
                public MessagingV1MessageReceipt Build()
                {
                    return _messagingV1MessageReceipt;
                }
            }
        }
        public class MessagingV1FailedMessageReceipt
        {
            [JsonProperty("to")]
            private string To {get; set;}
            [JsonProperty("error_message")]
            private string ErrorMessage {get; set;}
            [JsonProperty("error_code")]
            private int? ErrorCode {get; set;}
            public MessagingV1FailedMessageReceipt() { }
            public class Builder
            {
                private MessagingV1FailedMessageReceipt _messagingV1FailedMessageReceipt = new MessagingV1FailedMessageReceipt();
                public Builder()
                {
                }
                public Builder WithTo(string to)
                {
                    _messagingV1FailedMessageReceipt.To= to;
                    return this;
                }
                public Builder WithErrorMessage(string errorMessage)
                {
                    _messagingV1FailedMessageReceipt.ErrorMessage= errorMessage;
                    return this;
                }
                public Builder WithErrorCode(int? errorCode)
                {
                    _messagingV1FailedMessageReceipt.ErrorCode= errorCode;
                    return this;
                }
                public MessagingV1FailedMessageReceipt Build()
                {
                    return _messagingV1FailedMessageReceipt;
                }
            }
        }

    

        
        private static Request BuildCreateRequest(CreateMessageOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Messages";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.PreviewMessaging,
                path,
                
                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> Send messages to multiple recipients </summary>
        /// <param name="options"> Create Message parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Message </returns>
        public static MessageResource Create(CreateMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Send messages to multiple recipients </summary>
        /// <param name="options"> Create Message parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Message </returns>
        public static async System.Threading.Tasks.Task<MessageResource> CreateAsync(CreateMessageOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Send messages to multiple recipients </summary>
        /// <param name="createMessagesRequest">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Message </returns>
        public static MessageResource Create(
                                          MessageResource.CreateMessagesRequest createMessagesRequest,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateMessageOptions(createMessagesRequest){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Send messages to multiple recipients </summary>
        /// <param name="createMessagesRequest">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Message </returns>
        public static async System.Threading.Tasks.Task<MessageResource> CreateAsync(
                                                                                  MessageResource.CreateMessagesRequest createMessagesRequest,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateMessageOptions(createMessagesRequest){  };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a MessageResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MessageResource object represented by the provided JSON </returns>
        public static MessageResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageResource>(json);
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

    
        ///<summary> The number of Messages processed in the request, equal to the sum of success_count and error_count. </summary> 
        [JsonProperty("total_message_count")]
        public int? TotalMessageCount { get; private set; }

        ///<summary> The number of Messages successfully created. </summary> 
        [JsonProperty("success_count")]
        public int? SuccessCount { get; private set; }

        ///<summary> The number of Messages unsuccessfully processed in the request. </summary> 
        [JsonProperty("error_count")]
        public int? ErrorCount { get; private set; }

        ///<summary> The message_receipts </summary> 
        [JsonProperty("message_receipts")]
        public List<MessagingV1MessageReceipt> MessageReceipts { get; private set; }

        ///<summary> The failed_message_receipts </summary> 
        [JsonProperty("failed_message_receipts")]
        public List<MessagingV1FailedMessageReceipt> FailedMessageReceipts { get; private set; }

        ///<summary> The Twilio error code </summary> 
        [JsonProperty("code")]
        public int? Code { get; private set; }

        ///<summary> The error message details </summary> 
        [JsonProperty("message")]
        public string Message { get; private set; }

        ///<summary> The HTTP status code </summary> 
        [JsonProperty("status")]
        public int? Status { get; private set; }

        ///<summary> More information on the error </summary> 
        [JsonProperty("more_info")]
        public string MoreInfo { get; private set; }



        private MessageResource() {

        }
    }
}

