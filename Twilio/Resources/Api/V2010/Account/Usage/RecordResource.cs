using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Usage {

    public class RecordResource : Resource {
        public sealed class Category {
            public const string CALLERIDLOOKUPS="calleridlookups";
            public const string CALLS="calls";
            public const string CALLS_CLIENT="calls-client";
            public const string CALLS_INBOUND="calls-inbound";
            public const string CALLS_INBOUND_LOCAL="calls-inbound-local";
            public const string CALLS_INBOUND_TOLLFREE="calls-inbound-tollfree";
            public const string CALLS_OUTBOUND="calls-outbound";
            public const string CALLS_SIP="calls-sip";
            public const string PHONENUMBERS="phonenumbers";
            public const string PHONENUMBERS_LOCAL="phonenumbers-local";
            public const string PHONENUMBERS_TOLLFREE="phonenumbers-tollfree";
            public const string RECORDINGS="recordings";
            public const string RECORDINGSTORAGE="recordingstorage";
            public const string SHORTCODES="shortcodes";
            public const string SHORTCODES_CUSTOMEROWNED="shortcodes-customerowned";
            public const string SHORTCODES_RANDOM="shortcodes-random";
            public const string SHORTCODES_VANITY="shortcodes-vanity";
            public const string SMS="sms";
            public const string SMS_INBOUND="sms-inbound";
            public const string SMS_INBOUND_LONGCODE="sms-inbound-longcode";
            public const string SMS_INBOUND_SHORTCODE="sms-inbound-shortcode";
            public const string SMS_OUTBOUND="sms-outbound";
            public const string SMS_OUTBOUND_LONGCODE="sms-outbound-longcode";
            public const string SMS_OUTBOUND_SHORTCODE="sms-outbound-shortcode";
            public const string TOTALPRICE="totalprice";
            public const string TRANSCRIPTIONS="transcriptions";
        
            private readonly string value;
            
            public Category(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Category(string value) {
                return new Category(value);
            }
            
            public static implicit operator string(Category value) {
                return value.ToString();
            }
        }
    
        /**
         * Retrieve a list of usage-records belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return RecordReader capable of executing the read
         */
        public static RecordReader Read(string accountSid) {
            return new RecordReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a RecordResource object
         * 
         * @param json Raw JSON string
         * @return RecordResource object represented by the provided JSON
         */
        public static RecordResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RecordResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("category")]
        private readonly RecordResource.Category category;
        [JsonProperty("count")]
        private readonly string count;
        [JsonProperty("count_unit")]
        private readonly string countUnit;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("end_date")]
        private readonly DateTime? endDate;
        [JsonProperty("price")]
        private readonly decimal price;
        [JsonProperty("price_unit")]
        private readonly decimal? priceUnit;
        [JsonProperty("start_date")]
        private readonly DateTime? startDate;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("usage")]
        private readonly string usage;
        [JsonProperty("usage_unit")]
        private readonly string usageUnit;
    
        private RecordResource([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("api_version")]
                               string apiVersion, 
                               [JsonProperty("category")]
                               RecordResource.Category category, 
                               [JsonProperty("count")]
                               string count, 
                               [JsonProperty("count_unit")]
                               string countUnit, 
                               [JsonProperty("description")]
                               string description, 
                               [JsonProperty("end_date")]
                               string endDate, 
                               [JsonProperty("price")]
                               decimal price, 
                               [JsonProperty("price_unit")]
                               decimal? priceUnit, 
                               [JsonProperty("start_date")]
                               string startDate, 
                               [JsonProperty("subresource_uris")]
                               Dictionary<string, string> subresourceUris, 
                               [JsonProperty("uri")]
                               string uri, 
                               [JsonProperty("usage")]
                               string usage, 
                               [JsonProperty("usage_unit")]
                               string usageUnit) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.category = category;
            this.count = count;
            this.countUnit = countUnit;
            this.description = description;
            this.endDate = MarshalConverter.DateTimeFromString(endDate);
            this.price = price;
            this.priceUnit = priceUnit;
            this.startDate = MarshalConverter.DateTimeFromString(startDate);
            this.subresourceUris = subresourceUris;
            this.uri = uri;
            this.usage = usage;
            this.usageUnit = usageUnit;
        }
    
        /**
         * @return The Account that accrued the usage
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
         * @return The category of usage
         */
        public RecordResource.Category GetCategory() {
            return this.category;
        }
    
        /**
         * @return The number of usage events (e.g. the number of calls).
         */
        public string GetCount() {
            return this.count;
        }
    
        /**
         * @return The unit in which `Count` is measured
         */
        public string GetCountUnit() {
            return this.countUnit;
        }
    
        /**
         * @return A human-readable description of the usage category.
         */
        public string GetDescription() {
            return this.description;
        }
    
        /**
         * @return The last date usage is included in this record
         */
        public DateTime? GetEndDate() {
            return this.endDate;
        }
    
        /**
         * @return The total price of the usage
         */
        public decimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which `Price` is measured
         */
        public decimal? GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The first date usage is included in this record
         */
        public DateTime? GetStartDate() {
            return this.startDate;
        }
    
        /**
         * @return Subresources Uris for this UsageRecord
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return The amount of usage
         */
        public string GetUsage() {
            return this.usage;
        }
    
        /**
         * @return The units in which `Usage` is measured
         */
        public string GetUsageUnit() {
            return this.usageUnit;
        }
    }
}