using System;

namespace Twilio.Jwt
{
	public interface IScope
	{
		string Payload { get; }
	}
}
