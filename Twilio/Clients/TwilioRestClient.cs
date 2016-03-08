using System;
using Twilio.Http;
using System.Threading.Tasks;

namespace Twilio.Clients
{
	public class TwilioRestClient
	{
		public readonly int HTTP_STATUS_CODE_CREATED = 201;
		public readonly int HTTP_STATUS_CODE_NO_CONTENT = 204;
		public readonly int HTTP_STATUS_CODE_OK = 200;

		public enum Domains {
			API="api",
			CONVERSATIONS="conversations",
			LOOKUPS="lookups",
			MONITOR="monitor",
			PRICING="pricing",
			TASKROUTER="taskrouter",
			TRUNKING="trunking"
		};

		private HttpClient httpClient;
		private string username;
		private string password;
		private string accountSid;

		public TwilioRestClient (string username, string password, String accountSid = null, HttpClient httpClient = null) {
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
				this.httpClient = new SystemNetClient();
			}
		}

		public async Task<Response> request(Request request) {
			request.setAuth(this.username, this.password);
			return httpClient.makeRequest(request);
		}

		public string getAccountSid() {
			return accountSid;
		}

		public HttpClient getHttpClient() {
			return httpClient;
		}

		public void setHttpClient(HttpClient httpClient) {
			return httpClient;
		}
	}
}

