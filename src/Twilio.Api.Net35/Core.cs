using System.Reflection;
using System.Text;
using System;
using System.Net;

namespace Twilio
{
	/// <summary>
	/// REST API wrapper.
	/// </summary>
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Twilio API version to use when making requests
		/// </summary>
        public string ApiVersion { get; private set; }
		/// <summary>
		/// Base URL of API (defaults to https://api.twilio.com)
		/// </summary>
        public string BaseUrl { get; private set; }

#if FRAMEWORK
        /// <summary>
        /// 
        /// </summary>
        public IWebProxy Proxy {
            get { return _client.Proxy; }
            set { _client.Proxy = value; }
        }
#endif

		private string AccountSid { get; set; }
		private string AuthToken { get; set; }
        private string AccountResourceSid { get; set; }

        private string AuthorizationToken
        {
            get
            {
                var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", this.AccountSid, this.AuthToken)));
                return string.Format("Basic {0}", token);
            }
        }

		private RestClient _client;

		/// <summary>
		/// Initializes a new client with the specified credentials.
		/// </summary>
		/// <param name="accountSid">The AccountSid to authenticate with</param>
		/// <param name="authToken">The AuthToken to authenticate with</param>
        public TwilioRestClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid) { }

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        public TwilioRestClient(string accountSid, string authToken, string accountResourceSid)
        {
            ApiVersion = "2010-04-01";
            BaseUrl = "https://api.twilio.com/";
            AccountSid = accountSid;
            AuthToken = authToken;
            AccountResourceSid = accountResourceSid;

            // silverlight friendly way to get current version
            var assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            _client = new RestClient();
            _client.UserAgent = "twilio-csharp/" + version + " (.NET " + Environment.Version.ToString() + ")";

            //_client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);
            _client.DefaultParameters.Add(new Parameter() { Name = "Authorization", Value = AuthorizationToken, Type = ParameterType.HttpHeader });

#if FRAMEWORK
            _client.DefaultParameters.Add(new Parameter() { Name = "Accept-charset", Value = "utf-8", Type = ParameterType.HttpHeader });
#endif

            _client.BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion);
            _client.Timeout = 30500;

            // if acting on a subaccount, use request.AddUrlSegment("AccountSid", "value")
            // to override for that request.
            _client.DefaultParameters.Add(new Parameter() { Name = "AccountSid", Value = AccountResourceSid, Type = ParameterType.UrlSegment });
        }

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public virtual T Execute<T>(RestRequest request) where T : new()
		{
			request.OnBeforeDeserialization = (resp) =>
			{
				// for individual resources when there's an error to make
				// sure that RestException props are populated
				if (((int)resp.StatusCode) >= 400)
				{
					// have to read the bytes so .Content doesn't get populated
                    string restException = "{{ \"RestException\" : {0} }}";
					var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

                    System.Diagnostics.Debug.WriteLine(resp.RawBytes);

                    resp.Content = null;
                    byte[] newbytes= Encoding.UTF8.GetBytes(newJson.ToString());
					resp.RawBytes = newbytes;

                    System.Diagnostics.Debug.WriteLine(resp.RawBytes);

                    string foo = "bar";
				}
			};

			request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

			var response = _client.Execute<T>(request);
			return response.Data;
            
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
        //public virtual IRestResponse Execute(IRestRequest request)
        //{
        //    return _client.Execute(request);
        //}
#endif

		private string GetParameterNameWithEquality(ComparisonType? comparisonType, string parameterName)
		{
			if (comparisonType.HasValue)
			{
				switch (comparisonType)
				{
					case ComparisonType.GreaterThanOrEqualTo:
						parameterName += ">";
						break;
					case ComparisonType.LessThanOrEqualTo:
						parameterName += "<";
						break;
				}
			}
			return parameterName;
		}
	}
}
