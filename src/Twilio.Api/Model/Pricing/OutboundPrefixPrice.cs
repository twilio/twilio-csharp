using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    public class OutboundPrefixPrice
    {
        public List<string> PrefixList { get; set; }

        public string FriendlyName { get; set; }

        public decimal CallBasePrice { get; set; }

        public decimal CallCurrentPrice { get; set; }
    }
}