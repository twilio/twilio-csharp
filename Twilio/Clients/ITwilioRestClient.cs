using System;
using System.Threading.Tasks;
using Twilio.Http;

namespace Twilio.Clients
{
	public interface ITwilioRestClient
	{
		Task<Response> Request(Request request);
		string GetAccountSid();
		HttpClient GetHttpClient();
		void SetHttpClient(HttpClient httpClient);
	}
}

