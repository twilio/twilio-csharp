using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ShortCodeResource : Resource 
    {
        private static Request BuildFetchRequest(FetchShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SMS/ShortCodes/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an instance of a short code
        /// </summary>
        public static ShortCodeResource Fetch(FetchShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(FetchShortCodeOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch an instance of a short code
        /// </summary>
        public static ShortCodeResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SMS/ShortCodes/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update a short code with the following parameters
        /// </summary>
        public static ShortCodeResource Update(UpdateShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ShortCodeResource> UpdateAsync(UpdateShortCodeOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Update a short code with the following parameters
        /// </summary>
        public static ShortCodeResource Update(string sid, string accountSid = null, string friendlyName = null, string apiVersion = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateShortCodeOptions(sid){AccountSid = accountSid, FriendlyName = friendlyName, ApiVersion = apiVersion, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ShortCodeResource> UpdateAsync(string sid, string accountSid = null, string friendlyName = null, string apiVersion = null, Uri smsUrl = null, Twilio.Http.HttpMethod smsMethod = null, Uri smsFallbackUrl = null, Twilio.Http.HttpMethod smsFallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateShortCodeOptions(sid){AccountSid = accountSid, FriendlyName = friendlyName, ApiVersion = apiVersion, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SMS/ShortCodes.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of short-codes belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<ShortCodeResource> Read(ReadShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(ReadShortCodeOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of short-codes belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<ShortCodeResource> Read(string accountSid = null, string friendlyName = null, string shortCode = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions{AccountSid = accountSid, FriendlyName = friendlyName, ShortCode = shortCode, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(string accountSid = null, string friendlyName = null, string shortCode = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions{AccountSid = accountSid, FriendlyName = friendlyName, ShortCode = shortCode, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<ShortCodeResource> NextPage(Page<ShortCodeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a ShortCodeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ShortCodeResource object represented by the provided JSON </returns> 
        public static ShortCodeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ShortCodeResource>(json);
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
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("short_code")]
        public string ShortCode { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; private set; }
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; private set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private ShortCodeResource()
        {
        
        }
    }

}