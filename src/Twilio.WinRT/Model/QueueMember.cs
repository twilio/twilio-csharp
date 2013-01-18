using System;

namespace Twilio
{
    /// <summary>
    /// A QueueMember represents a single member of a Twilio Queue
    /// </summary>
    public sealed class QueueMember //: TwilioBase
    {
        /// <summary>
        /// Exception encountered during API request
        /// </summary>
        public RestException RestException { get; set; }
        /// <summary>
        /// The URI for this resource, relative to https://api.twilio.com
        /// </summary>
        public Uri Uri { get; set; }


        /// <summary>
        /// A 34 character string that identifies the caller
        /// </summary>
        public string CallSid { get; set; }

        /// <summary>
        /// The DateTime when the caller was enqueued
        /// </summary>
        public DateTimeOffset DateEnqueued { get; set; }

        /// <summary>
        /// The time in seconds that the caller has been queued
        /// </summary>
        public int? WaitTime { get; set; }

        /// <summary>
        /// The callers current position in the Queue
        /// </summary>
        public int? CurrentPosition { get; set; }
    }
}
