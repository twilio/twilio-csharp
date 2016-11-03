using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Usage 
{

    public class TriggerResource : Resource 
    {
        public sealed class UsageCategory : IStringEnum 
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
            
            public UsageCategory() {}
            
            public UsageCategory(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator UsageCategory(string value)
            {
                return new UsageCategory(value);
            }
            
            public static implicit operator string(UsageCategory value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class Recurring : IStringEnum 
        {
            public const string Daily = "daily";
            public const string Monthly = "monthly";
            public const string Yearly = "yearly";
            public const string Alltime = "alltime";
        
            private string _value;
            
            public Recurring() {}
            
            public Recurring(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Recurring(string value)
            {
                return new Recurring(value);
            }
            
            public static implicit operator string(Recurring value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class TriggerField : IStringEnum 
        {
            public const string Count = "count";
            public const string Usage = "usage";
            public const string Price = "price";
        
            private string _value;
            
            public TriggerField() {}
            
            public TriggerField(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator TriggerField(string value)
            {
                return new TriggerField(value);
            }
            
            public static implicit operator string(TriggerField value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
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
        public static TriggerCreator Creator(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory)
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
        public string accountSid { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod callbackMethod { get; set; }
        [JsonProperty("callback_url")]
        public Uri callbackUrl { get; set; }
        [JsonProperty("current_value")]
        public string currentValue { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_fired")]
        public DateTime? dateFired { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("recurring")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.Recurring recurring { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("trigger_by")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.TriggerField triggerBy { get; set; }
        [JsonProperty("trigger_value")]
        public string triggerValue { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
        [JsonProperty("usage_category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.UsageCategory usageCategory { get; set; }
        [JsonProperty("usage_record_uri")]
        public string usageRecordUri { get; set; }
    
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
                                TriggerResource.Recurring recurring, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("trigger_by")]
                                TriggerResource.TriggerField triggerBy, 
                                [JsonProperty("trigger_value")]
                                string triggerValue, 
                                [JsonProperty("uri")]
                                string uri, 
                                [JsonProperty("usage_category")]
                                TriggerResource.UsageCategory usageCategory, 
                                [JsonProperty("usage_record_uri")]
                                string usageRecordUri)
                                {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callbackMethod = callbackMethod;
            this.callbackUrl = callbackUrl;
            this.currentValue = currentValue;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateFired = MarshalConverter.DateTimeFromString(dateFired);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.recurring = recurring;
            this.sid = sid;
            this.triggerBy = triggerBy;
            this.triggerValue = triggerValue;
            this.uri = uri;
            this.usageCategory = usageCategory;
            this.usageRecordUri = usageRecordUri;
        }
    }
}