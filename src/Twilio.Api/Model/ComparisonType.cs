using System;

namespace Twilio
{
	/// <summary>
	/// Available types of range selections
	/// </summary>
	public enum ComparisonType
	{
		/// <summary>
		/// Selects items equal to value
		/// </summary>
		EqualTo,
		/// <summary>
		/// Selects items greater than or equal to value
		/// </summary>
		GreaterThanOrEqualTo,
		/// <summary>
		/// Selects items less than or equal to value
		/// </summary>
		LessThanOrEqualTo
	}
}