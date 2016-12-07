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

    public class CredentialListResource : Resource 
    {
        private static Request BuildReadRequest(ReadCredentialListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of Credentials belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<CredentialListResource> Read(ReadCredentialListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<CredentialListResource>.FromJson("credential_lists", response.Content);
            return new ResourceSet<CredentialListResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CredentialListResource>> ReadAsync(ReadCredentialListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of Credentials belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<CredentialListResource> Read(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCredentialListOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CredentialListResource>> ReadAsync(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCredentialListOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<CredentialListResource> NextPage(Page<CredentialListResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<CredentialListResource>.FromJson("credential_lists", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateCredentialListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Add a Credential to the list
        /// </summary>
        public static CredentialListResource Create(CreateCredentialListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CredentialListResource> CreateAsync(CreateCredentialListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Add a Credential to the list
        /// </summary>
        public static CredentialListResource Create(string friendlyName, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCredentialListOptions(friendlyName){AccountSid = accountSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CredentialListResource> CreateAsync(string friendlyName, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCredentialListOptions(friendlyName){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchCredentialListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a specific Credential in a list
        /// </summary>
        public static CredentialListResource Fetch(FetchCredentialListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CredentialListResource> FetchAsync(FetchCredentialListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a specific Credential in a list
        /// </summary>
        public static CredentialListResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCredentialListOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CredentialListResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCredentialListOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateCredentialListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Change the password of a Credential record
        /// </summary>
        public static CredentialListResource Update(UpdateCredentialListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CredentialListResource> UpdateAsync(UpdateCredentialListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Change the password of a Credential record
        /// </summary>
        public static CredentialListResource Update(string sid, string friendlyName, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCredentialListOptions(sid, friendlyName){AccountSid = accountSid};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CredentialListResource> UpdateAsync(string sid, string friendlyName, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCredentialListOptions(sid, friendlyName){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteCredentialListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Remove a credential from a CredentialList
        /// </summary>
        public static bool Delete(DeleteCredentialListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCredentialListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Remove a credential from a CredentialList
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCredentialListOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCredentialListOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CredentialListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialListResource object represented by the provided JSON </returns> 
        public static CredentialListResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CredentialListResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private CredentialListResource()
        {
        
        }
    }

}