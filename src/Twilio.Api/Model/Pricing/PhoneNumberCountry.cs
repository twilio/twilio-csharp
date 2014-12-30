using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    public class PhoneNumberCountry : TwilioBase
    {
        public string Country { get; set; }
        public string IsoCountry { get; set; }
        public string PriceUnit { get; set; }
        public List<PhoneNumberPrice> PhoneNumberPrices { get; set; }
    }
}