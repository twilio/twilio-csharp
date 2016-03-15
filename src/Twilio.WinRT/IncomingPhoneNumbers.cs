using RestRT;
using RestRT.Extensions;
using RestRT.Validation;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Twilio
{
	public partial class TwilioRestClient
    {
		/// <summary>
		/// Retrieve the details for an incoming phone number
		/// </summary>
		/// <param name="incomingPhoneNumberSid">The Sid of the number to retrieve</param>
        public IAsyncOperation<IncomingPhoneNumber> GetIncomingPhoneNumberAsync(string incomingPhoneNumberSid)
        {
            return (IAsyncOperation<IncomingPhoneNumber>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetIncomingPhoneNumberAsyncInternal(incomingPhoneNumberSid));
        }
        private async Task<IncomingPhoneNumber> GetIncomingPhoneNumberAsyncInternal(string incomingPhoneNumberSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";
			
			request.AddUrlSegment("IncomingPhoneNumberSid", incomingPhoneNumberSid);

            var result = await ExecuteAsync(request, typeof(IncomingPhoneNumber));
            return (IncomingPhoneNumber)result;
		}

		/// <summary>
		/// List all incoming phone numbers on current account
		/// </summary>
        public IAsyncOperation<IncomingPhoneNumberResult> ListIncomingPhoneNumbersAsync()
        {
            return (IAsyncOperation<IncomingPhoneNumberResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListIncomingPhoneNumbersAsyncInternal(null,null,null,null));
        }

		/// <summary>
		/// List incoming phone numbers on current account with filters
		/// </summary>
		/// <param name="phoneNumber">Optional phone number to match</param>
		/// <param name="friendlyName">Optional friendly name to match</param>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<IncomingPhoneNumberResult> ListIncomingPhoneNumbersAsync(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            return (IAsyncOperation<IncomingPhoneNumberResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListIncomingPhoneNumbersAsyncInternal(phoneNumber, friendlyName, pageNumber, count));
        }
        private async Task<IncomingPhoneNumberResult> ListIncomingPhoneNumbersAsyncInternal(string phoneNumber, string friendlyName, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers.json";

			if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(IncomingPhoneNumberResult));
            return (IncomingPhoneNumberResult)result;
        }

		/// <summary>
		/// Purchase/provision a local phone number
		/// </summary>
		/// <param name="options">Optional parameters to use when purchasing number</param>
        public IAsyncOperation<IncomingPhoneNumber> AddIncomingPhoneNumberAsync(PhoneNumberOptions options)
        {
            return (IAsyncOperation<IncomingPhoneNumber>)AsyncInfo.Run((System.Threading.CancellationToken ct) => AddIncomingPhoneNumberAsyncInternal(options));
        }
        private async Task<IncomingPhoneNumber> AddIncomingPhoneNumberAsyncInternal(PhoneNumberOptions options)
		{
			var request = new RestRequest();
            request.Method = Method.POST;
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers.json";
			
			if (options.PhoneNumber.HasValue())
			{
				request.AddParameter("PhoneNumber", options.PhoneNumber);
			}
			else
			{
				if (options.AreaCode.HasValue()) request.AddParameter("AreaCode", options.AreaCode);
			}

			AddPhoneNumberOptionsToRequest(request, options);
			AddSmsOptionsToRequest(request, options);

            var result = await ExecuteAsync(request, typeof(IncomingPhoneNumber));
            return (IncomingPhoneNumber)result;
		}

		/// <summary>
		/// Update the settings of an incoming phone number
		/// </summary>
		/// <param name="incomingPhoneNumberSid">The Sid of the phone number to update</param>
		/// <param name="options">Which settings to update. Only properties with values set will be updated.</param>
        public IAsyncOperation<IncomingPhoneNumber> UpdateIncomingPhoneNumberAsync(string incomingPhoneNumberSid, PhoneNumberOptions options)
        {
            return (IAsyncOperation<IncomingPhoneNumber>)AsyncInfo.Run((System.Threading.CancellationToken ct) => UpdateIncomingPhoneNumberAsyncInternal(incomingPhoneNumberSid, options));
        }
        private async Task<IncomingPhoneNumber> UpdateIncomingPhoneNumberAsyncInternal(string incomingPhoneNumberSid, PhoneNumberOptions options)
		{
			Require.Argument("IncomingPhoneNumberSid", incomingPhoneNumberSid);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";
			
			request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);
			AddPhoneNumberOptionsToRequest(request, options);
			AddSmsOptionsToRequest(request, options);

            var result = await ExecuteAsync(request, typeof(IncomingPhoneNumber));
            return (IncomingPhoneNumber)result;
        }

		/// <summary>
		/// Remove (deprovision) a phone number from the current account
		/// </summary>
		/// <param name="incomingPhoneNumberSid">The Sid of the number to remove</param>
        public IAsyncOperation<DeleteStatus> DeleteIncomingPhoneNumberAsync(string incomingPhoneNumberSid)
        {
            return (IAsyncOperation<DeleteStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DeleteIncomingPhoneNumberAsyncInternal(incomingPhoneNumberSid));
        }
        private async Task<DeleteStatus> DeleteIncomingPhoneNumberAsyncInternal(string incomingPhoneNumberSid)
		{
			Require.Argument("IncomingPhoneNumberSid", incomingPhoneNumberSid);
            var request = new RestRequest();
            request.Method = Method.DELETE;

			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";

			request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        private void AddPhoneNumberOptionsToRequest(RestRequest request, PhoneNumberOptions options)
		{
            if (options.AccountSid.HasValue())
            {
                request.AddParameter("AccountSid", options.AccountSid);
            }

			if (options.FriendlyName.HasValue())
			{
				Validate.IsValidLength(options.FriendlyName, 64);
				request.AddParameter("FriendlyName", options.FriendlyName);
			}
			// some check for null. in those cases an empty string is a valid value (to remove a URL assignment)
			if (options.VoiceApplicationSid != null) request.AddParameter("VoiceApplicationSid", options.VoiceApplicationSid);

			if (options.VoiceUrl != null) request.AddParameter("VoiceUrl", options.VoiceUrl);
			if (options.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", options.VoiceMethod.ToString());
			if (options.VoiceFallbackUrl != null) request.AddParameter("VoiceFallbackUrl", options.VoiceFallbackUrl);
			if (options.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", options.VoiceFallbackMethod.ToString());
			if (options.VoiceCallerIdLookup.HasValue) request.AddParameter("VoiceCallerIdLookup", options.VoiceCallerIdLookup.Value);
			if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
			if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod.ToString());
		}

		private void AddSmsOptionsToRequest(RestRequest request, PhoneNumberOptions options)
		{
			// some check for null. in those cases an empty string is a valid value (to remove a URL assignment)
			if (options.SmsApplicationSid != null) request.AddParameter("SmsApplicationSid", options.SmsApplicationSid);
			if (options.SmsUrl != null) request.AddParameter("SmsUrl", options.SmsUrl);
			if (options.SmsMethod.HasValue()) request.AddParameter("SmsMethod", options.SmsMethod.ToString());
			if (options.SmsFallbackUrl != null) request.AddParameter("SmsFallbackUrl", options.SmsFallbackUrl);
			if (options.SmsFallbackMethod.HasValue()) request.AddParameter("SmsFallbackMethod", options.SmsFallbackMethod.ToString());
		}	
	}
}