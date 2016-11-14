using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Usage.Record 
{

    public class MonthlyResource : Resource 
    {
        public sealed class MonthlyCategory : IStringEnum 
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
            
            public MonthlyCategory() {}
            
            public MonthlyCategory(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator MonthlyCategory(string value)
            {
                return new MonthlyCategory(value);
            }
            
            public static implicit operator string(MonthlyCategory value)
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
        /// <returns> MonthlyReader capable of executing the read </returns> 
        public static MonthlyReader Reader()
        {
            return new MonthlyReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a MonthlyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MonthlyResource object represented by the provided JSON </returns> 
        public static MonthlyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MonthlyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MonthlyResource.MonthlyCategory category { get; set; }
        [JsonProperty("count")]
        public string count { get; set; }
        [JsonProperty("count_unit")]
        public string countUnit { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("end_date")]
        public DateTime? endDate { get; set; }
        [JsonProperty("price")]
        public decimal? price { get; set; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; set; }
        [JsonProperty("start_date")]
        public DateTime? startDate { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
        [JsonProperty("usage")]
        public string usage { get; set; }
        [JsonProperty("usage_unit")]
        public string usageUnit { get; set; }
    
        public MonthlyResource()
        {
        
        }
    
        private MonthlyResource([JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("api_version")]
                                string apiVersion, 
                                [JsonProperty("category")]
                                MonthlyResource.MonthlyCategory category, 
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
    }
}