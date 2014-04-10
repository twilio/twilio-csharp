using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A CredentialLists instance associated with this domain
    /// </summary>
    public class CredentialListMapping : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The friendly name of this credential list mapping
        /// </summary>
        public String FriendlyName { get; set; }
    }
}
