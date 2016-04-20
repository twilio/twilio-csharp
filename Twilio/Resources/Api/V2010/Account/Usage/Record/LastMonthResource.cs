using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage.Record;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Usage.Record {

    public class LastMonthResource : Resource {
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
         * read
         * 
         * @param accountSid The account_sid
         * @return LastMonthReader capable of executing the read
         */
        public static LastMonthReader Read(string accountSid) {
            return new LastMonthReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a LastMonthResource object
         * 
         * @param json Raw JSON string
         * @return LastMonthResource object represented by the provided JSON
         */
        public static LastMonthResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<LastMonthResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("category")]
        private readonly LastMonthResource.Category category;
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
    
        public LastMonthResource() {
        
        }
    
        private LastMonthResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("api_version")]
                                  string apiVersion, 
                                  [JsonProperty("category")]
                                  LastMonthResource.Category category, 
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
         * @return The category
         */
        public LastMonthResource.Category GetCategory() {
            return this.category;
        }
    
        /**
         * @return The count
         */
        public string GetCount() {
            return this.count;
        }
    
        /**
         * @return The count_unit
         */
        public string GetCountUnit() {
            return this.countUnit;
        }
    
        /**
         * @return The description
         */
        public string GetDescription() {
            return this.description;
        }
    
        /**
         * @return The end_date
         */
        public DateTime? GetEndDate() {
            return this.endDate;
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
        public decimal? GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The start_date
         */
        public DateTime? GetStartDate() {
            return this.startDate;
        }
    
        /**
         * @return The subresource_uris
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return The usage
         */
        public string GetUsage() {
            return this.usage;
        }
    
        /**
         * @return The usage_unit
         */
        public string GetUsageUnit() {
            return this.usageUnit;
        }
    }
}