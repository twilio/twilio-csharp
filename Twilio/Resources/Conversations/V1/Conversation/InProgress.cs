using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Conversations.V1.Conversation;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Conversations.V1.Conversation {

    public class InProgress : Resource {
        public enum Status {
            CREATED="created",
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            FAILED="failed"
        };
    
        /**
         * read
         * 
         * @return InProgressReader capable of executing the read
         */
        public static InProgressReader read() {
            return new InProgressReader();
        }
    
        /**
         * Converts a JSON string into a InProgress object
         * 
         * @param json Raw JSON string
         * @return InProgress object represented by the provided JSON
         */
        public static InProgress fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<InProgress>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly InProgress.Status status;
        [JsonProperty("duration")]
        private readonly Integer duration;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("start_time")]
        private readonly DateTime startTime;
        [JsonProperty("end_time")]
        private readonly DateTime endTime;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("url")]
        private readonly URI url;
    
        private InProgress([JsonProperty("sid")]
                           String sid, 
                           [JsonProperty("status")]
                           InProgress.Status status, 
                           [JsonProperty("duration")]
                           Integer duration, 
                           [JsonProperty("date_created")]
                           String dateCreated, 
                           [JsonProperty("start_time")]
                           String startTime, 
                           [JsonProperty("end_time")]
                           String endTime, 
                           [JsonProperty("account_sid")]
                           String accountSid, 
                           [JsonProperty("url")]
                           URI url) {
            this.sid = sid;
            this.status = status;
            this.duration = duration;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.startTime = MarshalConverter.dateTimeFromString(startTime);
            this.endTime = MarshalConverter.dateTimeFromString(endTime);
            this.accountSid = accountSid;
            this.url = url;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public InProgress.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The duration
         */
        public Integer GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The start_time
         */
        public DateTime GetStartTime() {
            return this.startTime;
        }
    
        /**
         * @return The end_time
         */
        public DateTime GetEndTime() {
            return this.endTime;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}