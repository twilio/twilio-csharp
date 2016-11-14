using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    public class MemberResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> MemberFetcher capable of executing the fetch </returns> 
        public static MemberFetcher Fetcher(string serviceSid, string channelSid, string sid)
        {
            return new MemberFetcher(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="identity"> The identity </param>
        /// <returns> MemberCreator capable of executing the create </returns> 
        public static MemberCreator Creator(string serviceSid, string channelSid, string identity)
        {
            return new MemberCreator(serviceSid, channelSid, identity);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <returns> MemberReader capable of executing the read </returns> 
        public static MemberReader Reader(string serviceSid, string channelSid)
        {
            return new MemberReader(serviceSid, channelSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> MemberDeleter capable of executing the delete </returns> 
        public static MemberDeleter Deleter(string serviceSid, string channelSid, string sid)
        {
            return new MemberDeleter(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns> 
        public static MemberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MemberResource>(json);
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
        [JsonProperty("channel_sid")]
        public string ChannelSid { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("identity")]
        public string Identity { get; set; }
        [JsonProperty("last_consumed_message_index")]
        public int? LastConsumedMessageIndex { get; set; }
        [JsonProperty("last_consumption_timestamp")]
        public DateTime? LastConsumptionTimestamp { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("role_sid")]
        public string RoleSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public MemberResource()
        {
        
        }
    
        private MemberResource([JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("channel_sid")]
                               string channelSid, 
                               [JsonProperty("service_sid")]
                               string serviceSid, 
                               [JsonProperty("identity")]
                               string identity, 
                               [JsonProperty("last_consumed_message_index")]
                               int? lastConsumedMessageIndex, 
                               [JsonProperty("last_consumption_timestamp")]
                               string lastConsumptionTimestamp, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("role_sid")]
                               string roleSid, 
                               [JsonProperty("url")]
                               Uri url)
                               {
            Sid = sid;
            AccountSid = accountSid;
            ChannelSid = channelSid;
            ServiceSid = serviceSid;
            Identity = identity;
            LastConsumedMessageIndex = lastConsumedMessageIndex;
            LastConsumptionTimestamp = MarshalConverter.DateTimeFromString(lastConsumptionTimestamp);
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            RoleSid = roleSid;
            Url = url;
        }
    }
}