using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account.Call;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Call;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Call;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Call {

    public class Recording : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         * @return RecordingFetcher capable of executing the fetch
         */
        public static RecordingFetcher fetch(String accountSid, String callSid, String sid) {
            return new RecordingFetcher(accountSid, callSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         * @return RecordingDeleter capable of executing the delete
         */
        public static RecordingDeleter delete(String accountSid, String callSid, String sid) {
            return new RecordingDeleter(accountSid, callSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @return RecordingReader capable of executing the read
         */
        public static RecordingReader read(String accountSid, String callSid) {
            return new RecordingReader(accountSid, callSid);
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
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call_sid
         */
        public String GetCallSid() {
            return this.callSid;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The duration
         */
        public String GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}