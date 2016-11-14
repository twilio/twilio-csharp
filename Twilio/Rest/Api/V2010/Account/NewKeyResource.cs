using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class NewKeyResource : Resource 
    {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <returns> NewKeyCreator capable of executing the create </returns> 
        public static NewKeyCreator Creator()
        {
            return new NewKeyCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a NewKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NewKeyResource object represented by the provided JSON </returns> 
        public static NewKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NewKeyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }
    
        public NewKeyResource()
        {
        
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
                               string secret)
                               {
            Sid = sid;
            FriendlyName = friendlyName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Secret = secret;
        }
    }
}