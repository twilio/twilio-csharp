using System;

namespace Twilio.Pricing
{
    public class VoiceNumber : TwilioBase
    {
        public string Number { get; set; }

        public string Country { get; set; }

        public string IsoCountry { get; set; }

        public string PriceUnit { get; set; }

        public NumberCallPrice OutboundCallPrice { get; set; }

        public NumberCallPrice InboundCallPrice { get; set; }
    }
}