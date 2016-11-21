using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

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
        public string Sid { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("attributes")]
        public string Attributes { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("was_edited")]
        public bool? WasEdited { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("index")]
        public int? Index { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public MessageResource()
        {
        
        }
    
        private MessageResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("attributes")]
                                string attributes, 
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
            Sid = sid;
            AccountSid = accountSid;
            Attributes = attributes;
            ServiceSid = serviceSid;
            To = to;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            WasEdited = wasEdited;
            From = from;
            Body = body;
            Index = index;
            Url = url;
        }
    }
}