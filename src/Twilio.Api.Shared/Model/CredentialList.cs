using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A collection of credentials that are allowed to reach your SIP Domain
    /// </summary>
    public class CredentialList : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies each CredentialList.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// A human readable descriptive text, up to 64 characters long
        /// </summary>
        public string FriendlyName { get; set; }
    }
}
