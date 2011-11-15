using System;
using System.Linq;
using RestSharp;

#if WINDOWS_PHONE
using System.Windows;
#endif

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		/// <param name="callback">The callback function to execute when the async request completes</param>
		public void ExecuteAsync<T>(RestRequest request, Action<T> callback) where T : new()
		{
			request.OnBeforeDeserialization = (resp) =>
			{
				// for individual resources when there's an error to make
				// sure that RestException props are populated
				if (((int)resp.StatusCode) >= 400)
				{
					request.RootElement = "";
				}
			};

			_client.ExecuteAsync<T>(request, (response) =>
			{
				callback(response.Data);
			});
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		/// <param name="callback">The callback function to execute when the async request completes</param>
		public void ExecuteAsync(RestRequest request, Action<RestResponse> callback)
		{
			_client.ExecuteAsync(request, (response) =>
			{
				callback(response);
			});
		}
	}
}