using System;

namespace Twilio
{
	/// <summary>
	/// Options for handling call hangups
	/// </summary>
	public enum HangupStyle
	{
		/// <summary>
		///  Specifying canceled will attempt to hangup calls that are queued or ringing but not affect calls already in progress.
		/// </summary>
		Canceled,
		/// <summary>
		/// Specifying completed will attempt to hang up a call even if it's already in progress.
		/// </summary>
		Completed
	}
}
