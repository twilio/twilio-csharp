using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service {

    public class UserResource : SidResource {
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserFetcher capable of executing the fetch
         */
        public static UserFetcher Fetch(string serviceSid, string sid) {
            return new UserFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserDeleter capable of executing the delete
         */
        public static UserDeleter Delete(string serviceSid, string sid) {
            return new UserDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param identity The identity
         * @return UserCreator capable of executing the create
         */
        public static UserCreator Create(string serviceSid, string identity) {
            return new UserCreator(serviceSid, identity);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return UserReader capable of executing the read
         */
        public static UserReader Read(string serviceSid) {
            return new UserReader(serviceSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return UserUpdater capable of executing the update
         */
        public static UserUpdater Update(string serviceSid, string sid) {
            return new UserUpdater(serviceSid, sid);
        }
    
        /**
         * Converts a JSON string into a UserResource object
         * 
         * @param json Raw JSON string
         * @return UserResource object represented by the provided JSON
         */
        public static UserResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<UserResource>(json);
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
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public UserResource() {
        
        }
    
        private UserResource([JsonProperty("sid")]
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
                             Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.roleSid = roleSid;
            this.identity = identity;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
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
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}