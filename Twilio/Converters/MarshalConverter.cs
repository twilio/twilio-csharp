using System;

namespace Twilio.Converters
{
	public class MarshalConverter {
		public static DateTime DateTimeFromString(string dateTimeString) {
			return DateTime.Parse(dateTimeString);
		}
	}
}

