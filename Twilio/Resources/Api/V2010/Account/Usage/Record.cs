using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.util.Currency;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Usage {

    public class Record : Resource {
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
         * Retrieve a list of usage-records belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return RecordReader capable of executing the read
         */
        public static RecordReader read(String accountSid) {
            return new RecordReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Record object
         * 
         * @param json Raw JSON string
         * @return Record object represented by the provided JSON
         */
        public static Record fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Record>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("category")]
        private readonly Record.Category category;
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
    
        private Record([JsonProperty("account_sid")]
                       String accountSid, 
                       [JsonProperty("api_version")]
                       String apiVersion, 
                       [JsonProperty("category")]
                       Record.Category category, 
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
         * @return The Account that accrued the usage
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
         * @return The category of usage
         */
        public Record.Category GetCategory() {
            return this.category;
        }
    
        /**
         * @return The number of usage events (e.g. the number of calls).
         */
        public String GetCount() {
            return this.count;
        }
    
        /**
         * @return The unit in which `Count` is measured
         */
        public String GetCountUnit() {
            return this.countUnit;
        }
    
        /**
         * @return A human-readable description of the usage category.
         */
        public String GetDescription() {
            return this.description;
        }
    
        /**
         * @return The last date usage is included in this record
         */
        public DateTime GetEndDate() {
            return this.endDate;
        }
    
        /**
         * @return The total price of the usage
         */
        public BigDecimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which `Price` is measured
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The first date usage is included in this record
         */
        public DateTime GetStartDate() {
            return this.startDate;
        }
    
        /**
         * @return Subresources Uris for this UsageRecord
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    
        /**
         * @return The amount of usage
         */
        public String GetUsage() {
            return this.usage;
        }
    
        /**
         * @return The units in which `Usage` is measured
         */
        public String GetUsageUnit() {
            return this.usageUnit;
        }
    }
}