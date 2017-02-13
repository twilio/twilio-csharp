using System;
using System.Collections.Generic;

namespace Twilio.Converters
{
    public class Promoter
    {
        public static Uri UriFromString(string url)
        {
            return new Uri(url);
        }

        public static List<T> ListOfOne<T>(T one)
        {
            return new List<T> {one};
        }
    }
}

