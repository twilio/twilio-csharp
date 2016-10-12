using Twilio.Clients;
using Twilio.Exceptions;

namespace Twilio
{
	public class TwilioClient
	{
		private static string _username;
		private static string _password;
		private static string _accountSid;
		private static TwilioRestClient _restClient;

		private TwilioClient() {}

		public static void Init(string username, string password)
		{
			SetUsername(username);
			SetPassword(password);
		}

		public static void Init(string username, string password, string accountSid)
		{
			SetUsername(username);
			SetPassword(password);
			SetAccountSid(accountSid);
		}

		public static void SetUsername(string username)
		{
		    if (username == null)
		    {
		        throw new AuthenticationException("Username can not be null");
		    }

		    if (username != _username)
		    {
		        Invalidate();
		    }

			_username = username;
		}

		public static void SetPassword(string password) {
		    if (password == null)
		    {
		        throw new AuthenticationException("Password can not be null");
		    }

		    if (password != _password)
		    {
		        Invalidate();
		    }

			_password = password;
		}

		public static void SetAccountSid(string accountSid)
		{
		    if (accountSid == null)
		    {
		        throw new AuthenticationException("AccountSid can not be null");
		    }

		    if (accountSid != _accountSid)
		    {
		        Invalidate();
		    }

			_accountSid = accountSid;
		}

		public static TwilioRestClient GetRestClient()
		{
		    if (_restClient != null)
		    {
		        return _restClient;
		    }

		    if (_username == null || _password == null)
		    {
		        throw new AuthenticationException (
		            "TwilioRestClient was used before AccountSid and AuthToken were set, please call Twilio.init()"
		        );
		    }

		    _restClient = new TwilioRestClient(_username, _password, accountSid: _accountSid);
		    return _restClient;
		}

		public static void SetRestClient(TwilioRestClient restClient)
		{
			_restClient = restClient;
		}

		public static void Invalidate()
		{
			_restClient = null;
		}
	}
}

