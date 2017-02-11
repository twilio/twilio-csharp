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
        ///
        /// <param name="options"> Read PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static ResourceSet<PublicKeyResource> Read(ReadPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<PublicKeyResource>.FromJson("credentials", response.Content);
            return new ResourceSet<PublicKeyResource>(page, options, client);
        }
    
        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<PublicKeyResource>> ReadAsync(ReadPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<PublicKeyResource>.FromJson("credentials", response.Content);
            return new ResourceSet<PublicKeyResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static ResourceSet<PublicKeyResource> Read(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPublicKeyOptions{PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<PublicKeyResource>> ReadAsync(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadPublicKeyOptions{PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
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
        ///
        /// <param name="options"> Create PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static PublicKeyResource Create(CreatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<PublicKeyResource> CreateAsync(CreatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="publicKey"> The public_key </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static PublicKeyResource Create(string publicKey, string friendlyName = null, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreatePublicKeyOptions(publicKey){FriendlyName = friendlyName, AccountSid = accountSid};
            return Create(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="publicKey"> The public_key </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<PublicKeyResource> CreateAsync(string publicKey, string friendlyName = null, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreatePublicKeyOptions(publicKey){FriendlyName = friendlyName, AccountSid = accountSid};
            return await CreateAsync(options, client);
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
        ///
        /// <param name="options"> Fetch PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static PublicKeyResource Fetch(FetchPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<PublicKeyResource> FetchAsync(FetchPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static PublicKeyResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchPublicKeyOptions(sid);
            return Fetch(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<PublicKeyResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchPublicKeyOptions(sid);
            return await FetchAsync(options, client);
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
        ///
        /// <param name="options"> Update PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static PublicKeyResource Update(UpdatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<PublicKeyResource> UpdateAsync(UpdatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static PublicKeyResource Update(string sid, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdatePublicKeyOptions(sid){FriendlyName = friendlyName};
            return Update(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<PublicKeyResource> UpdateAsync(string sid, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdatePublicKeyOptions(sid){FriendlyName = friendlyName};
            return await UpdateAsync(options, client);
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
        ///
        /// <param name="options"> Delete PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static bool Delete(DeletePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns> 
        public static bool Delete(string sid, ITwilioRestClient client = null)
        {
            var options = new DeletePublicKeyOptions(sid);
            return Delete(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new DeletePublicKeyOptions(sid);
            return await DeleteAsync(options, client);
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
    
        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private PublicKeyResource()
        {
        
        }
    }

}