using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sms;
using Twilio.Deleters.Api.V2010.Account.Sms;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sms;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sms;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sms;

namespace Twilio.Resources.Api.V2010.Account.Sms {

    public class SmsMessage : SidResource {
        public enum Status {
            QUEUED="queued",
            SENDING="sending",
            SENT="sent",
            FAILED="failed",
            RECEIVED="received"
        };
    
        public enum Direction {
            INBOUND="inbound",
            OUTBOUND_API="outbound-api",
            OUTBOUND_CALL="outbound-call",
            OUTBOUND_REPLY="outbound-reply"
        };
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param body The body
         * @return SmsMessageCreator capable of executing the create
         */
        public static SmsMessageCreator create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            return new SmsMessageCreator(accountSid, to, from, body);
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param mediaUrl The media_url
         * @return SmsMessageCreator capable of executing the create
         */
        public static SmsMessageCreator create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            return new SmsMessageCreator(accountSid, to, from, mediaUrl);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageDeleter capable of executing the delete
         */
        public static SmsMessageDeleter delete(string accountSid, string sid) {
            return new SmsMessageDeleter(accountSid, sid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageFetcher capable of executing the fetch
         */
        public static SmsMessageFetcher fetch(string accountSid, string sid) {
            return new SmsMessageFetcher(accountSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return SmsMessageReader capable of executing the read
         */
        public static SmsMessageReader read(string accountSid) {
            return new SmsMessageReader(accountSid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageUpdater capable of executing the update
         */
        public static SmsMessageUpdater update(string accountSid, string sid) {
            return new SmsMessageUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a SmsMessage object
         * 
         * @param json Raw JSON string
         * @return SmsMessage object represented by the provided JSON
         */
        public static SmsMessage fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SmsMessage>(json);
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
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("date_sent")]
        private readonly DateTime dateSent;
        [JsonProperty("direction")]
        private readonly SmsMessage.Direction direction;
        [JsonProperty("from")]
        private readonly Twilio.Types.PhoneNumber from;
        [JsonProperty("price")]
        private readonly decimal price;
        [JsonProperty("price_unit")]
        private readonly decimal priceUnit;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        private readonly SmsMessage.Status status;
        [JsonProperty("to")]
        private readonly string to;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private SmsMessage([JsonProperty("account_sid")]
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
                           SmsMessage.Direction direction, 
                           [JsonProperty("from")]
                           Twilio.Types.PhoneNumber from, 
                           [JsonProperty("price")]
                           decimal price, 
                           [JsonProperty("price_unit")]
                           decimal priceUnit, 
                           [JsonProperty("sid")]
                           string sid, 
                           [JsonProperty("status")]
                           SmsMessage.Status status, 
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
            this.from = from;
            this.price = price;
            this.priceUnit = priceUnit;
            this.sid = sid;
            this.status = status;
            this.to = to;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The body
         */
        public string GetBody() {
            return this.body;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The date_sent
         */
        public DateTime GetDateSent() {
            return this.dateSent;
        }
    
        /**
         * @return The direction
         */
        public SmsMessage.Direction GetDirection() {
            return this.direction;
        }
    
        /**
         * @return The from
         */
        public Twilio.Types.PhoneNumber GetFrom() {
            return this.from;
        }
    
        /**
         * @return The price
         */
        public decimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public decimal GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public SmsMessage.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The to
         */
        public string GetTo() {
            return this.to;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}