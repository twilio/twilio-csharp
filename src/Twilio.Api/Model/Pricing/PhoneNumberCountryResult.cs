using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    public class PhoneNumberCountryResult : TwilioListBase
    {
        public List<PhoneNumberCountry> Countries { get; set; }
    }
}