using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Status of a Dequeue request
    /// </summary>
    public enum DequeueStatus
    {
        /// <summary>
        /// The Dequeue was successful
        /// </summary>
        Success,
        /// <summary>
        /// The Dequeue failed
        /// </summary>
        Failed
    }
}
