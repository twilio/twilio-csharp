using System;
using System.Collections;
using System.Collections.Generic;

namespace Twilio.Monitor
{
    /// <summary>
    /// An Event instance resource represents a single Twilio Event.
    /// </summary>
    public class Event : TwilioBase
    {
        /// <summary>
        /// The unique ID for this Event.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The unique ID of the Account that owns this Event.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The unique ID of the actor that generated this Event.
        /// </summary>
        public string ActorSid { get; set; }
        /// <summary>
        /// The type of actor that generated this Event.
        /// </summary>
        public string ActorType { get; set; }
        /// <summary>
        /// This Event's description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The date at which this Event was generated.
        /// </summary>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// The type of this Event.
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// The unique ID of the resource for this Event.
        /// </summary>
        public string ResourceSid { get; set; }
        /// <summary>
        /// The resource type of this Event.
        /// </summary>
        public string ResourceType { get; set; }
        /// <summary>
        /// The source of this Event.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// The source IP address of this Event.
        /// </summary>
        public string SourceIpAddress { get; set; }
        /// <summary>
        /// The data involved in this Event.
        /// </summary>
        public Dictionary<string, Dictionary<string, Object>> EventData { get; set; }
        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        public Dictionary<string, string> Links { get; set; }
    }
}
