using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Accounts.V1.Credential 
{

    public class PublicKeyResource : Resource 
    {
        private static Request BuildReadRequest(ReadPublicKeyOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Accounts,
                "/v1/Credentials/PublicKeys",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<PublicKeyResource> Read(ReadPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<PublicKeyResource>.FromJson("credentials", response.Content);
            return new ResourceSet<PublicKeyResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<PublicKeyResource>> ReadAsync(ReadPublicKeyOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<PublicKeyResource> Read(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPublicKeyOptions{PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<PublicKeyResource>> ReadAsync(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPublicKeyOptions{PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<PublicKeyResource> NextPage(Page<PublicKeyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Accounts,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<PublicKeyResource>.FromJson("credentials", response.Content);
        }
    
        private static Request BuildCreateRequest(CreatePublicKeyOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Accounts,
                "/v1/Credentials/PublicKeys",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static PublicKeyResource Create(CreatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PublicKeyResource> CreateAsync(CreatePublicKeyOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static PublicKeyResource Create(string publicKey, string friendlyName = null, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreatePublicKeyOptions(publicKey){FriendlyName = friendlyName, AccountSid = accountSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PublicKeyResource> CreateAsync(string publicKey, string friendlyName = null, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreatePublicKeyOptions(publicKey){FriendlyName = friendlyName, AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchPublicKeyOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Accounts,
                "/v1/Credentials/PublicKeys/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static PublicKeyResource Fetch(FetchPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PublicKeyResource> FetchAsync(FetchPublicKeyOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static PublicKeyResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchPublicKeyOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PublicKeyResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchPublicKeyOptions(sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdatePublicKeyOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Accounts,
                "/v1/Credentials/PublicKeys/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static PublicKeyResource Update(UpdatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PublicKeyResource> UpdateAsync(UpdatePublicKeyOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static PublicKeyResource Update(string sid, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdatePublicKeyOptions(sid){FriendlyName = friendlyName};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<PublicKeyResource> UpdateAsync(string sid, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdatePublicKeyOptions(sid){FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeletePublicKeyOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Accounts,
                "/v1/Credentials/PublicKeys/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeletePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePublicKeyOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string sid, ITwilioRestClient client = null)
        {
            var options = new DeletePublicKeyOptions(sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new DeletePublicKeyOptions(sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a PublicKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PublicKeyResource object represented by the provided JSON </returns> 
        public static PublicKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<PublicKeyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private PublicKeyResource()
        {
        
        }
    }

}