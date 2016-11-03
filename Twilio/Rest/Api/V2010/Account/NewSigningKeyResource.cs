using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class NewSigningKeyResource : Resource 
    {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <returns> NewSigningKeyCreator capable of executing the create </returns> 
        public static NewSigningKeyCreator Creator()
        {
            return new NewSigningKeyCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a NewSigningKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NewSigningKeyResource object represented by the provided JSON </returns> 
        public static NewSigningKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NewSigningKeyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("secret")]
        public string secret { get; set; }
    
        public NewSigningKeyResource()
        {
        
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
                                      string secret)
                                      {
            this.sid = sid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.secret = secret;
        }
    }
}