using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ConnectAppResource : Resource {
        public sealed class Permission : IStringEnum {
            public const string GetAll = "get-all";
            public const string PostAll = "post-all";
        
            private string _value;
            
            public Permission() { }
            
            public Permission(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator Permission(string value) {
                return new Permission(value);
            }
            
            public static implicit operator string(Permission value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a connect-app
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique connect-app Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ConnectAppFetcher capable of executing the fetch </returns> 
        public static ConnectAppFetcher Fetcher(string sid, string accountSid=null) {
            return new ConnectAppFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Update a connect-app with the specified parameters
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="authorizeRedirectUrl"> URIL Twilio sends requests when users authorize </param>
        /// <param name="companyName"> The company name set for this Connect App. </param>
        /// <param name="deauthorizeCallbackMethod"> HTTP method Twilio WIll use making requests to the url </param>
        /// <param name="deauthorizeCallbackUrl"> URL Twilio will send a request when a user de-authorizes this app </param>
        /// <param name="description"> A more detailed human readable description </param>
        /// <param name="friendlyName"> A human readable name for the Connect App. </param>
        /// <param name="homepageUrl"> The URL users can obtain more information </param>
        /// <param name="permissions"> The set of permissions that your ConnectApp requests. </param>
        /// <returns> ConnectAppUpdater capable of executing the update </returns> 
        public static ConnectAppUpdater Updater(string sid, string accountSid=null, Uri authorizeRedirectUrl=null, string companyName=null, Twilio.Http.HttpMethod deauthorizeCallbackMethod=null, Uri deauthorizeCallbackUrl=null, string description=null, string friendlyName=null, Uri homepageUrl=null, List<ConnectAppResource.Permission> permissions=null) {
            return new ConnectAppUpdater(sid, accountSid:accountSid, authorizeRedirectUrl:authorizeRedirectUrl, companyName:companyName, deauthorizeCallbackMethod:deauthorizeCallbackMethod, deauthorizeCallbackUrl:deauthorizeCallbackUrl, description:description, friendlyName:friendlyName, homepageUrl:homepageUrl, permissions:permissions);
        }
    
        /// <summary>
        /// Retrieve a list of connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ConnectAppReader capable of executing the read </returns> 
        public static ConnectAppReader Reader(string accountSid=null) {
            return new ConnectAppReader(accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ConnectAppResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConnectAppResource object represented by the provided JSON </returns> 
        public static ConnectAppResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConnectAppResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("authorize_redirect_url")]
        public Uri authorizeRedirectUrl { get; }
        [JsonProperty("company_name")]
        public string companyName { get; }
        [JsonProperty("deauthorize_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod deauthorizeCallbackMethod { get; }
        [JsonProperty("deauthorize_callback_url")]
        public Uri deauthorizeCallbackUrl { get; }
        [JsonProperty("description")]
        public string description { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("homepage_url")]
        public Uri homepageUrl { get; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<ConnectAppResource.Permission> permissions { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public ConnectAppResource() {
        
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
                                   List<ConnectAppResource.Permission> permissions, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("uri")]
                                   string uri) {
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