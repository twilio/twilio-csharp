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
	/// Search filter options for AvailablePhoneNumber search
	/// </summary>
	public class AvailablePhoneNumberListRequest
	{
		/// <summary>
		/// Find phone numbers in the specified Area Code. Only available for North American numbers.
		/// </summary>
		public string AreaCode { get; set; }
		/// <summary>
		/// A pattern to match phone numbers on. Valid characters are '*' and [0-9a-zA-Z]. The '*' character will match any single digit.
		/// </summary>
		public string Contains { get; set; }
		/// <summary>
		/// Limit results to a particular region (i.e. State/Province). Given a phone number, search within the same Region as that number.
		/// </summary>
		public string InRegion { get; set; }
		/// <summary>
		/// Limit results to a particular postal code. Given a phone number, search within the same postal code as that number.
		/// </summary>
		public string InPostalCode { get; set; }
		/// <summary>
		/// Given a latitude/longitude pair lat,long find geographically close numbers within Distance miles.
		/// </summary>
		public string NearLatLong { get; set; }
		/// <summary>
		/// Specifies the search radius for a Near- query in miles. If not specified this defaults to 25 miles.
		/// </summary>
		public int? Distance { get; set; }
		/// <summary>
		/// Given a phone number, find a geographically close number within Distance miles. Distance defaults to 25 miles.
		/// </summary>
		public string NearNumber { get; set; }
		/// <summary>
		/// Limit results to a specific Local access and transport area (LATA). Given a phone number, search within the same LATA as that number.
		/// </summary>
		public string InLata { get; set; }
		/// <summary>
		/// Limit results to a specific rate center, or given a phone number search within the same rate center as that number. Requires InLata to be set as well.
		/// </summary>
		public string InRateCenter { get; set; }
	}
}
