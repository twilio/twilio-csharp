using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Usage 
{

    public class RecordResource : Resource 
    {
        public sealed class CategoryEnum : StringEnum 
        {
            private CategoryEnum(string value) : base(value) {}
            public CategoryEnum() {}
        
            public static CategoryEnum AuthyAuthentications = new CategoryEnum("authy-authentications");
            public static CategoryEnum AuthyCallsOutbound = new CategoryEnum("authy-calls-outbound");
            public static CategoryEnum AuthyMonthlyFees = new CategoryEnum("authy-monthly-fees");
            public static CategoryEnum AuthyPhoneIntelligence = new CategoryEnum("authy-phone-intelligence");
            public static CategoryEnum AuthyPhoneVerifications = new CategoryEnum("authy-phone-verifications");
            public static CategoryEnum AuthySmsOutbound = new CategoryEnum("authy-sms-outbound");
            public static CategoryEnum CallProgessEvents = new CategoryEnum("call-progess-events");
            public static CategoryEnum Calleridlookups = new CategoryEnum("calleridlookups");
            public static CategoryEnum Calls = new CategoryEnum("calls");
            public static CategoryEnum CallsClient = new CategoryEnum("calls-client");
            public static CategoryEnum CallsGlobalconference = new CategoryEnum("calls-globalconference");
            public static CategoryEnum CallsInbound = new CategoryEnum("calls-inbound");
            public static CategoryEnum CallsInboundLocal = new CategoryEnum("calls-inbound-local");
            public static CategoryEnum CallsInboundMobile = new CategoryEnum("calls-inbound-mobile");
            public static CategoryEnum CallsInboundTollfree = new CategoryEnum("calls-inbound-tollfree");
            public static CategoryEnum CallsOutbound = new CategoryEnum("calls-outbound");
            public static CategoryEnum CallsRecordings = new CategoryEnum("calls-recordings");
            public static CategoryEnum CallsSip = new CategoryEnum("calls-sip");
            public static CategoryEnum CallsSipInbound = new CategoryEnum("calls-sip-inbound");
            public static CategoryEnum CallsSipOutbound = new CategoryEnum("calls-sip-outbound");
            public static CategoryEnum CarrierLookups = new CategoryEnum("carrier-lookups");
            public static CategoryEnum Conversations = new CategoryEnum("conversations");
            public static CategoryEnum ConversationsApiRequests = new CategoryEnum("conversations-api-requests");
            public static CategoryEnum ConversationsConversationEvents = new CategoryEnum("conversations-conversation-events");
            public static CategoryEnum ConversationsEndpointConnectivity = new CategoryEnum("conversations-endpoint-connectivity");
            public static CategoryEnum ConversationsEvents = new CategoryEnum("conversations-events");
            public static CategoryEnum ConversationsParticipantEvents = new CategoryEnum("conversations-participant-events");
            public static CategoryEnum ConversationsParticipants = new CategoryEnum("conversations-participants");
            public static CategoryEnum IpMessaging = new CategoryEnum("ip-messaging");
            public static CategoryEnum IpMessagingCommands = new CategoryEnum("ip-messaging-commands");
            public static CategoryEnum IpMessagingDataStorage = new CategoryEnum("ip-messaging-data-storage");
            public static CategoryEnum IpMessagingDataTransfer = new CategoryEnum("ip-messaging-data-transfer");
            public static CategoryEnum IpMessagingEndpointConnectivity = new CategoryEnum("ip-messaging-endpoint-connectivity");
            public static CategoryEnum Lookups = new CategoryEnum("lookups");
            public static CategoryEnum Mediastorage = new CategoryEnum("mediastorage");
            public static CategoryEnum Mms = new CategoryEnum("mms");
            public static CategoryEnum MmsInbound = new CategoryEnum("mms-inbound");
            public static CategoryEnum MmsInboundLongcode = new CategoryEnum("mms-inbound-longcode");
            public static CategoryEnum MmsInboundShortcode = new CategoryEnum("mms-inbound-shortcode");
            public static CategoryEnum MmsOutbound = new CategoryEnum("mms-outbound");
            public static CategoryEnum MmsOutboundLongcode = new CategoryEnum("mms-outbound-longcode");
            public static CategoryEnum MmsOutboundShortcode = new CategoryEnum("mms-outbound-shortcode");
            public static CategoryEnum MonitorReads = new CategoryEnum("monitor-reads");
            public static CategoryEnum MonitorStorage = new CategoryEnum("monitor-storage");
            public static CategoryEnum MonitorWrites = new CategoryEnum("monitor-writes");
            public static CategoryEnum NumberFormatLookups = new CategoryEnum("number-format-lookups");
            public static CategoryEnum Phonenumbers = new CategoryEnum("phonenumbers");
            public static CategoryEnum PhonenumbersCps = new CategoryEnum("phonenumbers-cps");
            public static CategoryEnum PhonenumbersEmergency = new CategoryEnum("phonenumbers-emergency");
            public static CategoryEnum PhonenumbersLocal = new CategoryEnum("phonenumbers-local");
            public static CategoryEnum PhonenumbersMobile = new CategoryEnum("phonenumbers-mobile");
            public static CategoryEnum PhonenumbersSetups = new CategoryEnum("phonenumbers-setups");
            public static CategoryEnum PhonenumbersTollfree = new CategoryEnum("phonenumbers-tollfree");
            public static CategoryEnum Premiumsupport = new CategoryEnum("premiumsupport");
            public static CategoryEnum Recordings = new CategoryEnum("recordings");
            public static CategoryEnum Recordingstorage = new CategoryEnum("recordingstorage");
            public static CategoryEnum Shortcodes = new CategoryEnum("shortcodes");
            public static CategoryEnum ShortcodesCustomerowned = new CategoryEnum("shortcodes-customerowned");
            public static CategoryEnum ShortcodesMmsEnablement = new CategoryEnum("shortcodes-mms-enablement");
            public static CategoryEnum ShortcodesMps = new CategoryEnum("shortcodes-mps");
            public static CategoryEnum ShortcodesRandom = new CategoryEnum("shortcodes-random");
            public static CategoryEnum ShortcodesUk = new CategoryEnum("shortcodes-uk");
            public static CategoryEnum ShortcodesVanity = new CategoryEnum("shortcodes-vanity");
            public static CategoryEnum Sms = new CategoryEnum("sms");
            public static CategoryEnum SmsInbound = new CategoryEnum("sms-inbound");
            public static CategoryEnum SmsInboundLongcode = new CategoryEnum("sms-inbound-longcode");
            public static CategoryEnum SmsInboundShortcode = new CategoryEnum("sms-inbound-shortcode");
            public static CategoryEnum SmsOutbound = new CategoryEnum("sms-outbound");
            public static CategoryEnum SmsOutboundLongcode = new CategoryEnum("sms-outbound-longcode");
            public static CategoryEnum SmsOutboundShortcode = new CategoryEnum("sms-outbound-shortcode");
            public static CategoryEnum TaskrouterTasks = new CategoryEnum("taskrouter-tasks");
            public static CategoryEnum Totalprice = new CategoryEnum("totalprice");
            public static CategoryEnum Transcriptions = new CategoryEnum("transcriptions");
            public static CategoryEnum TrunkingCps = new CategoryEnum("trunking-cps");
            public static CategoryEnum TrunkingEmergencyCalls = new CategoryEnum("trunking-emergency-calls");
            public static CategoryEnum TrunkingOrigination = new CategoryEnum("trunking-origination");
            public static CategoryEnum TrunkingOriginationLocal = new CategoryEnum("trunking-origination-local");
            public static CategoryEnum TrunkingOriginationMobile = new CategoryEnum("trunking-origination-mobile");
            public static CategoryEnum TrunkingOriginationTollfree = new CategoryEnum("trunking-origination-tollfree");
            public static CategoryEnum TrunkingRecordings = new CategoryEnum("trunking-recordings");
            public static CategoryEnum TrunkingSecure = new CategoryEnum("trunking-secure");
            public static CategoryEnum TrunkingTermination = new CategoryEnum("trunking-termination");
            public static CategoryEnum Turnmegabytes = new CategoryEnum("turnmegabytes");
            public static CategoryEnum TurnmegabytesAustralia = new CategoryEnum("turnmegabytes-australia");
            public static CategoryEnum TurnmegabytesBrasil = new CategoryEnum("turnmegabytes-brasil");
            public static CategoryEnum TurnmegabytesIreland = new CategoryEnum("turnmegabytes-ireland");
            public static CategoryEnum TurnmegabytesJapan = new CategoryEnum("turnmegabytes-japan");
            public static CategoryEnum TurnmegabytesSingapore = new CategoryEnum("turnmegabytes-singapore");
            public static CategoryEnum TurnmegabytesUseast = new CategoryEnum("turnmegabytes-useast");
            public static CategoryEnum TurnmegabytesUswest = new CategoryEnum("turnmegabytes-uswest");
        }
    
        /// <summary>
        /// Retrieve a list of usage-records belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> RecordReader capable of executing the read </returns> 
        public static RecordReader Reader()
        {
            return new RecordReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a RecordResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordResource object represented by the provided JSON </returns> 
        public static RecordResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RecordResource>(json);
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
        public RecordResource.CategoryEnum Category { get; set; }
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
    
        public RecordResource()
        {
        
        }
    
        private RecordResource([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("api_version")]
                               string apiVersion, 
                               [JsonProperty("category")]
                               RecordResource.CategoryEnum category, 
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