using System;
using System.Collections.Generic;

namespace Twilio.Jwt
{
	public class ClientCapability : BaseJwt
	{
		private readonly HashSet<IScope> _scopes;

		public ClientCapability(
			string accountSid,
			string authToken,
			DateTime? expiration = null,
			HashSet<IScope> scopes = null
		) : base (authToken, accountSid, expiration.HasValue ? expiration.Value : DateTime.UtcNow.AddSeconds(3600))
		{
			this._scopes = scopes;
		}

		public override Dictionary<string, object> Headers
		{
			get
			{
				return new Dictionary<string, object>();
			}
		}

		public override Dictionary<string, object> Claims
		{
			get
			{
				var claims = new Dictionary<string, object>();
				if (_scopes != null)
				{
					var scopes = new List<string>();
					foreach (var scope in _scopes)
					{
						scopes.Add(scope.Payload);
					}

					claims.Add("scope", String.Join(" ", scopes));
				}

				return claims;
			}
		}
	}
}
