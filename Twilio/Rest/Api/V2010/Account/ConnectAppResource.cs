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

    public class ConnectAppResource : Resource 
    {
        public sealed class PermissionEnum : StringEnum 
        {
            private PermissionEnum(string value) : base(value) {}
            public PermissionEnum() {}
        
            public static readonly PermissionEnum GetAll = new PermissionEnum("get-all");
            public static readonly PermissionEnum PostAll = new PermissionEnum("post-all");
        }
    
        private static Request BuildFetchRequest(FetchConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/ConnectApps/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        public static ConnectAppResource Fetch(FetchConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ConnectAppResource> FetchAsync(FetchConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        public static ConnectAppResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchConnectAppOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ConnectAppResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchConnectAppOptions(sid){AccountSid = accountSid};
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/ConnectApps/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        public static ConnectAppResource Update(UpdateConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ConnectAppResource> UpdateAsync(UpdateConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        public static ConnectAppResource Update(string sid, string accountSid = null, Uri authorizeRedirectUrl = null, string companyName = null, Twilio.Http.HttpMethod deauthorizeCallbackMethod = null, Uri deauthorizeCallbackUrl = null, string description = null, string friendlyName = null, Uri homepageUrl = null, List<ConnectAppResource.PermissionEnum> permissions = null, ITwilioRestClient client = null)
        {
            var options = new UpdateConnectAppOptions(sid){AccountSid = accountSid, AuthorizeRedirectUrl = authorizeRedirectUrl, CompanyName = companyName, DeauthorizeCallbackMethod = deauthorizeCallbackMethod, DeauthorizeCallbackUrl = deauthorizeCallbackUrl, Description = description, FriendlyName = friendlyName, HomepageUrl = homepageUrl, Permissions = permissions};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ConnectAppResource> UpdateAsync(string sid, string accountSid = null, Uri authorizeRedirectUrl = null, string companyName = null, Twilio.Http.HttpMethod deauthorizeCallbackMethod = null, Uri deauthorizeCallbackUrl = null, string description = null, string friendlyName = null, Uri homepageUrl = null, List<ConnectAppResource.PermissionEnum> permissions = null, ITwilioRestClient client = null)
        {
            var options = new UpdateConnectAppOptions(sid){AccountSid = accountSid, AuthorizeRedirectUrl = authorizeRedirectUrl, CompanyName = companyName, DeauthorizeCallbackMethod = deauthorizeCallbackMethod, DeauthorizeCallbackUrl = deauthorizeCallbackUrl, Description = description, FriendlyName = friendlyName, HomepageUrl = homepageUrl, Permissions = permissions};
            return await UpdateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadConnectAppOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/ConnectApps.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<ConnectAppResource> Read(ReadConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ConnectAppResource>.FromJson("connect_apps", response.Content);
            return new ResourceSet<ConnectAppResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ConnectAppResource>> ReadAsync(ReadConnectAppOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<ConnectAppResource>.FromJson("connect_apps", response.Content);
            return new ResourceSet<ConnectAppResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<ConnectAppResource> Read(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadConnectAppOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ConnectAppResource>> ReadAsync(string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadConnectAppOptions{AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<ConnectAppResource> NextPage(Page<ConnectAppResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ConnectAppResource>.FromJson("connect_apps", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a ConnectAppResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConnectAppResource object represented by the provided JSON </returns> 
        public static ConnectAppResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ConnectAppResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("authorize_redirect_url")]
        public Uri AuthorizeRedirectUrl { get; private set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; private set; }
        [JsonProperty("deauthorize_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod DeauthorizeCallbackMethod { get; private set; }
        [JsonProperty("deauthorize_callback_url")]
        public Uri DeauthorizeCallbackUrl { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("homepage_url")]
        public Uri HomepageUrl { get; private set; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<ConnectAppResource.PermissionEnum> Permissions { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private ConnectAppResource()
        {
        
        }
    }

}