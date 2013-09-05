using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Twilio.TwiML
{
	/// <summary>
	/// Class used to validate incoming requests from Twilio using 'Request Validation' as described
	/// in the Security section of the Twilio TwiML API documentation.
	/// </summary>
	public class RequestValidator
	{
		/// <summary>
		/// Performs request validation using the current HTTP context passed in manually or from
		/// the ASP.NET MVC ValidateRequestAttribute
		/// </summary>
		/// <param name="context">HttpContext to use for validation</param>
		/// <param name="authToken">AuthToken for the account used to sign the request</param>
		public bool IsValidRequest(HttpContext context, string authToken)
		{
			return IsValidRequest(context, authToken, null);
		}

		/// <summary>
		/// Performs request validation using the current HTTP context passed in manually or from
		/// the ASP.NET MVC ValidateRequestAttribute
		/// </summary>
		/// <param name="context">HttpContext to use for validation</param>
		/// <param name="authToken">AuthToken for the account used to sign the request</param>
		/// <param name="urlOverride">The URL to use for validation, if different from Request.Url (sometimes needed if web site is behind a proxy or load-balancer)</param>
		public bool IsValidRequest(HttpContext context, string authToken, string urlOverride)
		{
			if (context.Request.IsLocal)
			{
				return true;
			}

			// validate request
			// http://www.twilio.com/docs/security-reliability/security
			// Take the full URL of the request, from the protocol (http...) through the end of the query string (everything after the ?)
			var value = new StringBuilder();
			var fullUrl = string.IsNullOrEmpty(urlOverride) ? context.Request.Url.AbsoluteUri : urlOverride;

			value.Append(fullUrl);

			// If the request is a POST, take all of the POST parameters and sort them alphabetically.
			if (context.Request.HttpMethod == "POST")
			{
				// Iterate through that sorted list of POST parameters, and append the variable name and value (with no delimiters) to the end of the URL string
				var sortedKeys = context.Request.Form.AllKeys.OrderBy(k => k, StringComparer.Ordinal).ToList();
				foreach (var key in sortedKeys)
				{
					value.Append(key);
					value.Append(context.Request.Form[key]);
				}
			}

			// Sign the resulting value with HMAC-SHA1 using your AuthToken as the key (remember, your AuthToken's case matters!).
			var sha1 = new HMACSHA1(Encoding.UTF8.GetBytes(authToken));
			var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(value.ToString()));

			// Base64 encode the hash
			var encoded = Convert.ToBase64String(hash);

			// Compare your hash to ours, submitted in the X-Twilio-Signature header. If they match, then you're good to go.
			var sig = context.Request.Headers["X-Twilio-Signature"];

			return sig == encoded;
		}
	}
}
