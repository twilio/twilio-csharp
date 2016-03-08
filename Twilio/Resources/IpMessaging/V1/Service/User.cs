using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Ipmessaging.V1.Service;
using Twilio.Deleters.Ipmessaging.V1.Service;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1.Service;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1.Service;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1.Service;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1.Service {

    public class User : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserFetcher capable of executing the fetch
         */
        public static UserFetcher fetch(String serviceSid, String sid) {
            return new UserFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserDeleter capable of executing the delete
         */
        public static UserDeleter delete(String serviceSid, String sid) {
            return new UserDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param identity The identity
         * @param roleSid The role_sid
         * @return UserCreator capable of executing the create
         */
        public static UserCreator create(String serviceSid, String identity, String roleSid) {
            return new UserCreator(serviceSid, identity, roleSid);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return UserReader capable of executing the read
         */
        public static UserReader read(String serviceSid) {
            return new UserReader(serviceSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @param roleSid The role_sid
         * @return UserUpdater capable of executing the update
         */
        public static UserUpdater update(String serviceSid, String sid, String roleSid) {
            return new UserUpdater(serviceSid, sid, roleSid);
        }
    
        /**
         * Converts a JSON string into a User object
         * 
         * @param json Raw JSON string
         * @return User object represented by the provided JSON
         */
        public static User fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<User>(json);
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
        [JsonProperty("role_sid")]
        private readonly String roleSid;
        [JsonProperty("identity")]
        private readonly String identity;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly URI url;
        [JsonProperty("links")]
        private readonly Map<String, String> links;
    
        private User([JsonProperty("sid")]
                     String sid, 
                     [JsonProperty("account_sid")]
                     String accountSid, 
                     [JsonProperty("service_sid")]
                     String serviceSid, 
                     [JsonProperty("role_sid")]
                     String roleSid, 
                     [JsonProperty("identity")]
                     String identity, 
                     [JsonProperty("date_created")]
                     String dateCreated, 
                     [JsonProperty("date_updated")]
                     String dateUpdated, 
                     [JsonProperty("url")]
                     URI url, 
                     [JsonProperty("links")]
                     Map<String, String> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.roleSid = roleSid;
            this.identity = identity;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.url = url;
            this.links = links;
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
         * @return The role_sid
         */
        public String GetRoleSid() {
            return this.roleSid;
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
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    
        /**
         * @return The links
         */
        public Map<String, String> GetLinks() {
            return this.links;
        }
    }
}