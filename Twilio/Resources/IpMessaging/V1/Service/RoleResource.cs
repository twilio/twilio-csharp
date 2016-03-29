using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.IpMessaging.V1.Service;
using Twilio.Deleters.IpMessaging.V1.Service;
using Twilio.Exceptions;
using Twilio.Fetchers.IpMessaging.V1.Service;
using Twilio.Http;
using Twilio.Readers.IpMessaging.V1.Service;
using Twilio.Resources;
using Twilio.Updaters.IpMessaging.V1.Service;

namespace Twilio.Resources.IpMessaging.V1.Service {

    public class RoleResource : SidResource {
        public sealed class RoleType {
            public const string CHANNEL="channel";
            public const string DEPLOYMENT="deployment";
        
            private readonly string value;
            
            public RoleType(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator RoleType(string value) {
                return new RoleType(value);
            }
            
            public static implicit operator string(RoleType value) {
                return value.ToString();
            }
        }
    
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return RoleFetcher capable of executing the fetch
         */
        public static RoleFetcher fetch(string serviceSid, string sid) {
            return new RoleFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return RoleDeleter capable of executing the delete
         */
        public static RoleDeleter delete(string serviceSid, string sid) {
            return new RoleDeleter(serviceSid, sid);
        }
    
        /**
         * create
         * 
         * @param serviceSid The service_sid
         * @param friendlyName The friendly_name
         * @param type The type
         * @param permission The permission
         * @return RoleCreator capable of executing the create
         */
        public static RoleCreator create(string serviceSid, string friendlyName, RoleResource.RoleType type, List<string> permission) {
            return new RoleCreator(serviceSid, friendlyName, type, permission);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return RoleReader capable of executing the read
         */
        public static RoleReader read(string serviceSid) {
            return new RoleReader(serviceSid);
        }
    
        /**
         * update
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @param permission The permission
         * @return RoleUpdater capable of executing the update
         */
        public static RoleUpdater update(string serviceSid, string sid, string friendlyName, List<string> permission) {
            return new RoleUpdater(serviceSid, sid, friendlyName, permission);
        }
    
        /**
         * Converts a JSON string into a RoleResource object
         * 
         * @param json Raw JSON string
         * @return RoleResource object represented by the provided JSON
         */
        public static RoleResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RoleResource>(json);
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
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("type")]
        private readonly RoleResource.RoleType type;
        [JsonProperty("permissions")]
        private readonly List<string> permissions;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        private RoleResource([JsonProperty("sid")]
                             string sid, 
                             [JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("service_sid")]
                             string serviceSid, 
                             [JsonProperty("friendly_name")]
                             string friendlyName, 
                             [JsonProperty("type")]
                             RoleResource.RoleType type, 
                             [JsonProperty("permissions")]
                             List<string> permissions, 
                             [JsonProperty("date_created")]
                             string dateCreated, 
                             [JsonProperty("date_updated")]
                             string dateUpdated, 
                             [JsonProperty("url")]
                             Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.permissions = permissions;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The type
         */
        public RoleResource.RoleType GetRoleType() {
            return this.type;
        }
    
        /**
         * @return The permissions
         */
        public List<string> GetPermissions() {
            return this.permissions;
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
    }
}