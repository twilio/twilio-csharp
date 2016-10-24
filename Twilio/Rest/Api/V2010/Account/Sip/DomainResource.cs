using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class DomainResource : Resource {
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
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("auth_type")]
        public string authType { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("domain_name")]
        public string domainName { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("uri")]
        public string uri { get; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; }
        [JsonProperty("voice_fallback_url")]
        public Uri voiceFallbackUrl { get; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceMethod { get; }
        [JsonProperty("voice_status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceStatusCallbackMethod { get; }
        [JsonProperty("voice_status_callback_url")]
        public Uri voiceStatusCallbackUrl { get; }
        [JsonProperty("voice_url")]
        public Uri voiceUrl { get; }
    
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
    }
}