using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class FetchParticipantOptions : IOptions<ParticipantResource> 
    {
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
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
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public string CallSid { get; }
        public bool? Muted { get; set; }
        public bool? Hold { get; set; }
        public Uri HoldUrl { get; set; }
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
                p.Add(new KeyValuePair<string, string>("Muted", Muted.ToString()));
            }
            
            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.ToString()));
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
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public Types.PhoneNumber From { get; }
        public Types.PhoneNumber To { get; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public List<string> StatusCallbackEvent { get; set; }
        public int? Timeout { get; set; }
        public bool? Record { get; set; }
        public bool? Muted { get; set; }
        public ParticipantResource.BeepEnum Beep { get; set; }
        public bool? StartConferenceOnEnter { get; set; }
        public bool? EndConferenceOnExit { get; set; }
        public Uri WaitUrl { get; set; }
        public Twilio.Http.HttpMethod WaitMethod { get; set; }
        public bool? EarlyMedia { get; set; }
        public int? MaxParticipants { get; set; }
        public ParticipantResource.ConferenceRecordEnum ConferenceRecord { get; set; }
        public string ConferenceTrim { get; set; }
        public Uri ConferenceStatusCallback { get; set; }
        public Twilio.Http.HttpMethod ConferenceStatusCallbackMethod { get; set; }
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
                p.AddRange(StatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("StatusCallbackEvent", prop.ToString())));
            }
            
            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.ToString()));
            }
            
            if (Record != null)
            {
                p.Add(new KeyValuePair<string, string>("Record", Record.ToString()));
            }
            
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.ToString()));
            }
            
            if (Beep != null)
            {
                p.Add(new KeyValuePair<string, string>("Beep", Beep.ToString()));
            }
            
            if (StartConferenceOnEnter != null)
            {
                p.Add(new KeyValuePair<string, string>("StartConferenceOnEnter", StartConferenceOnEnter.ToString()));
            }
            
            if (EndConferenceOnExit != null)
            {
                p.Add(new KeyValuePair<string, string>("EndConferenceOnExit", EndConferenceOnExit.ToString()));
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
                p.Add(new KeyValuePair<string, string>("EarlyMedia", EarlyMedia.ToString()));
            }
            
            if (MaxParticipants != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxParticipants", MaxParticipants.ToString()));
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
                p.AddRange(ConferenceStatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("ConferenceStatusCallbackEvent", prop.ToString())));
            }
            
            return p;
        }
    }

    public class DeleteParticipantOptions : IOptions<ParticipantResource> 
    {
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
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
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public bool? Muted { get; set; }
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
                p.Add(new KeyValuePair<string, string>("Muted", Muted.ToString()));
            }
            
            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}