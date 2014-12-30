using System;

namespace Twilio.Pricing
{
    public class NumberCallPrice
    {
        public string NumberType { get; set; }

        public decimal CallBasePrice { get; set; }

        public decimal CallCurrentPrice { get; set; }
    }
}