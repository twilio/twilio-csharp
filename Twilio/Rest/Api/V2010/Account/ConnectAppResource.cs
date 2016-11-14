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

    public class ConnectAppResource : Resource 
    {
        public sealed class ConnectAppPermission : IStringEnum 
        {
            public const string GetAll = "get-all";
            public const string PostAll = "post-all";
        
            private string _value;
            
            public ConnectAppPermission() {}
            
            public ConnectAppPermission(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator ConnectAppPermission(string value)
            {
                return new ConnectAppPermission(value);
            }
            
            public static implicit operator string(ConnectAppPermission value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
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
        public string accountSid { get; set; }
        [JsonProperty("authorize_redirect_url")]
        public Uri authorizeRedirectUrl { get; set; }
        [JsonProperty("company_name")]
        public string companyName { get; set; }
        [JsonProperty("deauthorize_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod deauthorizeCallbackMethod { get; set; }
        [JsonProperty("deauthorize_callback_url")]
        public Uri deauthorizeCallbackUrl { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("homepage_url")]
        public Uri homepageUrl { get; set; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<ConnectAppResource.ConnectAppPermission> permissions { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
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
                                   List<ConnectAppResource.ConnectAppPermission> permissions, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("uri")]
                                   string uri)
                                   {
            this.accountSid = accountSid;
            this.authorizeRedirectUrl = authorizeRedirectUrl;
            this.companyName = companyName;
            this.deauthorizeCallbackMethod = deauthorizeCallbackMethod;
            this.deauthorizeCallbackUrl = deauthorizeCallbackUrl;
            this.description = description;
            this.friendlyName = friendlyName;
            this.homepageUrl = homepageUrl;
            this.permissions = permissions;
            this.sid = sid;
            this.uri = uri;
        }
    }
}