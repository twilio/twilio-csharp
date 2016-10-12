#if NET40
using System.Threading.Tasks;
#endif

using Twilio.Http;

namespace Twilio.Clients
{
    /// <summary>
    /// Interface for a Twilio Client
    /// </summary>
	public interface ITwilioRestClient
	{

		#if NET40
	    /// <summary>
	    /// Make an async request to Twilio
	    /// </summary>
	    ///
	    /// <param name="request">Request to make</param>
	    /// <returns>Task that resolves to response</returns>
		Task<Response> RequestAsync(Request request);
		#endif

	    /// <summary>
	    /// Make a request to Twilio
	    /// </summary>
	    ///
	    /// <param name="request">Request to make</param>
	    /// <returns>response of the request</returns>
		Response Request(Request request);

	    /// <summary>
	    /// Get the account sid all requests are made against
	    /// </summary>
	    ///
	    /// <returns>the account sid</returns>
		string GetAccountSid();

	    /// <summary>
	    /// Get the http client that makes requests
	    /// </summary>
	    ///
	    /// <returns>the client that makes http requests</returns>
		HttpClient GetHttpClient();
	}
}

