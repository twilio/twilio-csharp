using System;

namespace Twilio
{
    public class PhoneNumberPrice
    {
        public string Type { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}

