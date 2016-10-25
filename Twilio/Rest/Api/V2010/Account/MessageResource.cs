using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class MessageResource : Resource 
    {
        public sealed class Status : IStringEnum 
        {
            public const string Queued = "queued";
            public const string Sending = "sending";
            public const string Sent = "sent";
            public const string Failed = "failed";
            public const string Delivered = "delivered";
            public const string Undelivered = "undelivered";
            public const string Receiving = "receiving";
            public const string Received = "received";
        
            private string _value;
            
            public Status() {}
            
            public Status(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Status(string value)
            {
                return new Status(value);
            }
            
            public static implicit operator string(Status value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class Direction : IStringEnum 
        {
            public const string Inbound = "inbound";
            public const string OutboundApi = "outbound-api";
            public const string OutboundCall = "outbound-call";
            public const string OutboundReply = "outbound-reply";
        
            private string _value;
            
            public Direction() {}
            
            public Direction(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Direction(string value)
            {
                return new Direction(value);
            }
            
            public static implicit operator string(Direction value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body, string accountSid=null, string messagingServiceSid=null, List<Uri> mediaUrl=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            return new MessageCreator(to, from, body, accountSid:accountSid, messagingServiceSid:messagingServiceSid, mediaUrl:mediaUrl, statusCallback:statusCallback, applicationSid:applicationSid, maxPrice:maxPrice, provideFeedback:provideFeedback);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl, string accountSid=null, string messagingServiceSid=null, string body=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            return new MessageCreator(to, from, mediaUrl, accountSid:accountSid, messagingServiceSid:messagingServiceSid, body:body, statusCallback:statusCallback, applicationSid:applicationSid, maxPrice:maxPrice, provideFeedback:provideFeedback);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, string messagingServiceSid, string body, string accountSid=null, Twilio.Types.PhoneNumber from=null, List<Uri> mediaUrl=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            return new MessageCreator(to, messagingServiceSid, body, accountSid:accountSid, from:from, mediaUrl:mediaUrl, statusCallback:statusCallback, applicationSid:applicationSid, maxPrice:maxPrice, provideFeedback:provideFeedback);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <param name="statusCallback"> URL Twilio will request when the status changes </param>
        /// <param name="applicationSid"> The application to use for callbacks </param>
        /// <param name="maxPrice"> The max_price </param>
        /// <param name="provideFeedback"> The provide_feedback </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl, string accountSid=null, Twilio.Types.PhoneNumber from=null, string body=null, Uri statusCallback=null, string applicationSid=null, decimal? maxPrice=null, bool? provideFeedback=null)
        {
            return new MessageCreator(to, messagingServiceSid, mediaUrl, accountSid:accountSid, from:from, body:body, statusCallback:statusCallback, applicationSid:applicationSid, maxPrice:maxPrice, provideFeedback:provideFeedback);
        }
    
        /// <summary>
        /// Deletes a message record from your account
        /// </summary>
        ///
        /// <param name="sid"> The message to delete </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> MessageDeleter capable of executing the delete </returns> 
        public static MessageDeleter Deleter(string sid, string accountSid=null)
        {
            return new MessageDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Fetch a message belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique message Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> MessageFetcher capable of executing the fetch </returns> 
        public static MessageFetcher Fetcher(string sid, string accountSid=null)
        {
            return new MessageFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieve a list of messages belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> Filter by messages to this number </param>
        /// <param name="from"> Filter by from number </param>
        /// <param name="dateSent"> Filter by date sent </param>
        /// <returns> MessageReader capable of executing the read </returns> 
        public static MessageReader Reader(string accountSid=null, Twilio.Types.PhoneNumber to=null, Twilio.Types.PhoneNumber from=null, string dateSent=null)
        {
            return new MessageReader(accountSid:accountSid, to:to, from:from, dateSent:dateSent);
        }
    
        /// <summary>
        /// To redact a message-body from a post-flight message record, post to the message instance resource with an empty body
        /// </summary>
        ///
        /// <param name="sid"> The message to redact </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageUpdater capable of executing the update </returns> 
        public static MessageUpdater Updater(string sid, string accountSid=null, string body=null)
        {
            return new MessageUpdater(sid, accountSid:accountSid, body:body);
        }
    
        /// <summary>
        /// Converts a JSON string into a MessageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MessageResource object represented by the provided JSON </returns> 
        public static MessageResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MessageResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("body")]
        public string body { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("date_sent")]
        public DateTime? dateSent { get; }
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResource.Direction direction { get; }
        [JsonProperty("error_code")]
        public int? errorCode { get; }
        [JsonProperty("error_message")]
        public string errorMessage { get; }
        [JsonProperty("from")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber from { get; }
        [JsonProperty("num_media")]
        public string numMedia { get; }
        [JsonProperty("num_segments")]
        public string numSegments { get; }
        [JsonProperty("price")]
        public decimal? price { get; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResource.Status status { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
        [JsonProperty("to")]
        public string to { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public MessageResource()
        {
        
        }
    
        private MessageResource([JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("api_version")]
                                string apiVersion, 
                                [JsonProperty("body")]
                                string body, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("date_sent")]
                                string dateSent, 
                                [JsonProperty("direction")]
                                MessageResource.Direction direction, 
                                [JsonProperty("error_code")]
                                int? errorCode, 
                                [JsonProperty("error_message")]
                                string errorMessage, 
                                [JsonProperty("from")]
                                Twilio.Types.PhoneNumber from, 
                                [JsonProperty("num_media")]
                                string numMedia, 
                                [JsonProperty("num_segments")]
                                string numSegments, 
                                [JsonProperty("price")]
                                decimal? price, 
                                [JsonProperty("price_unit")]
                                string priceUnit, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("status")]
                                MessageResource.Status status, 
                                [JsonProperty("subresource_uris")]
                                Dictionary<string, string> subresourceUris, 
                                [JsonProperty("to")]
                                string to, 
                                [JsonProperty("uri")]
                                string uri)
                                {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.body = body;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.dateSent = MarshalConverter.DateTimeFromString(dateSent);
            this.direction = direction;
            this.errorCode = errorCode;
            this.errorMessage = errorMessage;
            this.from = from;
            this.numMedia = numMedia;
            this.numSegments = numSegments;
            this.price = price;
            this.priceUnit = priceUnit;
            this.sid = sid;
            this.status = status;
            this.subresourceUris = subresourceUris;
            this.to = to;
            this.uri = uri;
        }
    }
}