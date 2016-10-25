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
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> DomainReader capable of executing the read </returns> 
        public static DomainReader Reader(string accountSid=null)
        {
            return new DomainReader(accountSid:accountSid);
        }
    
        /// <summary>
        /// Create a new Domain
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <param name="authType"> The types of authentication mapped to the domain </param>
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <param name="voiceMethod"> HTTP method to use with voice_url </param>
        /// <param name="voiceFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="voiceFallbackMethod"> HTTP method used with voice_fallback_url </param>
        /// <param name="voiceStatusCallbackUrl"> URL that Twilio will request with status updates </param>
        /// <param name="voiceStatusCallbackMethod"> The voice_status_callback_method </param>
        /// <returns> DomainCreator capable of executing the create </returns> 
        public static DomainCreator Creator(string domainName, string accountSid=null, string friendlyName=null, string authType=null, Uri voiceUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceStatusCallbackUrl=null, Twilio.Http.HttpMethod voiceStatusCallbackMethod=null)
        {
            return new DomainCreator(domainName, accountSid:accountSid, friendlyName:friendlyName, authType:authType, voiceUrl:voiceUrl, voiceMethod:voiceMethod, voiceFallbackUrl:voiceFallbackUrl, voiceFallbackMethod:voiceFallbackMethod, voiceStatusCallbackUrl:voiceStatusCallbackUrl, voiceStatusCallbackMethod:voiceStatusCallbackMethod);
        }
    
        /// <summary>
        /// Fetch an instance of a Domain
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Domain Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> DomainFetcher capable of executing the fetch </returns> 
        public static DomainFetcher Fetcher(string sid, string accountSid=null)
        {
            return new DomainFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Update the attributes of a domain
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="authType"> The auth_type </param>
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <param name="voiceFallbackMethod"> The voice_fallback_method </param>
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <param name="voiceMethod"> HTTP method to use with voice_url </param>
        /// <param name="voiceStatusCallbackMethod"> The voice_status_callback_method </param>
        /// <param name="voiceStatusCallbackUrl"> The voice_status_callback_url </param>
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> DomainUpdater capable of executing the update </returns> 
        public static DomainUpdater Updater(string sid, string accountSid=null, string authType=null, string friendlyName=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Twilio.Http.HttpMethod voiceStatusCallbackMethod=null, Uri voiceStatusCallbackUrl=null, Uri voiceUrl=null)
        {
            return new DomainUpdater(sid, accountSid:accountSid, authType:authType, friendlyName:friendlyName, voiceFallbackMethod:voiceFallbackMethod, voiceFallbackUrl:voiceFallbackUrl, voiceMethod:voiceMethod, voiceStatusCallbackMethod:voiceStatusCallbackMethod, voiceStatusCallbackUrl:voiceStatusCallbackUrl, voiceUrl:voiceUrl);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> DomainDeleter capable of executing the delete </returns> 
        public static DomainDeleter Deleter(string sid, string accountSid=null)
        {
            return new DomainDeleter(sid, accountSid:accountSid);
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
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
    
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