using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class IceServer
	{
		[JsonProperty("credential")]
		public string Credential { get; }
		[JsonProperty("username")]
		public string Username { get; }
	    [JsonProperty("url")]
		public Uri Url { get; }

	    public IceServer(string credential, string username, Uri url) {
			Credential = credential;
			Username = username;
			Url = url;
		}
	}
}

