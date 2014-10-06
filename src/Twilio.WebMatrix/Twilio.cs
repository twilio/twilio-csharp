using System;
using System.Web;
using Twilio;

namespace Twilio.WebMatrix
{
	/// <summary>
	/// A set of Twilio helpers for WebMatrix sites
	/// </summary>
	public class Twilio
	{
		/// <summary>
		/// The AccountSid to authenticate with when making requests
		/// </summary>
		public static string AccountSid { get; set; }
		/// <summary>
		/// The AuthToken to authenticate with when making requests
		/// </summary>
		public static string AuthToken { get; set; }

		/// <summary>
		/// Send an SMS message
		/// </summary>
		/// <param name="from">The number to send the message from</param>
		/// <param name="to">The number to send the message to</param>
		/// <param name="body">The contents of the message, up to 160 characters</param>
		/// <param name="statusCallbackUrl">The URL to notify of the message status</param>
		/// <returns>An SMSMessage Instance resource</returns>
        [Obsolete]
		public static SMSMessage SendSms(string from, string to, string body, string statusCallbackUrl)
		{
			CheckForCredentials();

			var twilio = new TwilioRestClient(AccountSid, AuthToken);
			return twilio.SendSmsMessage(from, to, body, statusCallbackUrl);	
		}

        /// <summary>
        /// Send an message
        /// </summary>
        /// <param name="from">The number to send the message from</param>
        /// <param name="to">The number to send the message to</param>
        /// <param name="body">The contents of the message, up to 160 characters</param>
        /// <param name="statusCallbackUrl">The URL to notify of the message status</param>
        /// <returns>An Message Instance resource</returns>
        public static Message SendMessage(string from, string to, string body, string statusCallbackUrl)
        {
            CheckForCredentials();

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            return twilio.SendMessage(from, to, body, statusCallbackUrl);
        }

		/// <summary>
		/// Initiate a new outgoing call
		/// </summary>
		/// <param name="from">The phone number to call from</param>
		/// <param name="to">The phone number to call to</param>
		/// <param name="url">The TwiML URL to use for controlling this call</param>
		/// <param name="statusCallback">The URL to notify upon completion of the call</param>
		/// <param name="statusCallbackMethod">The HTTP method to use when requesting the statusCallback URL</param>
		/// <param name="fallbackUrl">The URL to request upon encountering an in-call error</param>
		/// <param name="fallbackMethod">The HTTP method to use when requesting the fallbackUrl</param>
		/// <param name="ifMachine">The action to take when encountering an answering machine</param>
		/// <param name="sendDigits">The DTMF touch tone digits to transmit when the call is answered</param>
		/// <param name="timeout">The amount of time to allow a call to ring before ending</param>
		/// <returns>A Call Instance resource</returns>
		public static Call MakeCall(string from, string to, string url, string statusCallback,
									string statusCallbackMethod, string fallbackUrl, string fallbackMethod,
									string ifMachine, string sendDigits, int? timeout = null)
		{
			CheckForCredentials();

			var twilio = new TwilioRestClient(AccountSid, AuthToken);

			var options = new CallOptions();
			options.From = from;
			options.To = to;

			if (!string.IsNullOrEmpty(url))
			{
				options.Url = url;
			}
			else
			{
				options.Url = HttpContext.Current.Request.Url.ToString();
			}

			options.StatusCallback = statusCallback;
			options.StatusCallbackMethod = statusCallbackMethod;
			options.FallbackUrl = fallbackUrl;
			options.FallbackMethod = fallbackMethod;
			options.IfMachine = ifMachine;
			options.SendDigits = sendDigits;
			options.Timeout = timeout;

			return twilio.InitiateOutboundCall(options);
		}

		private static void CheckForCredentials()
		{
			if (string.IsNullOrEmpty(AccountSid) || string.IsNullOrEmpty(AuthToken))
			{
				throw new ApplicationException(@"Twilio credentials have not been specified. Verify Twilio.AccountSid 
											     and Twilio.AuthToken have been set to the values from your account dashboard.");
			}
		}
	}
}
