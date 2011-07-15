#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using RestSharp;


namespace Twilio
{
	/// <summary>
	/// REST API wrapper.
	/// </summary>
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Twilio API version to use when making requests
		/// </summary>
		public string ApiVersion { get; set; }
		/// <summary>
		/// Base URL of API (defaults to https://api.twilio.com)
		/// </summary>
		public string BaseUrl { get; set; }
		private string AccountSid { get; set; }
		private string AuthToken { get; set; }

		private RestClient _client;

		/// <summary>
		/// Initializes a new client with the specified credentials.
		/// </summary>
		/// <param name="accountSid">The AccountSid to authenticate with</param>
		/// <param name="authToken">The AuthToken to authenticate with</param>
		public TwilioRestClient(string accountSid, string authToken)
		{
			ApiVersion = "2010-04-01"; 
			BaseUrl = "https://api.twilio.com/";
			AccountSid = accountSid;
			AuthToken = authToken;

			_client = new RestClient();
			_client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);
			_client.BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion);

			// if acting on a subaccount, use request.AddUrlSegment("AccountSid", "value")
			// to override for that request.
			_client.AddDefaultUrlSegment("AccountSid", AccountSid); 
		}

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public T Execute<T>(RestRequest request) where T : new()
		{
			var response = _client.Execute<T>(request);
			return response.Data;
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public RestResponse Execute(RestRequest request)
		{
			return _client.Execute(request);
		}
#endif

		private string GetParameterNameWithEquality(ComparisonType? comparisonType, string parameterName)
		{
			if (comparisonType.HasValue)
			{
				switch (comparisonType)
				{
					case ComparisonType.GreaterThanOrEqualTo:
						parameterName += ">";
						break;
					case ComparisonType.LessThanOrEqualTo:
						parameterName += "<";
						break;
				}
			}
			return parameterName;
		}
	}
}