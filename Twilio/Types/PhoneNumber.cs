namespace Twilio.Types
{
	public class PhoneNumber : IEndpoint
	{
		private readonly string _number;

		public PhoneNumber(string number)
		{
			_number = number;
		}

		public override string ToString()
		{
			return _number;
		}
	}
}

