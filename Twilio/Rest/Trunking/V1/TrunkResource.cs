using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1 
{

    public class TrunkResource : Resource 
    {
        private static Request BuildFetchRequest(FetchTrunkOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TrunkResource Fetch(FetchTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TrunkResource> FetchAsync(FetchTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TrunkResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchTrunkOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TrunkResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchTrunkOptions(sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteTrunkOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteTrunkOptions(sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteTrunkOptions(sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateTrunkOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static TrunkResource Create(CreateTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TrunkResource> CreateAsync(CreateTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static TrunkResource Create(string friendlyName = null, string domainName = null, Uri disasterRecoveryUrl = null, Twilio.Http.HttpMethod disasterRecoveryMethod = null, string recording = null, bool? secure = null, ITwilioRestClient client = null)
        {
            var options = new CreateTrunkOptions{FriendlyName = friendlyName, DomainName = domainName, DisasterRecoveryUrl = disasterRecoveryUrl, DisasterRecoveryMethod = disasterRecoveryMethod, Recording = recording, Secure = secure};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TrunkResource> CreateAsync(string friendlyName = null, string domainName = null, Uri disasterRecoveryUrl = null, Twilio.Http.HttpMethod disasterRecoveryMethod = null, string recording = null, bool? secure = null, ITwilioRestClient client = null)
        {
            var options = new CreateTrunkOptions{FriendlyName = friendlyName, DomainName = domainName, DisasterRecoveryUrl = disasterRecoveryUrl, DisasterRecoveryMethod = disasterRecoveryMethod, Recording = recording, Secure = secure};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadTrunkOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TrunkResource> Read(ReadTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TrunkResource>.FromJson("trunks", response.Content);
            return new ResourceSet<TrunkResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TrunkResource>> ReadAsync(ReadTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<TrunkResource>.FromJson("trunks", response.Content);
            return new ResourceSet<TrunkResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TrunkResource> Read(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTrunkOptions{PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TrunkResource>> ReadAsync(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTrunkOptions{PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<TrunkResource> NextPage(Page<TrunkResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Trunking,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TrunkResource>.FromJson("trunks", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateTrunkOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static TrunkResource Update(UpdateTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TrunkResource> UpdateAsync(UpdateTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static TrunkResource Update(string sid, string friendlyName = null, string domainName = null, Uri disasterRecoveryUrl = null, Twilio.Http.HttpMethod disasterRecoveryMethod = null, string recording = null, bool? secure = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTrunkOptions(sid){FriendlyName = friendlyName, DomainName = domainName, DisasterRecoveryUrl = disasterRecoveryUrl, DisasterRecoveryMethod = disasterRecoveryMethod, Recording = recording, Secure = secure};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TrunkResource> UpdateAsync(string sid, string friendlyName = null, string domainName = null, Uri disasterRecoveryUrl = null, Twilio.Http.HttpMethod disasterRecoveryMethod = null, string recording = null, bool? secure = null, ITwilioRestClient client = null)
        {
            var options = new UpdateTrunkOptions(sid){FriendlyName = friendlyName, DomainName = domainName, DisasterRecoveryUrl = disasterRecoveryUrl, DisasterRecoveryMethod = disasterRecoveryMethod, Recording = recording, Secure = secure};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TrunkResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TrunkResource object represented by the provided JSON </returns> 
        public static TrunkResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TrunkResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("domain_name")]
        public string DomainName { get; private set; }
        [JsonProperty("disaster_recovery_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod DisasterRecoveryMethod { get; private set; }
        [JsonProperty("disaster_recovery_url")]
        public Uri DisasterRecoveryUrl { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("secure")]
        public bool? Secure { get; private set; }
        [JsonProperty("recording")]
        public object Recording { get; private set; }
        [JsonProperty("auth_type")]
        public string AuthType { get; private set; }
        [JsonProperty("auth_type_set")]
        public List<string> AuthTypeSet { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private TrunkResource()
        {
        
        }
    }

}