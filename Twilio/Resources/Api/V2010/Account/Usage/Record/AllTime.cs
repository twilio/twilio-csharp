using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage.Record;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Usage.Record {

    public class AllTime : Resource {
        public enum Category {
            CALLERIDLOOKUPS="calleridlookups",
            CALLS="calls",
            CALLS_CLIENT="calls-client",
            CALLS_INBOUND="calls-inbound",
            CALLS_INBOUND_LOCAL="calls-inbound-local",
            CALLS_INBOUND_TOLLFREE="calls-inbound-tollfree",
            CALLS_OUTBOUND="calls-outbound",
            CALLS_SIP="calls-sip",
            PHONENUMBERS="phonenumbers",
            PHONENUMBERS_LOCAL="phonenumbers-local",
            PHONENUMBERS_TOLLFREE="phonenumbers-tollfree",
            RECORDINGS="recordings",
            RECORDINGSTORAGE="recordingstorage",
            SHORTCODES="shortcodes",
            SHORTCODES_CUSTOMEROWNED="shortcodes-customerowned",
            SHORTCODES_RANDOM="shortcodes-random",
            SHORTCODES_VANITY="shortcodes-vanity",
            SMS="sms",
            SMS_INBOUND="sms-inbound",
            SMS_INBOUND_LONGCODE="sms-inbound-longcode",
            SMS_INBOUND_SHORTCODE="sms-inbound-shortcode",
            SMS_OUTBOUND="sms-outbound",
            SMS_OUTBOUND_LONGCODE="sms-outbound-longcode",
            SMS_OUTBOUND_SHORTCODE="sms-outbound-shortcode",
            TOTALPRICE="totalprice",
            TRANSCRIPTIONS="transcriptions"
        };
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return AllTimeReader capable of executing the read
         */
        public static AllTimeReader read(string accountSid) {
            return new AllTimeReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a AllTime object
         * 
         * @param json Raw JSON string
         * @return AllTime object represented by the provided JSON
         */
        public static AllTime fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AllTime>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("category")]
        private readonly AllTime.Category category;
        [JsonProperty("count")]
        private readonly string count;
        [JsonProperty("count_unit")]
        private readonly string countUnit;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("end_date")]
        private readonly DateTime endDate;
        [JsonProperty("price")]
        private readonly decimal price;
        [JsonProperty("price_unit")]
        private readonly decimal priceUnit;
        [JsonProperty("start_date")]
        private readonly DateTime startDate;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("usage")]
        private readonly string usage;
        [JsonProperty("usage_unit")]
        private readonly string usageUnit;
    
        private AllTime([JsonProperty("account_sid")]
                        string accountSid, 
                        [JsonProperty("api_version")]
                        string apiVersion, 
                        [JsonProperty("category")]
                        AllTime.Category category, 
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
                        decimal priceUnit, 
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
        public AllTime.Category GetCategory() {
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
        public DateTime GetEndDate() {
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
        public decimal GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The start_date
         */
        public DateTime GetStartDate() {
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