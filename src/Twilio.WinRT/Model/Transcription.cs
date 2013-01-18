using System;

namespace Twilio
{
	/// <summary>
	/// An Transcription instance resource represents a single Twilio Transcription.
	/// </summary>
	public sealed class Transcription //: TwilioBase
	{
        /// <summary>
        /// Exception encountered during API request
        /// </summary>
        public RestException RestException { get; set; }
        /// <summary>
        /// The URI for this resource, relative to https://api.twilio.com
        /// </summary>
        public Uri Uri { get; set; }


		/// <summary>
		/// A 34 character string that uniquely identifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this resource was created
		/// </summary>
		public DateTimeOffset DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTimeOffset DateUpdated { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for this transcription.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// A string representing the status of the transcription: in-progress, completed or failed.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The unique id of the Recording this Transcription was made of.
		/// </summary>
		public string RecordingSid { get; set; }
		/// <summary>
		/// The duration of the transcribed audio, in seconds.
		/// </summary>
		public int Duration { get; set; }
		/// <summary>
		/// The text content of the transcription.
		/// </summary>
		public string TranscriptionText { get; set; }
		/// <summary>
		/// The charge for this transcript in USD. Populated after the transcript is completed. Note, this value may not be immediately available.
		/// </summary>
		public double? Price { get; set; }
	}
}