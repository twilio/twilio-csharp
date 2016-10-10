using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1 {

    public class CredentialResource : SidResource {
        public sealed class PushService : IStringEnum {
            public const string GCM="gcm";
            public const string APN="apn";
        
            private string value;
            
            public PushService() { }
            
            public PushService(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator PushService(string value) {
                return new PushService(value);
            }
            
            public static implicit operator string(PushService value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * read
         * 
         * @return CredentialReader capable of executing the read
         */
        public static CredentialReader Reader() {
            return new CredentialReader();
        }
    
        /**
         * create
         * 
         * @param type The type
         * @return CredentialCreator capable of executing the create
         */
        public static CredentialCreator Creator(CredentialResource.PushService type) {
            return new CredentialCreator(type);
        }
    
        /**
         * fetch
         * 
         * @param sid The sid
         * @return CredentialFetcher capable of executing the fetch
         */
        public static CredentialFetcher Fetcher(string sid) {
            return new CredentialFetcher(sid);
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return CredentialUpdater capable of executing the update
         */
        public static CredentialUpdater Updater(string sid) {
            return new CredentialUpdater(sid);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return CredentialDeleter capable of executing the delete
         */
        public static CredentialDeleter Deleter(string sid) {
            return new CredentialDeleter(sid);
        }
    
        /**
         * Converts a JSON string into a CredentialResource object
         * 
         * @param json Raw JSON string
         * @return CredentialResource object represented by the provided JSON
         */
        public static CredentialResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CredentialResource>(json);
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
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly CredentialResource.PushService type;
        [JsonProperty("sandbox")]
        private readonly string sandbox;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public CredentialResource() {
        
        }
    
        private CredentialResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("type")]
                                   CredentialResource.PushService type, 
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The type
         */
        public CredentialResource.PushService GetCredentialType() {
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