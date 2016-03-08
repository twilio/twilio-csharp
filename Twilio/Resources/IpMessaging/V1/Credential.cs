using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Ipmessaging.V1;
using Twilio.Deleters.Ipmessaging.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.IpMessaging.V1 {

    public class Credential : SidResource {
        public enum PushService {
            GCM="gcm",
            APN="apn"
        };
    
        /**
         * read
         * 
         * @return CredentialReader capable of executing the read
         */
        public static CredentialReader read() {
            return new CredentialReader();
        }
    
        /**
         * create
         * 
         * @param friendlyName The friendly_name
         * @param type The type
         * @return CredentialCreator capable of executing the create
         */
        public static CredentialCreator create(String friendlyName, Credential.PushService type) {
            return new CredentialCreator(friendlyName, type);
        }
    
        /**
         * fetch
         * 
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher fetch(String sid) {
            return new CredentialFetcher(sid);
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @param type The type
         * @return CredentialUpdater capable of executing the update
         */
        public static CredentialUpdater update(String sid, String friendlyName, Credential.PushService type) {
            return new CredentialUpdater(sid, friendlyName, type);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter delete(String sid) {
            return new CredentialDeleter(sid);
        }
    
        /**
         * Converts a JSON string into a Credential object
         * 
         * @param json Raw JSON string
         * @return Credential object represented by the provided JSON
         */
        public static Credential fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Credential>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("type")]
        private readonly Credential.PushService type;
        [JsonProperty("sandbox")]
        private readonly String sandbox;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Credential([JsonProperty("sid")]
                           String sid, 
                           [JsonProperty("account_sid")]
                           String accountSid, 
                           [JsonProperty("friendly_name")]
                           String friendlyName, 
                           [JsonProperty("type")]
                           Credential.PushService type, 
                           [JsonProperty("sandbox")]
                           String sandbox, 
                           [JsonProperty("date_created")]
                           String dateCreated, 
                           [JsonProperty("date_updated")]
                           String dateUpdated, 
                           [JsonProperty("url")]
                           URI url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.sandbox = sandbox;
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
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The type
         */
        public Credential.PushService GetType() {
            return this.type;
        }
    
        /**
         * @return The sandbox
         */
        public String GetSandbox() {
            return this.sandbox;
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