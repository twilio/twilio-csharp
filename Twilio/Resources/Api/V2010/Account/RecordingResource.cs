using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class RecordingResource : SidResource {
        /**
         * Fetch an instance of a recording
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique recording Sid
         * @return RecordingFetcher capable of executing the fetch
         */
        public static RecordingFetcher fetch(string accountSid, string sid) {
            return new RecordingFetcher(accountSid, sid);
        }
    
        /**
         * Delete a recording from your account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique recording Sid
         * @return RecordingDeleter capable of executing the delete
         */
        public static RecordingDeleter delete(string accountSid, string sid) {
            return new RecordingDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of recordings belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return RecordingReader capable of executing the read
         */
        public static RecordingReader read(string accountSid) {
            return new RecordingReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a RecordingResource object
         * 
         * @param json Raw JSON string
         * @return RecordingResource object represented by the provided JSON
         */
        public static RecordingResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("call_sid")]
        private readonly string callSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("duration")]
        private readonly string duration;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private RecordingResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("api_version")]
                                  string apiVersion, 
                                  [JsonProperty("call_sid")]
                                  string callSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("duration")]
                                  string duration, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("uri")]
                                  string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.duration = duration;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the API in use during the recording.
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call during which the recording was made.
         */
        public string GetCallSid() {
            return this.callSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The length of the recording, in seconds.
         */
        public string GetDuration() {
            return this.duration;
        }
    
        /**
         * @return A string that uniquely identifies this recording
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}