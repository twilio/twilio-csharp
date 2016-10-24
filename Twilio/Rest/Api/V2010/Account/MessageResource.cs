using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class MessageResource : Resource {
        public sealed class Status : IStringEnum {
            public const string QUEUED="queued";
            public const string SENDING="sending";
            public const string SENT="sent";
            public const string FAILED="failed";
            public const string DELIVERED="delivered";
            public const string UNDELIVERED="undelivered";
            public const string RECEIVING="receiving";
            public const string RECEIVED="received";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class Direction : IStringEnum {
            public const string INBOUND="inbound";
            public const string OUTBOUND_API="outbound-api";
            public const string OUTBOUND_CALL="outbound-call";
            public const string OUTBOUND_REPLY="outbound-reply";
        
            private string value;
            
            public Direction() { }
            
            public Direction(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Direction(string value) {
                return new Direction(value);
            }
            
            public static implicit operator string(Direction value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            return new MessageCreator(accountSid, to, from, body);
        }
    
        /// <summary>
        /// Create a MessageCreator to execute create.
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, 
                                             Twilio.Types.PhoneNumber from, 
                                             string body) {
            return new MessageCreator(to, from, body);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            return new MessageCreator(accountSid, to, from, mediaUrl);
        }
    
        /// <summary>
        /// Create a MessageCreator to execute create.
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, 
                                             Twilio.Types.PhoneNumber from, 
                                             List<Uri> mediaUrl) {
            return new MessageCreator(to, from, mediaUrl);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(string accountSid, Twilio.Types.PhoneNumber to, string messagingServiceSid, string body) {
            return new MessageCreator(accountSid, to, messagingServiceSid, body);
        }
    
        /// <summary>
        /// Create a MessageCreator to execute create.
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, 
                                             string messagingServiceSid, 
                                             string body) {
            return new MessageCreator(to, messagingServiceSid, body);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(string accountSid, Twilio.Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl) {
            return new MessageCreator(accountSid, to, messagingServiceSid, mediaUrl);
        }
    
        /// <summary>
        /// Create a MessageCreator to execute create.
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Twilio.Types.PhoneNumber to, 
                                             string messagingServiceSid, 
                                             List<Uri> mediaUrl) {
            return new MessageCreator(to, messagingServiceSid, mediaUrl);
        }
    
        /// <summary>
        /// Deletes a message record from your account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The message to delete </param>
        /// <returns> MessageDeleter capable of executing the delete </returns> 
        public static MessageDeleter Deleter(string accountSid, string sid) {
            return new MessageDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a MessageDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The message to delete </param>
        /// <returns> MessageDeleter capable of executing the delete </returns> 
        public static MessageDeleter Deleter(string sid) {
            return new MessageDeleter(sid);
        }
    
        /// <summary>
        /// Fetch a message belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique message Sid </param>
        /// <returns> MessageFetcher capable of executing the fetch </returns> 
        public static MessageFetcher Fetcher(string accountSid, string sid) {
            return new MessageFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a MessageFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique message Sid </param>
        /// <returns> MessageFetcher capable of executing the fetch </returns> 
        public static MessageFetcher Fetcher(string sid) {
            return new MessageFetcher(sid);
        }
    
        /// <summary>
        /// Retrieve a list of messages belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> MessageReader capable of executing the read </returns> 
        public static MessageReader Reader(string accountSid) {
            return new MessageReader(accountSid);
        }
    
        /// <summary>
        /// Create a MessageReader to execute read.
        /// </summary>
        ///
        /// <returns> MessageReader capable of executing the read </returns> 
        public static MessageReader Reader() {
            return new MessageReader();
        }
    
        /// <summary>
        /// To redact a message-body from a post-flight message record, post to the message instance resource with an empty body
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The message to redact </param>
        /// <returns> MessageUpdater capable of executing the update </returns> 
        public static MessageUpdater Updater(string accountSid, string sid) {
            return new MessageUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a MessageUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The message to redact </param>
        /// <returns> MessageUpdater capable of executing the update </returns> 
        public static MessageUpdater Updater(string sid) {
            return new MessageUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a MessageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MessageResource object represented by the provided JSON </returns> 
        public static MessageResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<MessageResource>(json);
            } catch (JsonException e) {
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
    
        public MessageResource() {
        
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
                                string uri) {
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