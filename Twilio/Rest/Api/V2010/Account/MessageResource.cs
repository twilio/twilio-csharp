using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class MessageResource : SidResource {
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
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("body")]
        private readonly string body;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("date_sent")]
        private readonly DateTime? dateSent;
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly MessageResource.Direction direction;
        [JsonProperty("error_code")]
        private readonly int? errorCode;
        [JsonProperty("error_message")]
        private readonly string errorMessage;
        [JsonProperty("from")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber from;
        [JsonProperty("num_media")]
        private readonly string numMedia;
        [JsonProperty("num_segments")]
        private readonly string numSegments;
        [JsonProperty("price")]
        private readonly decimal? price;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly MessageResource.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("to")]
        private readonly string to;
        [JsonProperty("uri")]
        private readonly string uri;
    
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The version of the Twilio API used to process the message. </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The text body of the message. Up to 1600 characters long. </returns> 
        public string GetBody() {
            return this.body;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The date the message was sent </returns> 
        public DateTime? GetDateSent() {
            return this.dateSent;
        }
    
        /// <returns> The direction of the message </returns> 
        public MessageResource.Direction GetDirection() {
            return this.direction;
        }
    
        /// <returns> The error code associated with the message </returns> 
        public int? GetErrorCode() {
            return this.errorCode;
        }
    
        /// <returns> Human readable description of the ErrorCode </returns> 
        public string GetErrorMessage() {
            return this.errorMessage;
        }
    
        /// <returns> The phone number that initiated the message </returns> 
        public Twilio.Types.PhoneNumber GetFrom() {
            return this.from;
        }
    
        /// <returns> Number of media files associated with the message </returns> 
        public string GetNumMedia() {
            return this.numMedia;
        }
    
        /// <returns> Indicates number of messages used to delivery the body </returns> 
        public string GetNumSegments() {
            return this.numSegments;
        }
    
        /// <returns> The amount billed for the message </returns> 
        public decimal? GetPrice() {
            return this.price;
        }
    
        /// <returns> The currency in which Price is measured </returns> 
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /// <returns> A string that uniquely identifies this message </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The status of this message </returns> 
        public MessageResource.Status GetStatus() {
            return this.status;
        }
    
        /// <returns> The subresource_uris </returns> 
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /// <returns> The phone number that received the message </returns> 
        public string GetTo() {
            return this.to;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}