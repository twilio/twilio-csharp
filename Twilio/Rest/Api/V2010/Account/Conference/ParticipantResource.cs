using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Conference {

    public class ParticipantResource : Resource {
        /// <summary>
        /// Fetch an instance of a participant
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantFetcher capable of executing the fetch </returns> 
        public static ParticipantFetcher Fetcher(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantFetcher(accountSid, conferenceSid, callSid);
        }
    
        /// <summary>
        /// Create a ParticipantFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantFetcher capable of executing the fetch </returns> 
        public static ParticipantFetcher Fetcher(string conferenceSid, 
                                                 string callSid) {
            return new ParticipantFetcher(conferenceSid, callSid);
        }
    
        /// <summary>
        /// Update the properties of this participant
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantUpdater capable of executing the update </returns> 
        public static ParticipantUpdater Updater(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantUpdater(accountSid, conferenceSid, callSid);
        }
    
        /// <summary>
        /// Create a ParticipantUpdater to execute update.
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantUpdater capable of executing the update </returns> 
        public static ParticipantUpdater Updater(string conferenceSid, 
                                                 string callSid) {
            return new ParticipantUpdater(conferenceSid, callSid);
        }
    
        /// <summary>
        /// Kick a participant from a given conference
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantDeleter capable of executing the delete </returns> 
        public static ParticipantDeleter Deleter(string accountSid, string conferenceSid, string callSid) {
            return new ParticipantDeleter(accountSid, conferenceSid, callSid);
        }
    
        /// <summary>
        /// Create a ParticipantDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantDeleter capable of executing the delete </returns> 
        public static ParticipantDeleter Deleter(string conferenceSid, 
                                                 string callSid) {
            return new ParticipantDeleter(conferenceSid, callSid);
        }
    
        /// <summary>
        /// Retrieve a list of participants belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <returns> ParticipantReader capable of executing the read </returns> 
        public static ParticipantReader Reader(string accountSid, string conferenceSid) {
            return new ParticipantReader(accountSid, conferenceSid);
        }
    
        /// <summary>
        /// Create a ParticipantReader to execute read.
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <returns> ParticipantReader capable of executing the read </returns> 
        public static ParticipantReader Reader(string conferenceSid) {
            return new ParticipantReader(conferenceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ParticipantResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ParticipantResource object represented by the provided JSON </returns> 
        public static ParticipantResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("call_sid")]
        public string callSid { get; }
        [JsonProperty("conference_sid")]
        public string conferenceSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("end_conference_on_exit")]
        public bool? endConferenceOnExit { get; }
        [JsonProperty("muted")]
        public bool? muted { get; }
        [JsonProperty("hold")]
        public bool? hold { get; }
        [JsonProperty("start_conference_on_enter")]
        public bool? startConferenceOnEnter { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public ParticipantResource() {
        
        }
    
        private ParticipantResource([JsonProperty("account_sid")]
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
    }
}