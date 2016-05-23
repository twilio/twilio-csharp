using System;

namespace Twilio
{
	/// <summary>
	/// An Recording instance resource represents a single Twilio Recording.
	/// </summary>
	public class Recording : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this resource was created
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for this recording.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The call during which the recording was made.
		/// </summary>
		public string CallSid { get; set; }
		/// <summary>
		/// The length of the recording, in seconds.
		/// </summary>
		public int Duration { get; set; }
		/// <summary>
		/// The version of the API in use during the recording.
		/// </summary>
		public string ApiVersion { get; set; }
		/// <summary>
		/// The charge for this recording in USD. Populated after the recording is completed. May not be immediately available. 
		/// Doesn't include storage charge.
		/// </summary>
		public decimal? Price { get; set; }
		/// <summary>
		/// The Price Unit of the recording.
		/// </summary>
		public string PriceUnit { get; set; }
		/// <summary>
		/// The Status of the recording.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The Source of the recording.
		/// </summary>
		public string Source { get; set; }
		/// <summary>
		/// The amount of Channels in the recording.
		/// </summary>
		public string Channels { get; set; }
	}
}
