using RestSharp;
using RestSharp.Validation;
using System;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Create a new token
		/// </summary>
		/// <param name="ttl">The time in seconds before this token expires</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void CreateToken(int ttl, Action<Token> callback) 
		{
			var request = new RestRequest (Method.POST);
			Require.Argument ("Ttl", ttl);
			request.Resource = "Accounts/{AccountSid}/Tokens.json";
			request.AddParameter ("Ttl", ttl);

			ExecuteAsync<Token>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// Create a new token
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void CreateToken(Action<Token> callback)
		{
			var request = new RestRequest (Method.POST);
			request.Resource = "Accounts/{AccountSid}/Tokens.json";
			ExecuteAsync<Token>(request, (response) => { callback(response); });
		}
	}

}
