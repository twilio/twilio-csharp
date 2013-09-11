using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class CredentialListResult : TwilioListBase
    {
        public List<CredentialList> CredentialLists { get; set; }
    }
}
