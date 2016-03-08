using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Recording : SidResource {
        /**
         * Fetch an instance of a recording
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique recording Sid
         * @return RecordingFetcher capable of executing the fetch
         */
        public static RecordingFetcher fetch(String accountSid, String sid) {
            return new RecordingFetcher(accountSid, sid);
        }
    
        /**
         * Delete a recording from your account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique recording Sid
         * @return RecordingDeleter capable of executing the delete
         */
        public static RecordingDeleter delete(String accountSid, String sid) {
            return new RecordingDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of recordings belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return RecordingReader capable of executing the read
         */
        public static RecordingReader read(String accountSid) {
            return new RecordingReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Recording object
         * 
         * @param json Raw JSON string
         * @return Recording object represented by the provided JSON
         */
        public static Recording fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Recording>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("call_sid")]
        private readonly String callSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("duration")]
        private readonly String duration;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Recording([JsonProperty("account_sid")]
                          String accountSid, 
                          [JsonProperty("api_version")]
                          String apiVersion, 
                          [JsonProperty("call_sid")]
                          String callSid, 
                          [JsonProperty("date_created")]
                          String dateCreated, 
                          [JsonProperty("date_updated")]
                          String dateUpdated, 
                          [JsonProperty("duration")]
                          String duration, 
                          [JsonProperty("sid")]
                          String sid, 
                          [JsonProperty("uri")]
                          String uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.duration = duration;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the API in use during the recording.
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call during which the recording was made.
         */
        public String GetCallSid() {
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
        public String GetDuration() {
            return this.duration;
        }
    
        /**
         * @return A string that uniquely identifies this recording
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}