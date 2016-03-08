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
using java.util.List;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1.Service {

    public class Role : SidResource {
        public enum RoleType {
            CHANNEL="channel",
            DEPLOYMENT="deployment"
        };
    
        /**
         * fetch
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return RoleFetcher capable of executing the fetch
         */
        public static RoleFetcher fetch(String serviceSid, String sid) {
            return new RoleFetcher(serviceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @return RoleDeleter capable of executing the delete
         */
        public static RoleDeleter delete(String serviceSid, String sid) {
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
        public static RoleCreator create(String serviceSid, String friendlyName, Role.RoleType type, List<String> permission) {
            return new RoleCreator(serviceSid, friendlyName, type, permission);
        }
    
        /**
         * read
         * 
         * @param serviceSid The service_sid
         * @return RoleReader capable of executing the read
         */
        public static RoleReader read(String serviceSid) {
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
        public static RoleUpdater update(String serviceSid, String sid, String friendlyName, List<String> permission) {
            return new RoleUpdater(serviceSid, sid, friendlyName, permission);
        }
    
        /**
         * Converts a JSON string into a Role object
         * 
         * @param json Raw JSON string
         * @return Role object represented by the provided JSON
         */
        public static Role fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Role>(json);
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
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("type")]
        private readonly Role.RoleType type;
        [JsonProperty("permissions")]
        private readonly List<String> permissions;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Role([JsonProperty("sid")]
                     String sid, 
                     [JsonProperty("account_sid")]
                     String accountSid, 
                     [JsonProperty("service_sid")]
                     String serviceSid, 
                     [JsonProperty("friendly_name")]
                     String friendlyName, 
                     [JsonProperty("type")]
                     Role.RoleType type, 
                     [JsonProperty("permissions")]
                     List<String> permissions, 
                     [JsonProperty("date_created")]
                     String dateCreated, 
                     [JsonProperty("date_updated")]
                     String dateUpdated, 
                     [JsonProperty("url")]
                     URI url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.permissions = permissions;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
         * @return The service_sid
         */
        public String GetServiceSid() {
            return this.serviceSid;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The type
         */
        public Role.RoleType GetType() {
            return this.type;
        }
    
        /**
         * @return The permissions
         */
        public List<String> GetPermissions() {
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
        public URI GetUrl() {
            return this.url;
        }
    }
}