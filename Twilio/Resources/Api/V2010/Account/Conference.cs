using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Conference : SidResource {
        public enum Status {
            INIT="init",
            IN_PROGRESS="in-progress",
            COMPLETED="completed"
        };
    
        /**
         * Fetch an instance of a conference
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique conference Sid
         * @return ConferenceFetcher capable of executing the fetch
         */
        public static ConferenceFetcher fetch(String accountSid, String sid) {
            return new ConferenceFetcher(accountSid, sid);
        }
    
        /**
         * Retrieve a list of conferences belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return ConferenceReader capable of executing the read
         */
        public static ConferenceReader read(String accountSid) {
            return new ConferenceReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Conference object
         * 
         * @param json Raw JSON string
         * @return Conference object represented by the provided JSON
         */
        public static Conference fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Conference>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly Conference.Status status;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Conference([JsonProperty("account_sid")]
                           String accountSid, 
                           [JsonProperty("date_created")]
                           String dateCreated, 
                           [JsonProperty("date_updated")]
                           String dateUpdated, 
                           [JsonProperty("api_version")]
                           String apiVersion, 
                           [JsonProperty("friendly_name")]
                           String friendlyName, 
                           [JsonProperty("sid")]
                           String sid, 
                           [JsonProperty("status")]
                           Conference.Status status, 
                           [JsonProperty("uri")]
                           String uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.apiVersion = apiVersion;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.status = status;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return A human readable description of this resource
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return A string that uniquely identifies this conference
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of the conference
         */
        public Conference.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}