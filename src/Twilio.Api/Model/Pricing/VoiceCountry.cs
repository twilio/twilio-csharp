using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    public class VoiceCountry : TwilioBase
    {
        public string Country { get; set; }
        public string IsoCountry { get; set; }
        public string PriceUnit { get; set; }
        public List<InboundCallPrice> InboundCallPrices { get; set; }
        public List<OutboundPrefixPrice> OutboundPrefixPrices { get; set; }
    }

}

