using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class SigningKeyResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyFetcher capable of executing the fetch </returns> 
        public static SigningKeyFetcher Fetcher(string sid)
        {
            return new SigningKeyFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyUpdater capable of executing the update </returns> 
        public static SigningKeyUpdater Updater(string sid)
        {
            return new SigningKeyUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyDeleter capable of executing the delete </returns> 
        public static SigningKeyDeleter Deleter(string sid)
        {
            return new SigningKeyDeleter(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> SigningKeyReader capable of executing the read </returns> 
        public static SigningKeyReader Reader()
        {
            return new SigningKeyReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a SigningKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SigningKeyResource object represented by the provided JSON </returns> 
        public static SigningKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SigningKeyResource>(json);
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
    
        public SigningKeyResource()
        {
        
        }
    
        private SigningKeyResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated)
                                   {
            Sid = sid;
            FriendlyName = friendlyName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
        }
    }
}