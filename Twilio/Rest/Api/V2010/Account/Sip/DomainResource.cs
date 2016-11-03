using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class DomainResource : Resource 
    {
        /// <summary>
        /// Retrieve a list of domains belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> DomainReader capable of executing the read </returns> 
        public static DomainReader Reader()
        {
            return new DomainReader();
        }
    
        /// <summary>
        /// Create a new Domain
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        /// <returns> DomainCreator capable of executing the create </returns> 
        public static DomainCreator Creator(string domainName)
        {
            return new DomainCreator(domainName);
        }
    
        /// <summary>
        /// Fetch an instance of a Domain
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Domain Sid </param>
        /// <returns> DomainFetcher capable of executing the fetch </returns> 
        public static DomainFetcher Fetcher(string sid)
        {
            return new DomainFetcher(sid);
        }
    
        /// <summary>
        /// Update the attributes of a domain
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DomainUpdater capable of executing the update </returns> 
        public static DomainUpdater Updater(string sid)
        {
            return new DomainUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> DomainDeleter capable of executing the delete </returns> 
        public static DomainDeleter Deleter(string sid)
        {
            return new DomainDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a DomainResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DomainResource object represented by the provided JSON </returns> 
        public static DomainResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DomainResource>(json);
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
        [JsonProperty("auth_type")]
        public string authType { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("domain_name")]
        public string domainName { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        [JsonProperty("voice_fallback_url")]
        public Uri voiceFallbackUrl { get; set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        [JsonProperty("voice_status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceStatusCallbackMethod { get; set; }
        [JsonProperty("voice_status_callback_url")]
        public Uri voiceStatusCallbackUrl { get; set; }
        [JsonProperty("voice_url")]
        public Uri voiceUrl { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; set; }
    
        public DomainResource()
        {
        
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
                               Uri voiceUrl, 
                               [JsonProperty("subresource_uris")]
                               Dictionary<string, string> subresourceUris)
                               {
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
            this.subresourceUris = subresourceUris;
        }
    }
}