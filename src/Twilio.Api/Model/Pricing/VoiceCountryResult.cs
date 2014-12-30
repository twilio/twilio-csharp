using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    public class VoiceCountryResult : TwilioListBase
    {
        public List<VoiceCountry> Countries { get; set; }
    }
}