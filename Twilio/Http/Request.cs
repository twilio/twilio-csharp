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

		public Request(System.Net.Http.HttpMethod method, string uri) : this(method, Twilio.Clients.Domains.API, uri) {
		}

		public Request(System.Net.Http.HttpMethod method, Twilio.Clients.Domains domain, string uri) {
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

		public override bool Equals(object obj) {
			if (obj == null)
				return false;
			if (ReferenceEquals (this, obj))
				return true;
			if (obj.GetType () != typeof(Request))
				return false;
			Request other = (Request)obj;
			return method == other.method && uri == other.uri && queryParams == other.queryParams && postParams == other.postParams;
		}
			

		public override int GetHashCode() {
			unchecked {
				return (method != null ? method.GetHashCode () : 0) ^ (uri != null ? uri.GetHashCode () : 0) ^ (queryParams != null ? queryParams.GetHashCode () : 0) ^ (postParams != null ? postParams.GetHashCode () : 0);
			}
		}
	}
}
