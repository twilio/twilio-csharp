using System;

namespace Twilio.Tests
{
    public class TwilioTest
    {
        public string Serialize(object obj) => obj.ToString();
        public string Serialize(DateTime date) => date.ToString("yyyy-MM-dd");
        public string Serialize(bool boolean) => boolean.ToString().ToLower();
        public string Serialize(Uri url) => url.AbsoluteUri.TrimEnd('/');
    }
}

