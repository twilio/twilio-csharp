using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class Key : TwilioBase
    {
        public string Sid { get; set; }
        public string FriendlyName { get; set; }
        public string Secret { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    } 
}
