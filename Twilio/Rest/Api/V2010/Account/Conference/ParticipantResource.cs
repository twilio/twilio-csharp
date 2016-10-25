using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantResource : Resource 
    {
        /// <summary>
        /// Fetch an instance of a participant
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ParticipantFetcher capable of executing the fetch </returns> 
        public static ParticipantFetcher Fetcher(string conferenceSid, string callSid, string accountSid=null)
        {
            return new ParticipantFetcher(conferenceSid, callSid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Update the properties of this participant
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="muted"> Indicates if the participant should be muted </param>
        /// <param name="hold"> The hold </param>
        /// <param name="holdUrl"> The hold_url </param>
        /// <param name="holdMethod"> The hold_method </param>
        /// <returns> ParticipantUpdater capable of executing the update </returns> 
        public static ParticipantUpdater Updater(string conferenceSid, string callSid, string accountSid=null, bool? muted=null, bool? hold=null, Uri holdUrl=null, Twilio.Http.HttpMethod holdMethod=null)
        {
            return new ParticipantUpdater(conferenceSid, callSid, accountSid:accountSid, muted:muted, hold:hold, holdUrl:holdUrl, holdMethod:holdMethod);
        }
    
        /// <summary>
        /// Kick a participant from a given conference
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ParticipantDeleter capable of executing the delete </returns> 
        public static ParticipantDeleter Deleter(string conferenceSid, string callSid, string accountSid=null)
        {
            return new ParticipantDeleter(conferenceSid, callSid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieve a list of participants belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="muted"> Filter by muted participants </param>
        /// <param name="hold"> The hold </param>
        /// <returns> ParticipantReader capable of executing the read </returns> 
        public static ParticipantReader Reader(string conferenceSid, string accountSid=null, bool? muted=null, bool? hold=null)
        {
            return new ParticipantReader(conferenceSid, accountSid:accountSid, muted:muted, hold:hold);
        }
    
        /// <summary>
        /// Converts a JSON string into a ParticipantResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ParticipantResource object represented by the provided JSON </returns> 
        public static ParticipantResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
            }
            catch (JsonException e)
            {
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
    
        public ParticipantResource()
        {
        
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
                                    string uri)
                                    {
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