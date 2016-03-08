using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.types.IceServer;
using java.util.List;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Token : Resource {
        /**
         * Create a new token
         * 
         * @param accountSid The account_sid
         * @return TokenCreator capable of executing the create
         */
        public static TokenCreator create(String accountSid) {
            return new TokenCreator(accountSid);
        }
    
        /**
         * Converts a JSON string into a Token object
         * 
         * @param json Raw JSON string
         * @return Token object represented by the provided JSON
         */
        public static Token fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Token>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("ice_servers")]
        private readonly List<IceServer> iceServers;
        [JsonProperty("password")]
        private readonly String password;
        [JsonProperty("ttl")]
        private readonly String ttl;
        [JsonProperty("username")]
        private readonly String username;
    
        private Token([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("date_created")]
                      String dateCreated, 
                      [JsonProperty("date_updated")]
                      String dateUpdated, 
                      [JsonProperty("ice_servers")]
                      List<IceServer> iceServers, 
                      [JsonProperty("password")]
                      String password, 
                      [JsonProperty("ttl")]
                      String ttl, 
                      [JsonProperty("username")]
                      String username) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.iceServers = iceServers;
            this.password = password;
            this.ttl = ttl;
            this.username = username;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
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
        public String GetPassword() {
            return this.password;
        }
    
        /**
         * @return The duration in seconds the credentials are valid
         */
        public String GetTtl() {
            return this.ttl;
        }
    
        /**
         * @return The temporary username that uniquely identifies a Token.
         */
        public String GetUsername() {
            return this.username;
        }
    }
}