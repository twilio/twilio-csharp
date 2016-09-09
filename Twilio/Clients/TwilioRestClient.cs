using System;
using Twilio.Http;
#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Clients
{
	public class TwilioRestClient : ITwilioRestClient
	{
		private HttpClient httpClient;
		private string username;
		private string password;
		private string accountSid;

		public TwilioRestClient(string username, string password, String accountSid = null, HttpClient httpClient = null) {
			this.username = username;
			this.password = password;
			if (accountSid != null) {
				this.accountSid = accountSid;
			} else {
				this.accountSid = username;
			}

			if (httpClient != null) {
				this.httpClient = httpClient;
			} else {
				this.httpClient = new WebRequestClient();
			}
		}

		#if NET40
		public Task<Response> RequestAsync(Request request) {
			request.SetAuth(this.username, this.password);
			var response = httpClient.MakeRequest(request);

			return Task.FromResult(response);
		}
		#endif

		public Response Request(Request request) {
			request.SetAuth(this.username, this.password);
			var response = httpClient.MakeRequest(request);

			return response;
		}

		public string GetAccountSid() {
			return accountSid;
		}

		public HttpClient GetHttpClient() {
			return httpClient;
		}

		public void SetHttpClient(HttpClient httpClient) {
			this.httpClient = httpClient;
		}
	}
}

