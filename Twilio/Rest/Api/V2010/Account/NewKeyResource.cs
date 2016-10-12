using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class NewKeyResource : Resource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> NewKeyCreator capable of executing the create </returns> 
        public static NewKeyCreator Creator(string accountSid) {
            return new NewKeyCreator(accountSid);
        }
    
        /// <summary>
        /// Create a NewKeyCreator to execute create.
        /// </summary>
        ///
        /// <returns> NewKeyCreator capable of executing the create </returns> 
        public static NewKeyCreator Creator() {
            return new NewKeyCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a NewKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NewKeyResource object represented by the provided JSON </returns> 
        public static NewKeyResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<NewKeyResource>(json);
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
    
        public NewKeyResource() {
        
        }
    
        private NewKeyResource([JsonProperty("sid")]
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