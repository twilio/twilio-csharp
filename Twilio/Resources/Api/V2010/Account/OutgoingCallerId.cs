using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class OutgoingCallerId : SidResource {
        /**
         * Fetch an outgoing-caller-id belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique outgoing-caller-id Sid
         * @return OutgoingCallerIdFetcher capable of executing the fetch
         */
        public static OutgoingCallerIdFetcher fetch(String accountSid, String sid) {
            return new OutgoingCallerIdFetcher(accountSid, sid);
        }
    
        /**
         * Updates the caller-id
         * 
         * @param accountSid The account_sid
         * @param sid Update by unique outgoing-caller-id Sid
         * @return OutgoingCallerIdUpdater capable of executing the update
         */
        public static OutgoingCallerIdUpdater update(String accountSid, String sid) {
            return new OutgoingCallerIdUpdater(accountSid, sid);
        }
    
        /**
         * Delete the caller-id specified from the account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique outgoing-caller-id Sid
         * @return OutgoingCallerIdDeleter capable of executing the delete
         */
        public static OutgoingCallerIdDeleter delete(String accountSid, String sid) {
            return new OutgoingCallerIdDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of outgoing-caller-ids belonging to the account used to make
         * the request
         * 
         * @param accountSid The account_sid
         * @return OutgoingCallerIdReader capable of executing the read
         */
        public static OutgoingCallerIdReader read(String accountSid) {
            return new OutgoingCallerIdReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a OutgoingCallerId object
         * 
         * @param json Raw JSON string
         * @return OutgoingCallerId object represented by the provided JSON
         */
        public static OutgoingCallerId fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<OutgoingCallerId>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("phone_number")]
        private readonly com.twilio.types.PhoneNumber phoneNumber;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private OutgoingCallerId([JsonProperty("sid")]
                                 String sid, 
                                 [JsonProperty("date_created")]
                                 String dateCreated, 
                                 [JsonProperty("date_updated")]
                                 String dateUpdated, 
                                 [JsonProperty("friendly_name")]
                                 String friendlyName, 
                                 [JsonProperty("account_sid")]
                                 String accountSid, 
                                 [JsonProperty("phone_number")]
                                 com.twilio.types.PhoneNumber phoneNumber, 
                                 [JsonProperty("uri")]
                                 String uri) {
            this.sid = sid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this outgoing-caller-ids
         */
        public String GetSid() {
            return this.sid;
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
         * @return A human readable description for this resource
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The incoming phone number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}