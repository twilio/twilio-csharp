using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class SipDomainResult : TwilioListBase
    {
        public List<SipDomain> SipDomains { get; set; }
    }
}
