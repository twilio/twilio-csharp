using System;
using System.Threading.Tasks;
using Twilio.Http;

namespace Twilio.Clients
{
	public interface ITwilioRestClient
	{
		#if NET40
		Task<Response> RequestAsync(Request request);
		#endif
		Response Request(Request request);
		string GetAccountSid();
		HttpClient GetHttpClient();
		void SetHttpClient(HttpClient httpClient);
	}
}

