using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

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
    
        /**
         * Send a message from the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param body The body
         * @return MessageCreator capable of executing the create
         */
        public static MessageCreator Create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            return new MessageCreator(accountSid, to, from, body);
        }
    
        /**
         * Send a message from the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param mediaUrl The media_url
         * @return MessageCreator capable of executing the create
         */
        public static MessageCreator Create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            return new MessageCreator(accountSid, to, from, mediaUrl);
        }
    
        /**
         * Deletes a message record from your account
         * 
         * @param accountSid The account_sid
         * @param sid The message to delete
         * @return MessageDeleter capable of executing the delete
         */
        public static MessageDeleter Delete(string accountSid, string sid) {
            return new MessageDeleter(accountSid, sid);
        }
    
        /**
         * Fetch a message belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique message Sid
         * @return MessageFetcher capable of executing the fetch
         */
        public static MessageFetcher Fetch(string accountSid, string sid) {
            return new MessageFetcher(accountSid, sid);
        }
    
        /**
         * Retrieve a list of messages belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return MessageReader capable of executing the read
         */
        public static MessageReader Read(string accountSid) {
            return new MessageReader(accountSid);
        }
    
        /**
         * To redact a message-body from a post-flight message record, post to the
         * message instance resource with an empty body
         * 
         * @param accountSid The account_sid
         * @param sid The message to redact
         * @return MessageUpdater capable of executing the update
         */
        public static MessageUpdater Update(string accountSid, string sid) {
            return new MessageUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a MessageResource object
         * 
         * @param json Raw JSON string
         * @return MessageResource object represented by the provided JSON
         */
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
        private readonly decimal price;
        [JsonProperty("price_unit")]
        private readonly decimal? priceUnit;
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
                                decimal price, 
                                [JsonProperty("price_unit")]
                                decimal? priceUnit, 
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
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the Twilio API used to process the message.
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The text body of the message. Up to 1600 characters long.
         */
        public string GetBody() {
            return this.body;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The date the message was sent
         */
        public DateTime? GetDateSent() {
            return this.dateSent;
        }
    
        /**
         * @return The direction of the message
         */
        public MessageResource.Direction GetDirection() {
            return this.direction;
        }
    
        /**
         * @return The error code associated with the message
         */
        public int? GetErrorCode() {
            return this.errorCode;
        }
    
        /**
         * @return Human readable description of the ErrorCode
         */
        public string GetErrorMessage() {
            return this.errorMessage;
        }
    
        /**
         * @return The phone number that initiated the message
         */
        public Twilio.Types.PhoneNumber GetFrom() {
            return this.from;
        }
    
        /**
         * @return Number of media files associated with the message
         */
        public string GetNumMedia() {
            return this.numMedia;
        }
    
        /**
         * @return Indicates number of messages used to delivery the body
         */
        public string GetNumSegments() {
            return this.numSegments;
        }
    
        /**
         * @return The amount billed for the message
         */
        public decimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which Price is measured
         */
        public decimal? GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return A string that uniquely identifies this message
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of this message
         */
        public MessageResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The subresource_uris
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The phone number that received the message
         */
        public string GetTo() {
            return this.to;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}