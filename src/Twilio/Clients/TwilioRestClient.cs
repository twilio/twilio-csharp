
using System;
using System.Net;
using Newtonsoft.Json;
using Twilio.Exceptions;

#if !NET35
using System.Threading.Tasks;
#endif

using Twilio.Http;
#if NET35
using Twilio.Http.Net35;
#endif

namespace Twilio.Clients
{
    /// <summary>
    /// Implementation of a TwilioRestClient.
    /// </summary>
    public class TwilioRestClient : ITwilioRestClient
    {
        /// <summary>
        /// Client to make HTTP requests
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Account SID to use for requests
        /// </summary>
        public string AccountSid { get; }

        /// <summary>
        /// Twilio region to make requests to
        /// </summary>
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
            HttpClient = httpClient ?? DefaultClient();
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
            Response response;
            try
            {
                response = HttpClient.MakeRequest(request);
            }
            catch (Exception clientException)
            {
                throw new ApiConnectionException(
                    "Connection Error: " + request.Method + request.ConstructUrl(),
                    clientException
                );
            }
            return ProcessResponse(response);
        }

#if !NET35
        /// <summary>
        /// Make a request to the Twilio API
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>Task that resolves to the response of the request</returns>
        public async Task<Response> RequestAsync(Request request)
        {
            request.SetAuth(_username, _password);
            Response response;
            try
            {
                response = await HttpClient.MakeRequestAsync(request);
            }
            catch (Exception clientException)
            {
                throw new ApiConnectionException(
                    "Connection Error: " + request.Method + request.ConstructUrl(),
                    clientException
                );
            }
            return ProcessResponse(response);
        }
        
        private static HttpClient DefaultClient()
        {
            return new SystemNetHttpClient();
        }
#else
        private static HttpClient DefaultClient()
        {
            return new WebRequestClient();
        }
#endif

        private static Response ProcessResponse(Response response)
        {
            if (response == null)
            {
                throw new ApiConnectionException("Connection Error: No response received.");
            }

            if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.Ambiguous)
            {
                return response;
            }

            // Deserialize and throw exception
            RestException restException = null;
            try
            {
                restException = RestException.FromJson(response.Content);
            }
            catch (JsonReaderException) { /* Allow null check below to handle */ }
            
            if (restException == null)
            {
                throw new ApiException("Api Error: " + response.StatusCode + " - " + (response.Content ?? "[no content]"));
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

