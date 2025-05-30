/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using System.Linq;
using Twilio.Types;


namespace Twilio.Rest.Api.V2010.Account.Conference
{

    /// <summary> create </summary>
    public class CreateParticipantOptions : IOptions<ParticipantResource>
    {
        
        ///<summary> The SID of the participant's conference. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The phone number, Client identifier, or username portion of SIP address that made this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). Client identifiers are formatted `client:name`. If using a phone number, it must be a Twilio number or a Verified [outgoing caller id](https://www.twilio.com/docs/voice/api/outgoing-caller-ids) for your account. If the `to` parameter is a phone number, `from` must also be a phone number. If `to` is sip address, this value of `from` should be a username portion to be used to populate the P-Asserted-Identity header that is passed to the SIP endpoint. </summary> 
        public IEndpoint From { get; }

        ///<summary> The phone number, SIP address, or Client identifier that received this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). SIP addresses are formatted as `sip:name@company.com`. Client identifiers are formatted `client:name`. [Custom parameters](https://www.twilio.com/docs/voice/api/conference-participant-resource#custom-parameters) may also be specified. </summary> 
        public IEndpoint To { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The URL we should call using the `status_callback_method` to send status information to your application. </summary> 
        public Uri StatusCallback { get; set; }

        ///<summary> The HTTP method we should use to call `status_callback`. Can be: `GET` and `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }

        ///<summary> The conference state changes that should generate a call to `status_callback`. Can be: `initiated`, `ringing`, `answered`, and `completed`. Separate multiple values with a space. The default value is `completed`. </summary> 
        public List<string> StatusCallbackEvent { get; set; }

        ///<summary> A label for this participant. If one is supplied, it may subsequently be used to fetch, update or delete the participant. </summary> 
        public string Label { get; set; }

        ///<summary> The number of seconds that we should allow the phone to ring before assuming there is no answer. Can be an integer between `5` and `600`, inclusive. The default value is `60`. We always add a 5-second timeout buffer to outgoing calls, so  value of 10 would result in an actual timeout that was closer to 15 seconds. </summary> 
        public int? Timeout { get; set; }

        ///<summary> Whether to record the participant and their conferences, including the time between conferences. Can be `true` or `false` and the default is `false`. </summary> 
        public bool? Record { get; set; }

        ///<summary> Whether the agent is muted in the conference. Can be `true` or `false` and the default is `false`. </summary> 
        public bool? Muted { get; set; }

        ///<summary> Whether to play a notification beep to the conference when the participant joins. Can be: `true`, `false`, `onEnter`, or `onExit`. The default value is `true`. </summary> 
        public string Beep { get; set; }

        ///<summary> Whether to start the conference when the participant joins, if it has not already started. Can be: `true` or `false` and the default is `true`. If `false` and the conference has not started, the participant is muted and hears background music until another participant starts the conference. </summary> 
        public bool? StartConferenceOnEnter { get; set; }

        ///<summary> Whether to end the conference when the participant leaves. Can be: `true` or `false` and defaults to `false`. </summary> 
        public bool? EndConferenceOnExit { get; set; }

        ///<summary> The URL that Twilio calls using the `wait_method` before the conference has started. The URL may return an MP3 file, a WAV file, or a TwiML document. The default value is the URL of our standard hold music. If you do not want anything to play while waiting for the conference to start, specify an empty string by setting `wait_url` to `''`. For more details on the allowable verbs within the `waitUrl`, see the `waitUrl` attribute in the [<Conference> TwiML instruction](https://www.twilio.com/docs/voice/twiml/conference#attributes-waiturl). </summary> 
        public Uri WaitUrl { get; set; }

        ///<summary> The HTTP method we should use to call `wait_url`. Can be `GET` or `POST` and the default is `POST`. When using a static audio file, this should be `GET` so that we can cache the file. </summary> 
        public Twilio.Http.HttpMethod WaitMethod { get; set; }

        ///<summary> Whether to allow an agent to hear the state of the outbound call, including ringing or disconnect messages. Can be: `true` or `false` and defaults to `true`. </summary> 
        public bool? EarlyMedia { get; set; }

        ///<summary> The maximum number of participants in the conference. Can be a positive integer from `2` to `250`. The default value is `250`. </summary> 
        public int? MaxParticipants { get; set; }

        ///<summary> Whether to record the conference the participant is joining. Can be: `true`, `false`, `record-from-start`, and `do-not-record`. The default value is `false`. </summary> 
        public string ConferenceRecord { get; set; }

        ///<summary> Whether to trim leading and trailing silence from the conference recording. Can be: `trim-silence` or `do-not-trim` and defaults to `trim-silence`. </summary> 
        public string ConferenceTrim { get; set; }

        ///<summary> The URL we should call using the `conference_status_callback_method` when the conference events in `conference_status_callback_event` occur. Only the value set by the first participant to join the conference is used. Subsequent `conference_status_callback` values are ignored. </summary> 
        public Uri ConferenceStatusCallback { get; set; }

        ///<summary> The HTTP method we should use to call `conference_status_callback`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod ConferenceStatusCallbackMethod { get; set; }

        ///<summary> The conference state changes that should generate a call to `conference_status_callback`. Can be: `start`, `end`, `join`, `leave`, `mute`, `hold`, `modify`, `speaker`, and `announcement`. Separate multiple values with a space. Defaults to `start end`. </summary> 
        public List<string> ConferenceStatusCallbackEvent { get; set; }

        ///<summary> The recording channels for the final recording. Can be: `mono` or `dual` and the default is `mono`. </summary> 
        public string RecordingChannels { get; set; }

        ///<summary> The URL that we should call using the `recording_status_callback_method` when the recording status changes. </summary> 
        public Uri RecordingStatusCallback { get; set; }

        ///<summary> The HTTP method we should use when we call `recording_status_callback`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }

        ///<summary> The SIP username used for authentication. </summary> 
        public string SipAuthUsername { get; set; }

        ///<summary> The SIP password for authentication. </summary> 
        public string SipAuthPassword { get; set; }

        ///<summary> The [region](https://support.twilio.com/hc/en-us/articles/223132167-How-global-low-latency-routing-and-region-selection-work-for-conferences-and-Client-calls) where we should mix the recorded audio. Can be:`us1`, `us2`, `ie1`, `de1`, `sg1`, `br1`, `au1`, or `jp1`. </summary> 
        public string Region { get; set; }

        ///<summary> The URL we should call using the `conference_recording_status_callback_method` when the conference recording is available. </summary> 
        public Uri ConferenceRecordingStatusCallback { get; set; }

        ///<summary> The HTTP method we should use to call `conference_recording_status_callback`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod ConferenceRecordingStatusCallbackMethod { get; set; }

        ///<summary> The recording state changes that should generate a call to `recording_status_callback`. Can be: `started`, `in-progress`, `paused`, `resumed`, `stopped`, `completed`, `failed`, and `absent`. Separate multiple values with a space, ex: `'in-progress completed failed'`. </summary> 
        public List<string> RecordingStatusCallbackEvent { get; set; }

        ///<summary> The conference recording state changes that generate a call to `conference_recording_status_callback`. Can be: `in-progress`, `completed`, `failed`, and `absent`. Separate multiple values with a space, ex: `'in-progress completed failed'` </summary> 
        public List<string> ConferenceRecordingStatusCallbackEvent { get; set; }

        ///<summary> Whether the participant is coaching another call. Can be: `true` or `false`. If not present, defaults to `false` unless `call_sid_to_coach` is defined. If `true`, `call_sid_to_coach` must be defined. </summary> 
        public bool? Coaching { get; set; }

        ///<summary> The SID of the participant who is being `coached`. The participant being coached is the only participant who can hear the participant who is `coaching`. </summary> 
        public string CallSidToCoach { get; set; }

        ///<summary> Jitter buffer size for the connecting participant. Twilio will use this setting to apply Jitter Buffer before participant's audio is mixed into the conference. Can be: `off`, `small`, `medium`, and `large`. Default to `large`. </summary> 
        public string JitterBufferSize { get; set; }

        ///<summary> The SID of a BYOC (Bring Your Own Carrier) trunk to route this call with. Note that `byoc` is only meaningful when `to` is a phone number; it will otherwise be ignored. (Beta) </summary> 
        public string Byoc { get; set; }

        ///<summary> The phone number, Client identifier, or username portion of SIP address that made this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). Client identifiers are formatted `client:name`. If using a phone number, it must be a Twilio number or a Verified [outgoing caller id](https://www.twilio.com/docs/voice/api/outgoing-caller-ids) for your account. If the `to` parameter is a phone number, `callerId` must also be a phone number. If `to` is sip address, this value of `callerId` should be a username portion to be used to populate the From header that is passed to the SIP endpoint. </summary> 
        public string CallerId { get; set; }

        ///<summary> The Reason for the outgoing call. Use it to specify the purpose of the call that is presented on the called party's phone. (Branded Calls Beta) </summary> 
        public string CallReason { get; set; }

        ///<summary> The audio track to record for the call. Can be: `inbound`, `outbound` or `both`. The default is `both`. `inbound` records the audio that is received by Twilio. `outbound` records the audio that is sent from Twilio. `both` records the audio that is received and sent by Twilio. </summary> 
        public string RecordingTrack { get; set; }

        ///<summary> The maximum duration of the call in seconds. Constraints depend on account and configuration. </summary> 
        public int? TimeLimit { get; set; }

        ///<summary> Whether to detect if a human, answering machine, or fax has picked up the call. Can be: `Enable` or `DetectMessageEnd`. Use `Enable` if you would like us to return `AnsweredBy` as soon as the called party is identified. Use `DetectMessageEnd`, if you would like to leave a message on an answering machine. For more information, see [Answering Machine Detection](https://www.twilio.com/docs/voice/answering-machine-detection). </summary> 
        public string MachineDetection { get; set; }

        ///<summary> The number of seconds that we should attempt to detect an answering machine before timing out and sending a voice request with `AnsweredBy` of `unknown`. The default timeout is 30 seconds. </summary> 
        public int? MachineDetectionTimeout { get; set; }

        ///<summary> The number of milliseconds that is used as the measuring stick for the length of the speech activity, where durations lower than this value will be interpreted as a human and longer than this value as a machine. Possible Values: 1000-6000. Default: 2400. </summary> 
        public int? MachineDetectionSpeechThreshold { get; set; }

        ///<summary> The number of milliseconds of silence after speech activity at which point the speech activity is considered complete. Possible Values: 500-5000. Default: 1200. </summary> 
        public int? MachineDetectionSpeechEndThreshold { get; set; }

        ///<summary> The number of milliseconds of initial silence after which an `unknown` AnsweredBy result will be returned. Possible Values: 2000-10000. Default: 5000. </summary> 
        public int? MachineDetectionSilenceTimeout { get; set; }

        ///<summary> The URL that we should call using the `amd_status_callback_method` to notify customer application whether the call was answered by human, machine or fax. </summary> 
        public Uri AmdStatusCallback { get; set; }

        ///<summary> The HTTP method we should use when calling the `amd_status_callback` URL. Can be: `GET` or `POST` and the default is `POST`. </summary> 
        public Twilio.Http.HttpMethod AmdStatusCallbackMethod { get; set; }

        ///<summary> Whether to trim any leading and trailing silence from the participant recording. Can be: `trim-silence` or `do-not-trim` and the default is `trim-silence`. </summary> 
        public string Trim { get; set; }

        ///<summary> A token string needed to invoke a forwarded call. A call_token is generated when an incoming call is received on a Twilio number. Pass an incoming call's call_token value to a forwarded call via the call_token parameter when creating a new call. A forwarded call should bear the same CallerID of the original incoming call. </summary> 
        public string CallToken { get; set; }


        /// <summary> Construct a new CreateParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The SID of the participant's conference. </param>
        /// <param name="from"> The phone number, Client identifier, or username portion of SIP address that made this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). Client identifiers are formatted `client:name`. If using a phone number, it must be a Twilio number or a Verified [outgoing caller id](https://www.twilio.com/docs/voice/api/outgoing-caller-ids) for your account. If the `to` parameter is a phone number, `from` must also be a phone number. If `to` is sip address, this value of `from` should be a username portion to be used to populate the P-Asserted-Identity header that is passed to the SIP endpoint. </param>
        /// <param name="to"> The phone number, SIP address, or Client identifier that received this call. Phone numbers are in [E.164](https://www.twilio.com/docs/glossary/what-e164) format (e.g., +16175551212). SIP addresses are formatted as `sip:name@company.com`. Client identifiers are formatted `client:name`. [Custom parameters](https://www.twilio.com/docs/voice/api/conference-participant-resource#custom-parameters) may also be specified. </param>
        public CreateParticipantOptions(string pathConferenceSid, IEndpoint from, IEndpoint to)
        {
            PathConferenceSid = pathConferenceSid;
            From = from;
            To = to;
            StatusCallbackEvent = new List<string>();
            ConferenceStatusCallbackEvent = new List<string>();
            RecordingStatusCallbackEvent = new List<string>();
            ConferenceRecordingStatusCallbackEvent = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
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
                p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
            }
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            if (StatusCallbackEvent != null)
            {
                p.AddRange(StatusCallbackEvent.Select(StatusCallbackEvent => new KeyValuePair<string, string>("StatusCallbackEvent", StatusCallbackEvent)));
            }
            if (Label != null)
            {
                p.Add(new KeyValuePair<string, string>("Label", Label));
            }
            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.ToString()));
            }
            if (Record != null)
            {
                p.Add(new KeyValuePair<string, string>("Record", Record.Value.ToString().ToLower()));
            }
            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString().ToLower()));
            }
            if (Beep != null)
            {
                p.Add(new KeyValuePair<string, string>("Beep", Beep));
            }
            if (StartConferenceOnEnter != null)
            {
                p.Add(new KeyValuePair<string, string>("StartConferenceOnEnter", StartConferenceOnEnter.Value.ToString().ToLower()));
            }
            if (EndConferenceOnExit != null)
            {
                p.Add(new KeyValuePair<string, string>("EndConferenceOnExit", EndConferenceOnExit.Value.ToString().ToLower()));
            }
            if (WaitUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitUrl", Serializers.Url(WaitUrl)));
            }
            if (WaitMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitMethod", WaitMethod.ToString()));
            }
            if (EarlyMedia != null)
            {
                p.Add(new KeyValuePair<string, string>("EarlyMedia", EarlyMedia.Value.ToString().ToLower()));
            }
            if (MaxParticipants != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxParticipants", MaxParticipants.ToString()));
            }
            if (ConferenceRecord != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecord", ConferenceRecord));
            }
            if (ConferenceTrim != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceTrim", ConferenceTrim));
            }
            if (ConferenceStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceStatusCallback", Serializers.Url(ConferenceStatusCallback)));
            }
            if (ConferenceStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceStatusCallbackMethod", ConferenceStatusCallbackMethod.ToString()));
            }
            if (ConferenceStatusCallbackEvent != null)
            {
                p.AddRange(ConferenceStatusCallbackEvent.Select(ConferenceStatusCallbackEvent => new KeyValuePair<string, string>("ConferenceStatusCallbackEvent", ConferenceStatusCallbackEvent)));
            }
            if (RecordingChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingChannels", RecordingChannels));
            }
            if (RecordingStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallback", Serializers.Url(RecordingStatusCallback)));
            }
            if (RecordingStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallbackMethod", RecordingStatusCallbackMethod.ToString()));
            }
            if (SipAuthUsername != null)
            {
                p.Add(new KeyValuePair<string, string>("SipAuthUsername", SipAuthUsername));
            }
            if (SipAuthPassword != null)
            {
                p.Add(new KeyValuePair<string, string>("SipAuthPassword", SipAuthPassword));
            }
            if (Region != null)
            {
                p.Add(new KeyValuePair<string, string>("Region", Region));
            }
            if (ConferenceRecordingStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecordingStatusCallback", Serializers.Url(ConferenceRecordingStatusCallback)));
            }
            if (ConferenceRecordingStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("ConferenceRecordingStatusCallbackMethod", ConferenceRecordingStatusCallbackMethod.ToString()));
            }
            if (RecordingStatusCallbackEvent != null)
            {
                p.AddRange(RecordingStatusCallbackEvent.Select(RecordingStatusCallbackEvent => new KeyValuePair<string, string>("RecordingStatusCallbackEvent", RecordingStatusCallbackEvent)));
            }
            if (ConferenceRecordingStatusCallbackEvent != null)
            {
                p.AddRange(ConferenceRecordingStatusCallbackEvent.Select(ConferenceRecordingStatusCallbackEvent => new KeyValuePair<string, string>("ConferenceRecordingStatusCallbackEvent", ConferenceRecordingStatusCallbackEvent)));
            }
            if (Coaching != null)
            {
                p.Add(new KeyValuePair<string, string>("Coaching", Coaching.Value.ToString().ToLower()));
            }
            if (CallSidToCoach != null)
            {
                p.Add(new KeyValuePair<string, string>("CallSidToCoach", CallSidToCoach));
            }
            if (JitterBufferSize != null)
            {
                p.Add(new KeyValuePair<string, string>("JitterBufferSize", JitterBufferSize));
            }
            if (Byoc != null)
            {
                p.Add(new KeyValuePair<string, string>("Byoc", Byoc));
            }
            if (CallerId != null)
            {
                p.Add(new KeyValuePair<string, string>("CallerId", CallerId));
            }
            if (CallReason != null)
            {
                p.Add(new KeyValuePair<string, string>("CallReason", CallReason));
            }
            if (RecordingTrack != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingTrack", RecordingTrack));
            }
            if (TimeLimit != null)
            {
                p.Add(new KeyValuePair<string, string>("TimeLimit", TimeLimit.ToString()));
            }
            if (MachineDetection != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetection", MachineDetection));
            }
            if (MachineDetectionTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetectionTimeout", MachineDetectionTimeout.ToString()));
            }
            if (MachineDetectionSpeechThreshold != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetectionSpeechThreshold", MachineDetectionSpeechThreshold.ToString()));
            }
            if (MachineDetectionSpeechEndThreshold != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetectionSpeechEndThreshold", MachineDetectionSpeechEndThreshold.ToString()));
            }
            if (MachineDetectionSilenceTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetectionSilenceTimeout", MachineDetectionSilenceTimeout.ToString()));
            }
            if (AmdStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("AmdStatusCallback", Serializers.Url(AmdStatusCallback)));
            }
            if (AmdStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("AmdStatusCallbackMethod", AmdStatusCallbackMethod.ToString()));
            }
            if (Trim != null)
            {
                p.Add(new KeyValuePair<string, string>("Trim", Trim));
            }
            if (CallToken != null)
            {
                p.Add(new KeyValuePair<string, string>("CallToken", CallToken));
            }
            return p;
        }

        

    }
    /// <summary> Kick a participant from a given conference </summary>
    public class DeleteParticipantOptions : IOptions<ParticipantResource>
    {
        
        ///<summary> The SID of the conference with the participants to delete. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to delete. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20. </summary> 
        public string PathCallSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Participant resources to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The SID of the conference with the participants to delete. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to delete. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20. </param>
        public DeleteParticipantOptions(string pathConferenceSid, string pathCallSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathCallSid = pathCallSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Fetch an instance of a participant </summary>
    public class FetchParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the conference with the participant to fetch. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to fetch. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20. </summary> 
        public string PathCallSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Participant resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The SID of the conference with the participant to fetch. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to fetch. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20. </param>
        public FetchParticipantOptions(string pathConferenceSid, string pathCallSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathCallSid = pathCallSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of participants belonging to the account used to make the request </summary>
    public class ReadParticipantOptions : ReadOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the conference with the participants to read. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Participant resources to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Whether to return only participants that are muted. Can be: `true` or `false`. </summary> 
        public bool? Muted { get; set; }

        ///<summary> Whether to return only participants that are on hold. Can be: `true` or `false`. </summary> 
        public bool? Hold { get; set; }

        ///<summary> Whether to return only participants who are coaching another call. Can be: `true` or `false`. </summary> 
        public bool? Coaching { get; set; }



        /// <summary> Construct a new ListParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The SID of the conference with the participants to read. </param>
        public ReadParticipantOptions(string pathConferenceSid)
        {
            PathConferenceSid = pathConferenceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString().ToLower()));
            }
            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.Value.ToString().ToLower()));
            }
            if (Coaching != null)
            {
                p.Add(new KeyValuePair<string, string>("Coaching", Coaching.Value.ToString().ToLower()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> Update the properties of the participant </summary>
    public class UpdateParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the conference with the participant to update. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to update. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20. </summary> 
        public string PathCallSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Participant resources to update. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Whether the participant should be muted. Can be `true` or `false`. `true` will mute the participant, and `false` will un-mute them. Anything value other than `true` or `false` is interpreted as `false`. </summary> 
        public bool? Muted { get; set; }

        ///<summary> Whether the participant should be on hold. Can be: `true` or `false`. `true` puts the participant on hold, and `false` lets them rejoin the conference. </summary> 
        public bool? Hold { get; set; }

        ///<summary> The URL we call using the `hold_method` for music that plays when the participant is on hold. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs. </summary> 
        public Uri HoldUrl { get; set; }

        ///<summary> The HTTP method we should use to call `hold_url`. Can be: `GET` or `POST` and the default is `GET`. </summary> 
        public Twilio.Http.HttpMethod HoldMethod { get; set; }

        ///<summary> The URL we call using the `announce_method` for an announcement to the participant. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs. </summary> 
        public Uri AnnounceUrl { get; set; }

        ///<summary> The HTTP method we should use to call `announce_url`. Can be: `GET` or `POST` and defaults to `POST`. </summary> 
        public Twilio.Http.HttpMethod AnnounceMethod { get; set; }

        ///<summary> The URL that Twilio calls using the `wait_method` before the conference has started. The URL may return an MP3 file, a WAV file, or a TwiML document. The default value is the URL of our standard hold music. If you do not want anything to play while waiting for the conference to start, specify an empty string by setting `wait_url` to `''`. For more details on the allowable verbs within the `waitUrl`, see the `waitUrl` attribute in the [<Conference> TwiML instruction](https://www.twilio.com/docs/voice/twiml/conference#attributes-waiturl). </summary> 
        public Uri WaitUrl { get; set; }

        ///<summary> The HTTP method we should use to call `wait_url`. Can be `GET` or `POST` and the default is `POST`. When using a static audio file, this should be `GET` so that we can cache the file. </summary> 
        public Twilio.Http.HttpMethod WaitMethod { get; set; }

        ///<summary> Whether to play a notification beep to the conference when the participant exits. Can be: `true` or `false`. </summary> 
        public bool? BeepOnExit { get; set; }

        ///<summary> Whether to end the conference when the participant leaves. Can be: `true` or `false` and defaults to `false`. </summary> 
        public bool? EndConferenceOnExit { get; set; }

        ///<summary> Whether the participant is coaching another call. Can be: `true` or `false`. If not present, defaults to `false` unless `call_sid_to_coach` is defined. If `true`, `call_sid_to_coach` must be defined. </summary> 
        public bool? Coaching { get; set; }

        ///<summary> The SID of the participant who is being `coached`. The participant being coached is the only participant who can hear the participant who is `coaching`. </summary> 
        public string CallSidToCoach { get; set; }



        /// <summary> Construct a new UpdateParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The SID of the conference with the participant to update. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID or label of the participant to update. Non URL safe characters in a label must be percent encoded, for example, a space character is represented as %20. </param>
        public UpdateParticipantOptions(string pathConferenceSid, string pathCallSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathCallSid = pathCallSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Muted != null)
            {
                p.Add(new KeyValuePair<string, string>("Muted", Muted.Value.ToString().ToLower()));
            }
            if (Hold != null)
            {
                p.Add(new KeyValuePair<string, string>("Hold", Hold.Value.ToString().ToLower()));
            }
            if (HoldUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("HoldUrl", Serializers.Url(HoldUrl)));
            }
            if (HoldMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("HoldMethod", HoldMethod.ToString()));
            }
            if (AnnounceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("AnnounceUrl", Serializers.Url(AnnounceUrl)));
            }
            if (AnnounceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("AnnounceMethod", AnnounceMethod.ToString()));
            }
            if (WaitUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitUrl", Serializers.Url(WaitUrl)));
            }
            if (WaitMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WaitMethod", WaitMethod.ToString()));
            }
            if (BeepOnExit != null)
            {
                p.Add(new KeyValuePair<string, string>("BeepOnExit", BeepOnExit.Value.ToString().ToLower()));
            }
            if (EndConferenceOnExit != null)
            {
                p.Add(new KeyValuePair<string, string>("EndConferenceOnExit", EndConferenceOnExit.Value.ToString().ToLower()));
            }
            if (Coaching != null)
            {
                p.Add(new KeyValuePair<string, string>("Coaching", Coaching.Value.ToString().ToLower()));
            }
            if (CallSidToCoach != null)
            {
                p.Add(new KeyValuePair<string, string>("CallSidToCoach", CallSidToCoach));
            }
            return p;
        }

        

    }


}

