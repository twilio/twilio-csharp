using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList 
{

    public class CredentialResource : Resource 
    {
        private static Request BuildReadRequest(ReadCredentialOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.CredentialListSid + "/Credentials.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static ResourceSet<CredentialResource> Read(ReadCredentialOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<CredentialResource>.FromJson("credentials", response.Content);
            return new ResourceSet<CredentialResource>(page, options, client);
        }
    
        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<CredentialResource>> ReadAsync(ReadCredentialOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<CredentialResource>.FromJson("credentials", response.Content);
            return new ResourceSet<CredentialResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static ResourceSet<CredentialResource> Read(string credentialListSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCredentialOptions(credentialListSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<CredentialResource>> ReadAsync(string credentialListSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCredentialOptions(credentialListSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
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
        public static Page<CredentialResource> NextPage(Page<CredentialResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<CredentialResource>.FromJson("credentials", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateCredentialOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.CredentialListSid + "/Credentials.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static CredentialResource Create(CreateCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="options"> Create Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<CredentialResource> CreateAsync(CreateCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static CredentialResource Create(string credentialListSid, string username, string password, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCredentialOptions(credentialListSid, username, password){AccountSid = accountSid};
            return Create(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<CredentialResource> CreateAsync(string credentialListSid, string username, string password, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCredentialOptions(credentialListSid, username, password){AccountSid = accountSid};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildFetchRequest(FetchCredentialOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.CredentialListSid + "/Credentials/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static CredentialResource Fetch(FetchCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="options"> Fetch Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<CredentialResource> FetchAsync(FetchCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static CredentialResource Fetch(string credentialListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCredentialOptions(credentialListSid, sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<CredentialResource> FetchAsync(string credentialListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCredentialOptions(credentialListSid, sid){AccountSid = accountSid};
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateCredentialOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.CredentialListSid + "/Credentials/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static CredentialResource Update(UpdateCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="options"> Update Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<CredentialResource> UpdateAsync(UpdateCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="password"> The password </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static CredentialResource Update(string credentialListSid, string sid, string accountSid = null, string password = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCredentialOptions(credentialListSid, sid){AccountSid = accountSid, Password = password};
            return Update(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="password"> The password </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<CredentialResource> UpdateAsync(string credentialListSid, string sid, string accountSid = null, string password = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCredentialOptions(credentialListSid, sid){AccountSid = accountSid, Password = password};
            return await UpdateAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteCredentialOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/CredentialLists/" + options.CredentialListSid + "/Credentials/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static bool Delete(DeleteCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="options"> Delete Credential parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCredentialOptions options, ITwilioRestClient client = null)
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
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Credential </returns> 
        public static bool Delete(string credentialListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCredentialOptions(credentialListSid, sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Credential </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string credentialListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCredentialOptions(credentialListSid, sid){AccountSid = accountSid};
            return await DeleteAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CredentialResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialResource object represented by the provided JSON </returns> 
        public static CredentialResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CredentialResource>(json);
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
        /// The credential_list_sid
        /// </summary>
        [JsonProperty("credential_list_sid")]
        public string CredentialListSid { get; private set; }
        /// <summary>
        /// The username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }
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
        /// The uri
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private CredentialResource()
        {
        
        }
    }

}