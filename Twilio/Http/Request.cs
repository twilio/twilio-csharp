using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.Rest;

namespace Twilio.Http
{
	public class Request
	{
		public HttpMethod Method { get; }
	    public string Username { get; set; }
	    public string Password { get; set; }

	    private readonly Uri _uri;
        private readonly List<KeyValuePair<string, string>> _queryParams;
        private readonly List<KeyValuePair<string, string>> _postParams;

	    public Request(HttpMethod method, string url)
	    {
	        Method = method;
	        _uri = new Uri(url);
	        _queryParams = new List<KeyValuePair<string, string>>();
	        _postParams = new List<KeyValuePair<string, string>>();
	    }

		public Request(
		    HttpMethod method,
		    Domain domain,
		    string uri,
		    string region,
		    List<KeyValuePair<string, string>> queryParams=null,
		    List<KeyValuePair<string, string>> postParams=null
		)
		{
			Method = method;

		    var b = new StringBuilder();
		    b.Append("https://").Append(domain);
		    if (!string.IsNullOrEmpty(region))
		    {
		        b.Append(".").Append(region);
		    }
		    b.Append(".twilio.com").Append(uri);

		    _uri = new Uri(b.ToString());
		    _queryParams = queryParams ?? new List<KeyValuePair<string, string>>();
			_postParams = postParams ?? new List<KeyValuePair<string, string>>();
		}

		public Uri ConstructUrl()
		{
		    return _queryParams.Count > 0 ?
		        new Uri(_uri.AbsoluteUri + "?" + EncodeParameters(_queryParams)) :
		        new Uri(_uri.AbsoluteUri);
		}

		public void SetAuth(string username, string password)
		{
			Username = username;
			Password = password;
		}
        
        private static string EncodeParameters(IEnumerable<KeyValuePair<string, string>> data)
        {
			var result = "";
			var first = true;
			foreach (var pair in data)
			{
				if (first)
				{
					first = false;
				}
				else
				{
					result += "&";
				}

				result += pair.Key + "=" + pair.Value;
			}

			return result;
        }
        
		public byte[] EncodePostParams()
		{
			return Encoding.UTF8.GetBytes(EncodeParameters(_postParams));
        }

		public void AddQueryParam(string name, string value)
		{
			AddParam(_queryParams, name, value);
		}

		public void AddPostParam(string name, string value)
		{
			AddParam(_postParams, name, value);
		}

		private static void AddParam(ICollection<KeyValuePair<string, string>> list, string name, string value)
		{
			list.Add(new KeyValuePair<string, string> (name, value));
		}

		public override bool Equals(object obj)
		{
		    if (obj == null)
		    {
		        return false;
		    }

		    if (ReferenceEquals(this, obj))
		    {
		        return true;
		    }
		    if (obj.GetType() != typeof(Request))
		    {
		        return false;
		    }

			var other = (Request)obj;
			return Method.Equals(other.Method) &&
			       _uri.Equals(other._uri) &&
			       _queryParams.All(other._queryParams.Contains) &&
			       _postParams.All(other._postParams.Contains);
		}
			

		public override int GetHashCode()
		{
			unchecked
			{
				return (Method?.GetHashCode() ?? 0) ^
				       (_uri?.GetHashCode() ?? 0) ^
				       (_queryParams?.GetHashCode() ?? 0) ^
				       (_postParams?.GetHashCode() ?? 0);
			}
		}
	}
}
