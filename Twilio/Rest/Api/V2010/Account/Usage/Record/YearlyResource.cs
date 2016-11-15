using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account.Usage.Record 
{

    public class YearlyResource : Resource 
    {
        public sealed class CategoryEnum : IStringEnum 
        {
            public const string AuthyAuthentications = "authy-authentications";
            public const string AuthyCallsOutbound = "authy-calls-outbound";
            public const string AuthyMonthlyFees = "authy-monthly-fees";
            public const string AuthyPhoneIntelligence = "authy-phone-intelligence";
            public const string AuthyPhoneVerifications = "authy-phone-verifications";
            public const string AuthySmsOutbound = "authy-sms-outbound";
            public const string CallProgessEvents = "call-progess-events";
            public const string Calleridlookups = "calleridlookups";
            public const string Calls = "calls";
            public const string CallsClient = "calls-client";
            public const string CallsGlobalconference = "calls-globalconference";
            public const string CallsInbound = "calls-inbound";
            public const string CallsInboundLocal = "calls-inbound-local";
            public const string CallsInboundMobile = "calls-inbound-mobile";
            public const string CallsInboundTollfree = "calls-inbound-tollfree";
            public const string CallsOutbound = "calls-outbound";
            public const string CallsRecordings = "calls-recordings";
            public const string CallsSip = "calls-sip";
            public const string CallsSipInbound = "calls-sip-inbound";
            public const string CallsSipOutbound = "calls-sip-outbound";
            public const string CarrierLookups = "carrier-lookups";
            public const string Conversations = "conversations";
            public const string ConversationsApiRequests = "conversations-api-requests";
            public const string ConversationsConversationEvents = "conversations-conversation-events";
            public const string ConversationsEndpointConnectivity = "conversations-endpoint-connectivity";
            public const string ConversationsEvents = "conversations-events";
            public const string ConversationsParticipantEvents = "conversations-participant-events";
            public const string ConversationsParticipants = "conversations-participants";
            public const string IpMessaging = "ip-messaging";
            public const string IpMessagingCommands = "ip-messaging-commands";
            public const string IpMessagingDataStorage = "ip-messaging-data-storage";
            public const string IpMessagingDataTransfer = "ip-messaging-data-transfer";
            public const string IpMessagingEndpointConnectivity = "ip-messaging-endpoint-connectivity";
            public const string Lookups = "lookups";
            public const string Mediastorage = "mediastorage";
            public const string Mms = "mms";
            public const string MmsInbound = "mms-inbound";
            public const string MmsInboundLongcode = "mms-inbound-longcode";
            public const string MmsInboundShortcode = "mms-inbound-shortcode";
            public const string MmsOutbound = "mms-outbound";
            public const string MmsOutboundLongcode = "mms-outbound-longcode";
            public const string MmsOutboundShortcode = "mms-outbound-shortcode";
            public const string MonitorReads = "monitor-reads";
            public const string MonitorStorage = "monitor-storage";
            public const string MonitorWrites = "monitor-writes";
            public const string NumberFormatLookups = "number-format-lookups";
            public const string Phonenumbers = "phonenumbers";
            public const string PhonenumbersCps = "phonenumbers-cps";
            public const string PhonenumbersEmergency = "phonenumbers-emergency";
            public const string PhonenumbersLocal = "phonenumbers-local";
            public const string PhonenumbersMobile = "phonenumbers-mobile";
            public const string PhonenumbersSetups = "phonenumbers-setups";
            public const string PhonenumbersTollfree = "phonenumbers-tollfree";
            public const string Premiumsupport = "premiumsupport";
            public const string Recordings = "recordings";
            public const string Recordingstorage = "recordingstorage";
            public const string Shortcodes = "shortcodes";
            public const string ShortcodesCustomerowned = "shortcodes-customerowned";
            public const string ShortcodesMmsEnablement = "shortcodes-mms-enablement";
            public const string ShortcodesMps = "shortcodes-mps";
            public const string ShortcodesRandom = "shortcodes-random";
            public const string ShortcodesUk = "shortcodes-uk";
            public const string ShortcodesVanity = "shortcodes-vanity";
            public const string Sms = "sms";
            public const string SmsInbound = "sms-inbound";
            public const string SmsInboundLongcode = "sms-inbound-longcode";
            public const string SmsInboundShortcode = "sms-inbound-shortcode";
            public const string SmsOutbound = "sms-outbound";
            public const string SmsOutboundLongcode = "sms-outbound-longcode";
            public const string SmsOutboundShortcode = "sms-outbound-shortcode";
            public const string TaskrouterTasks = "taskrouter-tasks";
            public const string Totalprice = "totalprice";
            public const string Transcriptions = "transcriptions";
            public const string TrunkingCps = "trunking-cps";
            public const string TrunkingEmergencyCalls = "trunking-emergency-calls";
            public const string TrunkingOrigination = "trunking-origination";
            public const string TrunkingOriginationLocal = "trunking-origination-local";
            public const string TrunkingOriginationMobile = "trunking-origination-mobile";
            public const string TrunkingOriginationTollfree = "trunking-origination-tollfree";
            public const string TrunkingRecordings = "trunking-recordings";
            public const string TrunkingSecure = "trunking-secure";
            public const string TrunkingTermination = "trunking-termination";
            public const string Turnmegabytes = "turnmegabytes";
            public const string TurnmegabytesAustralia = "turnmegabytes-australia";
            public const string TurnmegabytesBrasil = "turnmegabytes-brasil";
            public const string TurnmegabytesIreland = "turnmegabytes-ireland";
            public const string TurnmegabytesJapan = "turnmegabytes-japan";
            public const string TurnmegabytesSingapore = "turnmegabytes-singapore";
            public const string TurnmegabytesUseast = "turnmegabytes-useast";
            public const string TurnmegabytesUswest = "turnmegabytes-uswest";
        
            private string _value;
            
            public CategoryEnum() {}
            
            public CategoryEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator CategoryEnum(string value)
            {
                return new CategoryEnum(value);
            }
            
            public static implicit operator string(CategoryEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> YearlyReader capable of executing the read </returns> 
        public static YearlyReader Reader()
        {
            return new YearlyReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a YearlyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> YearlyResource object represented by the provided JSON </returns> 
        public static YearlyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<YearlyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public YearlyResource.CategoryEnum Category { get; set; }
        [JsonProperty("count")]
        public string Count { get; set; }
        [JsonProperty("count_unit")]
        public string CountUnit { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("usage")]
        public string Usage { get; set; }
        [JsonProperty("usage_unit")]
        public string UsageUnit { get; set; }
    
        public YearlyResource()
        {
        
        }
    
        private YearlyResource([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("api_version")]
                               string apiVersion, 
                               [JsonProperty("category")]
                               YearlyResource.CategoryEnum category, 
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
                               string usageUnit)
                               {
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            Category = category;
            Count = count;
            CountUnit = countUnit;
            Description = description;
            EndDate = MarshalConverter.DateTimeFromString(endDate);
            Price = price;
            PriceUnit = priceUnit;
            StartDate = MarshalConverter.DateTimeFromString(startDate);
            SubresourceUris = subresourceUris;
            Uri = uri;
            Usage = usage;
            UsageUnit = usageUnit;
        }
    }
}