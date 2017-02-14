using System;

namespace Twilio.Tests
{
    public class TwilioTest
    {
        public string Serialize(object obj) => obj.ToString();
        public string Serialize(DateTime date) => date.ToString("yyyy-MM-dd");
    }
}

