using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a paged list of phone calls made to and from the account.
		/// Makes a GET request to the Calls List resource.
		/// </summary>
        public virtual CallResult ListCalls()
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Calls.json";

			return Execute<CallResult>(request);
		}

		/// <summary>
		/// Returns a paged list of phone calls made to and from the account.
		/// Makes a GET request to the Calls List resource.
		/// </summary>
		/// <param name="options">List filter options. If an property is set the list will be filtered by that value.</param>
		public virtual CallResult ListCalls(CallListRequest options)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Calls.json";

			AddCallListOptions(options, request);

			return Execute<CallResult>(request);
		}

        /// <summary>
        /// Returns a paged list of phone calls made to and from the account.
        /// Makes a GET request to the Calls List resource.
        /// </summary>
        /// <param name="To"></param>
		public virtual CallResult ListCalls(string To)
        {
            var request = new RestRequest {Resource = "Accounts/{AccountSid}/Calls.json"};

            AddCallListOptions(new CallListRequest() {To = To}, request);

            return Execute<CallResult>(request);
        }

		/// <summary>
		/// Returns the single Call resource identified by {CallSid}
		///  Makes a GET request to a Call Instance resource.
		/// </summary>
		/// <param name="callSid">The Sid of the Call resource to retrieve</param>
        public virtual Call GetCall(string callSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";

			request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

			return Execute<Call>(request);
		}

		/// <summary>
		/// Deletes the single Call resource identified by {callSid}.
		/// </summary>
		/// <param name="callSid">The Sid of the Call resource to delete.</param>
        public virtual DeleteStatus DeleteCall(string callSid)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";
			request.AddUrlSegment("CallSid", callSid);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}

		/// <summary>
		/// Initiates a new phone call. Makes a POST request to the Calls List resource.
		/// </summary>
		/// <param name="from">The phone number to use as the caller id. Format with a '+' and country code e.g., +16175551212 (E.164 format). Must be a Twilio number or a valid outgoing caller id for your account.</param>
		/// <param name="to">The number to call formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
		/// <param name="url">The fully qualified URL that should be consulted when the call connects. Just like when you set a URL for your inbound calls. URL should return TwiML.</param>
        public virtual Call InitiateOutboundCall(string from, string to, string url)
		{
			return InitiateOutboundCall(from, to, url, string.Empty);
		}

		/// <summary>
		/// Initiates a new phone call. Makes a POST request to the Calls List resource.
		/// </summary>
		/// <param name="from">The phone number to use as the caller id. Format with a '+' and country code e.g., +16175551212 (E.164 format). Must be a Twilio number or a valid outgoing caller id for your account.</param>
		/// <param name="to">The number to call formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
		/// <param name="url">The fully qualified URL that should be consulted when the call connects. Just like when you set a URL for your inbound calls. URL should return TwiML.</param>
		/// <param name="statusCallback">A URL that Twilio will request when the call ends to notify your app.</param>
        public virtual Call InitiateOutboundCall(string from, string to, string url, string statusCallback)
		{
			return InitiateOutboundCall(new CallOptions
			{
				From = from,
				To = to,
				Url = url,
				StatusCallback = statusCallback
			});
		}

		/// <summary>
		/// Initiates a new phone call. Makes a POST request to the Calls List resource.
		/// </summary>
		/// <param name="options">Call settings. Only properties with values set will be used.</param>
        public virtual Call InitiateOutboundCall(CallOptions options)
		{
			Require.Argument("From", options.From);
			Require.Argument("To", options.To);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Calls.json";

			AddCallOptions(options, request);

			return Execute<Call>(request);
		}

		/// <summary>
		/// Hangs up a call in progress. Makes a POST request to a Call Instance resource.
		/// </summary>
		/// <param name="callSid">The Sid of the call to hang up.</param>
		/// <param name="style">'Canceled' will attempt to hangup calls that are queued or ringing but not affect calls already in progress. 'Completed' will attempt to hang up a call even if it's already in progress.</param>
        public virtual Call HangupCall(string callSid, HangupStyle style)
		{
			Require.Argument("CallSid", callSid);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";

			request.AddUrlSegment("CallSid", callSid);
			request.AddParameter("Status", style.ToString().ToLower());

			return Execute<Call>(request);
		}

		/// <summary>
		/// Redirect a call in progress to a new TwiML URL.  Makes a POST request to a Call Instance resource.
		/// </summary>
		/// <param name="callSid">The Sid of the call to redirect</param>
		/// <param name="redirectUrl">The URL to redirect the call to.</param>
		/// <param name="redirectMethod">The HTTP method to use when requesting the redirectUrl</param>
        public virtual Call RedirectCall(string callSid, string redirectUrl, string redirectMethod)
		{
			Require.Argument("CallSid", callSid);
			Require.Argument("Url", redirectUrl);

            CallOptions options = new CallOptions();
            options.Url = redirectUrl;
            options.Method = redirectMethod;

            return RedirectCall(callSid, options);
		}

        /// <summary>
        /// Redirect a call in progress to a new TwiML URL.  Makes a POST request to a Call Instance resource.
        /// </summary>
        /// <param name="callSid">The Sid of the call to redirect</param>
        /// <param name="options">Call settings. Only Url, Method, FallbackUrl, FallbackMethod, StatusCallback and StatusCallbackMethod properties with values set will be used.</param>
        public virtual Call RedirectCall(string callSid, CallOptions options)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("Url", options.Url);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";

            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);
            request.AddParameter("Url", options.Url);
            if (options.Method.HasValue()) request.AddParameter("Method", options.Method);

            if (options.FallbackUrl.HasValue()) request.AddParameter("FallbackUrl", options.FallbackUrl);
            if (options.FallbackMethod.HasValue()) request.AddParameter("FallbackMethod", options.FallbackMethod);

            if (options.StatusCallback.HasValue())
            {
                request.AddParameter("StatusCallback", options.StatusCallback);
                request.AddParameter("StatusCallbackUrl", options.StatusCallback); //workaround for issue DEVX-401
            }

            if (options.RecordingStatusCallback.HasValue())
            {
                request.AddParameter("RecordingStatusCallback", options.RecordingStatusCallback);
            }
            if (options.RecordingStatusCallbackMethod.HasValue())
            {
              request.AddParameter("RecordingStatusCallbackMethod", options.RecordingStatusCallbackMethod); 
            }
            if (options.RecordingChannels.HasValue()) request.AddParameter("RecordingChannels", options.RecordingChannels);

            if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod);

            return Execute<Call>(request);
        }
	}
}
