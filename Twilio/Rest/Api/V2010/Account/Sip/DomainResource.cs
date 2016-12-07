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
        private static Request BuildReadRequest(ReadDomainOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/Domains.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of domains belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<DomainResource> Read(ReadDomainOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<DomainResource>.FromJson("domains", response.Content);
            return new ResourceSet<DomainResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<DomainResource>> ReadAsync(ReadDomainOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of domains belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<DomainResource> Read(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDomainOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<DomainResource>> ReadAsync(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDomainOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<DomainResource> NextPage(Page<DomainResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<DomainResource>.FromJson("domains", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateDomainOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/Domains.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Create a new Domain
        /// </summary>
        public static DomainResource Create(CreateDomainOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DomainResource> CreateAsync(CreateDomainOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Create a new Domain
        /// </summary>
        public static DomainResource Create(string domainName, string accountSid = null, string friendlyName = null, string authType = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceStatusCallbackUrl = null, Twilio.Http.HttpMethod voiceStatusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new CreateDomainOptions(domainName){AccountSid = accountSid, FriendlyName = friendlyName, AuthType = authType, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceFallbackMethod = voiceFallbackMethod, VoiceStatusCallbackUrl = voiceStatusCallbackUrl, VoiceStatusCallbackMethod = voiceStatusCallbackMethod};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DomainResource> CreateAsync(string domainName, string accountSid = null, string friendlyName = null, string authType = null, Uri voiceUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceStatusCallbackUrl = null, Twilio.Http.HttpMethod voiceStatusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new CreateDomainOptions(domainName){AccountSid = accountSid, FriendlyName = friendlyName, AuthType = authType, VoiceUrl = voiceUrl, VoiceMethod = voiceMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceFallbackMethod = voiceFallbackMethod, VoiceStatusCallbackUrl = voiceStatusCallbackUrl, VoiceStatusCallbackMethod = voiceStatusCallbackMethod};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchDomainOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an instance of a Domain
        /// </summary>
        public static DomainResource Fetch(FetchDomainOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DomainResource> FetchAsync(FetchDomainOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch an instance of a Domain
        /// </summary>
        public static DomainResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchDomainOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DomainResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchDomainOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateDomainOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update the attributes of a domain
        /// </summary>
        public static DomainResource Update(UpdateDomainOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DomainResource> UpdateAsync(UpdateDomainOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Update the attributes of a domain
        /// </summary>
        public static DomainResource Update(string sid, string accountSid = null, string authType = null, string friendlyName = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Twilio.Http.HttpMethod voiceStatusCallbackMethod = null, Uri voiceStatusCallbackUrl = null, Uri voiceUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateDomainOptions(sid){AccountSid = accountSid, AuthType = authType, FriendlyName = friendlyName, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceStatusCallbackMethod = voiceStatusCallbackMethod, VoiceStatusCallbackUrl = voiceStatusCallbackUrl, VoiceUrl = voiceUrl};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DomainResource> UpdateAsync(string sid, string accountSid = null, string authType = null, string friendlyName = null, Twilio.Http.HttpMethod voiceFallbackMethod = null, Uri voiceFallbackUrl = null, Twilio.Http.HttpMethod voiceMethod = null, Twilio.Http.HttpMethod voiceStatusCallbackMethod = null, Uri voiceStatusCallbackUrl = null, Uri voiceUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateDomainOptions(sid){AccountSid = accountSid, AuthType = authType, FriendlyName = friendlyName, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceStatusCallbackMethod = voiceStatusCallbackMethod, VoiceStatusCallbackUrl = voiceStatusCallbackUrl, VoiceUrl = voiceUrl};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteDomainOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteDomainOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteDomainOptions options, ITwilioRestClient client)
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
            var options = new DeleteDomainOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteDomainOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
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
        public string AccountSid { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("auth_type")]
        public string AuthType { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("domain_name")]
        public string DomainName { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; private set; }
        [JsonProperty("voice_fallback_url")]
        public Uri VoiceFallbackUrl { get; private set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; private set; }
        [JsonProperty("voice_status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceStatusCallbackMethod { get; private set; }
        [JsonProperty("voice_status_callback_url")]
        public Uri VoiceStatusCallbackUrl { get; private set; }
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; private set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
    
        private DomainResource()
        {
        
        }
    }

}