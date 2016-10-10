using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Usage.Record {

    public class TodayResource : Resource {
        public sealed class Category : IStringEnum {
            public const string AUTHY_AUTHENTICATIONS="authy-authentications";
            public const string AUTHY_CALLS_OUTBOUND="authy-calls-outbound";
            public const string AUTHY_MONTHLY_FEES="authy-monthly-fees";
            public const string AUTHY_PHONE_INTELLIGENCE="authy-phone-intelligence";
            public const string AUTHY_PHONE_VERIFICATIONS="authy-phone-verifications";
            public const string AUTHY_SMS_OUTBOUND="authy-sms-outbound";
            public const string CALL_PROGESS_EVENTS="call-progess-events";
            public const string CALLERIDLOOKUPS="calleridlookups";
            public const string CALLS="calls";
            public const string CALLS_CLIENT="calls-client";
            public const string CALLS_GLOBALCONFERENCE="calls-globalconference";
            public const string CALLS_INBOUND="calls-inbound";
            public const string CALLS_INBOUND_LOCAL="calls-inbound-local";
            public const string CALLS_INBOUND_MOBILE="calls-inbound-mobile";
            public const string CALLS_INBOUND_TOLLFREE="calls-inbound-tollfree";
            public const string CALLS_OUTBOUND="calls-outbound";
            public const string CALLS_RECORDINGS="calls-recordings";
            public const string CALLS_SIP="calls-sip";
            public const string CALLS_SIP_INBOUND="calls-sip-inbound";
            public const string CALLS_SIP_OUTBOUND="calls-sip-outbound";
            public const string CARRIER_LOOKUPS="carrier-lookups";
            public const string CONVERSATIONS="conversations";
            public const string CONVERSATIONS_API_REQUESTS="conversations-api-requests";
            public const string CONVERSATIONS_CONVERSATION_EVENTS="conversations-conversation-events";
            public const string CONVERSATIONS_ENDPOINT_CONNECTIVITY="conversations-endpoint-connectivity";
            public const string CONVERSATIONS_EVENTS="conversations-events";
            public const string CONVERSATIONS_PARTICIPANT_EVENTS="conversations-participant-events";
            public const string CONVERSATIONS_PARTICIPANTS="conversations-participants";
            public const string IP_MESSAGING="ip-messaging";
            public const string IP_MESSAGING_COMMANDS="ip-messaging-commands";
            public const string IP_MESSAGING_DATA_STORAGE="ip-messaging-data-storage";
            public const string IP_MESSAGING_DATA_TRANSFER="ip-messaging-data-transfer";
            public const string IP_MESSAGING_ENDPOINT_CONNECTIVITY="ip-messaging-endpoint-connectivity";
            public const string LOOKUPS="lookups";
            public const string MEDIASTORAGE="mediastorage";
            public const string MMS="mms";
            public const string MMS_INBOUND="mms-inbound";
            public const string MMS_INBOUND_LONGCODE="mms-inbound-longcode";
            public const string MMS_INBOUND_SHORTCODE="mms-inbound-shortcode";
            public const string MMS_OUTBOUND="mms-outbound";
            public const string MMS_OUTBOUND_LONGCODE="mms-outbound-longcode";
            public const string MMS_OUTBOUND_SHORTCODE="mms-outbound-shortcode";
            public const string MONITOR_READS="monitor-reads";
            public const string MONITOR_STORAGE="monitor-storage";
            public const string MONITOR_WRITES="monitor-writes";
            public const string NUMBER_FORMAT_LOOKUPS="number-format-lookups";
            public const string PHONENUMBERS="phonenumbers";
            public const string PHONENUMBERS_CPS="phonenumbers-cps";
            public const string PHONENUMBERS_EMERGENCY="phonenumbers-emergency";
            public const string PHONENUMBERS_LOCAL="phonenumbers-local";
            public const string PHONENUMBERS_MOBILE="phonenumbers-mobile";
            public const string PHONENUMBERS_SETUPS="phonenumbers-setups";
            public const string PHONENUMBERS_TOLLFREE="phonenumbers-tollfree";
            public const string PREMIUMSUPPORT="premiumsupport";
            public const string RECORDINGS="recordings";
            public const string RECORDINGSTORAGE="recordingstorage";
            public const string SHORTCODES="shortcodes";
            public const string SHORTCODES_CUSTOMEROWNED="shortcodes-customerowned";
            public const string SHORTCODES_MMS_ENABLEMENT="shortcodes-mms-enablement";
            public const string SHORTCODES_MPS="shortcodes-mps";
            public const string SHORTCODES_RANDOM="shortcodes-random";
            public const string SHORTCODES_UK="shortcodes-uk";
            public const string SHORTCODES_VANITY="shortcodes-vanity";
            public const string SMS="sms";
            public const string SMS_INBOUND="sms-inbound";
            public const string SMS_INBOUND_LONGCODE="sms-inbound-longcode";
            public const string SMS_INBOUND_SHORTCODE="sms-inbound-shortcode";
            public const string SMS_OUTBOUND="sms-outbound";
            public const string SMS_OUTBOUND_LONGCODE="sms-outbound-longcode";
            public const string SMS_OUTBOUND_SHORTCODE="sms-outbound-shortcode";
            public const string TASKROUTER_TASKS="taskrouter-tasks";
            public const string TOTALPRICE="totalprice";
            public const string TRANSCRIPTIONS="transcriptions";
            public const string TRUNKING_CPS="trunking-cps";
            public const string TRUNKING_EMERGENCY_CALLS="trunking-emergency-calls";
            public const string TRUNKING_ORIGINATION="trunking-origination";
            public const string TRUNKING_ORIGINATION_LOCAL="trunking-origination-local";
            public const string TRUNKING_ORIGINATION_MOBILE="trunking-origination-mobile";
            public const string TRUNKING_ORIGINATION_TOLLFREE="trunking-origination-tollfree";
            public const string TRUNKING_RECORDINGS="trunking-recordings";
            public const string TRUNKING_SECURE="trunking-secure";
            public const string TRUNKING_TERMINATION="trunking-termination";
            public const string TURNMEGABYTES="turnmegabytes";
            public const string TURNMEGABYTES_AUSTRALIA="turnmegabytes-australia";
            public const string TURNMEGABYTES_BRASIL="turnmegabytes-brasil";
            public const string TURNMEGABYTES_IRELAND="turnmegabytes-ireland";
            public const string TURNMEGABYTES_JAPAN="turnmegabytes-japan";
            public const string TURNMEGABYTES_SINGAPORE="turnmegabytes-singapore";
            public const string TURNMEGABYTES_USEAST="turnmegabytes-useast";
            public const string TURNMEGABYTES_USWEST="turnmegabytes-uswest";
        
            private string value;
            
            public Category() { }
            
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
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return TodayReader capable of executing the read
         */
        public static TodayReader Reader(string accountSid) {
            return new TodayReader(accountSid);
        }
    
        /**
         * Create a TodayReader to execute read.
         * 
         * @return TodayReader capable of executing the read
         */
        public static TodayReader Reader() {
            return new TodayReader();
        }
    
        /**
         * Converts a JSON string into a TodayResource object
         * 
         * @param json Raw JSON string
         * @return TodayResource object represented by the provided JSON
         */
        public static TodayResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TodayResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("category")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly TodayResource.Category category;
        [JsonProperty("count")]
        private readonly string count;
        [JsonProperty("count_unit")]
        private readonly string countUnit;
        [JsonProperty("description")]
        private readonly string description;
        [JsonProperty("end_date")]
        private readonly DateTime? endDate;
        [JsonProperty("price")]
        private readonly decimal? price;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
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
    
        public TodayResource() {
        
        }
    
        private TodayResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("api_version")]
                              string apiVersion, 
                              [JsonProperty("category")]
                              TodayResource.Category category, 
                              [JsonProperty("count")]
                              string count, 
                              [JsonProperty("count_unit")]
                              string countUnit, 
                              [JsonProperty("description")]
                              string description, 
                              [JsonProperty("end_date")]
                              string endDate, 
                              [JsonProperty("price")]
                              decimal? price, 
                              [JsonProperty("price_unit")]
                              string priceUnit, 
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
        public TodayResource.Category GetCategory() {
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