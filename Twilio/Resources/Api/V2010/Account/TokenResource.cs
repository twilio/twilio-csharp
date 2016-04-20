using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources;
using Twilio.Types;

namespace Twilio.Resources.Api.V2010.Account {

    public class TokenResource : Resource {
        /**
         * Create a new token
         * 
         * @param accountSid The account_sid
         * @return TokenCreator capable of executing the create
         */
        public static TokenCreator Create(string accountSid) {
            return new TokenCreator(accountSid);
        }
    
        /**
         * Converts a JSON string into a TokenResource object
         * 
         * @param json Raw JSON string
         * @return TokenResource object represented by the provided JSON
         */
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
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return An array representing the ephemeral credentials
         */
        public List<IceServer> GetIceServers() {
            return this.iceServers;
        }
    
        /**
         * @return The temporary password used for authenticating
         */
        public string GetPassword() {
            return this.password;
        }
    
        /**
         * @return The duration in seconds the credentials are valid
         */
        public string GetTtl() {
            return this.ttl;
        }
    
        /**
         * @return The temporary username that uniquely identifies a Token.
         */
        public string GetUsername() {
            return this.username;
        }
    }
}