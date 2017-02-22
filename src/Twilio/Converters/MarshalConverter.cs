using System;

namespace Twilio.Converters
{
    /// <summary>
    /// Convert strings to objects
    /// </summary>
    public class MarshalConverter
    {
        /// <summary>
        /// Convert a date time string to a DateTime object
        /// </summary>
        /// <param name="dateTimeString">date time string to convert</param>
        /// <returns>Converted DateTime object</returns>
        public static DateTime DateTimeFromString(string dateTimeString)
        {
            return DateTime.Parse(dateTimeString);
        }
    }
}

