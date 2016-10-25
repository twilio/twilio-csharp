using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel 
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
        /// <param name="from"> The from </param>
        /// <param name="attributes"> The attributes </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(string serviceSid, string channelSid, string body, string from=null, string attributes=null)
        {
            return new MessageCreator(serviceSid, channelSid, body, from:from, attributes:attributes);
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
        /// <param name="attributes"> The attributes </param>
        /// <returns> MessageUpdater capable of executing the update </returns> 
        public static MessageUpdater Updater(string serviceSid, string channelSid, string sid, string body, Object attributes=null)
        {
            return new MessageUpdater(serviceSid, channelSid, sid, body, attributes:attributes);
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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; }
        [JsonProperty("to")]
        public string to { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("was_edited")]
        public bool? wasEdited { get; }
        [JsonProperty("from")]
        public string from { get; }
        [JsonProperty("body")]
        public string body { get; }
        [JsonProperty("index")]
        public int? index { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
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