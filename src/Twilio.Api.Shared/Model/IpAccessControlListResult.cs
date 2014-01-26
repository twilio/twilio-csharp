using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class IpAccessControlListResult : TwilioListBase
    {
        public List<IpAccessControlList> IpAccessControlLists { get; set; }
    }
}
