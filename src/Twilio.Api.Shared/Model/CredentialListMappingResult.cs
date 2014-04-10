using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class CredentialListMappingResult : TwilioListBase
    {
        /// <summary>
        /// The CredentialLists instances associated with this domain
        /// </summary>
        public List<CredentialListMapping> CredentialListMappings { get; set; }
    }
}
