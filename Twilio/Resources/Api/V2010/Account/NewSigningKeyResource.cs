using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class NewSigningKeyResource : Resource {
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @return NewSigningKeyCreator capable of executing the create
         */
        public static NewSigningKeyCreator Create(string accountSid) {
            return new NewSigningKeyCreator(accountSid);
        }
    
        /**
         * Converts a JSON string into a NewSigningKeyResource object
         * 
         * @param json Raw JSON string
         * @return NewSigningKeyResource object represented by the provided JSON
         */
        public static NewSigningKeyResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<NewSigningKeyResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("secret")]
        private readonly string secret;
    
        public NewSigningKeyResource() {
        
        }
    
        private NewSigningKeyResource([JsonProperty("sid")]
                                      string sid, 
                                      [JsonProperty("friendly_name")]
                                      string friendlyName, 
                                      [JsonProperty("date_created")]
                                      string dateCreated, 
                                      [JsonProperty("date_updated")]
                                      string dateUpdated, 
                                      [JsonProperty("secret")]
                                      string secret) {
            this.sid = sid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.secret = secret;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The secret
         */
        public string GetSecret() {
            return this.secret;
        }
    }
}