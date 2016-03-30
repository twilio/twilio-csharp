using System;
using System.Collections.Generic;

namespace Twilio.Http
{
	public class Request
	{
		private System.Net.Http.HttpMethod method;
		private Uri uri;
		private string username;
		private string password;
        private List<KeyValuePair<string, string>> queryParams;
        private List<KeyValuePair<string, string>> postParams;

		public Request(System.Net.Http.HttpMethod method, string uri) : this(method, Twilio.Clients.TwilioRestClient.Domains.API, uri) {
		}

		public Request(System.Net.Http.HttpMethod method, Twilio.Clients.TwilioRestClient.Domains domain, string uri) {
			this.method = method;
			this.uri = new Uri("https://" + domain.ToString() + ".twilio.com" + uri);

			this.queryParams = new List<KeyValuePair<string, string>>();
			this.postParams = new List<KeyValuePair<string, string>>();
		}

		public Uri ConstructURL() {
			return uri;
        }

		public System.Net.Http.HttpMethod GetMethod() {
            return this.method;
        }
        
        public string GetUsername() {
            return this.username;
        }
        
        public string GetPassword() {
            return this.password;
        }

		public void SetAuth(string username, string password) {
			this.username = username;
			this.password = password;
		}
        
        private static System.Net.Http.HttpContent EncodeParameters(List<KeyValuePair<string, string>> data) {
            return new System.Net.Http.FormUrlEncodedContent(data);
        }
        
        public System.Net.Http.HttpContent EncodePostParams() {
            return EncodeParameters(this.postParams);
        }

		public void AddQueryParam(string name, string value) {
			AddParam(queryParams, name, value);
		}

		public void AddPostParam(string name, string value) {
			AddParam(postParams, name, value);
		}

		private void AddParam(List<KeyValuePair<string, string>> list, string name, string value) {
			list.Add(new KeyValuePair<string, string> (name, value));
		}
	}
}
