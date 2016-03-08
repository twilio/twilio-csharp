using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Usage;
using Twilio.Deleters.Api.V2010.Account.Usage;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Usage;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Usage;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Usage;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Usage {

    public class Trigger : SidResource {
        public enum UsageCategory {
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
    
        public enum Recurring {
            DAILY="daily",
            MONTHLY="monthly",
            YEARLY="yearly",
            ALLTIME="alltime"
        };
    
        public enum TriggerField {
            COUNT="count",
            USAGE="usage",
            PRICE="price"
        };
    
        /**
         * Fetch and instance of a usage-trigger
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique usage-trigger Sid
         * @return TriggerFetcher capable of executing the fetch
         */
        public static TriggerFetcher fetch(String accountSid, String sid) {
            return new TriggerFetcher(accountSid, sid);
        }
    
        /**
         * Update an instance of a usage trigger
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return TriggerUpdater capable of executing the update
         */
        public static TriggerUpdater update(String accountSid, String sid) {
            return new TriggerUpdater(accountSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return TriggerDeleter capable of executing the delete
         */
        public static TriggerDeleter delete(String accountSid, String sid) {
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
        public static TriggerCreator create(String accountSid, URI callbackUrl, String triggerValue, Trigger.UsageCategory usageCategory) {
            return new TriggerCreator(accountSid, callbackUrl, triggerValue, usageCategory);
        }
    
        /**
         * Retrieve a list of usage-triggers belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return TriggerReader capable of executing the read
         */
        public static TriggerReader read(String accountSid) {
            return new TriggerReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Trigger object
         * 
         * @param json Raw JSON string
         * @return Trigger object represented by the provided JSON
         */
        public static Trigger fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Trigger>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("callback_method")]
        private readonly HttpMethod callbackMethod;
        [JsonProperty("callback_url")]
        private readonly URI callbackUrl;
        [JsonProperty("current_value")]
        private readonly String currentValue;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_fired")]
        private readonly DateTime dateFired;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("recurring")]
        private readonly Trigger.Recurring recurring;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("trigger_by")]
        private readonly Trigger.TriggerField triggerBy;
        [JsonProperty("trigger_value")]
        private readonly String triggerValue;
        [JsonProperty("uri")]
        private readonly String uri;
        [JsonProperty("usage_category")]
        private readonly Trigger.UsageCategory usageCategory;
        [JsonProperty("usage_record_uri")]
        private readonly String usageRecordUri;
    
        private Trigger([JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("api_version")]
                        String apiVersion, 
                        [JsonProperty("callback_method")]
                        HttpMethod callbackMethod, 
                        [JsonProperty("callback_url")]
                        URI callbackUrl, 
                        [JsonProperty("current_value")]
                        String currentValue, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_fired")]
                        String dateFired, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("friendly_name")]
                        String friendlyName, 
                        [JsonProperty("recurring")]
                        Trigger.Recurring recurring, 
                        [JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("trigger_by")]
                        Trigger.TriggerField triggerBy, 
                        [JsonProperty("trigger_value")]
                        String triggerValue, 
                        [JsonProperty("uri")]
                        String uri, 
                        [JsonProperty("usage_category")]
                        Trigger.UsageCategory usageCategory, 
                        [JsonProperty("usage_record_uri")]
                        String usageRecordUri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callbackMethod = callbackMethod;
            this.callbackUrl = callbackUrl;
            this.currentValue = currentValue;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateFired = MarshalConverter.dateTimeFromString(dateFired);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
         * @return HTTP method to use with callback_url
         */
        public HttpMethod GetCallbackMethod() {
            return this.callbackMethod;
        }
    
        /**
         * @return URL Twilio will request when the trigger fires
         */
        public URI GetCallbackUrl() {
            return this.callbackUrl;
        }
    
        /**
         * @return The current value of the field the trigger is watching.
         */
        public String GetCurrentValue() {
            return this.currentValue;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date the trigger was last fired
         */
        public DateTime GetDateFired() {
            return this.dateFired;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A user-specified, human-readable name for the trigger.
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return How this trigger recurs
         */
        public Trigger.Recurring GetRecurring() {
            return this.recurring;
        }
    
        /**
         * @return The trigger's unique Sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The field in the UsageRecord that fires the trigger
         */
        public Trigger.TriggerField GetTriggerBy() {
            return this.triggerBy;
        }
    
        /**
         * @return the value at which the trigger will fire
         */
        public String GetTriggerValue() {
            return this.triggerValue;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    
        /**
         * @return The usage category the trigger watches
         */
        public Trigger.UsageCategory GetUsageCategory() {
            return this.usageCategory;
        }
    
        /**
         * @return The URI of the UsageRecord this trigger is watching
         */
        public String GetUsageRecordUri() {
            return this.usageRecordUri;
        }
    }
}