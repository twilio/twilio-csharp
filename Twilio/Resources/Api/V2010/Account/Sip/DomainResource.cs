using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip;

namespace Twilio.Resources.Api.V2010.Account.Sip {

    public class DomainResource : SidResource {
        /**
         * Retrieve a list of domains belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return DomainReader capable of executing the read
         */
        public static DomainReader Read(string accountSid) {
            return new DomainReader(accountSid);
        }
    
        /**
         * Create a new Domain
         * 
         * @param accountSid The account_sid
         * @param domainName The unique address on Twilio to route SIP traffic
         * @return DomainCreator capable of executing the create
         */
        public static DomainCreator Create(string accountSid, string domainName) {
            return new DomainCreator(accountSid, domainName);
        }
    
        /**
         * Fetch an instance of a Domain
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique Domain Sid
         * @return DomainFetcher capable of executing the fetch
         */
        public static DomainFetcher Fetch(string accountSid, string sid) {
            return new DomainFetcher(accountSid, sid);
        }
    
        /**
         * Update the attributes of a domain
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return DomainUpdater capable of executing the update
         */
        public static DomainUpdater Update(string accountSid, string sid) {
            return new DomainUpdater(accountSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return DomainDeleter capable of executing the delete
         */
        public static DomainDeleter Delete(string accountSid, string sid) {
            return new DomainDeleter(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a DomainResource object
         * 
         * @param json Raw JSON string
         * @return DomainResource object represented by the provided JSON
         */
        public static DomainResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<DomainResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("auth_type")]
        private readonly string authType;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("domain_name")]
        private readonly string domainName;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("voice_fallback_method")]
        private readonly System.Net.Http.HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly Uri voiceFallbackUrl;
        [JsonProperty("voice_method")]
        private readonly System.Net.Http.HttpMethod voiceMethod;
        [JsonProperty("voice_status_callback_method")]
        private readonly System.Net.Http.HttpMethod voiceStatusCallbackMethod;
        [JsonProperty("voice_status_callback_url")]
        private readonly Uri voiceStatusCallbackUrl;
        [JsonProperty("voice_url")]
        private readonly Uri voiceUrl;
    
        public DomainResource() {
        
        }
    
        private DomainResource([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("api_version")]
                               string apiVersion, 
                               [JsonProperty("auth_type")]
                               string authType, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("domain_name")]
                               string domainName, 
                               [JsonProperty("friendly_name")]
                               string friendlyName, 
                               [JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("uri")]
                               string uri, 
                               [JsonProperty("voice_fallback_method")]
                               System.Net.Http.HttpMethod voiceFallbackMethod, 
                               [JsonProperty("voice_fallback_url")]
                               Uri voiceFallbackUrl, 
                               [JsonProperty("voice_method")]
                               System.Net.Http.HttpMethod voiceMethod, 
                               [JsonProperty("voice_status_callback_method")]
                               System.Net.Http.HttpMethod voiceStatusCallbackMethod, 
                               [JsonProperty("voice_status_callback_url")]
                               Uri voiceStatusCallbackUrl, 
                               [JsonProperty("voice_url")]
                               Uri voiceUrl) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.authType = authType;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.domainName = domainName;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uri = uri;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.voiceMethod = voiceMethod;
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            this.voiceUrl = voiceUrl;
        }
    
        /**
         * @return The unique id of the account that sent the message
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The Twilio API version used to process the message
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The types of authentication mapped to the domain
         */
        public string GetAuthType() {
            return this.authType;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The unique address on Twilio to route SIP traffic
         */
        public string GetDomainName() {
            return this.domainName;
        }
    
        /**
         * @return A user-specified, human-readable name for the trigger.
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return A string that uniquely identifies the SIP Domain
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return HTTP method used with voice_fallback_url
         */
        public System.Net.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /**
         * @return URL Twilio will request if an error occurs in executing TwiML
         */
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with voice_url
         */
        public System.Net.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return The voice_status_callback_method
         */
        public System.Net.Http.HttpMethod GetVoiceStatusCallbackMethod() {
            return this.voiceStatusCallbackMethod;
        }
    
        /**
         * @return URL that Twilio will request with status updates
         */
        public Uri GetVoiceStatusCallbackUrl() {
            return this.voiceStatusCallbackUrl;
        }
    
        /**
         * @return URL Twilio will request when receiving a call
         */
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}