using RestSharp;
using RestSharp.Extensions;
using System.Reflection;
using RestSharp.Deserializers;
using Newtonsoft.Json.Linq;
using System.Text;

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
		public string ApiVersion { get; set; }
		/// <summary>
		/// Base URL of API (defaults to https://api.twilio.com)
		/// </summary>
		public string BaseUrl { get; set; }
		private string AccountSid { get; set; }
		private string AuthToken { get; set; }

		private RestClient _client;

		/// <summary>
		/// Initializes a new client with the specified credentials.
		/// </summary>
		/// <param name="accountSid">The AccountSid to authenticate with</param>
		/// <param name="authToken">The AuthToken to authenticate with</param>
		public TwilioRestClient(string accountSid, string authToken)
		{
			ApiVersion = "2010-04-01"; 
			BaseUrl = "https://api.twilio.com/";
			AccountSid = accountSid;
			AuthToken = authToken;

			// silverlight friendly way to get current version
			var assembly = Assembly.GetExecutingAssembly();
			AssemblyName assemblyName = new AssemblyName(assembly.FullName);
			var version = assemblyName.Version;

			_client = new RestClient();
			_client.UserAgent = "twilio-csharp/" + version; 
			_client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);
			_client.BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion);

			// if acting on a subaccount, use request.AddUrlSegment("AccountSid", "value")
			// to override for that request.
			_client.AddDefaultUrlSegment("AccountSid", AccountSid); 
		}

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public T Execute<T>(RestRequest request) where T : new()
		{
			request.OnBeforeDeserialization = (resp) =>
			{
				// for individual resources when there's an error to make
				// sure that RestException props are populated
				if (((int)resp.StatusCode) >= 400)
				{
					// have to read the bytes so .Content doesn't get populated
					var content = resp.RawBytes.AsString();
					var json = JObject.Parse(content);
					var newJson = new JObject();
					newJson["RestException"] = json;
					resp.Content = null;
					resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
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
		public IRestResponse Execute(IRestRequest request)
		{
			return _client.Execute(request);
		}
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
