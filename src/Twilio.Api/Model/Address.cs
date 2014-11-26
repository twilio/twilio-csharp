using System;

namespace Twilio
{
	/// <summary>
	/// An Address resource represents a single address to be associated with Twilio Phone Numbers.
	/// </summary>
	public class Address : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this address.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for creating this address.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// A user provided string that identifies this address.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// Gets or sets the name of the customer.
		/// </summary>
		/// <value>The name of the customer.</value>
		public string CustomerName { get; set; }
		/// <summary>
		/// Gets or sets the street component of the address.
		/// </summary>
		/// <value>The street number and name.</value>
		public string Street { get; set; }
		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>The city.</value>
		public string City { get; set; }
		/// <summary>
		/// Gets or sets the region.
		/// </summary>
		/// <value>The region.</value>
		public string Region { get; set; }
		/// <summary>
		/// Gets or sets the postal code.
		/// </summary>
		/// <value>The postal code.</value>
		public string PostalCode { get; set; }
		/// <summary>
		/// The ISO country code for this address.
		/// </summary>
		/// <value>An ISO-3166-1 alpha-2 (two-letter) country code.</value>
		public string IsoCountry { get; set; }

		/// <summary>
		/// The date that this address was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this address was last updated, given as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }

	}
}

