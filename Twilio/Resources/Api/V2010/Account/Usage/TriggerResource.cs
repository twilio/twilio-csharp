using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Usage;
using Twilio.Deleters.Api.V2010.Account.Usage;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Usage;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Usage;

namespace Twilio.Resources.Api.V2010.Account.Usage {

    public class TriggerResource : SidResource {
        public sealed class UsageCategory : IStringEnum {
            public const string CALLERIDLOOKUPS="calleridlookups";
            public const string CALLS="calls";
            public const string CALLS_CLIENT="calls-client";
            public const string CALLS_INBOUND="calls-inbound";
            public const string CALLS_INBOUND_LOCAL="calls-inbound-local";
            public const string CALLS_INBOUND_TOLLFREE="calls-inbound-tollfree";
            public const string CALLS_OUTBOUND="calls-outbound";
            public const string CALLS_SIP="calls-sip";
            public const string PHONENUMBERS="phonenumbers";
            public const string PHONENUMBERS_LOCAL="phonenumbers-local";
            public const string PHONENUMBERS_TOLLFREE="phonenumbers-tollfree";
            public const string RECORDINGS="recordings";
            public const string RECORDINGSTORAGE="recordingstorage";
            public const string SHORTCODES="shortcodes";
            public const string SHORTCODES_CUSTOMEROWNED="shortcodes-customerowned";
            public const string SHORTCODES_RANDOM="shortcodes-random";
            public const string SHORTCODES_VANITY="shortcodes-vanity";
            public const string SMS="sms";
            public const string SMS_INBOUND="sms-inbound";
            public const string SMS_INBOUND_LONGCODE="sms-inbound-longcode";
            public const string SMS_INBOUND_SHORTCODE="sms-inbound-shortcode";
            public const string SMS_OUTBOUND="sms-outbound";
            public const string SMS_OUTBOUND_LONGCODE="sms-outbound-longcode";
            public const string SMS_OUTBOUND_SHORTCODE="sms-outbound-shortcode";
            public const string TOTALPRICE="totalprice";
            public const string TRANSCRIPTIONS="transcriptions";
        
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
    
        /**
         * Fetch and instance of a usage-trigger
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique usage-trigger Sid
         * @return TriggerFetcher capable of executing the fetch
         */
        public static TriggerFetcher Fetch(string accountSid, string sid) {
            return new TriggerFetcher(accountSid, sid);
        }
    
        /**
         * Update an instance of a usage trigger
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return TriggerUpdater capable of executing the update
         */
        public static TriggerUpdater Update(string accountSid, string sid) {
            return new TriggerUpdater(accountSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return TriggerDeleter capable of executing the delete
         */
        public static TriggerDeleter Delete(string accountSid, string sid) {
            return new TriggerDeleter(accountSid, sid);
        }
    
        /**
         * Create a new UsageTrigger
         * 
         * @param accountSid The account_sid
         * @param callbackUrl URL Twilio will request when the trigger fires
         * @param triggerValue the value at which the trigger will fire
         * @param usageCategory The usage category the trigger watches
         * @return TriggerCreator capable of executing the create
         */
        public static TriggerCreator Create(string accountSid, Uri callbackUrl, string triggerValue, TriggerResource.UsageCategory usageCategory) {
            return new TriggerCreator(accountSid, callbackUrl, triggerValue, usageCategory);
        }
    
        /**
         * Retrieve a list of usage-triggers belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return TriggerReader capable of executing the read
         */
        public static TriggerReader Read(string accountSid) {
            return new TriggerReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a TriggerResource object
         * 
         * @param json Raw JSON string
         * @return TriggerResource object represented by the provided JSON
         */
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
        private readonly System.Net.Http.HttpMethod callbackMethod;
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
                                System.Net.Http.HttpMethod callbackMethod, 
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
    
        /**
         * @return The account this trigger monitors.
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
         * @return HTTP method to use with callback_url
         */
        public System.Net.Http.HttpMethod GetCallbackMethod() {
            return this.callbackMethod;
        }
    
        /**
         * @return URL Twilio will request when the trigger fires
         */
        public Uri GetCallbackUrl() {
            return this.callbackUrl;
        }
    
        /**
         * @return The current value of the field the trigger is watching.
         */
        public string GetCurrentValue() {
            return this.currentValue;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date the trigger was last fired
         */
        public DateTime? GetDateFired() {
            return this.dateFired;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A user-specified, human-readable name for the trigger.
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return How this trigger recurs
         */
        public TriggerResource.Recurring GetRecurring() {
            return this.recurring;
        }
    
        /**
         * @return The trigger's unique Sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The field in the UsageRecord that fires the trigger
         */
        public TriggerResource.TriggerField GetTriggerBy() {
            return this.triggerBy;
        }
    
        /**
         * @return the value at which the trigger will fire
         */
        public string GetTriggerValue() {
            return this.triggerValue;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return The usage category the trigger watches
         */
        public TriggerResource.UsageCategory GetUsageCategory() {
            return this.usageCategory;
        }
    
        /**
         * @return The URI of the UsageRecord this trigger is watching
         */
        public string GetUsageRecordUri() {
            return this.usageRecordUri;
        }
    }
}