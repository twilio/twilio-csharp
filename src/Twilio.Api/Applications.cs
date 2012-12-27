using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details for an application instance. Makes a GET request to an Application Instance resource.
		/// </summary>
		/// <param name="applicationSid">The Sid of the application to retrieve</param>
		public Application GetApplication(string applicationSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";

			request.AddUrlSegment("ApplicationSid", applicationSid);

			return Execute<Application>(request);
		}

		/// <summary>
		/// List applications on current account
		/// </summary>
		public ApplicationResult ListApplications()
		{
			return ListApplications(null, null, null);
		}

		/// <summary>
		/// List applications on current account with filters
		/// </summary>
		/// <param name="friendlyName">Optional friendly name to match</param>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
		public ApplicationResult ListApplications(string friendlyName, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Applications.json";

			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<ApplicationResult>(request);
		}

		/// <summary>
		/// Create a new application
		/// </summary>
		/// <param name="friendlyName">The friendly name to name the application</param>
		/// <param name="options">Optional parameters to use when purchasing number</param>
		public Application AddApplication(string friendlyName, ApplicationOptions options)
		{
			var request = new RestRequest(Method.POST);
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

			return Execute<Application>(request);
		}

		/// <summary>
		/// Tries to update the application's properties, and returns the updated resource representation if successful.
		/// </summary>
		/// <param name="applicationSid">The Sid of the application to update</param>
		/// <param name="options">Which settings to update. Only properties with values set will be updated.</param>
		public Application UpdateApplication(string applicationSid, ApplicationOptions options)
		{
			Require.Argument("ApplicationSid", applicationSid);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";
			request.AddUrlSegment("ApplicationSid", applicationSid);
			
			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (options != null)
			{
				if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName.ToString());
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

			return Execute<Application>(request);
		}

		/// <summary>
		/// Tries to update the application's properties, and returns the updated resource representation if successful.
		/// </summary>
		/// <param name="applicationSid">The Sid of the application to update</param>
		/// <param name="friendlyName">The friendly name to rename the application to (optional, null to leave as-is)</param>
		/// <param name="options">Which settings to update. Only properties with values set will be updated.</param>
		public Application UpdateApplication(string applicationSid, string friendlyName, ApplicationOptions options)
		{
			if (friendlyName.HasValue())
			{
				options.FriendlyName = friendlyName;
			}
			return UpdateApplication(applicationSid, options);
		}

		/// <summary>
		/// Delete this application. If this application's sid is assigned to any IncomingPhoneNumber resources as a VoiceApplicationSid or SmsApplicationSid it will be removed.
		/// </summary>
		/// <param name="applicationSid">The Sid of the number to remove</param>
		public DeleteStatus DeleteApplication(string applicationSid)
		{
			Require.Argument("ApplicationSid", applicationSid);
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";

			request.AddUrlSegment("ApplicationSid", applicationSid);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}
	}
}
