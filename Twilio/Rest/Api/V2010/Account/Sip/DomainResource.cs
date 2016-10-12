using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class DomainResource : SidResource {
        /// <summary>
        /// Retrieve a list of domains belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> DomainReader capable of executing the read </returns> 
        public static DomainReader Reader(string accountSid) {
            return new DomainReader(accountSid);
        }
    
        /// <summary>
        /// Create a DomainReader to execute read.
        /// </summary>
        ///
        /// <returns> DomainReader capable of executing the read </returns> 
        public static DomainReader Reader() {
            return new DomainReader();
        }
    
        /// <summary>
        /// Create a new Domain
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        /// <returns> DomainCreator capable of executing the create </returns> 
        public static DomainCreator Creator(string accountSid, string domainName) {
            return new DomainCreator(accountSid, domainName);
        }
    
        /// <summary>
        /// Create a DomainCreator to execute create.
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        /// <returns> DomainCreator capable of executing the create </returns> 
        public static DomainCreator Creator(string domainName) {
            return new DomainCreator(domainName);
        }
    
        /// <summary>
        /// Fetch an instance of a Domain
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique Domain Sid </param>
        /// <returns> DomainFetcher capable of executing the fetch </returns> 
        public static DomainFetcher Fetcher(string accountSid, string sid) {
            return new DomainFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a DomainFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Domain Sid </param>
        /// <returns> DomainFetcher capable of executing the fetch </returns> 
        public static DomainFetcher Fetcher(string sid) {
            return new DomainFetcher(sid);
        }
    
        /// <summary>
        /// Update the attributes of a domain
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> DomainUpdater capable of executing the update </returns> 
        public static DomainUpdater Updater(string accountSid, string sid) {
            return new DomainUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a DomainUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DomainUpdater capable of executing the update </returns> 
        public static DomainUpdater Updater(string sid) {
            return new DomainUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> DomainDeleter capable of executing the delete </returns> 
        public static DomainDeleter Deleter(string accountSid, string sid) {
            return new DomainDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a DomainDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DomainDeleter capable of executing the delete </returns> 
        public static DomainDeleter Deleter(string sid) {
            return new DomainDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a DomainResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DomainResource object represented by the provided JSON </returns> 
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
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly Uri voiceFallbackUrl;
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod voiceMethod;
        [JsonProperty("voice_status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod voiceStatusCallbackMethod;
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
                               Twilio.Http.HttpMethod voiceFallbackMethod, 
                               [JsonProperty("voice_fallback_url")]
                               Uri voiceFallbackUrl, 
                               [JsonProperty("voice_method")]
                               Twilio.Http.HttpMethod voiceMethod, 
                               [JsonProperty("voice_status_callback_method")]
                               Twilio.Http.HttpMethod voiceStatusCallbackMethod, 
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
    
        /// <returns> The unique id of the account that sent the message </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The Twilio API version used to process the message </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The types of authentication mapped to the domain </returns> 
        public string GetAuthType() {
            return this.authType;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The unique address on Twilio to route SIP traffic </returns> 
        public string GetDomainName() {
            return this.domainName;
        }
    
        /// <returns> A user-specified, human-readable name for the trigger. </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> A string that uniquely identifies the SIP Domain </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> HTTP method used with voice_fallback_url </returns> 
        public Twilio.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /// <returns> URL Twilio will request if an error occurs in executing TwiML </returns> 
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /// <returns> HTTP method to use with voice_url </returns> 
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /// <returns> The voice_status_callback_method </returns> 
        public Twilio.Http.HttpMethod GetVoiceStatusCallbackMethod() {
            return this.voiceStatusCallbackMethod;
        }
    
        /// <returns> URL that Twilio will request with status updates </returns> 
        public Uri GetVoiceStatusCallbackUrl() {
            return this.voiceStatusCallbackUrl;
        }
    
        /// <returns> URL Twilio will request when receiving a call </returns> 
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}