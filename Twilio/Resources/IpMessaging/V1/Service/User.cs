using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Ipmessaging.V1.Service;
using Twilio.Deleters.Ipmessaging.V1.Service;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1.Service;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1.Service;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1.Service;

namespace Twilio.Resources.IpMessaging.V1.Service {

    public class User : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserFetcher capable of executing the fetch
         */
        public static UserFetcher fetch(string serviceSid, string sid) {
            return new UserFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserDeleter capable of executing the delete
         */
        public static UserDeleter delete(string serviceSid, string sid) {
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
        public static UserCreator create(string serviceSid, string identity, string roleSid) {
            return new UserCreator(serviceSid, identity, roleSid);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return UserReader capable of executing the read
         */
        public static UserReader read(string serviceSid) {
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
        public static UserUpdater update(string serviceSid, string sid, string roleSid) {
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
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("service_sid")]
        private readonly string serviceSid;
        [JsonProperty("role_sid")]
        private readonly string roleSid;
        [JsonProperty("identity")]
        private readonly string identity;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        private User([JsonProperty("sid")]
                     string sid, 
                     [JsonProperty("account_sid")]
                     string accountSid, 
                     [JsonProperty("service_sid")]
                     string serviceSid, 
                     [JsonProperty("role_sid")]
                     string roleSid, 
                     [JsonProperty("identity")]
                     string identity, 
                     [JsonProperty("date_created")]
                     string dateCreated, 
                     [JsonProperty("date_updated")]
                     string dateUpdated, 
                     [JsonProperty("url")]
                     Uri url, 
                     [JsonProperty("links")]
                     Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.roleSid = roleSid;
            this.identity = identity;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
            this.links = links;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
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
         * @return The role_sid
         */
        public string GetRoleSid() {
            return this.roleSid;
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
        public Uri GetUrl() {
            return this.url;
        }
    
        /**
         * @return The links
         */
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}