using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a paged list of phone calls made to and from the account.
		/// Sorted by DateUpdated with most-recent calls first.
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListCalls(Action<CallResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Calls.json";

			ExecuteAsync<CallResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Returns a paged list of phone calls made to and from the account.
		/// Sorted by DateUpdated with most-recent calls first.
		/// </summary>
		/// <param name="options">List filter options. If an property is set the list will be filtered by that value.</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListCalls(CallListRequest options, Action<CallResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Calls.json";

			AddCallListOptions(options, request);

			ExecuteAsync<CallResult>(request, (response) => callback(response));
		}

		private void AddCallListOptions(CallListRequest options, RestRequest request)
		{
			if (options.From.HasValue()) request.AddParameter("From", options.From);
			if (options.To.HasValue()) request.AddParameter("To", options.To);
			if (options.Status.HasValue()) request.AddParameter("Status", options.Status);

			var startTimeParameterName = GetParameterNameWithEquality(options.StartTimeComparison, "StartTime");
			var endTimeParameterName = GetParameterNameWithEquality(options.EndTimeComparison, "EndTime");

			if (options.StartTime.HasValue) request.AddParameter(startTimeParameterName, options.StartTime.Value.ToString("yyyy-MM-dd"));
			if (options.EndTime.HasValue) request.AddParameter(endTimeParameterName, options.EndTime.Value.ToString("yyyy-MM-dd"));

			if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
			if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);

			if (options.ParentCallSid.HasValue()) request.AddParameter("ParentCallSid", options.ParentCallSid);
		}

		/// <summary>
		/// Returns the single Call resource identified by {CallSid}
		/// </summary>
		/// <param name="callSid">The Sid of the Call resource to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetCall(string callSid, Action<Call> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";

			request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

			ExecuteAsync<Call>(request, (response) => callback(response));
		}

		/// <summary>
		///  Deletes a single Call resource identified by {CallSid}.
		/// </summary>
		/// <param name="callSid">The Sid of the Call resource to delete.</param>
		/// <param name="callback">Method to call upon completion.</param>
		public virtual void DeleteCall(string callSid, Action<DeleteStatus> callback)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";

			request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
		}

		/// <summary>
		/// Initiates a new phone call.
		/// </summary>
		/// <param name="from">The phone number to use as the caller id. Format with a '+' and country code e.g., +16175551212 (E.164 format). Must be a Twilio number or a valid outgoing caller id for your account.</param>
		/// <param name="to">The number to call formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
		/// <param name="url">The fully qualified URL that should be consulted when the call connects. Just like when you set a URL for your inbound calls. URL should return TwiML.</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void InitiateOutboundCall(string from, string to, string url, Action<Call> callback)
		{
			InitiateOutboundCall(from, to, url, null, callback);
		}

		/// <summary>
		/// Initiates a new phone call.
		/// </summary>
		/// <param name="from">The phone number to use as the caller id. Format with a '+' and country code e.g., +16175551212 (E.164 format). Must be a Twilio number or a valid outgoing caller id for your account.</param>
		/// <param name="to">The number to call formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
		/// <param name="url">The fully qualified URL that should be consulted when the call connects. Just like when you set a URL for your inbound calls. URL should return TwiML.</param>
		/// <param name="statusCallback">A URL that Twilio will request when the call ends to notify your app.</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void InitiateOutboundCall(string from, string to, string url, string statusCallback, Action<Call> callback)
		{
			InitiateOutboundCall(new CallOptions
			{
				From = from,
				To = to,
				Url = url,
				StatusCallback = statusCallback
			},
			callback);
		}

		/// <summary>
		/// Initiates a new phone call.
		/// </summary>
		/// <param name="options">Call settings. Only properties with values set will be used.</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void InitiateOutboundCall(CallOptions options, Action<Call> callback)
		{
			Require.Argument("From", options.From);
			Require.Argument("To", options.To);
			Require.Argument("Url", options.Url);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Calls.json";

			AddCallOptions(options, request);

			ExecuteAsync<Call>(request, (response) => callback(response));
		}

		private static void AddCallOptions(CallOptions options, RestRequest request)
		{
			request.AddParameter("From", options.From);
			request.AddParameter("To", options.To);

			if (options.ApplicationSid.HasValue())
			{
				request.AddParameter("ApplicationSid", options.ApplicationSid);
			}
			else
			{
				request.AddParameter("Url", options.Url);
			}

			if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
			if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod);
			if (options.StatusCallbackEvents != null)
			{
				for (int i = 0; i < options.StatusCallbackEvents.Length; i++)
				{
						request.AddParameter("StatusCallbackEvent", options.StatusCallbackEvents[i]);
				}
			}
			if (options.FallbackUrl.HasValue()) request.AddParameter("FallbackUrl", options.FallbackUrl);
			if (options.FallbackMethod.HasValue()) request.AddParameter("FallbackMethod", options.FallbackMethod);
			if (options.Method.HasValue()) request.AddParameter("Method", options.Method);
			if (options.SendDigits.HasValue()) request.AddParameter("SendDigits", options.SendDigits);
			if (options.IfMachine.HasValue()) request.AddParameter("IfMachine", options.IfMachine);
			if (options.Timeout.HasValue) request.AddParameter("Timeout", options.Timeout.Value);
			if (options.Record) request.AddParameter("Record", "true");
			if (options.SipAuthUsername.HasValue()) request.AddParameter("SipAuthUsername", options.SipAuthUsername);
			if (options.SipAuthPassword.HasValue()) request.AddParameter("SipAuthPassword", options.SipAuthPassword);
			if (options.RecordingStatusCallback.HasValue())
			{
			    request.AddParameter("RecordingStatusCallback", options.RecordingStatusCallback);
			}
			if (options.RecordingStatusCallbackMethod.HasValue())
			{
			  request.AddParameter("RecordingStatusCallbackMethod", options.RecordingStatusCallbackMethod); 
			}
			if (options.RecordingChannels.HasValue()) request.AddParameter("RecordingChannels", options.RecordingChannels);
		}

		/// <summary>
		/// Hangs up a call in progress.
		/// </summary>
		/// <param name="callSid">The Sid of the call to hang up.</param>
		/// <param name="style">'Canceled' will attempt to hangup calls that are queued or ringing but not affect calls already in progress. 'Completed' will attempt to hang up a call even if it's already in progress.</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void HangupCall(string callSid, HangupStyle style, Action<Call> callback)
		{
			Require.Argument("CallSid", callSid);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}.json";

			request.AddUrlSegment("CallSid", callSid);
			request.AddParameter("Status", style.ToString().ToLower());

			ExecuteAsync<Call>(request, (response) => callback(response));
		}

        /// <summary>
        /// Redirect a call in progress to a new TwiML URL.  Makes a POST request to a Call Instance resource.
        /// </summary>
        /// <param name="callSid">The Sid of the call to redirect</param>
        /// <param name="redirectUrl">The URL to redirect the call to.</param>
        /// <param name="redirectMethod">The HTTP method to use when requesting the redirectUrl</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void RedirectCall(string callSid, string redirectUrl, string redirectMethod, Action<Call> callback)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("Url", redirectUrl);

            CallOptions options = new CallOptions();
            options.Url = redirectUrl;
            options.Method = redirectMethod;

            RedirectCall(callSid, options, callback);
        }

        /// <summary>
        /// Redirect a call in progress to a new TwiML URL.  Makes a POST request to a Call Instance resource.
        /// </summary>
        /// <param name="callSid">The Sid of the call to redirect</param>
        /// <param name="options">Call settings. Only Url, Method, FallbackUrl, FallbackMethod, StatusCallback and StatusCallbackMethod properties with values set will be used.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void RedirectCall(string callSid, CallOptions options, Action<Call> callback)
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
            if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod);

            if (options.RecordingStatusCallback.HasValue())
            {
                request.AddParameter("RecordingStatusCallback", options.RecordingStatusCallback);
            }
            if (options.RecordingStatusCallbackMethod.HasValue())
            {
              request.AddParameter("RecordingStatusCallbackMethod", options.RecordingStatusCallbackMethod); 
            }
            if (options.RecordingChannels.HasValue()) request.AddParameter("RecordingChannels", options.RecordingChannels);

            ExecuteAsync<Call>(request, (response) => callback(response));
        }

	}
}
