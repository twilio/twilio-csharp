using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class ConferenceResource : SidResource {
        public sealed class Status : IStringEnum {
            public const string INIT="init";
            public const string IN_PROGRESS="in-progress";
            public const string COMPLETED="completed";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * Fetch an instance of a conference
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique conference Sid
         * @return ConferenceFetcher capable of executing the fetch
         */
        public static ConferenceFetcher Fetch(string accountSid, string sid) {
            return new ConferenceFetcher(accountSid, sid);
        }
    
        /**
         * Retrieve a list of conferences belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ConferenceReader capable of executing the read
         */
        public static ConferenceReader Read(string accountSid) {
            return new ConferenceReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a ConferenceResource object
         * 
         * @param json Raw JSON string
         * @return ConferenceResource object represented by the provided JSON
         */
        public static ConferenceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ConferenceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly ConferenceResource.Status status;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public ConferenceResource() {
        
        }
    
        private ConferenceResource([JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("api_version")]
                                   string apiVersion, 
                                   [JsonProperty("friendly_name")]
                                   string friendlyName, 
                                   [JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("status")]
                                   ConferenceResource.Status status, 
                                   [JsonProperty("uri")]
                                   string uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.apiVersion = apiVersion;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.status = status;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return A human readable description of this resource
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return A string that uniquely identifies this conference
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of the conference
         */
        public ConferenceResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}