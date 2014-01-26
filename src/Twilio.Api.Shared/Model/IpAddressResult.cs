using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class IpAddressResult : TwilioListBase
    {
        public List<IpAddress> IpAddresses { get; set; }
    }
}
