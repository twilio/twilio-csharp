using System;

namespace Twilio
{
	/// <summary>
	/// An Conference instance resource represents a single Twilio Conference.
	/// </summary>
	public class Conference : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this conference.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for creating this conference.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// A user provided string that identifies this conference room.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// A string representing the status of the conference. May be init, in-progress, or completed.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The date that this conference was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this conference was last updated, given as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }
	}
}