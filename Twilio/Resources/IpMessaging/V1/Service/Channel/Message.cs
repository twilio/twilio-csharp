using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Ipmessaging.V1.Service.Channel;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1.Service.Channel;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1.Service.Channel;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1.Service.Channel {

    public class Message : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @return MessageFetcher capable of executing the fetch
         */
        public static MessageFetcher fetch(String serviceSid, String channelSid, String sid) {
            return new MessageFetcher(serviceSid, channelSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param body The body
         * @return MessageCreator capable of executing the create
         */
        public static MessageCreator create(String serviceSid, String channelSid, String body) {
            return new MessageCreator(serviceSid, channelSid, body);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @return MessageReader capable of executing the read
         */
        public static MessageReader read(String serviceSid, String channelSid) {
            return new MessageReader(serviceSid, channelSid);
        }
    
        /**
         * Converts a JSON string into a Message object
         * 
         * @param json Raw JSON string
         * @return Message object represented by the provided JSON
         */
        public static Message fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Message>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("service_sid")]
        private readonly String serviceSid;
        [JsonProperty("to")]
        private readonly String to;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("was_edited")]
        private readonly Boolean wasEdited;
        [JsonProperty("from")]
        private readonly String from;
        [JsonProperty("body")]
        private readonly String body;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Message([JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("service_sid")]
                        String serviceSid, 
                        [JsonProperty("to")]
                        String to, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("was_edited")]
                        Boolean wasEdited, 
                        [JsonProperty("from")]
                        String from, 
                        [JsonProperty("body")]
                        String body, 
                        [JsonProperty("url")]
                        URI url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.to = to;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.wasEdited = wasEdited;
            this.from = from;
            this.body = body;
            this.url = url;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The service_sid
         */
        public String GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The to
         */
        public String GetTo() {
            return this.to;
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
         * @return The was_edited
         */
        public Boolean GetWasEdited() {
            return this.wasEdited;
        }
    
        /**
         * @return The from
         */
        public String GetFrom() {
            return this.from;
        }
    
        /**
         * @return The body
         */
        public String GetBody() {
            return this.body;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}