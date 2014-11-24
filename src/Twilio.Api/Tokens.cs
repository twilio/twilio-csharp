using RestSharp;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
    {
		/// <summary>
		/// Create a new token
		/// </summary>
		/// <param name="ttl">The friendly name to name the application</param>
        public virtual Token CreateToken(int ttl) 
        {
			var request = new RestRequest (Method.POST);
			Require.Argument ("Ttl", ttl);
			request.Resource = "Accounts/{AccountSid}/Tokens.json";
			request.AddParameter ("Ttl", ttl);

			return Execute<Token>(request);
        }

		/// <summary>
		/// Create a new token
		/// </summary>
		public virtual Token CreateToken()
		{
			var request = new RestRequest (Method.POST);
			request.Resource = "Accounts/{AccountSid}/Tokens.json";
			return Execute<Token>(request);
		}
    }

}
