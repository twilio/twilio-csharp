using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using System.Reflection;
using RestSharp.Deserializers;
using System.Text;
using System;
using System.Net;

using Twilio.Model;


namespace Twilio
{

    public abstract partial class TwilioClient
    {
        /// <summary>
        /// Twilio API version to use when making requests
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// Base URL of API
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

        protected string AccountSid { get; set; }

        protected string AuthToken { get; set; }

        protected string AccountResourceSid { get; set; }

        protected string DateFormat { get; set; }

        protected RestClient _client;

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        /// <param name="apiVersion"></param>
        /// <param name="baseUrl"></param>
        public TwilioClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl)
        {
            ApiVersion = apiVersion;
            BaseUrl = baseUrl;
            AccountSid = accountSid;
            AuthToken = authToken;
            AccountResourceSid = accountResourceSid;
            DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

            // silverlight friendly way to get current version
            var assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            _client = new RestClient();
            _client.UserAgent = "twilio-csharp/" + version + " (.NET " + Environment.Version.ToString() + ")";
            _client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);

#if FRAMEWORK
            _client.AddDefaultHeader("Accept-charset", "utf-8");
#endif

            _client.BaseUrl = new Uri(string.Format("{0}{1}", BaseUrl, ApiVersion));
            _client.Timeout = 30500;

            // if acting on a subaccount, use request.AddUrlSegment("AccountSid", "value")
            // to override for that request.
            _client.AddDefaultUrlSegment("AccountSid", AccountResourceSid); 
        }

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public virtual T Execute<T>(IRestRequest request) where T : new()
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

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
            };

            request.DateFormat = DateFormat;

            var response = _client.Execute<T>(request);
            return response.Data;
        }

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public virtual IRestResponse Execute(IRestRequest request)
		{
			return _client.Execute(request);
		}
#endif

        protected string GetParameterNameWithEquality(ComparisonType? comparisonType, string parameterName)
        {
            if (comparisonType.HasValue) {
                switch (comparisonType) {
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

    /// <summary>
    /// REST API wrapper.
    /// </summary>
    public partial class TwilioRestClient : TwilioClient
    {
        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        public TwilioRestClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid)
        {
        }

		#if FRAMEWORK

        public virtual T GetNextPage<T>(TwilioListBase resourceResult) where T : TwilioListBase, new()
        {
            var request = new RestRequest();
            request.Resource = resourceResult.NextPageUri.OriginalString.Replace("/" + ApiVersion, "");

            return Execute<T>(request);
        }

        public virtual T GetPreviousPage<T>(TwilioListBase resourceResult) where T : TwilioListBase, new()
        {
            var request = new RestRequest();
            request.Resource = resourceResult.PreviousPageUri.OriginalString.Replace("/" + ApiVersion, "");

            return Execute<T>(request);
        }

		#endif

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        public TwilioRestClient(string accountSid, string authToken, string accountResourceSid) : base(accountSid, authToken, accountResourceSid, "2010-04-01", "https://api.twilio.com/")
        {
        }

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid">The AccountSid for the account you want to use</param>
        /// <param name="apiVersion">The version of the Twilio API to use</param>
        /// <param name="baseUrl">The base URL of the Twilio API</param>
        public TwilioRestClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl) : base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl)
        {
        }
    }
/*
    public partial class NextGenClient : TwilioClient
    {
        public NextGenClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl) : base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl)
        {
        }

		#if FRAMEWORK
		#if !NOASYNCPAGING

        public virtual T GetNextPage<T>(NextGenListBase resourceResult) where T : NextGenListBase, new()
        {
            var request = new RestRequest();
            request.Resource = resourceResult.Meta.NextPageUrl.PathAndQuery.Replace("/" + ApiVersion, "");

            return Execute<T>(request);
        }

        public virtual T GetPreviousPage<T>(NextGenListBase resourceResult) where T : NextGenListBase, new()
        {
            var request = new RestRequest();
            request.Resource = resourceResult.Meta.PreviousPageUrl.PathAndQuery.Replace("/" + ApiVersion, "");

            return Execute<T>(request);
        }

		#endif
		#endif
    }
*/
}
