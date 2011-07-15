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
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// List with paging information
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TwilioList<T> : List<T>
	{
		/// <summary>
		/// The current page number. Zero-indexed, so the first page is 0.
		/// </summary>
		public int Page { get; set; }
		/// <summary>
		/// The total number of pages.
		/// </summary>
		public int NumPages { get; set; }
		/// <summary>
		/// How many items are in each page
		/// </summary>
		public int PageSize { get; set; }
		/// <summary>
		/// The total number of items in the list.
		/// </summary>
		public int Total { get; set; }
		/// <summary>
		/// The position in the overall list of the first item in this page.
		/// </summary>
		public int Start { get; set; }
		/// <summary>
		/// The position in the overall list of the last item in this page.
		/// </summary>
		public int End { get; set; }
		/// <summary>
		/// The URI of the current page.
		/// </summary>
		public Uri Uri { get; set; }
		/// <summary>
		/// The URI for the first page of this list.
		/// </summary>
		public Uri FirstPageUri { get; set; }
		/// <summary>
		/// The URI for the next page of this list.
		/// </summary>
		public Uri NextPageUri { get; set; }
		/// <summary>
		/// The URI for the previous page of this list.
		/// </summary>
		public Uri PreviousPageUri { get; set; }
		/// <summary>
		/// The URI for the last page of this list.
		/// </summary>
		public Uri LastPageUri { get; set; }
	}
}