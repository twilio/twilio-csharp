using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel {

    public class MessageResource : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @return MessageFetcher capable of executing the fetch
         */
        public static MessageFetcher Fetch(string serviceSid, string channelSid, string sid) {
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
        public static MessageCreator Create(string serviceSid, string channelSid, string body) {
            return new MessageCreator(serviceSid, channelSid, body);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @return MessageReader capable of executing the read
         */
        public static MessageReader Read(string serviceSid, string channelSid) {
            return new MessageReader(serviceSid, channelSid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @return MessageDeleter capable of executing the delete
         */
        public static MessageDeleter Delete(string serviceSid, string channelSid, string sid) {
            return new MessageDeleter(serviceSid, channelSid, sid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @param body The body
         * @return MessageUpdater capable of executing the update
         */
        public static MessageUpdater Update(string serviceSid, string channelSid, string sid, string body) {
            return new MessageUpdater(serviceSid, channelSid, sid, body);
        }
    
        /**
         * Converts a JSON string into a MessageResource object
         * 
         * @param json Raw JSON string
         * @return MessageResource object represented by the provided JSON
         */
        public static MessageResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<MessageResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("to")]
        private readonly string to;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("was_edited")]
        private readonly bool? wasEdited;
        [JsonProperty("from")]
        private readonly string from;
        [JsonProperty("body")]
        private readonly string body;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public MessageResource() {
        
        }
    
        private MessageResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("to")]
                                string to, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("was_edited")]
                                bool? wasEdited, 
                                [JsonProperty("from")]
                                string from, 
                                [JsonProperty("body")]
                                string body, 
                                [JsonProperty("url")]
                                Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.to = to;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.wasEdited = wasEdited;
            this.from = from;
            this.body = body;
            this.url = url;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The service_sid
         */
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The to
         */
        public string GetTo() {
            return this.to;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The was_edited
         */
        public bool? GetWasEdited() {
            return this.wasEdited;
        }
    
        /**
         * @return The from
         */
        public string GetFrom() {
            return this.from;
        }
    
        /**
         * @return The body
         */
        public string GetBody() {
            return this.body;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}