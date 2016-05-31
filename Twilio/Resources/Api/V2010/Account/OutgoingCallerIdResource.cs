using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

    public class OutgoingCallerIdResource : SidResource {
        /**
         * Fetch an outgoing-caller-id belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique outgoing-caller-id Sid
         * @return OutgoingCallerIdFetcher capable of executing the fetch
         */
        public static OutgoingCallerIdFetcher Fetch(string accountSid, string sid) {
            return new OutgoingCallerIdFetcher(accountSid, sid);
        }
    
        /**
         * Updates the caller-id
         * 
         * @param accountSid The account_sid
         * @param sid Update by unique outgoing-caller-id Sid
         * @return OutgoingCallerIdUpdater capable of executing the update
         */
        public static OutgoingCallerIdUpdater Update(string accountSid, string sid) {
            return new OutgoingCallerIdUpdater(accountSid, sid);
        }
    
        /**
         * Delete the caller-id specified from the account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique outgoing-caller-id Sid
         * @return OutgoingCallerIdDeleter capable of executing the delete
         */
        public static OutgoingCallerIdDeleter Delete(string accountSid, string sid) {
            return new OutgoingCallerIdDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of outgoing-caller-ids belonging to the account used to make
         * the request
         * 
         * @param accountSid The account_sid
         * @return OutgoingCallerIdReader capable of executing the read
         */
        public static OutgoingCallerIdReader Read(string accountSid) {
            return new OutgoingCallerIdReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a OutgoingCallerIdResource object
         * 
         * @param json Raw JSON string
         * @return OutgoingCallerIdResource object represented by the provided JSON
         */
        public static OutgoingCallerIdResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<OutgoingCallerIdResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public OutgoingCallerIdResource() {
        
        }
    
        private OutgoingCallerIdResource([JsonProperty("sid")]
                                         string sid, 
                                         [JsonProperty("date_created")]
                                         string dateCreated, 
                                         [JsonProperty("date_updated")]
                                         string dateUpdated, 
                                         [JsonProperty("friendly_name")]
                                         string friendlyName, 
                                         [JsonProperty("account_sid")]
                                         string accountSid, 
                                         [JsonProperty("phone_number")]
                                         Twilio.Types.PhoneNumber phoneNumber, 
                                         [JsonProperty("uri")]
                                         string uri) {
            this.sid = sid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this outgoing-caller-ids
         */
        public override string GetSid() {
            return this.sid;
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
         * @return A human readable description for this resource
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The incoming phone number
         */
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}