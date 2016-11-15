using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Usage 
{

    public class TriggerResource : Resource 
    {
        public sealed class UsageCategoryEnum : StringEnum 
        {
            private UsageCategoryEnum(string value) : base(value) {}
            public UsageCategoryEnum() {}
        
            public static UsageCategoryEnum AuthyAuthentications = new UsageCategoryEnum("authy-authentications");
            public static UsageCategoryEnum AuthyCallsOutbound = new UsageCategoryEnum("authy-calls-outbound");
            public static UsageCategoryEnum AuthyMonthlyFees = new UsageCategoryEnum("authy-monthly-fees");
            public static UsageCategoryEnum AuthyPhoneIntelligence = new UsageCategoryEnum("authy-phone-intelligence");
            public static UsageCategoryEnum AuthyPhoneVerifications = new UsageCategoryEnum("authy-phone-verifications");
            public static UsageCategoryEnum AuthySmsOutbound = new UsageCategoryEnum("authy-sms-outbound");
            public static UsageCategoryEnum CallProgessEvents = new UsageCategoryEnum("call-progess-events");
            public static UsageCategoryEnum Calleridlookups = new UsageCategoryEnum("calleridlookups");
            public static UsageCategoryEnum Calls = new UsageCategoryEnum("calls");
            public static UsageCategoryEnum CallsClient = new UsageCategoryEnum("calls-client");
            public static UsageCategoryEnum CallsGlobalconference = new UsageCategoryEnum("calls-globalconference");
            public static UsageCategoryEnum CallsInbound = new UsageCategoryEnum("calls-inbound");
            public static UsageCategoryEnum CallsInboundLocal = new UsageCategoryEnum("calls-inbound-local");
            public static UsageCategoryEnum CallsInboundMobile = new UsageCategoryEnum("calls-inbound-mobile");
            public static UsageCategoryEnum CallsInboundTollfree = new UsageCategoryEnum("calls-inbound-tollfree");
            public static UsageCategoryEnum CallsOutbound = new UsageCategoryEnum("calls-outbound");
            public static UsageCategoryEnum CallsRecordings = new UsageCategoryEnum("calls-recordings");
            public static UsageCategoryEnum CallsSip = new UsageCategoryEnum("calls-sip");
            public static UsageCategoryEnum CallsSipInbound = new UsageCategoryEnum("calls-sip-inbound");
            public static UsageCategoryEnum CallsSipOutbound = new UsageCategoryEnum("calls-sip-outbound");
            public static UsageCategoryEnum CarrierLookups = new UsageCategoryEnum("carrier-lookups");
            public static UsageCategoryEnum Conversations = new UsageCategoryEnum("conversations");
            public static UsageCategoryEnum ConversationsApiRequests = new UsageCategoryEnum("conversations-api-requests");
            public static UsageCategoryEnum ConversationsConversationEvents = new UsageCategoryEnum("conversations-conversation-events");
            public static UsageCategoryEnum ConversationsEndpointConnectivity = new UsageCategoryEnum("conversations-endpoint-connectivity");
            public static UsageCategoryEnum ConversationsEvents = new UsageCategoryEnum("conversations-events");
            public static UsageCategoryEnum ConversationsParticipantEvents = new UsageCategoryEnum("conversations-participant-events");
            public static UsageCategoryEnum ConversationsParticipants = new UsageCategoryEnum("conversations-participants");
            public static UsageCategoryEnum IpMessaging = new UsageCategoryEnum("ip-messaging");
            public static UsageCategoryEnum IpMessagingCommands = new UsageCategoryEnum("ip-messaging-commands");
            public static UsageCategoryEnum IpMessagingDataStorage = new UsageCategoryEnum("ip-messaging-data-storage");
            public static UsageCategoryEnum IpMessagingDataTransfer = new UsageCategoryEnum("ip-messaging-data-transfer");
            public static UsageCategoryEnum IpMessagingEndpointConnectivity = new UsageCategoryEnum("ip-messaging-endpoint-connectivity");
            public static UsageCategoryEnum Lookups = new UsageCategoryEnum("lookups");
            public static UsageCategoryEnum Mediastorage = new UsageCategoryEnum("mediastorage");
            public static UsageCategoryEnum Mms = new UsageCategoryEnum("mms");
            public static UsageCategoryEnum MmsInbound = new UsageCategoryEnum("mms-inbound");
            public static UsageCategoryEnum MmsInboundLongcode = new UsageCategoryEnum("mms-inbound-longcode");
            public static UsageCategoryEnum MmsInboundShortcode = new UsageCategoryEnum("mms-inbound-shortcode");
            public static UsageCategoryEnum MmsOutbound = new UsageCategoryEnum("mms-outbound");
            public static UsageCategoryEnum MmsOutboundLongcode = new UsageCategoryEnum("mms-outbound-longcode");
            public static UsageCategoryEnum MmsOutboundShortcode = new UsageCategoryEnum("mms-outbound-shortcode");
            public static UsageCategoryEnum MonitorReads = new UsageCategoryEnum("monitor-reads");
            public static UsageCategoryEnum MonitorStorage = new UsageCategoryEnum("monitor-storage");
            public static UsageCategoryEnum MonitorWrites = new UsageCategoryEnum("monitor-writes");
            public static UsageCategoryEnum NumberFormatLookups = new UsageCategoryEnum("number-format-lookups");
            public static UsageCategoryEnum Phonenumbers = new UsageCategoryEnum("phonenumbers");
            public static UsageCategoryEnum PhonenumbersCps = new UsageCategoryEnum("phonenumbers-cps");
            public static UsageCategoryEnum PhonenumbersEmergency = new UsageCategoryEnum("phonenumbers-emergency");
            public static UsageCategoryEnum PhonenumbersLocal = new UsageCategoryEnum("phonenumbers-local");
            public static UsageCategoryEnum PhonenumbersMobile = new UsageCategoryEnum("phonenumbers-mobile");
            public static UsageCategoryEnum PhonenumbersSetups = new UsageCategoryEnum("phonenumbers-setups");
            public static UsageCategoryEnum PhonenumbersTollfree = new UsageCategoryEnum("phonenumbers-tollfree");
            public static UsageCategoryEnum Premiumsupport = new UsageCategoryEnum("premiumsupport");
            public static UsageCategoryEnum Recordings = new UsageCategoryEnum("recordings");
            public static UsageCategoryEnum Recordingstorage = new UsageCategoryEnum("recordingstorage");
            public static UsageCategoryEnum Shortcodes = new UsageCategoryEnum("shortcodes");
            public static UsageCategoryEnum ShortcodesCustomerowned = new UsageCategoryEnum("shortcodes-customerowned");
            public static UsageCategoryEnum ShortcodesMmsEnablement = new UsageCategoryEnum("shortcodes-mms-enablement");
            public static UsageCategoryEnum ShortcodesMps = new UsageCategoryEnum("shortcodes-mps");
            public static UsageCategoryEnum ShortcodesRandom = new UsageCategoryEnum("shortcodes-random");
            public static UsageCategoryEnum ShortcodesUk = new UsageCategoryEnum("shortcodes-uk");
            public static UsageCategoryEnum ShortcodesVanity = new UsageCategoryEnum("shortcodes-vanity");
            public static UsageCategoryEnum Sms = new UsageCategoryEnum("sms");
            public static UsageCategoryEnum SmsInbound = new UsageCategoryEnum("sms-inbound");
            public static UsageCategoryEnum SmsInboundLongcode = new UsageCategoryEnum("sms-inbound-longcode");
            public static UsageCategoryEnum SmsInboundShortcode = new UsageCategoryEnum("sms-inbound-shortcode");
            public static UsageCategoryEnum SmsOutbound = new UsageCategoryEnum("sms-outbound");
            public static UsageCategoryEnum SmsOutboundLongcode = new UsageCategoryEnum("sms-outbound-longcode");
            public static UsageCategoryEnum SmsOutboundShortcode = new UsageCategoryEnum("sms-outbound-shortcode");
            public static UsageCategoryEnum TaskrouterTasks = new UsageCategoryEnum("taskrouter-tasks");
            public static UsageCategoryEnum Totalprice = new UsageCategoryEnum("totalprice");
            public static UsageCategoryEnum Transcriptions = new UsageCategoryEnum("transcriptions");
            public static UsageCategoryEnum TrunkingCps = new UsageCategoryEnum("trunking-cps");
            public static UsageCategoryEnum TrunkingEmergencyCalls = new UsageCategoryEnum("trunking-emergency-calls");
            public static UsageCategoryEnum TrunkingOrigination = new UsageCategoryEnum("trunking-origination");
            public static UsageCategoryEnum TrunkingOriginationLocal = new UsageCategoryEnum("trunking-origination-local");
            public static UsageCategoryEnum TrunkingOriginationMobile = new UsageCategoryEnum("trunking-origination-mobile");
            public static UsageCategoryEnum TrunkingOriginationTollfree = new UsageCategoryEnum("trunking-origination-tollfree");
            public static UsageCategoryEnum TrunkingRecordings = new UsageCategoryEnum("trunking-recordings");
            public static UsageCategoryEnum TrunkingSecure = new UsageCategoryEnum("trunking-secure");
            public static UsageCategoryEnum TrunkingTermination = new UsageCategoryEnum("trunking-termination");
            public static UsageCategoryEnum Turnmegabytes = new UsageCategoryEnum("turnmegabytes");
            public static UsageCategoryEnum TurnmegabytesAustralia = new UsageCategoryEnum("turnmegabytes-australia");
            public static UsageCategoryEnum TurnmegabytesBrasil = new UsageCategoryEnum("turnmegabytes-brasil");
            public static UsageCategoryEnum TurnmegabytesIreland = new UsageCategoryEnum("turnmegabytes-ireland");
            public static UsageCategoryEnum TurnmegabytesJapan = new UsageCategoryEnum("turnmegabytes-japan");
            public static UsageCategoryEnum TurnmegabytesSingapore = new UsageCategoryEnum("turnmegabytes-singapore");
            public static UsageCategoryEnum TurnmegabytesUseast = new UsageCategoryEnum("turnmegabytes-useast");
            public static UsageCategoryEnum TurnmegabytesUswest = new UsageCategoryEnum("turnmegabytes-uswest");
        }
    
        public sealed class RecurringEnum : StringEnum 
        {
            private RecurringEnum(string value) : base(value) {}
            public RecurringEnum() {}
        
            public static RecurringEnum Daily = new RecurringEnum("daily");
            public static RecurringEnum Monthly = new RecurringEnum("monthly");
            public static RecurringEnum Yearly = new RecurringEnum("yearly");
            public static RecurringEnum Alltime = new RecurringEnum("alltime");
        }
    
        public sealed class TriggerFieldEnum : StringEnum 
        {
            private TriggerFieldEnum(string value) : base(value) {}
            public TriggerFieldEnum() {}
        
            public static TriggerFieldEnum Count = new TriggerFieldEnum("count");
            public static TriggerFieldEnum Usage = new TriggerFieldEnum("usage");
            public static TriggerFieldEnum Price = new TriggerFieldEnum("price");
        }
    
        /// <summary>
        /// Fetch and instance of a usage-trigger
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique usage-trigger Sid </param>
        /// <returns> TriggerFetcher capable of executing the fetch </returns> 
        public static TriggerFetcher Fetcher(string sid)
        {
            return new TriggerFetcher(sid);
        }
    
        /// <summary>
        /// Update an instance of a usage trigger
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TriggerUpdater capable of executing the update </returns> 
        public static TriggerUpdater Updater(string sid)
        {
            return new TriggerUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TriggerDeleter capable of executing the delete </returns> 
        public static TriggerDeleter Deleter(string sid)
        {
            return new TriggerDeleter(sid);
        }
    
        /// <summary>
        /// Create a new UsageTrigger
        /// </summary>
        ///
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        /// <returns> TriggerCreator capable of executing the create </returns> 
        public static TriggerCreator Creator(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategoryEnum usageCategory)
        {
            return new TriggerCreator(callbackUrl, triggerValue, usageCategory);
        }
    
        /// <summary>
        /// Retrieve a list of usage-triggers belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> TriggerReader capable of executing the read </returns> 
        public static TriggerReader Reader()
        {
            return new TriggerReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a TriggerResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TriggerResource object represented by the provided JSON </returns> 
        public static TriggerResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TriggerResource>(json);
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
        [JsonProperty("callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod CallbackMethod { get; set; }
        [JsonProperty("callback_url")]
        public Uri CallbackUrl { get; set; }
        [JsonProperty("current_value")]
        public string CurrentValue { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_fired")]
        public DateTime? DateFired { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("recurring")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.RecurringEnum Recurring { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("trigger_by")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.TriggerFieldEnum TriggerBy { get; set; }
        [JsonProperty("trigger_value")]
        public string TriggerValue { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("usage_category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.UsageCategoryEnum UsageCategory { get; set; }
        [JsonProperty("usage_record_uri")]
        public string UsageRecordUri { get; set; }
    
        public TriggerResource()
        {
        
        }
    
        private TriggerResource([JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("api_version")]
                                string apiVersion, 
                                [JsonProperty("callback_method")]
                                Twilio.Http.HttpMethod callbackMethod, 
                                [JsonProperty("callback_url")]
                                Uri callbackUrl, 
                                [JsonProperty("current_value")]
                                string currentValue, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_fired")]
                                string dateFired, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("recurring")]
                                TriggerResource.RecurringEnum recurring, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("trigger_by")]
                                TriggerResource.TriggerFieldEnum triggerBy, 
                                [JsonProperty("trigger_value")]
                                string triggerValue, 
                                [JsonProperty("uri")]
                                string uri, 
                                [JsonProperty("usage_category")]
                                TriggerResource.UsageCategoryEnum usageCategory, 
                                [JsonProperty("usage_record_uri")]
                                string usageRecordUri)
                                {
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            CallbackMethod = callbackMethod;
            CallbackUrl = callbackUrl;
            CurrentValue = currentValue;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateFired = MarshalConverter.DateTimeFromString(dateFired);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            Recurring = recurring;
            Sid = sid;
            TriggerBy = triggerBy;
            TriggerValue = triggerValue;
            Uri = uri;
            UsageCategory = usageCategory;
            UsageRecordUri = usageRecordUri;
        }
    }
}