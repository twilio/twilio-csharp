using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public class SmsMessageResource : SidResource {
        public sealed class Status : IStringEnum {
            public const string QUEUED="queued";
            public const string SENDING="sending";
            public const string SENT="sent";
            public const string FAILED="failed";
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
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param body The body
         * @return SmsMessageCreator capable of executing the create
         */
        public static SmsMessageCreator Create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
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
        public static SmsMessageCreator Create(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            return new SmsMessageCreator(accountSid, to, from, mediaUrl);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageDeleter capable of executing the delete
         */
        public static SmsMessageDeleter Delete(string accountSid, string sid) {
            return new SmsMessageDeleter(accountSid, sid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageFetcher capable of executing the fetch
         */
        public static SmsMessageFetcher Fetch(string accountSid, string sid) {
            return new SmsMessageFetcher(accountSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return SmsMessageReader capable of executing the read
         */
        public static SmsMessageReader Read(string accountSid) {
            return new SmsMessageReader(accountSid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SmsMessageUpdater capable of executing the update
         */
        public static SmsMessageUpdater Update(string accountSid, string sid) {
            return new SmsMessageUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a SmsMessageResource object
         * 
         * @param json Raw JSON string
         * @return SmsMessageResource object represented by the provided JSON
         */
        public static SmsMessageResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SmsMessageResource>(json);
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
        private readonly SmsMessageResource.Direction direction;
        [JsonProperty("from")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber from;
        [JsonProperty("price")]
        private readonly decimal? price;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly SmsMessageResource.Status status;
        [JsonProperty("to")]
        private readonly string to;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public SmsMessageResource() {
        
        }
    
        private SmsMessageResource([JsonProperty("account_sid")]
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
                                   SmsMessageResource.Direction direction, 
                                   [JsonProperty("from")]
                                   Twilio.Types.PhoneNumber from, 
                                   [JsonProperty("price")]
                                   decimal? price, 
                                   [JsonProperty("price_unit")]
                                   string priceUnit, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("status")]
                                   SmsMessageResource.Status status, 
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
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The date_sent
         */
        public DateTime? GetDateSent() {
            return this.dateSent;
        }
    
        /**
         * @return The direction
         */
        public SmsMessageResource.Direction GetDirection() {
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
        public decimal? GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public SmsMessageResource.Status GetStatus() {
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