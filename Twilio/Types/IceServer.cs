using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class IceServer
	{
		[JsonProperty("credential")]
		private string credential;
		[JsonProperty("username")]
		private string username;
		[JsonProperty("url")]
		private Uri url;

		public IceServer(string credential, string username, Uri url) {
			this.credential = credential;
			this.username = username;
			this.url = url;
		}

		public string GetCredential() {
			return credential;
		}

		public string GetUsername() {
			return username;
		}

		public Uri GetUrl() {
			return url;
		}
	}
}

