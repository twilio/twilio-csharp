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
        public sealed class ParticipantStatus : IStringEnum 
        {
            public const string Queued = "queued";
            public const string Connecting = "connecting";
            public const string Ringing = "ringing";
            public const string Connected = "connected";
            public const string Complete = "complete";
            public const string Failed = "failed";
        
            private string _value;
            
            public ParticipantStatus() {}
            
            public ParticipantStatus(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator ParticipantStatus(string value)
            {
                return new ParticipantStatus(value);
            }
            
            public static implicit operator string(ParticipantStatus value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class ParticipantBeep : IStringEnum 
        {
            public const string True = "true";
            public const string False = "false";
            public const string Onenter = "onEnter";
            public const string Onexit = "onExit";
        
            private string _value;
            
            public ParticipantBeep() {}
            
            public ParticipantBeep(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator ParticipantBeep(string value)
            {
                return new ParticipantBeep(value);
            }
            
            public static implicit operator string(ParticipantBeep value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class ParticipantConferenceRecord : IStringEnum 
        {
            public const string DoNotRecord = "do-not-record";
            public const string RecordFromStart = "record-from-start";
        
            private string _value;
            
            public ParticipantConferenceRecord() {}
            
            public ParticipantConferenceRecord(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator ParticipantConferenceRecord(string value)
            {
                return new ParticipantConferenceRecord(value);
            }
            
            public static implicit operator string(ParticipantConferenceRecord value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a participant
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantFetcher capable of executing the fetch </returns> 
        public static ParticipantFetcher Fetcher(string conferenceSid, string callSid)
        {
            return new ParticipantFetcher(conferenceSid, callSid);
        }
    
        /// <summary>
        /// Update the properties of this participant
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantUpdater capable of executing the update </returns> 
        public static ParticipantUpdater Updater(string conferenceSid, string callSid)
        {
            return new ParticipantUpdater(conferenceSid, callSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="conferenceSid"> The conference_sid </param>
        /// <param name="from"> The from </param>
        /// <param name="to"> The to </param>
        /// <returns> ParticipantCreator capable of executing the create </returns> 
        public static ParticipantCreator Creator(string conferenceSid, Twilio.Types.PhoneNumber from, Twilio.Types.PhoneNumber to)
        {
            return new ParticipantCreator(conferenceSid, from, to);
        }
    
        /// <summary>
        /// Kick a participant from a given conference
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        /// <returns> ParticipantDeleter capable of executing the delete </returns> 
        public static ParticipantDeleter Deleter(string conferenceSid, string callSid)
        {
            return new ParticipantDeleter(conferenceSid, callSid);
        }
    
        /// <summary>
        /// Retrieve a list of participants belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <returns> ParticipantReader capable of executing the read </returns> 
        public static ParticipantReader Reader(string conferenceSid)
        {
            return new ParticipantReader(conferenceSid);
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
        public string accountSid { get; set; }
        [JsonProperty("call_sid")]
        public string callSid { get; set; }
        [JsonProperty("conference_sid")]
        public string conferenceSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("end_conference_on_exit")]
        public bool? endConferenceOnExit { get; set; }
        [JsonProperty("muted")]
        public bool? muted { get; set; }
        [JsonProperty("hold")]
        public bool? hold { get; set; }
        [JsonProperty("start_conference_on_enter")]
        public bool? startConferenceOnEnter { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ParticipantResource.ParticipantStatus status { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
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
                                    [JsonProperty("status")]
                                    ParticipantResource.ParticipantStatus status, 
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
            this.status = status;
            this.uri = uri;
        }
    }
}