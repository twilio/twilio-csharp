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

namespace Twilio
{
	/// <summary>
	/// Exceptions returned in the HTTP response body when something goes wrong.
	/// </summary>
	public class RestException
	{
		/// <summary>
		/// The HTTP status code for the exception.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// (Conditional) The URL of Twilio's documentation for the error code.
		/// </summary>
		public string MoreInfo { get; set; }
		/// <summary>
		/// (Conditional) An error code to find help for the exception.
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// A more descriptive message regarding the exception.
		/// </summary>
		public string Message { get; set; }
	}
}