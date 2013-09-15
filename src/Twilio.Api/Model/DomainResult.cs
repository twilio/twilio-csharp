using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class DomainResult : TwilioListBase
    {
        public List<Domain> Domains { get; set; }
    }
}
