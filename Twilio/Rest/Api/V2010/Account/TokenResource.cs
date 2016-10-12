using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account {

    public class TokenResource : Resource {
        /// <summary>
        /// Create a new token
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> TokenCreator capable of executing the create </returns> 
        public static TokenCreator Creator(string accountSid) {
            return new TokenCreator(accountSid);
        }
    
        /// <summary>
        /// Create a TokenCreator to execute create.
        /// </summary>
        ///
        /// <returns> TokenCreator capable of executing the create </returns> 
        public static TokenCreator Creator() {
            return new TokenCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a TokenResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TokenResource object represented by the provided JSON </returns> 
        public static TokenResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TokenResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("ice_servers")]
        private readonly List<IceServer> iceServers;
        [JsonProperty("password")]
        private readonly string password;
        [JsonProperty("ttl")]
        private readonly string ttl;
        [JsonProperty("username")]
        private readonly string username;
    
        public TokenResource() {
        
        }
    
        private TokenResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("ice_servers")]
                              List<IceServer> iceServers, 
                              [JsonProperty("password")]
                              string password, 
                              [JsonProperty("ttl")]
                              string ttl, 
                              [JsonProperty("username")]
                              string username) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.iceServers = iceServers;
            this.password = password;
            this.ttl = ttl;
            this.username = username;
        }
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> An array representing the ephemeral credentials </returns> 
        public List<IceServer> GetIceServers() {
            return this.iceServers;
        }
    
        /// <returns> The temporary password used for authenticating </returns> 
        public string GetPassword() {
            return this.password;
        }
    
        /// <returns> The duration in seconds the credentials are valid </returns> 
        public string GetTtl() {
            return this.ttl;
        }
    
        /// <returns> The temporary username that uniquely identifies a Token. </returns> 
        public string GetUsername() {
            return this.username;
        }
    }
}