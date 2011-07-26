using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JWT;

namespace Twilio
{
	public class TwilioCapability
	{
		string _accountSid;
		string _authToken;
		string _clientName;

		List<ScopeURI> _scopes;

		public TwilioCapability(string accountSid, string authToken)
		{
			_accountSid = accountSid;
			_authToken = authToken;
			_scopes = new List<ScopeURI>();
		}

		void Allow(string service, string capability, object prms)
		{
			// add to scope
			_scopes.Add(new ScopeURI(service, capability, prms));
		}

		public void AllowClientIncoming(string clientName)
		{
			// clientName must be a non-zero length alphanumeric string
			if (Regex.IsMatch(clientName, @"\W"))
			{
				throw new ArgumentException("Only alphanumeric characters allowed in client name.");
			}

			if (string.IsNullOrEmpty(clientName))
			{
				throw new ArgumentException("Client name must not be a zero length string or NULL.");
			}

			_clientName = clientName;
			Allow("client", "incoming", null);
		}

		public void AllowClientOutgoing(string applicationSid)
		{
			AllowClientOutgoing(applicationSid, null);
		}

		public void AllowClientOutgoing(string applicationSid, object appParams)
		{
			Allow("client", "outgoing", new { appSid = applicationSid, appParams });
		}

		public string GenerateToken()
		{
			return GenerateToken(3600);
		}

		public string GenerateToken(int ttlSeconds)
		{
			var scope = string.Join(" ", _scopes.Select(s => s.ToString(_clientName)).ToArray());

			var payload = new
			{
				iss = _accountSid,
				exp = ConvertToUnixTimestamp(DateTime.UtcNow.AddSeconds(ttlSeconds)),
				scope
			};

			return JsonWebToken.Encode(payload, _authToken, JwtHashAlgorithm.HS256);
		}

		static int ConvertToUnixTimestamp(DateTime date)
		{
			DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			TimeSpan diff = date - origin;
			return (int)Math.Floor(diff.TotalSeconds);
		}
	}
}