using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class FetchParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string ConferenceSid { get; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string CallSid { get; }
    
        /// <summary>
        /// Construct a new FetchParticipantOptions
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public FetchParticipantOptions(string conferenceSid, string callSid)
        {
            ConferenceSid = conferenceSid;
            CallSid = callSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class UpdateParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string ConferenceSid { get; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string CallSid { get; }
        /// <summary>
        /// Indicates if the participant should be muted
        /// </summary>
        public bool? Muted { get; set; }
        /// <summary>
        /// The hold
        /// </summary>
        public bool? Hold { get; set; }
        /// <summary>
        /// The hold_url
        /// </summary>
        public Uri HoldUrl { get; set; }
        /// <summary>
        /// The hold_method
        /// </summary>
        public Twilio.Http.HttpMethod HoldMethod { get; set; }
    
        /// <summary>
        /// Construct a new UpdateParticipantOptions
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public UpdateParticipantOptions(string conferenceSid, string callSid)
        {
            ConferenceSid = conferenceSid;
            CallSid = callSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString()));
            }
            
            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.Value.ToString()));
            }
            
            if (HoldUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("HoldUrl", HoldUrl.ToString()));
            }
            
            if (HoldMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("HoldMethod", HoldMethod.ToString()));
            }
            
            return p;
        }
    }

    public class CreateParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The conference_sid
        /// </summary>
        public string ConferenceSid { get; }
        /// <summary>
        /// The from
        /// </summary>
        public Types.PhoneNumber From { get; }
        /// <summary>
        /// The to
        /// </summary>
        public Types.PhoneNumber To { get; }
        /// <summary>
        /// The status_callback
        /// </summary>
        public Uri StatusCallback { get; set; }
        /// <summary>
        /// The status_callback_method
        /// </summary>
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        /// <summary>
        /// The status_callback_event
        /// </summary>
        public List<string> StatusCallbackEvent { get; set; }
        /// <summary>
        /// The timeout
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// The record
        /// </summary>
        public bool? Record { get; set; }
        /// <summary>
        /// The muted
        /// </summary>
        public bool? Muted { get; set; }
        /// <summary>
        /// The beep
        /// </summary>
        public ParticipantResource.BeepEnum Beep { get; set; }
        /// <summary>
        /// The start_conference_on_enter
        /// </summary>
        public bool? StartConferenceOnEnter { get; set; }
        /// <summary>
        /// The end_conference_on_exit
        /// </summary>
        public bool? EndConferenceOnExit { get; set; }
        /// <summary>
        /// The wait_url
        /// </summary>
        public Uri WaitUrl { get; set; }
        /// <summary>
        /// The wait_method
        /// </summary>
        public Twilio.Http.HttpMethod WaitMethod { get; set; }
        /// <summary>
        /// The early_media
        /// </summary>
        public bool? EarlyMedia { get; set; }
        /// <summary>
        /// The max_participants
        /// </summary>
        public int? MaxParticipants { get; set; }
        /// <summary>
        /// The conference_record
        /// </summary>
        public ParticipantResource.ConferenceRecordEnum ConferenceRecord { get; set; }
        /// <summary>
        /// The conference_trim
        /// </summary>
        public string ConferenceTrim { get; set; }
        /// <summary>
        /// The conference_status_callback
        /// </summary>
        public Uri ConferenceStatusCallback { get; set; }
        /// <summary>
        /// The conference_status_callback_method
        /// </summary>
        public Twilio.Http.HttpMethod ConferenceStatusCallbackMethod { get; set; }
        /// <summary>
        /// The conference_status_callback_event
        /// </summary>
        public List<string> ConferenceStatusCallbackEvent { get; set; }
    
        /// <summary>
        /// Construct a new CreateParticipantOptions
        /// </summary>
        ///
        /// <param name="conferenceSid"> The conference_sid </param>
        /// <param name="from"> The from </param>
        /// <param name="to"> The to </param>
        public CreateParticipantOptions(string conferenceSid, Types.PhoneNumber from, Types.PhoneNumber to)
        {
            ConferenceSid = conferenceSid;
            From = from;
            To = to;
            StatusCallbackEvent = new List<string>();
            ConferenceStatusCallbackEvent = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            
            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }
            
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            
            if (StatusCallbackEvent != null)
            {
                p.AddRange(StatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("StatusCallbackEvent", prop)));
            }
            
            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.Value.ToString()));
            }
            
            if (Record != null)
            {
                p.Add(new KeyValuePair<string, string>("Record", Record.Value.ToString()));
            }
            
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString()));
            }
            
            if (Beep != null)
            {
                p.Add(new KeyValuePair<string, string>("Beep", Beep.ToString()));
            }
            
            if (StartConferenceOnEnter != null)
            {
                p.Add(new KeyValuePair<string, string>("StartConferenceOnEnter", StartConferenceOnEnter.Value.ToString()));
            }
            
            if (EndConferenceOnExit != null)
            {
                p.Add(new KeyValuePair<string, string>("EndConferenceOnExit", EndConferenceOnExit.Value.ToString()));
            }
            
            if (WaitUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitUrl", WaitUrl.ToString()));
            }
            
            if (WaitMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitMethod", WaitMethod.ToString()));
            }
            
            if (EarlyMedia != null)
            {
                p.Add(new KeyValuePair<string, string>("EarlyMedia", EarlyMedia.Value.ToString()));
            }
            
            if (MaxParticipants != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxParticipants", MaxParticipants.Value.ToString()));
            }
            
            if (ConferenceRecord != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecord", ConferenceRecord.ToString()));
            }
            
            if (ConferenceTrim != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceTrim", ConferenceTrim));
            }
            
            if (ConferenceStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceStatusCallback", ConferenceStatusCallback.ToString()));
            }
            
            if (ConferenceStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceStatusCallbackMethod", ConferenceStatusCallbackMethod.ToString()));
            }
            
            if (ConferenceStatusCallbackEvent != null)
            {
                p.AddRange(ConferenceStatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("ConferenceStatusCallbackEvent", prop)));
            }
            
            return p;
        }
    }

    public class DeleteParticipantOptions : IOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string ConferenceSid { get; }
        /// <summary>
        /// The call_sid
        /// </summary>
        public string CallSid { get; }
    
        /// <summary>
        /// Construct a new DeleteParticipantOptions
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public DeleteParticipantOptions(string conferenceSid, string callSid)
        {
            ConferenceSid = conferenceSid;
            CallSid = callSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class ReadParticipantOptions : ReadOptions<ParticipantResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The string that uniquely identifies this conference
        /// </summary>
        public string ConferenceSid { get; }
        /// <summary>
        /// Filter by muted participants
        /// </summary>
        public bool? Muted { get; set; }
        /// <summary>
        /// The hold
        /// </summary>
        public bool? Hold { get; set; }
    
        /// <summary>
        /// Construct a new ReadParticipantOptions
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        public ReadParticipantOptions(string conferenceSid)
        {
            ConferenceSid = conferenceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString()));
            }
            
            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.Value.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}