using RestRT;
using RestRT.Extensions;
using System.Reflection;
using RestRT.Deserializers;
using System.Text;
using System;
using System.Threading.Tasks;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;
using RestRT.Authenticators;

namespace Twilio
{
	/// <summary>
	/// REST API wrapper.
	/// </summary>
	public sealed partial class TwilioRestClient
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
			//var assembly = Assembly.GetExecutingAssembly();
			//AssemblyName assemblyName = new AssemblyName(assembly.FullName);
			//var version = assemblyName.Version;

            var asmName = this.GetType().AssemblyQualifiedName;
            var versionExpression = new System.Text.RegularExpressions.Regex("Version=(?<version>[0-9.]*)");
            var m = versionExpression.Match(asmName);
            string version = String.Empty;
            if (m.Success)
            {
                version = m.Groups["version"].Value;
            }

			_client = new RestClient();
			_client.UserAgent = "twilio-csharp/" + version; 
			_client.Authenticator = new HttpBasicAuthenticator(AccountSid, AuthToken);
			_client.BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion);

			// if acting on a subaccount, use request.AddUrlSegment("AccountSid", "value")
			// to override for that request.
			_client.AddDefaultUrlSegment("AccountSid", AccountSid); 
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
        //public T Execute<T>(RestRequest request) where T : new()
        //{
        //    request.OnBeforeDeserialization = (resp) =>
        //    {
        //        // for individual resources when there's an error to make
        //        // sure that RestException props are populated
        //        if (((int)resp.StatusCode) >= 400)
        //        {
        //            // have to read the bytes so .Content doesn't get populated
        //            var content = resp.RawBytes.AsString();
        //            var json = JObject.Parse(content);
        //            var newJson = new JObject();
        //            newJson["RestException"] = json;
        //            resp.Content = null;
        //            resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
        //        }
        //    };

        //    request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

        //    var response = _client.Execute<T>(request);
        //    return response.Data;
        //}

        public IAsyncOperation<object> ExecuteAsync(IRestRequest request)
        {
            return (IAsyncOperation<object>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ExecuteAsyncInternal(request));
        }
        private async Task<object> ExecuteAsyncInternal(IRestRequest request)
        {
            var result = await _client.ExecuteAsync(request);

            return result;
        }
		
        /// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
        public IAsyncOperation<object> ExecuteAsync(IRestRequest request, Type type)
        {
            return (IAsyncOperation<object>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ExecuteAsyncInternal(request, type));
        }
		private async Task<object> ExecuteAsyncInternal(IRestRequest request, Type type)
		{
            var result = await _client.ExecuteAsync(request);

            if (result.StatusCode >= 400)
            {
                // have to read the bytes so .Content doesn't get populated
                //var content = result.RawBytes.AsString();
                //var json = JObject.Parse(content);
                //var newJson = new JObject();
                //newJson["RestException"] = json;
                //result.Content = null;
                //result.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());

                // have to read the bytes so .Content doesn't get populated
                string restException = "{{ \"RestException\" : {0} }}";
                var content = result.RawBytes.AsString(); //get the response content
                var newJson = string.Format(restException, content);

                result.Content = null;
                result.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
            }

            var deserializer = new RestRT.Deserializers.JsonDeserializer();
            return deserializer.Deserialize(result, type);
		}

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