using System;
using Twilio.Http;
using System.Threading.Tasks;
using System.Net;

namespace Twilio.Clients
{
	public class TwilioRestClient
	{
		public const HttpStatusCode HTTP_STATUS_CODE_CREATED = HttpStatusCode.Created;
		public const HttpStatusCode HTTP_STATUS_CODE_NO_CONTENT = HttpStatusCode.NoContent;
		public const HttpStatusCode HTTP_STATUS_CODE_OK = HttpStatusCode.OK;

		public sealed class Domains {
			public const string API = "api";
			public const string CONVERSATIONS="conversations";
			public const string LOOKUPS = "lookups";
			public const string MONITOR = "monitor";
			public const string PRICING = "pricing";
			public const string TASKROUTER = "taskrouter";
			public const string TRUNKING = "trunking";
			public const string IPMESSAGING = "ipmessaging";

			private readonly string value;

			public Domains(string value) {
				this.value = value;
			}

			public override string ToString() {
				return value;
			}

			public static implicit operator Domains(string value) {
				return new Domains(value);
			}

			public static implicit operator string(Domains value) {
				return value.ToString();
			}
		}

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

		public async Task<Response> Request(Request request) {
			request.SetAuth(this.username, this.password);
			var response = await httpClient.MakeRequest(request);

			return response;
		}

		public string getAccountSid() {
			return accountSid;
		}

		public HttpClient getHttpClient() {
			return httpClient;
		}

		public void setHttpClient(HttpClient httpClient) {
			this.httpClient = httpClient;
		}
	}
}

