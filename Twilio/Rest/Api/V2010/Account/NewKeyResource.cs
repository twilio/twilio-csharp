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
        public string sid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("secret")]
        public string secret { get; }
    
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
    }
}