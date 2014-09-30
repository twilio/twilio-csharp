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

		public int? Page { get; set; }
		public int? PageSize { get; set; }
	}
}

