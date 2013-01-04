using System;

namespace Twilio
{
    /// <summary>
    /// A QueueMember represents a single member of a Twilio Queue
    /// </summary>
    public class QueueMember : TwilioBase
    {
        /// <summary>
        /// A 34 character string that identifies the caller
        /// </summary>
        public string CallSid { get; set; }

        /// <summary>
        /// The DateTime when the caller was enqueued
        /// </summary>
        public DateTime DateEnqueued { get; set; }

        /// <summary>
        /// The time in seconds that the caller has been queued
        /// </summary>
        public int? WaitTime { get; set; }

        /// <summary>
        /// The callers current position in the Queue
        /// </summary>
        public int? Position { get; set; }
    }
}
