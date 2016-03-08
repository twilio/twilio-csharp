using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip;
using Twilio.Deleters.Api.V2010.Account.Sip;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip {

    public class Domain : SidResource {
        /**
         * Retrieve a list of domains belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @return DomainReader capable of executing the read
         */
        public static DomainReader read(String accountSid) {
            return new DomainReader(accountSid);
        }
    
        /**
         * Create a new Domain
         * 
         * @param accountSid The account_sid
         * @param domainName The unique address on Twilio to route SIP traffic
         * @return DomainCreator capable of executing the create
         */
        public static DomainCreator create(String accountSid, String domainName) {
            return new DomainCreator(accountSid, domainName);
        }
    
        /**
         * Fetch an instance of a Domain
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique Domain Sid
         * @return DomainFetcher capable of executing the fetch
         */
        public static DomainFetcher fetch(String accountSid, String sid) {
            return new DomainFetcher(accountSid, sid);
        }
    
        /**
         * Update the attributes of a domain
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return DomainUpdater capable of executing the update
         */
        public static DomainUpdater update(String accountSid, String sid) {
            return new DomainUpdater(accountSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return DomainDeleter capable of executing the delete
         */
        public static DomainDeleter delete(String accountSid, String sid) {
            return new DomainDeleter(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a Domain object
         * 
         * @param json Raw JSON string
         * @return Domain object represented by the provided JSON
         */
        public static Domain fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Domain>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("auth_type")]
        private readonly String authType;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("domain_name")]
        private readonly String domainName;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
        [JsonProperty("voice_fallback_method")]
        private readonly HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly URI voiceFallbackUrl;
        [JsonProperty("voice_method")]
        private readonly HttpMethod voiceMethod;
        [JsonProperty("voice_status_callback_method")]
        private readonly HttpMethod voiceStatusCallbackMethod;
        [JsonProperty("voice_status_callback_url")]
        private readonly URI voiceStatusCallbackUrl;
        [JsonProperty("voice_url")]
        private readonly URI voiceUrl;
    
        private Domain([JsonProperty("account_sid")]
                       String accountSid, 
                       [JsonProperty("api_version")]
                       String apiVersion, 
                       [JsonProperty("auth_type")]
                       String authType, 
                       [JsonProperty("date_created")]
                       String dateCreated, 
                       [JsonProperty("date_updated")]
                       String dateUpdated, 
                       [JsonProperty("domain_name")]
                       String domainName, 
                       [JsonProperty("friendly_name")]
                       String friendlyName, 
                       [JsonProperty("sid")]
                       String sid, 
                       [JsonProperty("uri")]
                       String uri, 
                       [JsonProperty("voice_fallback_method")]
                       HttpMethod voiceFallbackMethod, 
                       [JsonProperty("voice_fallback_url")]
                       URI voiceFallbackUrl, 
                       [JsonProperty("voice_method")]
                       HttpMethod voiceMethod, 
                       [JsonProperty("voice_status_callback_method")]
                       HttpMethod voiceStatusCallbackMethod, 
                       [JsonProperty("voice_status_callback_url")]
                       URI voiceStatusCallbackUrl, 
                       [JsonProperty("voice_url")]
                       URI voiceUrl) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.authType = authType;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The Twilio API version used to process the message
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The types of authentication mapped to the domain
         */
        public String GetAuthType() {
            return this.authType;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The unique address on Twilio to route SIP traffic
         */
        public String GetDomainName() {
            return this.domainName;
        }
    
        /**
         * @return A user-specified, human-readable name for the trigger.
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return A string that uniquely identifies the SIP Domain
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    
        /**
         * @return HTTP method used with voice_fallback_url
         */
        public HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /**
         * @return URL Twilio will request if an error occurs in executing TwiML
         */
        public URI GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with voice_url
         */
        public HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return The voice_status_callback_method
         */
        public HttpMethod GetVoiceStatusCallbackMethod() {
            return this.voiceStatusCallbackMethod;
        }
    
        /**
         * @return URL that Twilio will request with status updates
         */
        public URI GetVoiceStatusCallbackUrl() {
            return this.voiceStatusCallbackUrl;
        }
    
        /**
         * @return URL Twilio will request when receiving a call
         */
        public URI GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}