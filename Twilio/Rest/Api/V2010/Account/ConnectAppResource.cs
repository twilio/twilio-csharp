using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
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
    
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique connect-app Sid </param>
        /// <returns> ConnectAppFetcher capable of executing the fetch </returns> 
        public static ConnectAppFetcher Fetcher(string sid)
        {
            return new ConnectAppFetcher(sid);
        }
    
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ConnectAppUpdater capable of executing the update </returns> 
        public static ConnectAppUpdater Updater(string sid)
        {
            return new ConnectAppUpdater(sid);
        }
    
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> ConnectAppReader capable of executing the read </returns> 
        public static ConnectAppReader Reader()
        {
            return new ConnectAppReader();
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
        public string AccountSid { get; set; }
        [JsonProperty("authorize_redirect_url")]
        public Uri AuthorizeRedirectUrl { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("deauthorize_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod DeauthorizeCallbackMethod { get; set; }
        [JsonProperty("deauthorize_callback_url")]
        public Uri DeauthorizeCallbackUrl { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("homepage_url")]
        public Uri HomepageUrl { get; set; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<ConnectAppResource.PermissionEnum> Permissions { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public ConnectAppResource()
        {
        
        }
    
        private ConnectAppResource([JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("authorize_redirect_url")]
                                   Uri authorizeRedirectUrl, 
                                   [JsonProperty("company_name")]
                                   string companyName, 
                                   [JsonProperty("deauthorize_callback_method")]
                                   Twilio.Http.HttpMethod deauthorizeCallbackMethod, 
                                   [JsonProperty("deauthorize_callback_url")]
                                   Uri deauthorizeCallbackUrl, 
                                   [JsonProperty("description")]
                                   string description, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("homepage_url")]
                                   Uri homepageUrl, 
                                   [JsonProperty("permissions")]
                                   List<ConnectAppResource.PermissionEnum> permissions, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("uri")]
                                   string uri)
                                   {
            AccountSid = accountSid;
            AuthorizeRedirectUrl = authorizeRedirectUrl;
            CompanyName = companyName;
            DeauthorizeCallbackMethod = deauthorizeCallbackMethod;
            DeauthorizeCallbackUrl = deauthorizeCallbackUrl;
            Description = description;
            FriendlyName = friendlyName;
            HomepageUrl = homepageUrl;
            Permissions = permissions;
            Sid = sid;
            Uri = uri;
        }
    }
}