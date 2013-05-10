using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Available options when verifying a new Outgoing Caller ID. 
    /// </summary>
    public sealed class OutgoingCallerIdOptions
    {
        /// <summary>
        /// A human readable description for the new caller ID with maximum length 64 characters. Defaults to a nicely formatted version of the number.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The number of seconds, between 0 and 60, to delay before initiating the validation call. Defaults to 0.
        /// </summary>
        public int? CallDelay { get; set; }

        /// <summary>
        /// Digits to dial after connecting the validation call.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// A URL that Twilio will request when the verification call ends to notify your app if the verification process was successful or not.
        /// </summary>
        public string StatusCallback { get; set; }

        /// <summary>
        /// The HTTP method Twilio should use when requesting the above URL. Defaults to POST.
        /// </summary>
        public string StatusCallbackMethod { get; set; }
    }
}