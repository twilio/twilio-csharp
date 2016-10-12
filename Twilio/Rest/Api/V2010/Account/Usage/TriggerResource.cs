using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Usage {

    public class TriggerResource : SidResource {
        public sealed class UsageCategory : IStringEnum {
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
            
            public UsageCategory() { }
            
            public UsageCategory(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator UsageCategory(string value) {
                return new UsageCategory(value);
            }
            
            public static implicit operator string(UsageCategory value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class Recurring : IStringEnum {
            public const string DAILY="daily";
            public const string MONTHLY="monthly";
            public const string YEARLY="yearly";
            public const string ALLTIME="alltime";
        
            private string value;
            
            public Recurring() { }
            
            public Recurring(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Recurring(string value) {
                return new Recurring(value);
            }
            
            public static implicit operator string(Recurring value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class TriggerField : IStringEnum {
            public const string COUNT="count";
            public const string USAGE="usage";
            public const string PRICE="price";
        
            private string value;
            
            public TriggerField() { }
            
            public TriggerField(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator TriggerField(string value) {
                return new TriggerField(value);
            }
            
            public static implicit operator string(TriggerField value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// Fetch and instance of a usage-trigger
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique usage-trigger Sid </param>
        /// <returns> TriggerFetcher capable of executing the fetch </returns> 
        public static TriggerFetcher Fetcher(string accountSid, string sid) {
            return new TriggerFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a TriggerFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique usage-trigger Sid </param>
        /// <returns> TriggerFetcher capable of executing the fetch </returns> 
        public static TriggerFetcher Fetcher(string sid) {
            return new TriggerFetcher(sid);
        }
    
        /// <summary>
        /// Update an instance of a usage trigger
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TriggerUpdater capable of executing the update </returns> 
        public static TriggerUpdater Updater(string accountSid, string sid) {
            return new TriggerUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a TriggerUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TriggerUpdater capable of executing the update </returns> 
        public static TriggerUpdater Updater(string sid) {
            return new TriggerUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TriggerDeleter capable of executing the delete </returns> 
        public static TriggerDeleter Deleter(string accountSid, string sid) {
            return new TriggerDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a TriggerDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> TriggerDeleter capable of executing the delete </returns> 
        public static TriggerDeleter Deleter(string sid) {
            return new TriggerDeleter(sid);
        }
    
        /// <summary>
        /// Create a new UsageTrigger
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        /// <returns> TriggerCreator capable of executing the create </returns> 
        public static TriggerCreator Creator(string accountSid, Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory) {
            return new TriggerCreator(accountSid, callbackUrl, triggerValue, usageCategory);
        }
    
        /// <summary>
        /// Create a TriggerCreator to execute create.
        /// </summary>
        ///
        /// <param name="callbackUrl"> URL Twilio will request when the trigger fires </param>
        /// <param name="triggerValue"> the value at which the trigger will fire </param>
        /// <param name="usageCategory"> The usage category the trigger watches </param>
        /// <returns> TriggerCreator capable of executing the create </returns> 
        public static TriggerCreator Creator(Uri callbackUrl, 
                                             string triggerValue, 
                                             TriggerResource.UsageCategory usageCategory) {
            return new TriggerCreator(callbackUrl, triggerValue, usageCategory);
        }
    
        /// <summary>
        /// Retrieve a list of usage-triggers belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> TriggerReader capable of executing the read </returns> 
        public static TriggerReader Reader(string accountSid) {
            return new TriggerReader(accountSid);
        }
    
        /// <summary>
        /// Create a TriggerReader to execute read.
        /// </summary>
        ///
        /// <returns> TriggerReader capable of executing the read </returns> 
        public static TriggerReader Reader() {
            return new TriggerReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a TriggerResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TriggerResource object represented by the provided JSON </returns> 
        public static TriggerResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TriggerResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod callbackMethod;
        [JsonProperty("callback_url")]
        private readonly Uri callbackUrl;
        [JsonProperty("current_value")]
        private readonly string currentValue;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_fired")]
        private readonly DateTime? dateFired;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("recurring")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly TriggerResource.Recurring recurring;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("trigger_by")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly TriggerResource.TriggerField triggerBy;
        [JsonProperty("trigger_value")]
        private readonly string triggerValue;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("usage_category")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly TriggerResource.UsageCategory usageCategory;
        [JsonProperty("usage_record_uri")]
        private readonly string usageRecordUri;
    
        public TriggerResource() {
        
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
                                string usageRecordUri) {
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
    
        /// <returns> The account this trigger monitors. </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> HTTP method to use with callback_url </returns> 
        public Twilio.Http.HttpMethod GetCallbackMethod() {
            return this.callbackMethod;
        }
    
        /// <returns> URL Twilio will request when the trigger fires </returns> 
        public Uri GetCallbackUrl() {
            return this.callbackUrl;
        }
    
        /// <returns> The current value of the field the trigger is watching. </returns> 
        public string GetCurrentValue() {
            return this.currentValue;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date the trigger was last fired </returns> 
        public DateTime? GetDateFired() {
            return this.dateFired;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A user-specified, human-readable name for the trigger. </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> How this trigger recurs </returns> 
        public TriggerResource.Recurring GetRecurring() {
            return this.recurring;
        }
    
        /// <returns> The trigger's unique Sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The field in the UsageRecord that fires the trigger </returns> 
        public TriggerResource.TriggerField GetTriggerBy() {
            return this.triggerBy;
        }
    
        /// <returns> the value at which the trigger will fire </returns> 
        public string GetTriggerValue() {
            return this.triggerValue;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> The usage category the trigger watches </returns> 
        public TriggerResource.UsageCategory GetUsageCategory() {
            return this.usageCategory;
        }
    
        /// <returns> The URI of the UsageRecord this trigger is watching </returns> 
        public string GetUsageRecordUri() {
            return this.usageRecordUri;
        }
    }
}