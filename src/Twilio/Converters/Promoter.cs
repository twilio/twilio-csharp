using System;
using System.Collections.Generic;

namespace Twilio.Converters
{
    /// <summary>
    /// Promote objects
    /// </summary>
    public class Promoter
    {
        /// <summary>
        /// Convert a string URL to a Uri object
        /// </summary>
        /// <param name="url">URL to convert</param>
        /// <returns>Converted Uri</returns>
        public static Uri UriFromString(string url)
        {
            return new Uri(url);
        }

        /// <summary>
        /// Promote a single entry to a List of one
        /// </summary>
        /// <param name="one">single entry to promote</param>
        /// <returns>List of the single object</returns>
        public static List<T> ListOfOne<T>(T one)
        {
            return new List<T> {one};
        }
    }
}

