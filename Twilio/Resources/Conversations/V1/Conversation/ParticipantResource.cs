using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Conversations.V1.Conversation;
using Twilio.Exceptions;
using Twilio.Fetchers.Conversations.V1.Conversation;
using Twilio.Http;
using Twilio.Readers.Conversations.V1.Conversation;
using Twilio.Resources;

namespace Twilio.Resources.Conversations.V1.Conversation {

    public class ParticipantResource : SidResource {
        public sealed class Status {
            public const string CREATED="created";
            public const string CONNECTING="connecting";
            public const string CONNECTED="connected";
            public const string DISCONNECTED="disconnected";
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
         * @param conversationSid The conversation_sid
         * @return ParticipantReader capable of executing the read
         */
        public static ParticipantReader read(string conversationSid) {
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
        public static ParticipantCreator create(string conversationSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from) {
            return new ParticipantCreator(conversationSid, to, from);
        }
    
        /**
         * fetch
         * 
         * @param conversationSid The conversation_sid
         * @param sid The sid
         * @return ParticipantFetcher capable of executing the fetch
         */
        public static ParticipantFetcher fetch(string conversationSid, string sid) {
            return new ParticipantFetcher(conversationSid, sid);
        }
    
        /**
         * Converts a JSON string into a ParticipantResource object
         * 
         * @param json Raw JSON string
         * @return ParticipantResource object represented by the provided JSON
         */
        public static ParticipantResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("address")]
        private readonly string address;
        [JsonProperty("status")]
        private readonly ParticipantResource.Status status;
        [JsonProperty("conversation_sid")]
        private readonly string conversationSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("start_time")]
        private readonly DateTime startTime;
        [JsonProperty("end_time")]
        private readonly DateTime endTime;
        [JsonProperty("duration")]
        private readonly int duration;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("url")]
        private readonly Uri url;
    
        private ParticipantResource([JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("address")]
                                    string address, 
                                    [JsonProperty("status")]
                                    ParticipantResource.Status status, 
                                    [JsonProperty("conversation_sid")]
                                    string conversationSid, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("start_time")]
                                    string startTime, 
                                    [JsonProperty("end_time")]
                                    string endTime, 
                                    [JsonProperty("duration")]
                                    int duration, 
                                    [JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("url")]
                                    Uri url) {
            this.sid = sid;
            this.address = address;
            this.status = status;
            this.conversationSid = conversationSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.startTime = MarshalConverter.DateTimeFromString(startTime);
            this.endTime = MarshalConverter.DateTimeFromString(endTime);
            this.duration = duration;
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
         * @return The address
         */
        public string GetAddress() {
            return this.address;
        }
    
        /**
         * @return The status
         */
        public ParticipantResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The conversation_sid
         */
        public string GetConversationSid() {
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
        public int GetDuration() {
            return this.duration;
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