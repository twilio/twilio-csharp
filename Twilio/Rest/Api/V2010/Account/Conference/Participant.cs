using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Conference;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Conference;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Conference;
using Twilio.Updaters.Api.V2010.Account.Conference;

namespace Twilio.Rest.Api.V2010.Account.Conference {

    public class Participant : SidResource {
        /**
         * Fetch an instance of a participant
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantFetcher capable of executing the fetch
         */
        public static ParticipantFetcher Fetch(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantFetcher(accountSid, conferenceSid, callSid);
        }
    
        /**
         * Create a ParticipantFetcher to execute fetch.
         * 
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantFetcher capable of executing the fetch
         */
        public static ParticipantFetcher Fetch(string conferenceSid, 
                                               string callSid) {
            return new ParticipantFetcher(conferenceSid, callSid);
        }
    
        /**
         * Update the properties of this participant
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantUpdater capable of executing the update
         */
        public static ParticipantUpdater Update(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantUpdater(accountSid, conferenceSid, callSid);
        }
    
        /**
         * Create a ParticipantUpdater to execute update.
         * 
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantUpdater capable of executing the update
         */
        public static ParticipantUpdater Update(string conferenceSid, 
                                                string callSid) {
            return new ParticipantUpdater(conferenceSid, callSid);
        }
    
        /**
         * Kick a participant from a given conference
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantDeleter capable of executing the delete
         */
        public static ParticipantDeleter Delete(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantDeleter(accountSid, conferenceSid, callSid);
        }
    
        /**
         * Create a ParticipantDeleter to execute delete.
         * 
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantDeleter capable of executing the delete
         */
        public static ParticipantDeleter Delete(string conferenceSid, 
                                                string callSid) {
            return new ParticipantDeleter(conferenceSid, callSid);
        }
    
        /**
         * Retrieve a list of participants belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @return ParticipantReader capable of executing the read
         */
        public static ParticipantReader Read(string accountSid, string conferenceSid) {
            return new ParticipantReader(accountSid, conferenceSid);
        }
    
        /**
         * Create a ParticipantReader to execute read.
         * 
         * @param conferenceSid The string that uniquely identifies this conference
         * @return ParticipantReader capable of executing the read
         */
        public static ParticipantReader Read(string conferenceSid) {
            return new ParticipantReader(conferenceSid);
        }
    
        /**
         * Converts a JSON string into a Participant object
         * 
         * @param json Raw JSON string
         * @return Participant object represented by the provided JSON
         */
        public static Participant FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Participant>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("call_sid")]
        private readonly string callSid;
        [JsonProperty("conference_sid")]
        private readonly string conferenceSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("end_conference_on_exit")]
        private readonly bool? endConferenceOnExit;
        [JsonProperty("muted")]
        private readonly bool? muted;
        [JsonProperty("hold")]
        private readonly bool? hold;
        [JsonProperty("start_conference_on_enter")]
        private readonly bool? startConferenceOnEnter;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public Participant() {
        
        }
    
        private Participant([JsonProperty("account_sid")]
                            string accountSid, 
                            [JsonProperty("call_sid")]
                            string callSid, 
                            [JsonProperty("conference_sid")]
                            string conferenceSid, 
                            [JsonProperty("date_created")]
                            string dateCreated, 
                            [JsonProperty("date_updated")]
                            string dateUpdated, 
                            [JsonProperty("end_conference_on_exit")]
                            bool? endConferenceOnExit, 
                            [JsonProperty("muted")]
                            bool? muted, 
                            [JsonProperty("hold")]
                            bool? hold, 
                            [JsonProperty("start_conference_on_enter")]
                            bool? startConferenceOnEnter, 
                            [JsonProperty("uri")]
                            string uri) {
            this.accountSid = accountSid;
            this.callSid = callSid;
            this.conferenceSid = conferenceSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.endConferenceOnExit = endConferenceOnExit;
            this.muted = muted;
            this.hold = hold;
            this.startConferenceOnEnter = startConferenceOnEnter;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this call
         */
        public override string GetSid() {
            return this.GetCallSid();
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return A string that uniquely identifies this call
         */
        public string GetCallSid() {
            return this.callSid;
        }
    
        /**
         * @return A string that uniquely identifies this conference
         */
        public string GetConferenceSid() {
            return this.conferenceSid;
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
         * @return Indicates if the endConferenceOnExit was set
         */
        public bool? GetEndConferenceOnExit() {
            return this.endConferenceOnExit;
        }
    
        /**
         * @return Indicates if the participant is muted
         */
        public bool? GetMuted() {
            return this.muted;
        }
    
        /**
         * @return The hold
         */
        public bool? GetHold() {
            return this.hold;
        }
    
        /**
         * @return Indicates if the startConferenceOnEnter attribute was set
         */
        public bool? GetStartConferenceOnEnter() {
            return this.startConferenceOnEnter;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}