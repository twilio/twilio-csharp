using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class KeyResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> KeyFetcher capable of executing the fetch </returns> 
        public static KeyFetcher Fetcher(string sid, string accountSid=null) {
            return new KeyFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> KeyUpdater capable of executing the update </returns> 
        public static KeyUpdater Updater(string sid, string accountSid=null, string friendlyName=null) {
            return new KeyUpdater(sid, accountSid:accountSid, friendlyName:friendlyName);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> KeyDeleter capable of executing the delete </returns> 
        public static KeyDeleter Deleter(string sid, string accountSid=null) {
            return new KeyDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> KeyReader capable of executing the read </returns> 
        public static KeyReader Reader(string accountSid=null) {
            return new KeyReader(accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a KeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> KeyResource object represented by the provided JSON </returns> 
        public static KeyResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<KeyResource>(json);
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
    
        public KeyResource() {
        
        }
    
        private KeyResource([JsonProperty("sid")]
                            string sid, 
                            [JsonProperty("friendly_name")]
                            string friendlyName, 
                            [JsonProperty("date_created")]
                            string dateCreated, 
                            [JsonProperty("date_updated")]
                            string dateUpdated) {
            this.sid = sid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
        }
    }
}