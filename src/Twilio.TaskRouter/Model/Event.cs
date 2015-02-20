using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Event.
    /// </summary>
    public class Event : TwilioBase
    {
        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the account sid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string ResourceType { get; set; }
        /// <summary>
        /// Gets or sets the resource sid.
        /// </summary>
        public string ResourceSid { get; set; }
        /// <summary>
        /// Gets or sets the resource URL.
        /// </summary>
        public string ResourceUrl { get; set; }
        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Gets or sets the source ip address.
        /// </summary>
        public string SourceIpAddress { get; set; }
        /// <summary>
        /// Gets or sets the type of the actor.
        /// </summary>
        public string ActorType { get; set; }
        /// <summary>
        /// Gets or sets the actor sid.
        /// </summary>
        public string ActorSid { get; set; }
        /// <summary>
        /// Gets or sets the actor URL.
        /// </summary>
        public string ActorUrl { get; set; }
        /// <summary>
        /// Gets or sets the event data.
        /// </summary>
        public Dictionary<string, string> EventData { get; set; }
    }
}

