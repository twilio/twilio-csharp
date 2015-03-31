using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// TaskRouter logs Events for each state change in the Workspace for the purpose of historical reporting and auditing.
    /// </summary>
    public class Event : TwilioBase
    {
        /// <summary>
        /// The unique ID for this Event.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// A description of this Event.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The unique ID of the Account that owns this Event.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// An identifier for this type of Event.
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// The type of object this Event is most relevant to (e.g. <see cref="Twilio.TaskRouter.Task"/> or <see cref="Twilio.TaskRouter.Reservation"/>).
        /// </summary>
        public string ResourceType { get; set; }
        /// <summary>
        /// The unique ID of the object this Event is most relevant to.
        /// </summary>
        public string ResourceSid { get; set; }
        /// <summary>
        /// The URL of the object this Event is most relevant to.
        /// </summary>
        public string ResourceUrl { get; set; }
        /// <summary>
        /// The time this Event was sent.
        /// </summary>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// The source of the Event.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// The IP Address of the actor that generated this Event.
        /// </summary>
        public string SourceIpAddress { get; set; }
        /// <summary>
        /// The type of the actor that generated this Event.
        /// </summary>
        public string ActorType { get; set; }
        /// <summary>
        /// The unique ID of the actor object that generated this Event.
        /// </summary>
        public string ActorSid { get; set; }
        /// <summary>
        /// The URL of the actor object that generated this Event.
        /// </summary>
        public string ActorUrl { get; set; }
        /// <summary>
        /// A dictionary of data pertaining to the specific event type.
        /// See <a href="https://www.twilio.com/docs/taskrouter/events">the TaskRouter documentation</a> for details.
        /// </summary>
        public Dictionary<string, string> EventData { get; set; }
    }
}

