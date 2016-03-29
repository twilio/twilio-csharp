using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Call;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Call;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Call;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Call {

    public class RecordingResource : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param sid The sid
         * @return RecordingFetcher capable of executing the fetch
         */
        public static RecordingFetcher fetch(string accountSid, string callSid, string sid) {
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
        public static RecordingDeleter delete(string accountSid, string callSid, string sid) {
            return new RecordingDeleter(accountSid, callSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @return RecordingReader capable of executing the read
         */
        public static RecordingReader read(string accountSid, string callSid) {
            return new RecordingReader(accountSid, callSid);
        }
    
        /**
         * Converts a JSON string into a RecordingResource object
         * 
         * @param json Raw JSON string
         * @return RecordingResource object represented by the provided JSON
         */
        public static RecordingResource FromJson(string json) {
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
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call_sid
         */
        public string GetCallSid() {
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
        public string GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}