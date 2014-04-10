using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class CredentialListResult : TwilioListBase
    {
        /// <summary>
        /// A list of Credential Lists for an account
        /// </summary>
        public List<CredentialList> CredentialLists { get; set; }
    }
}
