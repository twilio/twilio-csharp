using System;

namespace Twilio
{
	public class AddressListRequest
	{
		/// <summary>
		/// Only show Addresses with this friendly name.
		/// </summary>
		public string FriendlyName { get; set; }

		/// <summary>
		/// Only show Addresses with this customer name.
		/// </summary>
		public string CustomerName { get; set; }

		/// <summary>
		/// Only show Addresses located in this country.
		/// </summary>
		public string IsoCountry { get; set; }

    [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public int? Page { get; set; }

		public int? PageSize { get; set; }
	}
}

