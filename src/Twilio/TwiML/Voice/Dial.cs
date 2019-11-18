/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.TwiML.Voice
{

    /// <summary>
    /// Dial TwiML Verb
    /// </summary>
    public class Dial : TwiML
    {
        public sealed class TrimEnum : StringEnum
        {
            private TrimEnum(string value) : base(value) {}
            public TrimEnum() {}
            public static implicit operator TrimEnum(string value)
            {
                return new TrimEnum(value);
            }

            public static readonly TrimEnum TrimSilence = new TrimEnum("trim-silence");
            public static readonly TrimEnum DoNotTrim = new TrimEnum("do-not-trim");
        }

        public sealed class RecordEnum : StringEnum
        {
            private RecordEnum(string value) : base(value) {}
            public RecordEnum() {}
            public static implicit operator RecordEnum(string value)
            {
                return new RecordEnum(value);
            }

            public static readonly RecordEnum DoNotRecord = new RecordEnum("do-not-record");
            public static readonly RecordEnum RecordFromAnswer = new RecordEnum("record-from-answer");
            public static readonly RecordEnum RecordFromRinging = new RecordEnum("record-from-ringing");
            public static readonly RecordEnum RecordFromAnswerDual = new RecordEnum("record-from-answer-dual");
            public static readonly RecordEnum RecordFromRingingDual = new RecordEnum("record-from-ringing-dual");
        }

        public sealed class RecordingEventEnum : StringEnum
        {
            private RecordingEventEnum(string value) : base(value) {}
            public RecordingEventEnum() {}
            public static implicit operator RecordingEventEnum(string value)
            {
                return new RecordingEventEnum(value);
            }

            public static readonly RecordingEventEnum InProgress = new RecordingEventEnum("in-progress");
            public static readonly RecordingEventEnum Completed = new RecordingEventEnum("completed");
            public static readonly RecordingEventEnum Absent = new RecordingEventEnum("absent");
        }

        public sealed class RingToneEnum : StringEnum
        {
            private RingToneEnum(string value) : base(value) {}
            public RingToneEnum() {}
            public static implicit operator RingToneEnum(string value)
            {
                return new RingToneEnum(value);
            }

            public static readonly RingToneEnum At = new RingToneEnum("at");
            public static readonly RingToneEnum Au = new RingToneEnum("au");
            public static readonly RingToneEnum Bg = new RingToneEnum("bg");
            public static readonly RingToneEnum Br = new RingToneEnum("br");
            public static readonly RingToneEnum Be = new RingToneEnum("be");
            public static readonly RingToneEnum Ch = new RingToneEnum("ch");
            public static readonly RingToneEnum Cl = new RingToneEnum("cl");
            public static readonly RingToneEnum Cn = new RingToneEnum("cn");
            public static readonly RingToneEnum Cz = new RingToneEnum("cz");
            public static readonly RingToneEnum De = new RingToneEnum("de");
            public static readonly RingToneEnum Dk = new RingToneEnum("dk");
            public static readonly RingToneEnum Ee = new RingToneEnum("ee");
            public static readonly RingToneEnum Es = new RingToneEnum("es");
            public static readonly RingToneEnum Fi = new RingToneEnum("fi");
            public static readonly RingToneEnum Fr = new RingToneEnum("fr");
            public static readonly RingToneEnum Gr = new RingToneEnum("gr");
            public static readonly RingToneEnum Hu = new RingToneEnum("hu");
            public static readonly RingToneEnum Il = new RingToneEnum("il");
            public static readonly RingToneEnum In = new RingToneEnum("in");
            public static readonly RingToneEnum It = new RingToneEnum("it");
            public static readonly RingToneEnum Lt = new RingToneEnum("lt");
            public static readonly RingToneEnum Jp = new RingToneEnum("jp");
            public static readonly RingToneEnum Mx = new RingToneEnum("mx");
            public static readonly RingToneEnum My = new RingToneEnum("my");
            public static readonly RingToneEnum Nl = new RingToneEnum("nl");
            public static readonly RingToneEnum No = new RingToneEnum("no");
            public static readonly RingToneEnum Nz = new RingToneEnum("nz");
            public static readonly RingToneEnum Ph = new RingToneEnum("ph");
            public static readonly RingToneEnum Pl = new RingToneEnum("pl");
            public static readonly RingToneEnum Pt = new RingToneEnum("pt");
            public static readonly RingToneEnum Ru = new RingToneEnum("ru");
            public static readonly RingToneEnum Se = new RingToneEnum("se");
            public static readonly RingToneEnum Sg = new RingToneEnum("sg");
            public static readonly RingToneEnum Th = new RingToneEnum("th");
            public static readonly RingToneEnum Uk = new RingToneEnum("uk");
            public static readonly RingToneEnum Us = new RingToneEnum("us");
            public static readonly RingToneEnum UsOld = new RingToneEnum("us-old");
            public static readonly RingToneEnum Tw = new RingToneEnum("tw");
            public static readonly RingToneEnum Ve = new RingToneEnum("ve");
            public static readonly RingToneEnum Za = new RingToneEnum("za");
        }

        /// <summary>
        /// Phone number to dial
        /// </summary>
        public string NumberAttribute { get; set; }
        /// <summary>
        /// Action URL
        /// </summary>
        public Uri Action { get; set; }
        /// <summary>
        /// Action URL method
        /// </summary>
        public Twilio.Http.HttpMethod Method { get; set; }
        /// <summary>
        /// Time to wait for answer
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// Hangup call on star press
        /// </summary>
        public bool? HangupOnStar { get; set; }
        /// <summary>
        /// Max time length
        /// </summary>
        public int? TimeLimit { get; set; }
        /// <summary>
        /// Caller ID to display
        /// </summary>
        public string CallerId { get; set; }
        /// <summary>
        /// Record the call
        /// </summary>
        public Dial.RecordEnum Record { get; set; }
        /// <summary>
        /// Trim the recording
        /// </summary>
        public Dial.TrimEnum Trim { get; set; }
        /// <summary>
        /// Recording status callback URL
        /// </summary>
        public Uri RecordingStatusCallback { get; set; }
        /// <summary>
        /// Recording status callback URL method
        /// </summary>
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }
        /// <summary>
        /// Recording status callback events
        /// </summary>
        public List<Dial.RecordingEventEnum> RecordingStatusCallbackEvent { get; set; }
        /// <summary>
        /// Preserve the ringing behavior of the inbound call until the Dialed call picks up
        /// </summary>
        public bool? AnswerOnBridge { get; set; }
        /// <summary>
        /// Ringtone allows you to override the ringback tone that Twilio will play back to the caller while executing the Dial
        /// </summary>
        public Dial.RingToneEnum RingTone { get; set; }

        /// <summary>
        /// Create a new Dial
        /// </summary>
        /// <param name="number"> Phone number to dial, the body of the TwiML Element. </param>
        /// <param name="action"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="timeout"> Time to wait for answer </param>
        /// <param name="hangupOnStar"> Hangup call on star press </param>
        /// <param name="timeLimit"> Max time length </param>
        /// <param name="callerId"> Caller ID to display </param>
        /// <param name="record"> Record the call </param>
        /// <param name="trim"> Trim the recording </param>
        /// <param name="recordingStatusCallback"> Recording status callback URL </param>
        /// <param name="recordingStatusCallbackMethod"> Recording status callback URL method </param>
        /// <param name="recordingStatusCallbackEvent"> Recording status callback events </param>
        /// <param name="answerOnBridge"> Preserve the ringing behavior of the inbound call until the Dialed call picks up
        ///                      </param>
        /// <param name="ringTone"> Ringtone allows you to override the ringback tone that Twilio will play back to the caller
        ///                while executing the Dial </param>
        public Dial(string number = null,
                    Uri action = null,
                    Twilio.Http.HttpMethod method = null,
                    int? timeout = null,
                    bool? hangupOnStar = null,
                    int? timeLimit = null,
                    string callerId = null,
                    Dial.RecordEnum record = null,
                    Dial.TrimEnum trim = null,
                    Uri recordingStatusCallback = null,
                    Twilio.Http.HttpMethod recordingStatusCallbackMethod = null,
                    List<Dial.RecordingEventEnum> recordingStatusCallbackEvent = null,
                    bool? answerOnBridge = null,
                    Dial.RingToneEnum ringTone = null) : base("Dial")
        {
            this.NumberAttribute = number;
            this.Action = action;
            this.Method = method;
            this.Timeout = timeout;
            this.HangupOnStar = hangupOnStar;
            this.TimeLimit = timeLimit;
            this.CallerId = callerId;
            this.Record = record;
            this.Trim = trim;
            this.RecordingStatusCallback = recordingStatusCallback;
            this.RecordingStatusCallbackMethod = recordingStatusCallbackMethod;
            this.RecordingStatusCallbackEvent = recordingStatusCallbackEvent;
            this.AnswerOnBridge = answerOnBridge;
            this.RingTone = ringTone;
        }

        /// <summary>
        /// Return the body of the TwiML tag
        /// </summary>
        protected override string GetElementBody()
        {
            return this.NumberAttribute != null ? this.NumberAttribute : string.Empty;
        }

        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            if (this.Action != null)
            {
                attributes.Add(new XAttribute("action", Serializers.Url(this.Action)));
            }
            if (this.Method != null)
            {
                attributes.Add(new XAttribute("method", this.Method.ToString()));
            }
            if (this.Timeout != null)
            {
                attributes.Add(new XAttribute("timeout", this.Timeout.ToString()));
            }
            if (this.HangupOnStar != null)
            {
                attributes.Add(new XAttribute("hangupOnStar", this.HangupOnStar.Value.ToString().ToLower()));
            }
            if (this.TimeLimit != null)
            {
                attributes.Add(new XAttribute("timeLimit", this.TimeLimit.ToString()));
            }
            if (this.CallerId != null)
            {
                attributes.Add(new XAttribute("callerId", this.CallerId));
            }
            if (this.Record != null)
            {
                attributes.Add(new XAttribute("record", this.Record.ToString()));
            }
            if (this.Trim != null)
            {
                attributes.Add(new XAttribute("trim", this.Trim.ToString()));
            }
            if (this.RecordingStatusCallback != null)
            {
                attributes.Add(new XAttribute("recordingStatusCallback", Serializers.Url(this.RecordingStatusCallback)));
            }
            if (this.RecordingStatusCallbackMethod != null)
            {
                attributes.Add(new XAttribute("recordingStatusCallbackMethod", this.RecordingStatusCallbackMethod.ToString()));
            }
            if (this.RecordingStatusCallbackEvent != null)
            {
                attributes.Add(new XAttribute("recordingStatusCallbackEvent", String.Join(" ", this.RecordingStatusCallbackEvent.Select(e => e.ToString()).ToArray())));
            }
            if (this.AnswerOnBridge != null)
            {
                attributes.Add(new XAttribute("answerOnBridge", this.AnswerOnBridge.Value.ToString().ToLower()));
            }
            if (this.RingTone != null)
            {
                attributes.Add(new XAttribute("ringTone", this.RingTone.ToString()));
            }
            return attributes;
        }

        /// <summary>
        /// Create a new <Client/> element and append it as a child of this element.
        /// </summary>
        /// <param name="identity"> Client identity, the body of the TwiML Element. </param>
        /// <param name="url"> Client URL </param>
        /// <param name="method"> Client URL Method </param>
        /// <param name="statusCallbackEvent"> Events to trigger status callback </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> Status Callback URL Method </param>
        public Dial Client(string identity = null,
                           Uri url = null,
                           Twilio.Http.HttpMethod method = null,
                           List<Client.EventEnum> statusCallbackEvent = null,
                           Uri statusCallback = null,
                           Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new Client(
                identity,
                url,
                method,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Client/> element as a child of this element
        /// </summary>
        /// <param name="client"> A Client instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Dial Client(Client client)
        {
            this.Append(client);
            return this;
        }

        /// <summary>
        /// Create a new <Conference/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Conference name, the body of the TwiML Element. </param>
        /// <param name="muted"> Join the conference muted </param>
        /// <param name="beep"> Play beep when joining </param>
        /// <param name="startConferenceOnEnter"> Start the conference on enter </param>
        /// <param name="endConferenceOnExit"> End the conferenceon exit </param>
        /// <param name="waitUrl"> Wait URL </param>
        /// <param name="waitMethod"> Wait URL method </param>
        /// <param name="maxParticipants"> Maximum number of participants </param>
        /// <param name="record"> Record the conference </param>
        /// <param name="region"> Conference region </param>
        /// <param name="coach"> Call coach </param>
        /// <param name="trim"> Trim the conference recording </param>
        /// <param name="statusCallbackEvent"> Events to call status callback URL </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        /// <param name="recordingStatusCallback"> Recording status callback URL </param>
        /// <param name="recordingStatusCallbackMethod"> Recording status callback URL method </param>
        /// <param name="recordingStatusCallbackEvent"> Recording status callback events </param>
        /// <param name="eventCallbackUrl"> Event callback URL </param>
        public Dial Conference(string name = null,
                               bool? muted = null,
                               Conference.BeepEnum beep = null,
                               bool? startConferenceOnEnter = null,
                               bool? endConferenceOnExit = null,
                               Uri waitUrl = null,
                               Twilio.Http.HttpMethod waitMethod = null,
                               int? maxParticipants = null,
                               Conference.RecordEnum record = null,
                               Conference.RegionEnum region = null,
                               string coach = null,
                               Conference.TrimEnum trim = null,
                               List<Conference.EventEnum> statusCallbackEvent = null,
                               Uri statusCallback = null,
                               Twilio.Http.HttpMethod statusCallbackMethod = null,
                               Uri recordingStatusCallback = null,
                               Twilio.Http.HttpMethod recordingStatusCallbackMethod = null,
                               List<Conference.RecordingEventEnum> recordingStatusCallbackEvent = null,
                               Uri eventCallbackUrl = null)
        {
            var newChild = new Conference(
                name,
                muted,
                beep,
                startConferenceOnEnter,
                endConferenceOnExit,
                waitUrl,
                waitMethod,
                maxParticipants,
                record,
                region,
                coach,
                trim,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod,
                recordingStatusCallback,
                recordingStatusCallbackMethod,
                recordingStatusCallbackEvent,
                eventCallbackUrl
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Conference/> element as a child of this element
        /// </summary>
        /// <param name="conference"> A Conference instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Dial Conference(Conference conference)
        {
            this.Append(conference);
            return this;
        }

        /// <summary>
        /// Create a new <Number/> element and append it as a child of this element.
        /// </summary>
        /// <param name="phoneNumber"> Phone Number to dial, the body of the TwiML Element. </param>
        /// <param name="sendDigits"> DTMF tones to play when the call is answered </param>
        /// <param name="url"> TwiML URL </param>
        /// <param name="method"> TwiML URL method </param>
        /// <param name="statusCallbackEvent"> Events to call status callback </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        public Dial Number(Types.PhoneNumber phoneNumber = null,
                           string sendDigits = null,
                           Uri url = null,
                           Twilio.Http.HttpMethod method = null,
                           List<Number.EventEnum> statusCallbackEvent = null,
                           Uri statusCallback = null,
                           Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new Number(
                phoneNumber,
                sendDigits,
                url,
                method,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Number/> element as a child of this element
        /// </summary>
        /// <param name="number"> A Number instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Dial Number(Number number)
        {
            this.Append(number);
            return this;
        }

        /// <summary>
        /// Create a new <Queue/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Queue name, the body of the TwiML Element. </param>
        /// <param name="url"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="reservationSid"> TaskRouter Reservation SID </param>
        /// <param name="postWorkActivitySid"> TaskRouter Activity SID </param>
        public Dial Queue(string name = null,
                          Uri url = null,
                          Twilio.Http.HttpMethod method = null,
                          string reservationSid = null,
                          string postWorkActivitySid = null)
        {
            var newChild = new Queue(name, url, method, reservationSid, postWorkActivitySid);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Queue/> element as a child of this element
        /// </summary>
        /// <param name="queue"> A Queue instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Dial Queue(Queue queue)
        {
            this.Append(queue);
            return this;
        }

        /// <summary>
        /// Create a new <Sim/> element and append it as a child of this element.
        /// </summary>
        /// <param name="simSid"> SIM SID, the body of the TwiML Element. </param>
        public Dial Sim(string simSid = null)
        {
            var newChild = new Sim(simSid);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Sim/> element as a child of this element
        /// </summary>
        /// <param name="sim"> A Sim instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Dial Sim(Sim sim)
        {
            this.Append(sim);
            return this;
        }

        /// <summary>
        /// Create a new <Sip/> element and append it as a child of this element.
        /// </summary>
        /// <param name="sipUrl"> SIP URL, the body of the TwiML Element. </param>
        /// <param name="username"> SIP Username </param>
        /// <param name="password"> SIP Password </param>
        /// <param name="url"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="statusCallbackEvent"> Status callback events </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        public Dial Sip(Uri sipUrl = null,
                        string username = null,
                        string password = null,
                        Uri url = null,
                        Twilio.Http.HttpMethod method = null,
                        List<Sip.EventEnum> statusCallbackEvent = null,
                        Uri statusCallback = null,
                        Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new Sip(
                sipUrl,
                username,
                password,
                url,
                method,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Sip/> element as a child of this element
        /// </summary>
        /// <param name="sip"> A Sip instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Dial Sip(Sip sip)
        {
            this.Append(sip);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new Dial Append(TwiML childElem)
        {
            return (Dial) base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new Dial SetOption(string key, object value)
        {
            return (Dial) base.SetOption(key, value);
        }
    }

}