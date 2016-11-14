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

    public class AuthorizedConnectAppResource : Resource 
    {
        public sealed class PermissionEnum : IStringEnum 
        {
            public const string GetAll = "get-all";
            public const string PostAll = "post-all";
        
            private string _value;
            
            public PermissionEnum() {}
            
            public PermissionEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator PermissionEnum(string value)
            {
                return new PermissionEnum(value);
            }
            
            public static implicit operator string(PermissionEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of an authorized-connect-app
        /// </summary>
        ///
        /// <param name="connectAppSid"> The connect_app_sid </param>
        /// <returns> AuthorizedConnectAppFetcher capable of executing the fetch </returns> 
        public static AuthorizedConnectAppFetcher Fetcher(string connectAppSid)
        {
            return new AuthorizedConnectAppFetcher(connectAppSid);
        }
    
        /// <summary>
        /// Retrieve a list of authorized-connect-apps belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> AuthorizedConnectAppReader capable of executing the read </returns> 
        public static AuthorizedConnectAppReader Reader()
        {
            return new AuthorizedConnectAppReader();
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
        public string AccountSid { get; set; }
        [JsonProperty("connect_app_company_name")]
        public string ConnectAppCompanyName { get; set; }
        [JsonProperty("connect_app_description")]
        public string ConnectAppDescription { get; set; }
        [JsonProperty("connect_app_friendly_name")]
        public string ConnectAppFriendlyName { get; set; }
        [JsonProperty("connect_app_homepage_url")]
        public Uri ConnectAppHomepageUrl { get; set; }
        [JsonProperty("connect_app_sid")]
        public string ConnectAppSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("permissions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<AuthorizedConnectAppResource.PermissionEnum> Permissions { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public AuthorizedConnectAppResource()
        {
        
        }
    
        private AuthorizedConnectAppResource([JsonProperty("account_sid")]
                                             string accountSid, 
                                             [JsonProperty("connect_app_company_name")]
                                             string connectAppCompanyName, 
                                             [JsonProperty("connect_app_description")]
                                             string connectAppDescription, 
                                             [JsonProperty("connect_app_friendly_name")]
                                             string connectAppFriendlyName, 
                                             [JsonProperty("connect_app_homepage_url")]
                                             Uri connectAppHomepageUrl, 
                                             [JsonProperty("connect_app_sid")]
                                             string connectAppSid, 
                                             [JsonProperty("date_created")]
                                             string dateCreated, 
                                             [JsonProperty("date_updated")]
                                             string dateUpdated, 
                                             [JsonProperty("permissions")]
                                             List<AuthorizedConnectAppResource.PermissionEnum> permissions, 
                                             [JsonProperty("uri")]
                                             string uri)
                                             {
            AccountSid = accountSid;
            ConnectAppCompanyName = connectAppCompanyName;
            ConnectAppDescription = connectAppDescription;
            ConnectAppFriendlyName = connectAppFriendlyName;
            ConnectAppHomepageUrl = connectAppHomepageUrl;
            ConnectAppSid = connectAppSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Permissions = permissions;
            Uri = uri;
        }
    }
}