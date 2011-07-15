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
	/// An AvailablePhoneNumber instance resource represents a single AvailablePhoneNumber.
	/// </summary>
	public class AvailablePhoneNumber : TwilioBase
	{
		/// <summary>
		/// A nicely-formatted version of the phone number.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The phone number, in E.164 (i.e. "+1") format.
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// The LATA of this phone number.
		/// </summary>
		public string Lata { get; set; }
		/// <summary>
		/// The rate center of this phone number.
		/// </summary>
		public string RateCenter { get; set; }
		/// <summary>
		/// The latitude coordinate of this phone number.
		/// </summary>
		public decimal? Latitude { get; set; }
		/// <summary>
		/// The longitude coordinate of this phone number.
		/// </summary>
		public decimal? Longitude { get; set; }
		/// <summary>
		/// The two-letter state or province abbreviation of this phone number.
		/// </summary>
		public string Region { get; set; }
		/// <summary>
		/// The postal (zip) code of this phone number.
		/// </summary>
		public string PostalCode { get; set; }
		/// <summary>
		/// The ISO country code of this phone number.
		/// </summary>
		public string IsoCountry { get; set; }
	}
}
