using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel 
{

    public class InviteResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> InviteFetcher capable of executing the fetch </returns> 
        public static InviteFetcher Fetcher(string serviceSid, string channelSid, string sid)
        {
            return new InviteFetcher(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="identity"> The identity </param>
        /// <returns> InviteCreator capable of executing the create </returns> 
        public static InviteCreator Creator(string serviceSid, string channelSid, string identity)
        {
            return new InviteCreator(serviceSid, channelSid, identity);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <returns> InviteReader capable of executing the read </returns> 
        public static InviteReader Reader(string serviceSid, string channelSid)
        {
            return new InviteReader(serviceSid, channelSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> InviteDeleter capable of executing the delete </returns> 
        public static InviteDeleter Deleter(string serviceSid, string channelSid, string sid)
        {
            return new InviteDeleter(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a InviteResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> InviteResource object represented by the provided JSON </returns> 
        public static InviteResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<InviteResource>(json);
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
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("role_sid")]
        public string RoleSid { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public InviteResource()
        {
        
        }
    
        private InviteResource([JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("channel_sid")]
                               string channelSid, 
                               [JsonProperty("service_sid")]
                               string serviceSid, 
                               [JsonProperty("identity")]
                               string identity, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("role_sid")]
                               string roleSid, 
                               [JsonProperty("created_by")]
                               string createdBy, 
                               [JsonProperty("url")]
                               Uri url)
                               {
            Sid = sid;
            AccountSid = accountSid;
            ChannelSid = channelSid;
            ServiceSid = serviceSid;
            Identity = identity;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            RoleSid = roleSid;
            CreatedBy = createdBy;
            Url = url;
        }
    }
}