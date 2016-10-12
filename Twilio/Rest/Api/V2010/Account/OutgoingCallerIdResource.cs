using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class OutgoingCallerIdResource : SidResource {
        /// <summary>
        /// Fetch an outgoing-caller-id belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdFetcher capable of executing the fetch </returns> 
        public static OutgoingCallerIdFetcher Fetcher(string accountSid, string sid) {
            return new OutgoingCallerIdFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a OutgoingCallerIdFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdFetcher capable of executing the fetch </returns> 
        public static OutgoingCallerIdFetcher Fetcher(string sid) {
            return new OutgoingCallerIdFetcher(sid);
        }
    
        /// <summary>
        /// Updates the caller-id
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Update by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdUpdater capable of executing the update </returns> 
        public static OutgoingCallerIdUpdater Updater(string accountSid, string sid) {
            return new OutgoingCallerIdUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a OutgoingCallerIdUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> Update by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdUpdater capable of executing the update </returns> 
        public static OutgoingCallerIdUpdater Updater(string sid) {
            return new OutgoingCallerIdUpdater(sid);
        }
    
        /// <summary>
        /// Delete the caller-id specified from the account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdDeleter capable of executing the delete </returns> 
        public static OutgoingCallerIdDeleter Deleter(string accountSid, string sid) {
            return new OutgoingCallerIdDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a OutgoingCallerIdDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique outgoing-caller-id Sid </param>
        /// <returns> OutgoingCallerIdDeleter capable of executing the delete </returns> 
        public static OutgoingCallerIdDeleter Deleter(string sid) {
            return new OutgoingCallerIdDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of outgoing-caller-ids belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> OutgoingCallerIdReader capable of executing the read </returns> 
        public static OutgoingCallerIdReader Reader(string accountSid) {
            return new OutgoingCallerIdReader(accountSid);
        }
    
        /// <summary>
        /// Create a OutgoingCallerIdReader to execute read.
        /// </summary>
        ///
        /// <returns> OutgoingCallerIdReader capable of executing the read </returns> 
        public static OutgoingCallerIdReader Reader() {
            return new OutgoingCallerIdReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a OutgoingCallerIdResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OutgoingCallerIdResource object represented by the provided JSON </returns> 
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
    
        /// <returns> A string that uniquely identifies this outgoing-caller-ids </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A human readable description for this resource </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The incoming phone number </returns> 
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}