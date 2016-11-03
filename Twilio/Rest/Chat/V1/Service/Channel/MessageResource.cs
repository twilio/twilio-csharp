using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    public class MessageResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> MessageFetcher capable of executing the fetch </returns> 
        public static MessageFetcher Fetcher(string serviceSid, string channelSid, string sid)
        {
            return new MessageFetcher(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(string serviceSid, string channelSid, string body)
        {
            return new MessageCreator(serviceSid, channelSid, body);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <returns> MessageReader capable of executing the read </returns> 
        public static MessageReader Reader(string serviceSid, string channelSid)
        {
            return new MessageReader(serviceSid, channelSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> MessageDeleter capable of executing the delete </returns> 
        public static MessageDeleter Deleter(string serviceSid, string channelSid, string sid)
        {
            return new MessageDeleter(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageUpdater capable of executing the update </returns> 
        public static MessageUpdater Updater(string serviceSid, string channelSid, string sid, string body)
        {
            return new MessageUpdater(serviceSid, channelSid, sid, body);
        }
    
        /// <summary>
        /// Converts a JSON string into a MessageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MessageResource object represented by the provided JSON </returns> 
        public static MessageResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MessageResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; set; }
        [JsonProperty("to")]
        public string to { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("was_edited")]
        public bool? wasEdited { get; set; }
        [JsonProperty("from")]
        public string from { get; set; }
        [JsonProperty("body")]
        public string body { get; set; }
        [JsonProperty("index")]
        public int? index { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public MessageResource()
        {
        
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
                                [JsonProperty("index")]
                                int? index, 
                                [JsonProperty("url")]
                                Uri url)
                                {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.to = to;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.wasEdited = wasEdited;
            this.from = from;
            this.body = body;
            this.index = index;
            this.url = url;
        }
    }
}