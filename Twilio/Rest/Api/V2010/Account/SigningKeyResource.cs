using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class SigningKeyResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyFetcher capable of executing the fetch </returns> 
        public static SigningKeyFetcher Fetcher(string accountSid, string sid) {
            return new SigningKeyFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a SigningKeyFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyFetcher capable of executing the fetch </returns> 
        public static SigningKeyFetcher Fetcher(string sid) {
            return new SigningKeyFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyUpdater capable of executing the update </returns> 
        public static SigningKeyUpdater Updater(string accountSid, string sid) {
            return new SigningKeyUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a SigningKeyUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyUpdater capable of executing the update </returns> 
        public static SigningKeyUpdater Updater(string sid) {
            return new SigningKeyUpdater(sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyDeleter capable of executing the delete </returns> 
        public static SigningKeyDeleter Deleter(string accountSid, string sid) {
            return new SigningKeyDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a SigningKeyDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> SigningKeyDeleter capable of executing the delete </returns> 
        public static SigningKeyDeleter Deleter(string sid) {
            return new SigningKeyDeleter(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SigningKeyReader capable of executing the read </returns> 
        public static SigningKeyReader Reader(string accountSid) {
            return new SigningKeyReader(accountSid);
        }
    
        /// <summary>
        /// Create a SigningKeyReader to execute read.
        /// </summary>
        ///
        /// <returns> SigningKeyReader capable of executing the read </returns> 
        public static SigningKeyReader Reader() {
            return new SigningKeyReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a SigningKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SigningKeyResource object represented by the provided JSON </returns> 
        public static SigningKeyResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SigningKeyResource>(json);
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
    
        public SigningKeyResource() {
        
        }
    
        private SigningKeyResource([JsonProperty("sid")]
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