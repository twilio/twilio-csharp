using System;
using RestRT;
using RestRT.Extensions;
using RestRT.Validation;
using System.Threading.Tasks;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Twilio
{
	public sealed partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details for an application instance. Makes a GET request to an Application Instance resource.
		/// </summary>
		/// <param name="applicationSid">The Sid of the application to retrieve</param>
        public IAsyncOperation<Application> GetApplicationAsync(string applicationSid)
        {
            return (IAsyncOperation<Application>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetApplicationAsyncInternal(applicationSid));
        }        
        private async Task<Application> GetApplicationAsyncInternal(string applicationSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";
			
			request.AddUrlSegment("ApplicationSid", applicationSid);

            var result = await ExecuteAsync(request, typeof(Application));
            return (Application)result;
		}

		/// <summary>
		/// List applications on current account
		/// </summary>
        public IAsyncOperation<ApplicationResult> ListApplicationsAsync()
        {
            return (IAsyncOperation<ApplicationResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListApplicationsAsyncInternal(null, null, null));
        }

		/// <summary>
		/// List applications on current account with filters
		/// </summary>
		/// <param name="friendlyName">Optional friendly name to match</param>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<ApplicationResult> ListApplicationsAsync(string friendlyName, int? pageNumber, int? count)
        {
            return (IAsyncOperation<ApplicationResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListApplicationsAsyncInternal(friendlyName, pageNumber, count));
        }
        private async Task<ApplicationResult> ListApplicationsAsyncInternal(string friendlyName, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Applications.json";

			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			//return Execute<ApplicationResult>(request);
            var result = await ExecuteAsync(request, typeof(ApplicationResult));
            return (ApplicationResult)result;

		}

		/// <summary>
		/// Create a new application
		/// </summary>
		/// <param name="friendlyName">The friendly name to name the application</param>
		/// <param name="options">Optional parameters to use when purchasing number</param>
        public IAsyncOperation<Application> AddApplicationAsync(string friendlyName, ApplicationOptions options)
        {
            return (IAsyncOperation<Application>)AsyncInfo.Run((System.Threading.CancellationToken ct) => AddApplicationAsyncInternal(friendlyName, options));
        }
        private async Task<Application> AddApplicationAsyncInternal(string friendlyName, ApplicationOptions options)
		{
			var request = new RestRequest();
            request.Method = Method.POST;
			request.Resource = "Accounts/{AccountSid}/Applications.json";
			
			Require.Argument("FriendlyName", friendlyName);
			Validate.IsValidLength(friendlyName, 64);
			request.AddParameter("FriendlyName", friendlyName);

			// some check for null. in those cases an empty string is a valid value (to remove a URL assignment)
			if (options != null)
			{
				if (options.VoiceUrl != null) request.AddParameter("VoiceUrl", options.VoiceUrl);
				if (options.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", options.VoiceMethod.ToString());
				if (options.VoiceFallbackUrl != null) request.AddParameter("VoiceFallbackUrl", options.VoiceFallbackUrl);
				if (options.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", options.VoiceFallbackMethod.ToString());
				if (options.VoiceCallerIdLookup.HasValue) request.AddParameter("VoiceCallerIdLookup", options.VoiceCallerIdLookup.Value);
				if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
				if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod.ToString());
				if (options.SmsUrl != null) request.AddParameter("SmsUrl", options.SmsUrl);
				if (options.SmsMethod.HasValue()) request.AddParameter("SmsMethod", options.SmsMethod.ToString());
				if (options.SmsFallbackUrl != null) request.AddParameter("SmsFallbackUrl", options.SmsFallbackUrl);
				if (options.SmsFallbackMethod.HasValue()) request.AddParameter("SmsFallbackMethod", options.SmsFallbackMethod.ToString());
			}

            var result = await ExecuteAsync(request, typeof(Application));
            return (Application)result;
		}

		/// <summary>
		/// Tries to update the application's properties, and returns the updated resource representation if successful.
		/// </summary>
		/// <param name="applicationSid">The Sid of the application to update</param>
		/// <param name="friendlyName">The friendly name to rename the application to (optional, null to leave as-is)</param>
		/// <param name="options">Which settings to update. Only properties with values set will be updated.</param>
        public IAsyncOperation<Application> UpdateApplicationAsync(string applicationSid, string friendlyName, ApplicationOptions options)
        {
            return (IAsyncOperation<Application>)AsyncInfo.Run((System.Threading.CancellationToken ct) => UpdateApplicationAsyncInternal(applicationSid, friendlyName, options));
        }
        private async Task<Application> UpdateApplicationAsyncInternal(string applicationSid, string friendlyName, ApplicationOptions options)
		{
			Require.Argument("ApplicationSid", applicationSid);

			var request = new RestRequest();
            request.Method = Method.POST;
			request.Resource = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";
			request.AddUrlSegment("ApplicationSid", applicationSid);
			
			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (options != null)
			{
				if (options.VoiceUrl != null) request.AddParameter("VoiceUrl", options.VoiceUrl);
				if (options.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", options.VoiceMethod.ToString());
				if (options.VoiceFallbackUrl != null) request.AddParameter("VoiceFallbackUrl", options.VoiceFallbackUrl);
				if (options.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", options.VoiceFallbackMethod.ToString());
				if (options.VoiceCallerIdLookup.HasValue) request.AddParameter("VoiceCallerIdLookup", options.VoiceCallerIdLookup.Value);
				if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
				if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod.ToString());
				if (options.SmsUrl != null) request.AddParameter("SmsUrl", options.SmsUrl);
				if (options.SmsMethod.HasValue()) request.AddParameter("SmsMethod", options.SmsMethod.ToString());
				if (options.SmsFallbackUrl != null) request.AddParameter("SmsFallbackUrl", options.SmsFallbackUrl);
				if (options.SmsFallbackMethod.HasValue()) request.AddParameter("SmsFallbackMethod", options.SmsFallbackMethod.ToString());
			}

            var result = await ExecuteAsync(request, typeof(Application));
            return (Application)result;
		}

		/// <summary>
		/// Delete this application. If this application's sid is assigned to any IncomingPhoneNumber resources as a VoiceApplicationSid or SmsApplicationSid it will be removed.
		/// </summary>
		/// <param name="applicationSid">The Sid of the number to remove</param>
        public IAsyncOperation<DeleteStatus> DeleteApplicationAsync(string applicationSid)
        {
            return (IAsyncOperation<DeleteStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DeleteApplicationAsyncInternal(applicationSid));
        }        
        private async Task<DeleteStatus> DeleteApplicationAsyncInternal(string applicationSid)
		{
			Require.Argument("ApplicationSid", applicationSid);
			var request = new RestRequest();
            request.Method = Method.DELETE;
			request.Resource = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";

			request.AddUrlSegment("ApplicationSid", applicationSid);

			var response = (RestResponse)await ExecuteAsync(request);
			return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}
	}
}