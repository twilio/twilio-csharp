using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.IpMessaging.V1.Service.Channel;
using Twilio.Deleters.IpMessaging.V1.Service.Channel;
using Twilio.Exceptions;
using Twilio.Fetchers.IpMessaging.V1.Service.Channel;
using Twilio.Http;
using Twilio.Readers.IpMessaging.V1.Service.Channel;
using Twilio.Resources;

namespace Twilio.Resources.IpMessaging.V1.Service.Channel {

    public class MemberResource : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @return MemberFetcher capable of executing the fetch
         */
        public static MemberFetcher Fetch(string serviceSid, string channelSid, string sid) {
            return new MemberFetcher(serviceSid, channelSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param identity The identity
         * @return MemberCreator capable of executing the create
         */
        public static MemberCreator Create(string serviceSid, string channelSid, string identity) {
            return new MemberCreator(serviceSid, channelSid, identity);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @return MemberReader capable of executing the read
         */
        public static MemberReader Read(string serviceSid, string channelSid) {
            return new MemberReader(serviceSid, channelSid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @return MemberDeleter capable of executing the delete
         */
        public static MemberDeleter Delete(string serviceSid, string channelSid, string sid) {
            return new MemberDeleter(serviceSid, channelSid, sid);
        }
    
        /**
         * Converts a JSON string into a MemberResource object
         * 
         * @param json Raw JSON string
         * @return MemberResource object represented by the provided JSON
         */
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
         * @return The channel_sid
         */
        public string GetChannelSid() {
            return this.channelSid;
        }
    
        /**
         * @return The service_sid
         */
        public string GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The identity
         */
        public string GetIdentity() {
            return this.identity;
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
         * @return The role_sid
         */
        public string GetRoleSid() {
            return this.roleSid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}