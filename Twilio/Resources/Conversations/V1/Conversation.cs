using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Conversations.V1;
using Twilio.Http;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Conversations.V1 {

    public class Conversation : SidResource {
        public enum Status {
            CREATED="created",
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            FAILED="failed"
        };
    
        /**
         * fetch
         * 
         * @param sid The sid
         * @return ConversationFetcher capable of executing the fetch
         */
        public static ConversationFetcher fetch(String sid) {
            return new ConversationFetcher(sid);
        }
    
        /**
         * Converts a JSON string into a Conversation object
         * 
         * @param json Raw JSON string
         * @return Conversation object represented by the provided JSON
         */
        public static Conversation fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Conversation>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly Conversation.Status status;
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
    
        private Conversation([JsonProperty("sid")]
                             String sid, 
                             [JsonProperty("status")]
                             Conversation.Status status, 
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
        public Conversation.Status GetStatus() {
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