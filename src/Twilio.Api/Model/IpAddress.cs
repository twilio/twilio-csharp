using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;

namespace Twilio
{
    public class IpAddress : TwilioBase
    {
        public string Sid { get; set; }
        public string FriendlyName { get; set; }
        
        [DeserializeAs(Name="IpAddress")]
        public string Address { get; set; }
    }
}
