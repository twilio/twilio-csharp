using System;
using Twilio.Clients;
using Twilio.Exceptions;

namespace Twilio
{
	public class TwilioClient
	{
		private static string username;
		private static string password;
		private static string accountSid;
		private static TwilioRestClient restClient;

		public TwilioClient () {}

		public static void Init(string username, string password) {
			TwilioClient.SetUsername(username);
			TwilioClient.SetPassword(password);
		}

		public static void Init(string username, string password, string accountSid) {
			TwilioClient.SetUsername(username);
			TwilioClient.SetPassword(password);
			TwilioClient.SetAccountSid(accountSid);
		}

		public static void SetUsername(string username) {
			if (username == null)
				throw new AuthenticationException("Username can not be null");

			if (username != TwilioClient.username)
				TwilioClient.Invalidate();

			TwilioClient.username = username;
		}

		public static void SetPassword(string password) {
			if (password == null)
				throw new AuthenticationException("Password can not be null");

			if (password != TwilioClient.password)
				TwilioClient.Invalidate();

			TwilioClient.password = password;
		}

		public static void SetAccountSid(string accountSid) {
			if (accountSid == null)
				throw new AuthenticationException("AccountSid can not be null");

			if (accountSid != TwilioClient.accountSid)
				TwilioClient.Invalidate();

			TwilioClient.accountSid = accountSid;
		}

		public static TwilioRestClient GetRestClient() {
			if (TwilioClient.restClient == null) {
				if (TwilioClient.username == null || TwilioClient.password == null) {
					throw new AuthenticationException (
						"TwilioRestClient was used before AccountSid and AuthToken were set, please call Twilio.init()"
					);
				}

				if (TwilioClient.accountSid != null) {
					TwilioClient.restClient = new TwilioRestClient(TwilioClient.username, TwilioClient.password, TwilioClient.accountSid);
				} else {
					TwilioClient.restClient = new TwilioRestClient(TwilioClient.username, TwilioClient.password);
				}
			}

			return TwilioClient.restClient;
		}

		public static void SetRestClient(TwilioRestClient restClient) {
			TwilioClient.restClient = restClient;
		}

		public static void Invalidate() {
			TwilioClient.restClient = null;
		}
	}
}

