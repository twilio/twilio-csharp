using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Ipmessaging.V1.Service.Channel;
using Twilio.Deleters.Ipmessaging.V1.Service.Channel;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1.Service.Channel;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1.Service.Channel;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1.Service.Channel {

    public class Member : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @return MemberFetcher capable of executing the fetch
         */
        public static MemberFetcher fetch(String serviceSid, String channelSid, String sid) {
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
        public static MemberCreator create(String serviceSid, String channelSid, String identity) {
            return new MemberCreator(serviceSid, channelSid, identity);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @return MemberReader capable of executing the read
         */
        public static MemberReader read(String serviceSid, String channelSid) {
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
        public static MemberDeleter delete(String serviceSid, String channelSid, String sid) {
            return new MemberDeleter(serviceSid, channelSid, sid);
        }
    
        /**
         * Converts a JSON string into a Member object
         * 
         * @param json Raw JSON string
         * @return Member object represented by the provided JSON
         */
        public static Member fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Member>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("channel_sid")]
        private readonly String channelSid;
        [JsonProperty("service_sid")]
        private readonly String serviceSid;
        [JsonProperty("identity")]
        private readonly String identity;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("role_sid")]
        private readonly String roleSid;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Member([JsonProperty("sid")]
                       String sid, 
                       [JsonProperty("account_sid")]
                       String accountSid, 
                       [JsonProperty("channel_sid")]
                       String channelSid, 
                       [JsonProperty("service_sid")]
                       String serviceSid, 
                       [JsonProperty("identity")]
                       String identity, 
                       [JsonProperty("date_created")]
                       String dateCreated, 
                       [JsonProperty("date_updated")]
                       String dateUpdated, 
                       [JsonProperty("role_sid")]
                       String roleSid, 
                       [JsonProperty("url")]
                       URI url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.channelSid = channelSid;
            this.serviceSid = serviceSid;
            this.identity = identity;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.roleSid = roleSid;
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
         * @return The channel_sid
         */
        public String GetChannelSid() {
            return this.channelSid;
        }
    
        /**
         * @return The service_sid
         */
        public String GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The identity
         */
        public String GetIdentity() {
            return this.identity;
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
         * @return The role_sid
         */
        public String GetRoleSid() {
            return this.roleSid;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}