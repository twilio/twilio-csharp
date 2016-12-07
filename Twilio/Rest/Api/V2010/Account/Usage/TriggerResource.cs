using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Usage 
{

    public class TriggerResource : Resource 
    {
        public sealed class UsageCategoryEnum : StringEnum 
        {
            private UsageCategoryEnum(string value) : base(value) {}
            public UsageCategoryEnum() {}
        
            public static readonly UsageCategoryEnum AuthyAuthentications = new UsageCategoryEnum("authy-authentications");
            public static readonly UsageCategoryEnum AuthyCallsOutbound = new UsageCategoryEnum("authy-calls-outbound");
            public static readonly UsageCategoryEnum AuthyMonthlyFees = new UsageCategoryEnum("authy-monthly-fees");
            public static readonly UsageCategoryEnum AuthyPhoneIntelligence = new UsageCategoryEnum("authy-phone-intelligence");
            public static readonly UsageCategoryEnum AuthyPhoneVerifications = new UsageCategoryEnum("authy-phone-verifications");
            public static readonly UsageCategoryEnum AuthySmsOutbound = new UsageCategoryEnum("authy-sms-outbound");
            public static readonly UsageCategoryEnum CallProgessEvents = new UsageCategoryEnum("call-progess-events");
            public static readonly UsageCategoryEnum Calleridlookups = new UsageCategoryEnum("calleridlookups");
            public static readonly UsageCategoryEnum Calls = new UsageCategoryEnum("calls");
            public static readonly UsageCategoryEnum CallsClient = new UsageCategoryEnum("calls-client");
            public static readonly UsageCategoryEnum CallsGlobalconference = new UsageCategoryEnum("calls-globalconference");
            public static readonly UsageCategoryEnum CallsInbound = new UsageCategoryEnum("calls-inbound");
            public static readonly UsageCategoryEnum CallsInboundLocal = new UsageCategoryEnum("calls-inbound-local");
            public static readonly UsageCategoryEnum CallsInboundMobile = new UsageCategoryEnum("calls-inbound-mobile");
            public static readonly UsageCategoryEnum CallsInboundTollfree = new UsageCategoryEnum("calls-inbound-tollfree");
            public static readonly UsageCategoryEnum CallsOutbound = new UsageCategoryEnum("calls-outbound");
            public static readonly UsageCategoryEnum CallsRecordings = new UsageCategoryEnum("calls-recordings");
            public static readonly UsageCategoryEnum CallsSip = new UsageCategoryEnum("calls-sip");
            public static readonly UsageCategoryEnum CallsSipInbound = new UsageCategoryEnum("calls-sip-inbound");
            public static readonly UsageCategoryEnum CallsSipOutbound = new UsageCategoryEnum("calls-sip-outbound");
            public static readonly UsageCategoryEnum CarrierLookups = new UsageCategoryEnum("carrier-lookups");
            public static readonly UsageCategoryEnum Conversations = new UsageCategoryEnum("conversations");
            public static readonly UsageCategoryEnum ConversationsApiRequests = new UsageCategoryEnum("conversations-api-requests");
            public static readonly UsageCategoryEnum ConversationsConversationEvents = new UsageCategoryEnum("conversations-conversation-events");
            public static readonly UsageCategoryEnum ConversationsEndpointConnectivity = new UsageCategoryEnum("conversations-endpoint-connectivity");
            public static readonly UsageCategoryEnum ConversationsEvents = new UsageCategoryEnum("conversations-events");
            public static readonly UsageCategoryEnum ConversationsParticipantEvents = new UsageCategoryEnum("conversations-participant-events");
            public static readonly UsageCategoryEnum ConversationsParticipants = new UsageCategoryEnum("conversations-participants");
            public static readonly UsageCategoryEnum IpMessaging = new UsageCategoryEnum("ip-messaging");
            public static readonly UsageCategoryEnum IpMessagingCommands = new UsageCategoryEnum("ip-messaging-commands");
            public static readonly UsageCategoryEnum IpMessagingDataStorage = new UsageCategoryEnum("ip-messaging-data-storage");
            public static readonly UsageCategoryEnum IpMessagingDataTransfer = new UsageCategoryEnum("ip-messaging-data-transfer");
            public static readonly UsageCategoryEnum IpMessagingEndpointConnectivity = new UsageCategoryEnum("ip-messaging-endpoint-connectivity");
            public static readonly UsageCategoryEnum Lookups = new UsageCategoryEnum("lookups");
            public static readonly UsageCategoryEnum Mediastorage = new UsageCategoryEnum("mediastorage");
            public static readonly UsageCategoryEnum Mms = new UsageCategoryEnum("mms");
            public static readonly UsageCategoryEnum MmsInbound = new UsageCategoryEnum("mms-inbound");
            public static readonly UsageCategoryEnum MmsInboundLongcode = new UsageCategoryEnum("mms-inbound-longcode");
            public static readonly UsageCategoryEnum MmsInboundShortcode = new UsageCategoryEnum("mms-inbound-shortcode");
            public static readonly UsageCategoryEnum MmsOutbound = new UsageCategoryEnum("mms-outbound");
            public static readonly UsageCategoryEnum MmsOutboundLongcode = new UsageCategoryEnum("mms-outbound-longcode");
            public static readonly UsageCategoryEnum MmsOutboundShortcode = new UsageCategoryEnum("mms-outbound-shortcode");
            public static readonly UsageCategoryEnum MonitorReads = new UsageCategoryEnum("monitor-reads");
            public static readonly UsageCategoryEnum MonitorStorage = new UsageCategoryEnum("monitor-storage");
            public static readonly UsageCategoryEnum MonitorWrites = new UsageCategoryEnum("monitor-writes");
            public static readonly UsageCategoryEnum NumberFormatLookups = new UsageCategoryEnum("number-format-lookups");
            public static readonly UsageCategoryEnum Phonenumbers = new UsageCategoryEnum("phonenumbers");
            public static readonly UsageCategoryEnum PhonenumbersCps = new UsageCategoryEnum("phonenumbers-cps");
            public static readonly UsageCategoryEnum PhonenumbersEmergency = new UsageCategoryEnum("phonenumbers-emergency");
            public static readonly UsageCategoryEnum PhonenumbersLocal = new UsageCategoryEnum("phonenumbers-local");
            public static readonly UsageCategoryEnum PhonenumbersMobile = new UsageCategoryEnum("phonenumbers-mobile");
            public static readonly UsageCategoryEnum PhonenumbersSetups = new UsageCategoryEnum("phonenumbers-setups");
            public static readonly UsageCategoryEnum PhonenumbersTollfree = new UsageCategoryEnum("phonenumbers-tollfree");
            public static readonly UsageCategoryEnum Premiumsupport = new UsageCategoryEnum("premiumsupport");
            public static readonly UsageCategoryEnum Recordings = new UsageCategoryEnum("recordings");
            public static readonly UsageCategoryEnum Recordingstorage = new UsageCategoryEnum("recordingstorage");
            public static readonly UsageCategoryEnum Shortcodes = new UsageCategoryEnum("shortcodes");
            public static readonly UsageCategoryEnum ShortcodesCustomerowned = new UsageCategoryEnum("shortcodes-customerowned");
            public static readonly UsageCategoryEnum ShortcodesMmsEnablement = new UsageCategoryEnum("shortcodes-mms-enablement");
            public static readonly UsageCategoryEnum ShortcodesMps = new UsageCategoryEnum("shortcodes-mps");
            public static readonly UsageCategoryEnum ShortcodesRandom = new UsageCategoryEnum("shortcodes-random");
            public static readonly UsageCategoryEnum ShortcodesUk = new UsageCategoryEnum("shortcodes-uk");
            public static readonly UsageCategoryEnum ShortcodesVanity = new UsageCategoryEnum("shortcodes-vanity");
            public static readonly UsageCategoryEnum Sms = new UsageCategoryEnum("sms");
            public static readonly UsageCategoryEnum SmsInbound = new UsageCategoryEnum("sms-inbound");
            public static readonly UsageCategoryEnum SmsInboundLongcode = new UsageCategoryEnum("sms-inbound-longcode");
            public static readonly UsageCategoryEnum SmsInboundShortcode = new UsageCategoryEnum("sms-inbound-shortcode");
            public static readonly UsageCategoryEnum SmsOutbound = new UsageCategoryEnum("sms-outbound");
            public static readonly UsageCategoryEnum SmsOutboundLongcode = new UsageCategoryEnum("sms-outbound-longcode");
            public static readonly UsageCategoryEnum SmsOutboundShortcode = new UsageCategoryEnum("sms-outbound-shortcode");
            public static readonly UsageCategoryEnum TaskrouterTasks = new UsageCategoryEnum("taskrouter-tasks");
            public static readonly UsageCategoryEnum Totalprice = new UsageCategoryEnum("totalprice");
            public static readonly UsageCategoryEnum Transcriptions = new UsageCategoryEnum("transcriptions");
            public static readonly UsageCategoryEnum TrunkingCps = new UsageCategoryEnum("trunking-cps");
            public static readonly UsageCategoryEnum TrunkingEmergencyCalls = new UsageCategoryEnum("trunking-emergency-calls");
            public static readonly UsageCategoryEnum TrunkingOrigination = new UsageCategoryEnum("trunking-origination");
            public static readonly UsageCategoryEnum TrunkingOriginationLocal = new UsageCategoryEnum("trunking-origination-local");
            public static readonly UsageCategoryEnum TrunkingOriginationMobile = new UsageCategoryEnum("trunking-origination-mobile");
            public static readonly UsageCategoryEnum TrunkingOriginationTollfree = new UsageCategoryEnum("trunking-origination-tollfree");
            public static readonly UsageCategoryEnum TrunkingRecordings = new UsageCategoryEnum("trunking-recordings");
            public static readonly UsageCategoryEnum TrunkingSecure = new UsageCategoryEnum("trunking-secure");
            public static readonly UsageCategoryEnum TrunkingTermination = new UsageCategoryEnum("trunking-termination");
            public static readonly UsageCategoryEnum Turnmegabytes = new UsageCategoryEnum("turnmegabytes");
            public static readonly UsageCategoryEnum TurnmegabytesAustralia = new UsageCategoryEnum("turnmegabytes-australia");
            public static readonly UsageCategoryEnum TurnmegabytesBrasil = new UsageCategoryEnum("turnmegabytes-brasil");
            public static readonly UsageCategoryEnum TurnmegabytesIreland = new UsageCategoryEnum("turnmegabytes-ireland");
            public static readonly UsageCategoryEnum TurnmegabytesJapan = new UsageCategoryEnum("turnmegabytes-japan");
            public static readonly UsageCategoryEnum TurnmegabytesSingapore = new UsageCategoryEnum("turnmegabytes-singapore");
            public static readonly UsageCategoryEnum TurnmegabytesUseast = new UsageCategoryEnum("turnmegabytes-useast");
            public static readonly UsageCategoryEnum TurnmegabytesUswest = new UsageCategoryEnum("turnmegabytes-uswest");
        }
    
        public sealed class RecurringEnum : StringEnum 
        {
            private RecurringEnum(string value) : base(value) {}
            public RecurringEnum() {}
        
            public static readonly RecurringEnum Daily = new RecurringEnum("daily");
            public static readonly RecurringEnum Monthly = new RecurringEnum("monthly");
            public static readonly RecurringEnum Yearly = new RecurringEnum("yearly");
            public static readonly RecurringEnum Alltime = new RecurringEnum("alltime");
        }
    
        public sealed class TriggerFieldEnum : StringEnum 
        {
            private TriggerFieldEnum(string value) : base(value) {}
            public TriggerFieldEnum() {}
        
            public static readonly TriggerFieldEnum Count = new TriggerFieldEnum("count");
            public static readonly TriggerFieldEnum Usage = new TriggerFieldEnum("usage");
            public static readonly TriggerFieldEnum Price = new TriggerFieldEnum("price");
        }
    
        private static Request BuildFetchRequest(FetchTriggerOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Usage/Triggers/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch and instance of a usage-trigger
        /// </summary>
        public static TriggerResource Fetch(FetchTriggerOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TriggerResource> FetchAsync(FetchTriggerOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch and instance of a usage-trigger
        /// </summary>
        public static TriggerResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchTriggerOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TriggerResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchTriggerOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateTriggerOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Usage/Triggers/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update an instance of a usage trigger
        /// </summary>
        public static TriggerResource Update(UpdateTriggerOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TriggerResource> UpdateAsync(UpdateTriggerOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Update an instance of a usage trigger
        /// </summary>
        public static TriggerResource Update(string sid, string accountSid = null, Twilio.Http.HttpMethod callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTriggerOptions(sid){AccountSid = accountSid, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TriggerResource> UpdateAsync(string sid, string accountSid = null, Twilio.Http.HttpMethod callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTriggerOptions(sid){AccountSid = accountSid, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteTriggerOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Usage/Triggers/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteTriggerOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteTriggerOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteTriggerOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteTriggerOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateTriggerOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Usage/Triggers.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Create a new UsageTrigger
        /// </summary>
        public static TriggerResource Create(CreateTriggerOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TriggerResource> CreateAsync(CreateTriggerOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Create a new UsageTrigger
        /// </summary>
        public static TriggerResource Create(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategoryEnum usageCategory, string accountSid = null, Twilio.Http.HttpMethod callbackMethod = null, string friendlyName = null, TriggerResource.RecurringEnum recurring = null, TriggerResource.TriggerFieldEnum triggerBy = null, ITwilioRestClient client = null)
        {
            var options = new CreateTriggerOptions(callbackUrl, triggerValue, usageCategory){AccountSid = accountSid, CallbackMethod = callbackMethod, FriendlyName = friendlyName, Recurring = recurring, TriggerBy = triggerBy};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TriggerResource> CreateAsync(Uri callbackUrl, string triggerValue, TriggerResource.UsageCategoryEnum usageCategory, string accountSid = null, Twilio.Http.HttpMethod callbackMethod = null, string friendlyName = null, TriggerResource.RecurringEnum recurring = null, TriggerResource.TriggerFieldEnum triggerBy = null, ITwilioRestClient client = null)
        {
            var options = new CreateTriggerOptions(callbackUrl, triggerValue, usageCategory){AccountSid = accountSid, CallbackMethod = callbackMethod, FriendlyName = friendlyName, Recurring = recurring, TriggerBy = triggerBy};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadTriggerOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Usage/Triggers.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of usage-triggers belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<TriggerResource> Read(ReadTriggerOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TriggerResource>.FromJson("usage_triggers", response.Content);
            return new ResourceSet<TriggerResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TriggerResource>> ReadAsync(ReadTriggerOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of usage-triggers belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<TriggerResource> Read(string accountSid = null, TriggerResource.RecurringEnum recurring = null, TriggerResource.TriggerFieldEnum triggerBy = null, TriggerResource.UsageCategoryEnum usageCategory = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTriggerOptions{AccountSid = accountSid, Recurring = recurring, TriggerBy = triggerBy, UsageCategory = usageCategory, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TriggerResource>> ReadAsync(string accountSid = null, TriggerResource.RecurringEnum recurring = null, TriggerResource.TriggerFieldEnum triggerBy = null, TriggerResource.UsageCategoryEnum usageCategory = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTriggerOptions{AccountSid = accountSid, Recurring = recurring, TriggerBy = triggerBy, UsageCategory = usageCategory, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<TriggerResource> NextPage(Page<TriggerResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TriggerResource>.FromJson("usage_triggers", response.Content);
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
        public string AccountSid { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod CallbackMethod { get; private set; }
        [JsonProperty("callback_url")]
        public Uri CallbackUrl { get; private set; }
        [JsonProperty("current_value")]
        public string CurrentValue { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_fired")]
        public DateTime? DateFired { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("recurring")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.RecurringEnum Recurring { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("trigger_by")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.TriggerFieldEnum TriggerBy { get; private set; }
        [JsonProperty("trigger_value")]
        public string TriggerValue { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
        [JsonProperty("usage_category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TriggerResource.UsageCategoryEnum UsageCategory { get; private set; }
        [JsonProperty("usage_record_uri")]
        public string UsageRecordUri { get; private set; }
    
        private TriggerResource()
        {
        
        }
    }

}