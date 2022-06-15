/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Twilio.Converters;

namespace Twilio.TwiML.Voice
{

    /// <summary>
    /// Connect TwiML Verb
    /// </summary>
    public class Connect : TwiML
    {
        /// <summary>
        /// Action URL
        /// </summary>
        public Uri Action { get; set; }
        /// <summary>
        /// Action URL method
        /// </summary>
        public Twilio.Http.HttpMethod Method { get; set; }

        /// <summary>
        /// Create a new Connect
        /// </summary>
        /// <param name="action"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        public Connect(Uri action = null, Twilio.Http.HttpMethod method = null) : base("Connect")
        {
            this.Action = action;
            this.Method = method;
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
            return attributes;
        }

        /// <summary>
        /// Create a new <Room/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Room name, the body of the TwiML Element. </param>
        /// <param name="participantIdentity"> Participant identity when connecting to the Room </param>
        public Connect Room(string name = null, string participantIdentity = null)
        {
            var newChild = new Room(name, participantIdentity);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Room/> element as a child of this element
        /// </summary>
        /// <param name="room"> A Room instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Connect Room(Room room)
        {
            this.Append(room);
            return this;
        }

        /// <summary>
        /// Create a new <Autopilot/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Autopilot assistant sid or unique name, the body of the TwiML Element. </param>
        public Connect Autopilot(string name = null)
        {
            var newChild = new Autopilot(name);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Autopilot/> element as a child of this element
        /// </summary>
        /// <param name="autopilot"> A Autopilot instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Connect Autopilot(Autopilot autopilot)
        {
            this.Append(autopilot);
            return this;
        }

        /// <summary>
        /// Create a new <Stream/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Friendly name given to the Stream </param>
        /// <param name="connectorName"> Unique name for Stream Connector </param>
        /// <param name="url"> URL of the remote service where the Stream is routed </param>
        /// <param name="track"> Track to be streamed to remote service </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> Status Callback URL method </param>
        public Connect Stream(string name = null,
                              string connectorName = null,
                              string url = null,
                              Stream.TrackEnum track = null,
                              string statusCallback = null,
                              Stream.StatusCallbackMethodEnum statusCallbackMethod = null)
        {
            var newChild = new Stream(name, connectorName, url, track, statusCallback, statusCallbackMethod);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Stream/> element as a child of this element
        /// </summary>
        /// <param name="stream"> A Stream instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Connect Stream(Stream stream)
        {
            this.Append(stream);
            return this;
        }

        /// <summary>
        /// Create a new <VirtualAgent/> element and append it as a child of this element.
        /// </summary>
        /// <param name="connectorName"> Defines the conversation profile Dialogflow needs to use </param>
        /// <param name="language"> Language to be used by Dialogflow to transcribe speech </param>
        /// <param name="sentimentAnalysis"> Whether sentiment analysis needs to be enabled or not </param>
        /// <param name="statusCallback"> URL to post status callbacks from Twilio </param>
        /// <param name="statusCallbackMethod"> HTTP method to use when requesting the status callback URL </param>
        public Connect VirtualAgent(string connectorName = null,
                                    string language = null,
                                    bool? sentimentAnalysis = null,
                                    string statusCallback = null,
                                    Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new VirtualAgent(
                connectorName,
                language,
                sentimentAnalysis,
                statusCallback,
                statusCallbackMethod
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <VirtualAgent/> element as a child of this element
        /// </summary>
        /// <param name="virtualAgent"> A VirtualAgent instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Connect VirtualAgent(VirtualAgent virtualAgent)
        {
            this.Append(virtualAgent);
            return this;
        }

        /// <summary>
        /// Create a new <Conversation/> element and append it as a child of this element.
        /// </summary>
        /// <param name="serviceInstanceSid"> Service instance Sid </param>
        /// <param name="inboundAutocreation"> Inbound autocreation </param>
        /// <param name="routingAssignmentTimeout"> Routing assignment timeout </param>
        /// <param name="inboundTimeout"> Inbound timeout </param>
        /// <param name="record"> Record </param>
        /// <param name="trim"> Trim </param>
        /// <param name="recordingStatusCallback"> Recording status callback URL </param>
        /// <param name="recordingStatusCallbackMethod"> Recording status callback URL method </param>
        /// <param name="recordingStatusCallbackEvent"> Recording status callback events </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        /// <param name="statusCallbackEvent"> Events to call status callback URL </param>
        public Connect Conversation(string serviceInstanceSid = null,
                                    bool? inboundAutocreation = null,
                                    int? routingAssignmentTimeout = null,
                                    int? inboundTimeout = null,
                                    Conversation.RecordEnum record = null,
                                    Conversation.TrimEnum trim = null,
                                    Uri recordingStatusCallback = null,
                                    Twilio.Http.HttpMethod recordingStatusCallbackMethod = null,
                                    List<Conversation.RecordingEventEnum> recordingStatusCallbackEvent = null,
                                    Uri statusCallback = null,
                                    Twilio.Http.HttpMethod statusCallbackMethod = null,
                                    List<Conversation.EventEnum> statusCallbackEvent = null)
        {
            var newChild = new Conversation(
                serviceInstanceSid,
                inboundAutocreation,
                routingAssignmentTimeout,
                inboundTimeout,
                record,
                trim,
                recordingStatusCallback,
                recordingStatusCallbackMethod,
                recordingStatusCallbackEvent,
                statusCallback,
                statusCallbackMethod,
                statusCallbackEvent
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Conversation/> element as a child of this element
        /// </summary>
        /// <param name="conversation"> A Conversation instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Connect Conversation(Conversation conversation)
        {
            this.Append(conversation);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new Connect Append(TwiML childElem)
        {
            return (Connect) base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new Connect SetOption(string key, object value)
        {
            return (Connect) base.SetOption(key, value);
        }
    }

}