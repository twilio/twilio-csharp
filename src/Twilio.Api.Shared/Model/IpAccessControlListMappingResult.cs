using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class IpAccessControlListMappingResult : TwilioListBase
    {
        public List<IpAccessControlListMapping> IpAccessControlListMappings { get; set; }
    }
}
