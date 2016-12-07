using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AuthorizedConnectAppResource : Resource 
    {
        public sealed class PermissionEnum : StringEnum 
        {
            private PermissionEnum(string value) : base(value) {}
            public PermissionEnum() {}
        
            public static readonly PermissionEnum GetAll = new PermissionEnum("get-all");
            public static readonly PermissionEnum PostAll = new PermissionEnum("post-all");
        }
    
        private static Request BuildFetchRequest(FetchAuthorizedConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/AuthorizedConnectApps/" + options.ConnectAppSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an instance of an authorized-connect-app
        /// </summary>
        public static AuthorizedConnectAppResource Fetch(FetchAuthorizedConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AuthorizedConnectAppResource> FetchAsync(FetchAuthorizedConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch an instance of an authorized-connect-app
        /// </summary>
        public static AuthorizedConnectAppResource Fetch(string connectAppSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAuthorizedConnectAppOptions(connectAppSid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AuthorizedConnectAppResource> FetchAsync(string connectAppSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAuthorizedConnectAppOptions(connectAppSid){AccountSid = accountSid};
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadAuthorizedConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/AuthorizedConnectApps.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of authorized-connect-apps belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<AuthorizedConnectAppResource> Read(ReadAuthorizedConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<AuthorizedConnectAppResource>.FromJson("authorized_connect_apps", response.Content);
            return new ResourceSet<AuthorizedConnectAppResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AuthorizedConnectAppResource>> ReadAsync(ReadAuthorizedConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<AuthorizedConnectAppResource>.FromJson("authorized_connect_apps", response.Content);
            return new ResourceSet<AuthorizedConnectAppResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of authorized-connect-apps belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<AuthorizedConnectAppResource> Read(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAuthorizedConnectAppOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AuthorizedConnectAppResource>> ReadAsync(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAuthorizedConnectAppOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<AuthorizedConnectAppResource> NextPage(Page<AuthorizedConnectAppResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<AuthorizedConnectAppResource>.FromJson("authorized_connect_apps", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a AuthorizedConnectAppResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AuthorizedConnectAppResource object represented by the provided JSON </returns> 
        public static AuthorizedConnectAppResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AuthorizedConnectAppResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("connect_app_company_name")]
        public string ConnectAppCompanyName { get; private set; }
        [JsonProperty("connect_app_description")]
        public string ConnectAppDescription { get; private set; }
        [JsonProperty("connect_app_friendly_name")]
        public string ConnectAppFriendlyName { get; private set; }
        [JsonProperty("connect_app_homepage_url")]
        public Uri ConnectAppHomepageUrl { get; private set; }
        [JsonProperty("connect_app_sid")]
        public string ConnectAppSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<AuthorizedConnectAppResource.PermissionEnum> Permissions { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private AuthorizedConnectAppResource()
        {
        
        }
    }

}