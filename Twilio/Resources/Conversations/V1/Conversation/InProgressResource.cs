using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Conversations.V1.Conversation;
using Twilio.Resources;

namespace Twilio.Resources.Conversations.V1.Conversation {

    public class InProgressResource : Resource {
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
         * read
         * 
         * @return InProgressReader capable of executing the read
         */
        public static InProgressReader read() {
            return new InProgressReader();
        }
    
        /**
         * Converts a JSON string into a InProgressResource object
         * 
         * @param json Raw JSON string
         * @return InProgressResource object represented by the provided JSON
         */
        public static InProgressResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<InProgressResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        private readonly InProgressResource.Status status;
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
    
        private InProgressResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("status")]
                                   InProgressResource.Status status, 
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
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public InProgressResource.Status GetStatus() {
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