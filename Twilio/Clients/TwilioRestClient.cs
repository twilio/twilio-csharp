using System;
using Twilio.Http;
#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Clients
{
	public sealed class Domains {
		public const string API = "api";
		public const string CONVERSATIONS="conversations";
		public const string LOOKUPS = "lookups";
		public const string MONITOR = "monitor";
		public const string PRICING = "pricing";
		public const string TASKROUTER = "taskrouter";
		public const string TRUNKING = "trunking";
		public const string IPMESSAGING = "ipmessaging";
		public const string NOTIFICATIONS = "notifications";
    public const string PREVIEW = "preview";

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
#if NET40
                this.httpClient = new SystemNetClient();
#else
                this.httpClient = new WebRequestClient();
#endif
            }
        }

#if NET40
		public async Task<Response> RequestAsync(Request request) {
			request.SetAuth(this.username, this.password);
			var response = await httpClient.MakeRequestAsync(request);

            return response;
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

