using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Ipmessaging.V1;
using Twilio.Deleters.Ipmessaging.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Ipmessaging.V1;
using Twilio.Http;
using Twilio.Readers.Ipmessaging.V1;
using Twilio.Resources;
using Twilio.Updaters.Ipmessaging.V1;

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
        public static CredentialCreator create(string friendlyName, Credential.PushService type) {
            return new CredentialCreator(friendlyName, type);
        }
    
        /**
         * fetch
         * 
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher fetch(string sid) {
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
        public static CredentialUpdater update(string sid, string friendlyName, Credential.PushService type) {
            return new CredentialUpdater(sid, friendlyName, type);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter delete(string sid) {
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
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("type")]
        private readonly Credential.PushService type;
        [JsonProperty("sandbox")]
        private readonly string sandbox;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        private Credential([JsonProperty("sid")]
                           string sid, 
                           [JsonProperty("account_sid")]
                           string accountSid, 
                           [JsonProperty("friendly_name")]
                           string friendlyName, 
                           [JsonProperty("type")]
                           Credential.PushService type, 
                           [JsonProperty("sandbox")]
                           string sandbox, 
                           [JsonProperty("date_created")]
                           string dateCreated, 
                           [JsonProperty("date_updated")]
                           string dateUpdated, 
                           [JsonProperty("url")]
                           Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.sandbox = sandbox;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The type
         */
        public Credential.PushService GetCredentialType() {
            return this.type;
        }
    
        /**
         * @return The sandbox
         */
        public string GetSandbox() {
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
        public Uri GetUrl() {
            return this.url;
        }
    }
}