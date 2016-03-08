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

		public Request (System.Net.Http.HttpMethod method, Uri uri)
		{
			this.method = method;
			this.uri = uri;
		}

		public Uri constructURL() {
			return uri;
        }

		public System.Net.Http.HttpMethod getMethod() {
            return this.method;
        }
        
        public string getUsername() {
            return this.username;
        }
        
        public string getPassword() {
            return this.password;
        }

		public void setAuth(string username, string password) {
			this.username = username;
			this.password = password;
		}
        
        private static System.Net.Http.HttpContent encodeParameters(List<KeyValuePair<string, string>> data) {
            return new System.Net.Http.FormUrlEncodedContent(data);
        }
        
        public System.Net.Http.HttpContent encodePostParams() {
            return encodeParameters(this.postParams);
        }
	}
}
