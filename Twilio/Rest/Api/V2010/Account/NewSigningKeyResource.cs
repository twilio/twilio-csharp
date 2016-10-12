using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class NewSigningKeyResource : Resource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> NewSigningKeyCreator capable of executing the create </returns> 
        public static NewSigningKeyCreator Creator(string accountSid) {
            return new NewSigningKeyCreator(accountSid);
        }
    
        /// <summary>
        /// Create a NewSigningKeyCreator to execute create.
        /// </summary>
        ///
        /// <returns> NewSigningKeyCreator capable of executing the create </returns> 
        public static NewSigningKeyCreator Creator() {
            return new NewSigningKeyCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a NewSigningKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NewSigningKeyResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The sid </returns> 
        public string GetSid() {
            return this.sid;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The secret </returns> 
        public string GetSecret() {
            return this.secret;
        }
    }
}