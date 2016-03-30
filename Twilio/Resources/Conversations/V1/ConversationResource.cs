using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Conversations.V1;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Conversations.V1 {

    public class ConversationResource : SidResource {
        public sealed class Status {
            public const string CREATED="created";
            public const string IN_PROGRESS="in-progress";
            public const string COMPLETED="completed";
            public const string FAILED="failed";
        
            private readonly string value;
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
        }
    
        /**
         * fetch
         * 
         * @param sid The sid
         * @return ConversationFetcher capable of executing the fetch
         */
        public static ConversationFetcher fetch(string sid) {
            return new ConversationFetcher(sid);
        }
    
        /**
         * Converts a JSON string into a ConversationResource object
         * 
         * @param json Raw JSON string
         * @return ConversationResource object represented by the provided JSON
         */
        public static ConversationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConversationResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        private readonly ConversationResource.Status status;
        [JsonProperty("duration")]
        private readonly int? duration;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("start_time")]
        private readonly DateTime? startTime;
        [JsonProperty("end_time")]
        private readonly DateTime? endTime;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("url")]
        private readonly Uri url;
    
        private ConversationResource([JsonProperty("sid")]
                                     string sid, 
                                     [JsonProperty("status")]
                                     ConversationResource.Status status, 
                                     [JsonProperty("duration")]
                                     int? duration, 
                                     [JsonProperty("date_created")]
                                     string dateCreated, 
                                     [JsonProperty("start_time")]
                                     string startTime, 
                                     [JsonProperty("end_time")]
                                     string endTime, 
                                     [JsonProperty("account_sid")]
                                     string accountSid, 
                                     [JsonProperty("url")]
                                     Uri url) {
            this.sid = sid;
            this.status = status;
            this.duration = duration;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.startTime = MarshalConverter.DateTimeFromString(startTime);
            this.endTime = MarshalConverter.DateTimeFromString(endTime);
            this.accountSid = accountSid;
            this.url = url;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public ConversationResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The duration
         */
        public int? GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The start_time
         */
        public DateTime? GetStartTime() {
            return this.startTime;
        }
    
        /**
         * @return The end_time
         */
        public DateTime? GetEndTime() {
            return this.endTime;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}