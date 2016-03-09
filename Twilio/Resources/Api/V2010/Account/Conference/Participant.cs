using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Conference;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Conference;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Conference;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Conference;

namespace Twilio.Resources.Api.V2010.Account.Conference {

    public class Participant : SidResource {
        /**
         * Fetch an instance of a participant
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantFetcher capable of executing the fetch
         */
        public static ParticipantFetcher fetch(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantFetcher(accountSid, conferenceSid, callSid);
        }
    
        /**
         * Update the properties of this participant
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @param muted Indicates if the participant should be muted
         * @return ParticipantUpdater capable of executing the update
         */
        public static ParticipantUpdater update(string accountSid, string conferenceSid, string callSid, bool muted) {
            return new ParticipantUpdater(accountSid, conferenceSid, callSid, muted);
        }
    
        /**
         * Kick a participant from a given conference
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         * @return ParticipantDeleter capable of executing the delete
         */
        public static ParticipantDeleter delete(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantDeleter(accountSid, conferenceSid, callSid);
        }
    
        /**
         * Retrieve a list of participants belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @return ParticipantReader capable of executing the read
         */
        public static ParticipantReader read(string accountSid, string conferenceSid) {
            return new ParticipantReader(accountSid, conferenceSid);
        }
    
        /**
         * Converts a JSON string into a Participant object
         * 
         * @param json Raw JSON string
         * @return Participant object represented by the provided JSON
         */
        public static Participant fromJson(string json) {
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
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("end_conference_on_exit")]
        private readonly bool endConferenceOnExit;
        [JsonProperty("muted")]
        private readonly bool muted;
        [JsonProperty("start_conference_on_enter")]
        private readonly bool startConferenceOnEnter;
        [JsonProperty("uri")]
        private readonly string uri;
    
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
                            bool endConferenceOnExit, 
                            [JsonProperty("muted")]
                            bool muted, 
                            [JsonProperty("start_conference_on_enter")]
                            bool startConferenceOnEnter, 
                            [JsonProperty("uri")]
                            string uri) {
            this.accountSid = accountSid;
            this.callSid = callSid;
            this.conferenceSid = conferenceSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.endConferenceOnExit = endConferenceOnExit;
            this.muted = muted;
            this.startConferenceOnEnter = startConferenceOnEnter;
            this.uri = uri;
        }
    
        /**
         * @return A string that uniquely identifies this call
         */
        public string getSid() {
            return this.getCallSid();
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
         * @return Indicates if the endConferenceOnExit was set
         */
        public bool GetEndConferenceOnExit() {
            return this.endConferenceOnExit;
        }
    
        /**
         * @return Indicates if the participant is muted
         */
        public bool GetMuted() {
            return this.muted;
        }
    
        /**
         * @return Indicates if the startConferenceOnEnter attribute was set
         */
        public bool GetStartConferenceOnEnter() {
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