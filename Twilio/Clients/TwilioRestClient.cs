
using System.Net;
using Twilio.Exceptions;
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
			HttpClient = httpClient ?? null; // new WebRequestClient();
	        Region = region;
	    }

	    /// <summary>
	    /// Make a request to the Twilio API
	    /// </summary>
	    ///
	    /// <param name="request">request to make</param>
	    /// <returns>response of the request</returns>
		public Response Request(Request request)
	    {
			request.SetAuth(_username, _password);
	        var response = HttpClient.MakeRequest(request);
	        return ProcessResponse(response);
	    }

	    #if NET40
	    /// <summary>
	    /// Make a request to the Twilio API
	    /// </summary>
	    ///
	    /// <param name="request">request to make</param>
	    /// <returns>Task that resolves to the response of the request</returns>
	    public async Task<Response> RequestAsync(Request request)
	    {
	        request.SetAuth(_username, _password);
	        var response = await HttpClient.MakeRequestAysnc(request);
	        return ProcessResponse(response);
	    }
        #endif

	    private static Response ProcessResponse(Response response)
	    {
	        if (response == null)
	        {
	            throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
	        }

	        if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.Ambiguous)
	        {
	            return response;
	        }

	        // Throw exception
	        var restException = RestException.FromJson(response.Content);
	        if (restException == null)
	        {
	            throw new ApiException("Server Error, no content");
	        }

	        throw new ApiException(
	            restException.Code,
	            (int)response.StatusCode,
	            restException.Message ?? "Unable to make request, " + response.StatusCode,
	            restException.MoreInfo
	        );
	    }
	}
}

