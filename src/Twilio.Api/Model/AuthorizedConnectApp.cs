using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// An AuthorizedConnectApp instance
	/// </summary>
	public class AuthorizedConnectApp : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this authorized app.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The AccountSid of the SubAccount this Connect App has access to.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The date that this account was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this account was last updated, given in as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// The set of permissions that you have authorized for this Connect App. Valid permisisons are get-all or post-all.
		/// </summary>
		public List<string> Permissions { get; set; }
		/// <summary>
		/// A human readable name for the Connect App.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// A more detailed human readable description of the Connect App.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// The company name set for this Connect App.
		/// </summary>
		public string CompanyName { get; set; }
		/// <summary>
		/// The public URL for this Connect App.
		/// </summary>
		public string HomepageUrl { get; set; }
	}
}