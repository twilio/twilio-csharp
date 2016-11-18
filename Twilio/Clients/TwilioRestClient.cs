#if NET40
using System.Threading.Tasks;
#endif

using Twilio.Http;

namespace Twilio.Clients
{
    /// <summary>
    /// Implementation of a TwilioRestClient.
    /// </summary>
	public class TwilioRestClient : ITwilioRestClient
	{
		private readonly HttpClient _httpClient;
		private readonly string _username;
		private readonly string _password;
		private readonly string _accountSid;

	    /// <summary>
	    /// Constructor for a TwilioRestClient
	    /// </summary>
	    ///
	    /// <param name="username">username for requests</param>
	    /// <param name="password">password for requests</param>
	    /// <param name="accountSid">account sid to make requests for</param>
	    /// <param name="httpClient">http client used to make the requests</param>
		public TwilioRestClient(
	        string username,
	        string password,
	        string accountSid = null,
	        HttpClient httpClient = null
	    )
	    {
			_username = username;
			_password = password;
			_accountSid = accountSid ?? username;
			_httpClient = httpClient ?? new WebRequestClient();
		}

		#if NET40
	    /// <summary>
	    /// Make an async request
	    /// </summary>
	    ///
	    /// <param name="request">request to make</param>
	    /// <returns>Task that resolves to the request response</returns>
		public Task<Response> RequestAsync(Request request) {
			request.SetAuth(_username, _password);
			return Task.FromResult(_httpClient.MakeRequest(request));
		}
		#endif

	    /// <summary>
	    /// Make a request to the Twilio API
	    /// </summary>
	    ///
	    /// <param name="request">request to make</param>
	    /// <returns>response of the request</returns>
		public Response Request(Request request) {
			request.SetAuth(_username, _password);
			return _httpClient.MakeRequest(request);
		}

	    /// <summary>
	    /// Get the account sid
	    /// </summary>
	    ///
	    /// <returns>the account sid that request are made for</returns>
		public string GetAccountSid() {
			return _accountSid;
		}

	    /// <summary>
	    /// Get the http client
	    /// </summary>
	    ///
	    /// <returns>the client responsible for http requests</returns>
		public HttpClient GetHttpClient() {
			return _httpClient;
		}
	}
}

