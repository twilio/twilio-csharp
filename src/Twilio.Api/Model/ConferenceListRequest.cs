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

using System;

namespace Twilio
{
	/// <summary>
	/// Options for filtering list of Conference instances from API
	/// </summary>
	public class ConferenceListRequest
	{
		/// <summary>
		/// Only show conferences currently in with this status. May be init, in-progress, or completed.
		/// </summary>
		public int? Status { get; set; }
		/// <summary>
		/// List conferences who's FriendlyName is the exact match of this string.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// Only show conferences that started on this date. For comparison options, specify DateCreatedComparison value.
		/// </summary>
		public DateTime? DateCreated { get; set; }
		/// <summary>
		/// Type of comparison to perform with DateCreated filter parameter
		/// </summary>
		public ComparisonType DateCreatedComparison { get; set; }
		/// <summary>
		/// Only show conferences that were last updated on this date. For comparison options, specify DateUpdatedComparison value.
		/// </summary>
		public DateTime? DateUpdated { get; set; }
		/// <summary>
		/// Type of comparison to perform with DateUpdated filter parameter
		/// </summary>
		public ComparisonType DateUpdatedComparison { get; set; }
		/// <summary>
		/// Which page to view. Zero-indexed, so the first page is 0. The default is 0.
		/// </summary>
		public int? PageNumber { get; set; }
		/// <summary>
		/// How many resources to return in each list page. The default is 50, and the maximum is 1000.
		/// </summary>
		public int? Count { get; set; }
	}
}