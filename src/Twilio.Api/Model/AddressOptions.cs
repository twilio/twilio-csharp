using System;

namespace Twilio
{
	public class AddressOptions
	{
		/// <summary>
		/// An optional string that identifies this address. 64 characters maximum.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// You or your customer's name or business name.
		/// </summary>
		public string CustomerName { get; set; }
		/// <summary>
		/// The number and street address where you or your customer are located.
		/// </summary>	
		public string Street { get; set; }
		/// <summary>
		/// The city in which you or your customer are located.
		/// </summary>
		/// <value>The city.</value>
		public string City { get; set; }
		/// <summary>
		/// The state or region in which you or your customer are located.
		/// </summary>
		/// <value>The region.</value>
		public string Region { get; set; }
		/// <summary>
		/// The postal code in which you or your customer are located.
		/// </summary>
		/// <value>The postal code.</value>
		public string PostalCode { get; set; }
    }
}
