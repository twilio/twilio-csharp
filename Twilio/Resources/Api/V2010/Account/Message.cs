using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.net.URI;
using java.util.Currency;
using java.util.List;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Message : SidResource {
        public enum Status {
            QUEUED="queued",
            SENDING="sending",
            SENT="sent",
            FAILED="failed",
            DELIVERED="delivered",
            UNDELIVERED="undelivered",
            RECEIVING="receiving",
            RECEIVED="received"
        };
    
        public enum Direction {
            INBOUND="inbound",
            OUTBOUND_API="outbound-api",
            OUTBOUND_CALL="outbound-call",
            OUTBOUND_REPLY="outbound-reply"
        };
    
        /**
         * Send a message from the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param body The body
         * @return MessageCreator capable of executing the create
         */
        public static MessageCreator create(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, String body) {
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
        public static MessageCreator create(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, List<URI> mediaUrl) {
            return new MessageCreator(accountSid, to, from, mediaUrl);
        }
    
        /**
         * Deletes a message record from your account
         * 
         * @param accountSid The account_sid
         * @param sid The message to delete
         * @return MessageDeleter capable of executing the delete
         */
        public static MessageDeleter delete(String accountSid, String sid) {
            return new MessageDeleter(accountSid, sid);
        }
    
        /**
         * Fetch a message belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique message Sid
         * @return MessageFetcher capable of executing the fetch
         */
        public static MessageFetcher fetch(String accountSid, String sid) {
            return new MessageFetcher(accountSid, sid);
        }
    
        /**
         * Retrieve a list of messages belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return MessageReader capable of executing the read
         */
        public static MessageReader read(String accountSid) {
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
        public static MessageUpdater update(String accountSid, String sid) {
            return new MessageUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a Message object
         * 
         * @param json Raw JSON string
         * @return Message object represented by the provided JSON
         */
        public static Message fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Message>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("body")]
        private readonly String body;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("date_sent")]
        private readonly DateTime dateSent;
        [JsonProperty("direction")]
        private readonly Message.Direction direction;
        [JsonProperty("error_code")]
        private readonly Integer errorCode;
        [JsonProperty("error_message")]
        private readonly String errorMessage;
        [JsonProperty("from")]
        private readonly com.twilio.types.PhoneNumber from;
        [JsonProperty("num_media")]
        private readonly String numMedia;
        [JsonProperty("num_segments")]
        private readonly String numSegments;
        [JsonProperty("price")]
        private readonly BigDecimal price;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly Message.Status status;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
        [JsonProperty("to")]
        private readonly String to;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Message([JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("api_version")]
                        String apiVersion, 
                        [JsonProperty("body")]
                        String body, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("date_sent")]
                        String dateSent, 
                        [JsonProperty("direction")]
                        Message.Direction direction, 
                        [JsonProperty("error_code")]
                        Integer errorCode, 
                        [JsonProperty("error_message")]
                        String errorMessage, 
                        [JsonProperty("from")]
                        com.twilio.types.PhoneNumber from, 
                        [JsonProperty("num_media")]
                        String numMedia, 
                        [JsonProperty("num_segments")]
                        String numSegments, 
                        [JsonProperty("price")]
                        BigDecimal price, 
                        [JsonProperty("price_unit")]
                        [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                        Currency priceUnit, 
                        [JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("status")]
                        Message.Status status, 
                        [JsonProperty("subresource_uris")]
                        Map<String, String> subresourceUris, 
                        [JsonProperty("to")]
                        String to, 
                        [JsonProperty("uri")]
                        String uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.body = body;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.dateSent = MarshalConverter.dateTimeFromString(dateSent);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the Twilio API used to process the message.
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The text body of the message. Up to 1600 characters long.
         */
        public String GetBody() {
            return this.body;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The date the message was sent
         */
        public DateTime GetDateSent() {
            return this.dateSent;
        }
    
        /**
         * @return The direction of the message
         */
        public Message.Direction GetDirection() {
            return this.direction;
        }
    
        /**
         * @return The error code associated with the message
         */
        public Integer GetErrorCode() {
            return this.errorCode;
        }
    
        /**
         * @return Human readable description of the ErrorCode
         */
        public String GetErrorMessage() {
            return this.errorMessage;
        }
    
        /**
         * @return The phone number that initiated the message
         */
        public com.twilio.types.PhoneNumber GetFrom() {
            return this.from;
        }
    
        /**
         * @return Number of media files associated with the message
         */
        public String GetNumMedia() {
            return this.numMedia;
        }
    
        /**
         * @return Indicates number of messages used to delivery the body
         */
        public String GetNumSegments() {
            return this.numSegments;
        }
    
        /**
         * @return The amount billed for the message
         */
        public BigDecimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which Price is measured
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return A string that uniquely identifies this message
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of this message
         */
        public Message.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The subresource_uris
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The phone number that received the message
         */
        public String GetTo() {
            return this.to;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}