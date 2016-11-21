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
		public HttpClient HttpClient { get; }
	    public string AccountSid { get; }
        public string Region { get; }

	    private readonly string _username;
		private readonly string _password;

	    /// <summary>
	    /// Constructor for a TwilioRestClient
	    /// </summary>
	    ///
	    /// <param name="username">username for requests</param>
	    /// <param name="password">password for requests</param>
	    /// <param name="accountSid">account sid to make requests for</param>
	    /// <param name="region">region to make requests for</param>
	    /// <param name="httpClient">http client used to make the requests</param>
		public TwilioRestClient(
	        string username,
	        string password,
	        string accountSid = null,
	        string region = null,
	        HttpClient httpClient = null
	    )
	    {
			_username = username;
			_password = password;

	        AccountSid = accountSid ?? username;
	        HttpClient = httpClient ?? new WebRequestClient();
	        Region = region;
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
			return Task.FromResult(HttpClient.MakeRequest(request));
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
			return HttpClient.MakeRequest(request);
		}
	}
}

