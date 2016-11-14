using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010 
{

    public class AccountResource : Resource 
    {
        public sealed class StatusEnum : IStringEnum 
        {
            public const string Active = "active";
            public const string Suspended = "suspended";
            public const string Closed = "closed";
        
            private string _value;
            
            public StatusEnum() {}
            
            public StatusEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            
            public static implicit operator string(StatusEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class TypeEnum : IStringEnum 
        {
            public const string Trial = "Trial";
            public const string Full = "Full";
        
            private string _value;
            
            public TypeEnum() {}
            
            public TypeEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator TypeEnum(string value)
            {
                return new TypeEnum(value);
            }
            
            public static implicit operator string(TypeEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Create a new Twilio Subaccount from the account making the request
        /// </summary>
        ///
        /// <returns> AccountCreator capable of executing the create </returns> 
        public static AccountCreator Creator()
        {
            return new AccountCreator();
        }
    
        /// <summary>
        /// Fetch the account specified by the provided Account Sid
        /// </summary>
        ///
        /// <returns> AccountFetcher capable of executing the fetch </returns> 
        public static AccountFetcher Fetcher()
        {
            return new AccountFetcher();
        }
    
        /// <summary>
        /// Retrieves a collection of Accounts belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> AccountReader capable of executing the read </returns> 
        public static AccountReader Reader()
        {
            return new AccountReader();
        }
    
        /// <summary>
        /// Modify the properties of a given Account
        /// </summary>
        ///
        /// <returns> AccountUpdater capable of executing the update </returns> 
        public static AccountUpdater Updater()
        {
            return new AccountUpdater();
        }
    
        /// <summary>
        /// Converts a JSON string into a AccountResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AccountResource object represented by the provided JSON </returns> 
        public static AccountResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AccountResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("owner_account_sid")]
        public string OwnerAccountSid { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.StatusEnum Status { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.TypeEnum Type { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public AccountResource()
        {
        
        }
    
        private AccountResource([JsonProperty("auth_token")]
                                string authToken, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("owner_account_sid")]
                                string ownerAccountSid, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("status")]
                                AccountResource.StatusEnum status, 
                                [JsonProperty("subresource_uris")]
                                Dictionary<string, string> subresourceUris, 
                                [JsonProperty("type")]
                                AccountResource.TypeEnum type, 
                                [JsonProperty("uri")]
                                string uri)
                                {
            AuthToken = authToken;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            OwnerAccountSid = ownerAccountSid;
            Sid = sid;
            Status = status;
            SubresourceUris = subresourceUris;
            Type = type;
            Uri = uri;
        }
    }
}