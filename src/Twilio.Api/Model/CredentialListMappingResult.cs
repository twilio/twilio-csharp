using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class CredentialListMappingResult : TwilioListBase
    {
        public List<CredentialListMapping> CredentialListMappings { get; set; }
    }
}
