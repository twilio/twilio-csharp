using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service.Channel {

    public class MemberResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> MemberFetcher capable of executing the fetch </returns> 
        public static MemberFetcher Fetcher(string serviceSid, string channelSid, string sid) {
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
        public static MemberCreator Creator(string serviceSid, string channelSid, string identity) {
            return new MemberCreator(serviceSid, channelSid, identity);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <returns> MemberReader capable of executing the read </returns> 
        public static MemberReader Reader(string serviceSid, string channelSid) {
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
        public static MemberDeleter Deleter(string serviceSid, string channelSid, string sid) {
            return new MemberDeleter(serviceSid, channelSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns> 
        public static MemberResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<MemberResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("channel_sid")]
        private readonly string channelSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("identity")]
        private readonly string identity;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("role_sid")]
        private readonly string roleSid;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public MemberResource() {
        
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
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("role_sid")]
                               string roleSid, 
                               [JsonProperty("url")]
                               Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.channelSid = channelSid;
            this.serviceSid = serviceSid;
            this.identity = identity;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.roleSid = roleSid;
            this.url = url;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The channel_sid </returns> 
        public string GetChannelSid() {
            return this.channelSid;
        }
    
        /// <returns> The service_sid </returns> 
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /// <returns> The identity </returns> 
        public string GetIdentity() {
            return this.identity;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The role_sid </returns> 
        public string GetRoleSid() {
            return this.roleSid;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}