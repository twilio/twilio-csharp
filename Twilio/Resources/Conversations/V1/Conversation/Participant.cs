using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Conversations.V1.Conversation;
using Twilio.Exceptions;
using Twilio.Fetchers.Conversations.V1.Conversation;
using Twilio.Http;
using Twilio.Readers.Conversations.V1.Conversation;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Conversations.V1.Conversation {

    public class Participant : SidResource {
        public enum Status {
            CREATED="created",
            CONNECTING="connecting",
            CONNECTED="connected",
            DISCONNECTED="disconnected",
            FAILED="failed"
        };
    
        /**
         * read
         * 
         * @param conversationSid The conversation_sid
         * @return ParticipantReader capable of executing the read
         */
        public static ParticipantReader read(String conversationSid) {
            return new ParticipantReader(conversationSid);
        }
    
        /**
         * create
         * 
         * @param conversationSid The conversation_sid
         * @param to The to
         * @param from The from
         * @return ParticipantCreator capable of executing the create
         */
        public static ParticipantCreator create(String conversationSid, com.twilio.types.PhoneNumber to, com.twilio.types.PhoneNumber from) {
            return new ParticipantCreator(conversationSid, to, from);
        }
    
        /**
         * fetch
         * 
         * @param conversationSid The conversation_sid
         * @param sid The sid
         * @return ParticipantFetcher capable of executing the fetch
         */
        public static ParticipantFetcher fetch(String conversationSid, String sid) {
            return new ParticipantFetcher(conversationSid, sid);
        }
    
        /**
         * Converts a JSON string into a Participant object
         * 
         * @param json Raw JSON string
         * @return Participant object represented by the provided JSON
         */
        public static Participant fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Participant>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("address")]
        private readonly String address;
        [JsonProperty("status")]
        private readonly Participant.Status status;
        [JsonProperty("conversation_sid")]
        private readonly String conversationSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("start_time")]
        private readonly DateTime startTime;
        [JsonProperty("end_time")]
        private readonly DateTime endTime;
        [JsonProperty("duration")]
        private readonly Integer duration;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Participant([JsonProperty("sid")]
                            String sid, 
                            [JsonProperty("address")]
                            String address, 
                            [JsonProperty("status")]
                            Participant.Status status, 
                            [JsonProperty("conversation_sid")]
                            String conversationSid, 
                            [JsonProperty("date_created")]
                            String dateCreated, 
                            [JsonProperty("start_time")]
                            String startTime, 
                            [JsonProperty("end_time")]
                            String endTime, 
                            [JsonProperty("duration")]
                            Integer duration, 
                            [JsonProperty("account_sid")]
                            String accountSid, 
                            [JsonProperty("url")]
                            URI url) {
            this.sid = sid;
            this.address = address;
            this.status = status;
            this.conversationSid = conversationSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.startTime = MarshalConverter.dateTimeFromString(startTime);
            this.endTime = MarshalConverter.dateTimeFromString(endTime);
            this.duration = duration;
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
         * @return The address
         */
        public String GetAddress() {
            return this.address;
        }
    
        /**
         * @return The status
         */
        public Participant.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The conversation_sid
         */
        public String GetConversationSid() {
            return this.conversationSid;
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
         * @return The duration
         */
        public Integer GetDuration() {
            return this.duration;
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