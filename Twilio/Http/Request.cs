using System;
using System.Collections.Generic;
using System.Linq;

namespace Twilio.Http
{
	public class Request
	{
		private Twilio.Http.HttpMethod method;
		private Uri uri;
		private string username;
		private string password;
        private List<KeyValuePair<string, string>> queryParams;
        private List<KeyValuePair<string, string>> postParams;

		public Request(Twilio.Http.HttpMethod method, string uri) : this(method, Twilio.Clients.Domains.API, uri) {
		}

		public Request(Twilio.Http.HttpMethod method, Twilio.Clients.Domains domain, string uri) {
			this.method = method;
			this.uri = new Uri("https://" + domain.ToString() + ".twilio.com" + uri);

			this.queryParams = new List<KeyValuePair<string, string>>();
			this.postParams = new List<KeyValuePair<string, string>>();
		}

		public Uri ConstructURL() {
			return new Uri(uri.AbsoluteUri + "?" + EncodeParameters(queryParams));
        }

		public Twilio.Http.HttpMethod GetMethod() {
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
        
        private static string EncodeParameters(List<KeyValuePair<string, string>> data) {
			var result = "";

			var first = true;

			foreach (var pair in data) {
				if (first) {
					first = false;
				} else {
					result += "&";
				}

				result += pair.Key + "=" + pair.Value;
			}

			return result;
        }
        
		public byte[] EncodePostParams() {
			var content = EncodeParameters(postParams);
			return System.Text.Encoding.UTF8.GetBytes(content);
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

			return method.Equals(other.method) && uri.Equals(other.uri) && queryParams.All(other.queryParams.Contains) && postParams.All(other.postParams.Contains);
		}
			

		public override int GetHashCode() {
			unchecked {
				return (method != null ? method.GetHashCode () : 0) ^ (uri != null ? uri.GetHashCode () : 0) ^ (queryParams != null ? queryParams.GetHashCode () : 0) ^ (postParams != null ? postParams.GetHashCode () : 0);
			}
		}
	}
}
