using System;

namespace Twilio
{
	/// <summary>
	/// Exceptions returned in the HTTP response body when something goes wrong.
	/// </summary>
	public sealed class RestException
	{
		/// <summary>
		/// The HTTP status code for the exception.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// (Conditional) The URL of Twilio's documentation for the error code.
		/// </summary>
		public string MoreInfo { get; set; }
		/// <summary>
		/// (Conditional) An error code to find help for the exception.
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// A more descriptive message regarding the exception.
		/// </summary>
		public string Message { get; set; }
	}
}