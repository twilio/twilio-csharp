using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sms;
using Twilio.Deleters.Api.V2010.Account.Sms;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sms;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sms;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sms;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.net.URI;
using java.util.Currency;
using java.util.List;
using org.joda.time.DateTime;

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
        public static SmsMessageCreator create(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, String body) {
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
        public static SmsMessageCreator create(String accountSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from, List<URI> mediaUrl) {
            return new SmsMessageCreator(accountSid, to, from, mediaUrl);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageDeleter capable of executing the delete
         */
        public static SmsMessageDeleter delete(String accountSid, String sid) {
            return new SmsMessageDeleter(accountSid, sid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageFetcher capable of executing the fetch
         */
        public static SmsMessageFetcher fetch(String accountSid, String sid) {
            return new SmsMessageFetcher(accountSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return SmsMessageReader capable of executing the read
         */
        public static SmsMessageReader read(String accountSid) {
            return new SmsMessageReader(accountSid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageUpdater capable of executing the update
         */
        public static SmsMessageUpdater update(String accountSid, String sid) {
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
        private readonly SmsMessage.Direction direction;
        [JsonProperty("from")]
        private readonly com.twilio.types.PhoneNumber from;
        [JsonProperty("price")]
        private readonly BigDecimal price;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly SmsMessage.Status status;
        [JsonProperty("to")]
        private readonly String to;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private SmsMessage([JsonProperty("account_sid")]
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
                           SmsMessage.Direction direction, 
                           [JsonProperty("from")]
                           com.twilio.types.PhoneNumber from, 
                           [JsonProperty("price")]
                           BigDecimal price, 
                           [JsonProperty("price_unit")]
                           [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                           Currency priceUnit, 
                           [JsonProperty("sid")]
                           String sid, 
                           [JsonProperty("status")]
                           SmsMessage.Status status, 
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The body
         */
        public String GetBody() {
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
        public com.twilio.types.PhoneNumber GetFrom() {
            return this.from;
        }
    
        /**
         * @return The price
         */
        public BigDecimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
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
        public String GetTo() {
            return this.to;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}