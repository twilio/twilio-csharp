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
using RestSharp.Extensions;
using RestSharp.Validation;


namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns the Sandbox resource associated with the account identified by {YourAccountSid}. 
		/// Twilio accounts upgraded prior to February 2010 may not have a Sandbox resource, and in this case you will receive a 404 (Not Found) response.
		/// Makes a GET request to the Sandbox Instance resource.
		/// </summary>
		public Sandbox GetSandbox()
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Sandbox";

			return Execute<Sandbox>(request);
		}

		/// <summary>
		/// Update the TwiML voice and SMS URLs associated with the sandbox number.
		/// Makes a POST request to the Sandbox Instance resource.
		/// </summary>
		/// <param name="voiceUrl">The URL to use for incoming calls to your sandbox number.</param>
		/// <param name="voiceMethod">The HTTP method to use for incoming calls to your sandbox number.</param>
		/// <param name="smsUrl">The URL to use for incoming SMS text messages sent to your sandbox number.</param>
		/// <param name="smsMethod">The HTTP method to use for incoming text messages sent to your sandbox number.</param>
		public Sandbox UpdateSandbox(string voiceUrl, string voiceMethod, string smsUrl, string smsMethod)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Sandbox";

			request.AddParameter("VoiceUrl", voiceUrl);
			request.AddParameter("VoiceMethod", voiceMethod);
			request.AddParameter("SmsUrl", smsUrl);
			request.AddParameter("SmsMethod", smsMethod);

			return Execute<Sandbox>(request);
		}
	}
}