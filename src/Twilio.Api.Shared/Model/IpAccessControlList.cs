using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class IpAccessControlList : TwilioBase
    {
        public string Sid { get; set; }
        public string FriendlyName { get; set; }
    }
}
