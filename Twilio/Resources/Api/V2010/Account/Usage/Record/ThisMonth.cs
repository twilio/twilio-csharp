using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage.Record;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.util.Currency;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Usage.Record {

    public class ThisMonth : Resource {
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
         * @return ThisMonthReader capable of executing the read
         */
        public static ThisMonthReader read(String accountSid) {
            return new ThisMonthReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a ThisMonth object
         * 
         * @param json Raw JSON string
         * @return ThisMonth object represented by the provided JSON
         */
        public static ThisMonth fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ThisMonth>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("category")]
        private readonly ThisMonth.Category category;
        [JsonProperty("count")]
        private readonly String count;
        [JsonProperty("count_unit")]
        private readonly String countUnit;
        [JsonProperty("description")]
        private readonly String description;
        [JsonProperty("end_date")]
        private readonly DateTime endDate;
        [JsonProperty("price")]
        private readonly BigDecimal price;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("start_date")]
        private readonly DateTime startDate;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
        [JsonProperty("uri")]
        private readonly String uri;
        [JsonProperty("usage")]
        private readonly String usage;
        [JsonProperty("usage_unit")]
        private readonly String usageUnit;
    
        private ThisMonth([JsonProperty("account_sid")]
                          String accountSid, 
                          [JsonProperty("api_version")]
                          String apiVersion, 
                          [JsonProperty("category")]
                          ThisMonth.Category category, 
                          [JsonProperty("count")]
                          String count, 
                          [JsonProperty("count_unit")]
                          String countUnit, 
                          [JsonProperty("description")]
                          String description, 
                          [JsonProperty("end_date")]
                          String endDate, 
                          [JsonProperty("price")]
                          BigDecimal price, 
                          [JsonProperty("price_unit")]
                          [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                          Currency priceUnit, 
                          [JsonProperty("start_date")]
                          String startDate, 
                          [JsonProperty("subresource_uris")]
                          Map<String, String> subresourceUris, 
                          [JsonProperty("uri")]
                          String uri, 
                          [JsonProperty("usage")]
                          String usage, 
                          [JsonProperty("usage_unit")]
                          String usageUnit) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.category = category;
            this.count = count;
            this.countUnit = countUnit;
            this.description = description;
            this.endDate = MarshalConverter.dateTimeFromString(endDate);
            this.price = price;
            this.priceUnit = priceUnit;
            this.startDate = MarshalConverter.dateTimeFromString(startDate);
            this.subresourceUris = subresourceUris;
            this.uri = uri;
            this.usage = usage;
            this.usageUnit = usageUnit;
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
         * @return The category
         */
        public ThisMonth.Category GetCategory() {
            return this.category;
        }
    
        /**
         * @return The count
         */
        public String GetCount() {
            return this.count;
        }
    
        /**
         * @return The count_unit
         */
        public String GetCountUnit() {
            return this.countUnit;
        }
    
        /**
         * @return The description
         */
        public String GetDescription() {
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
         * @return The start_date
         */
        public DateTime GetStartDate() {
            return this.startDate;
        }
    
        /**
         * @return The subresource_uris
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    
        /**
         * @return The usage
         */
        public String GetUsage() {
            return this.usage;
        }
    
        /**
         * @return The usage_unit
         */
        public String GetUsageUnit() {
            return this.usageUnit;
        }
    }
}