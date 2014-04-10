using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class CredentialResult : TwilioListBase
    {
        /// <summary>
        /// The list of Credentials in a CredentialList
        /// </summary>
        public List<Credential> Credentials { get; set; }
    }
}
