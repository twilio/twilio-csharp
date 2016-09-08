using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class SigningKeyResource : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SigningKeyFetcher capable of executing the fetch
         */
        public static SigningKeyFetcher Fetch(string accountSid, string sid) {
            return new SigningKeyFetcher(accountSid, sid);
        }
    
        /**
         * Create a SigningKeyFetcher to execute fetch.
         * 
         * @param sid The sid
         * @return SigningKeyFetcher capable of executing the fetch
         */
        public static SigningKeyFetcher Fetch(string sid) {
            return new SigningKeyFetcher(sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SigningKeyUpdater capable of executing the update
         */
        public static SigningKeyUpdater Update(string accountSid, string sid) {
            return new SigningKeyUpdater(accountSid, sid);
        }
    
        /**
         * Create a SigningKeyUpdater to execute update.
         * 
         * @param sid The sid
         * @return SigningKeyUpdater capable of executing the update
         */
        public static SigningKeyUpdater Update(string sid) {
            return new SigningKeyUpdater(sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return SigningKeyDeleter capable of executing the delete
         */
        public static SigningKeyDeleter Delete(string accountSid, string sid) {
            return new SigningKeyDeleter(accountSid, sid);
        }
    
        /**
         * Create a SigningKeyDeleter to execute delete.
         * 
         * @param sid The sid
         * @return SigningKeyDeleter capable of executing the delete
         */
        public static SigningKeyDeleter Delete(string sid) {
            return new SigningKeyDeleter(sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return SigningKeyReader capable of executing the read
         */
        public static SigningKeyReader Read(string accountSid) {
            return new SigningKeyReader(accountSid);
        }
    
        /**
         * Create a SigningKeyReader to execute read.
         * 
         * @return SigningKeyReader capable of executing the read
         */
        public static SigningKeyReader Read() {
            return new SigningKeyReader();
        }
    
        /**
         * Converts a JSON string into a SigningKeyResource object
         * 
         * @param json Raw JSON string
         * @return SigningKeyResource object represented by the provided JSON
         */
        public static SigningKeyResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SigningKeyResource>(json);
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
    
        /**
         * @return The sid
         */
        public override string GetSid() {
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
    }
}