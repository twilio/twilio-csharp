using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.Rest;

#if !NET35
using System.Net;
#else
using System.Web;
#endif

namespace Twilio.Http
{
    /// <summary>
    /// Twilio request object
    /// </summary>
    public class Request
    {
        /// <summary>
        /// HTTP Method
        /// </summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// Auth username
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// Auth password
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Post params
        /// </summary>
        public List<KeyValuePair<string, string>> PostParams { get { return _postParams; } } 

        private readonly Uri _uri;
        private readonly List<KeyValuePair<string, string>> _queryParams;
        private readonly List<KeyValuePair<string, string>> _postParams;

        /// <summary>
        /// Create a new Twilio request
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="url">Request URL</param>
        public Request(HttpMethod method, string url)
        {
            Method = method;
            _uri = new Uri(url);
            _queryParams = new List<KeyValuePair<string, string>>();
            _postParams = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Create a new Twilio request
        /// </summary>
        /// <param name="method">HTTP method</param>
        /// <param name="domain">Twilio subdomain</param>
        /// <param name="uri">Request URI</param>
        /// <param name="region">Twilio region</param>
        /// <param name="queryParams">Query parameters</param>
        /// <param name="postParams">Post data</param>
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

        /// <summary>
        /// Construct the request URL
        /// </summary>
        /// <returns>Built URL including query parameters</returns>
        public Uri ConstructUrl()
        {
            return _queryParams.Count > 0 ?
                new Uri(_uri.AbsoluteUri + "?" + EncodeParameters(_queryParams)) :
                new Uri(_uri.AbsoluteUri);
        }

        /// <summary>
        /// Set auth for the request
        /// </summary>
        /// <param name="username">Auth username</param>
        /// <param name="password">Auth password</param>
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

#if !NET35
                result += WebUtility.UrlEncode(pair.Key) + "=" + WebUtility.UrlEncode(pair.Value);
#else
                result += HttpUtility.UrlEncode(pair.Key) + "=" + HttpUtility.UrlEncode(pair.Value);
#endif
            }

            return result;
        }
        
        /// <summary>
        /// Encode POST data for transfer
        /// </summary>
        /// <returns>Encoded byte array</returns>
        public byte[] EncodePostParams()
        {
            return Encoding.UTF8.GetBytes(EncodeParameters(_postParams));
        }

        /// <summary>
        /// Add query parameter to request
        /// </summary>
        /// <param name="name">name of parameter</param>
        /// <param name="value">value of parameter</param>
        public void AddQueryParam(string name, string value)
        {
            AddParam(_queryParams, name, value);
        }

        /// <summary>
        /// Add a parameter to the request payload
        /// </summary>
        /// <param name="name">name of parameter</param>
        /// <param name="value">value of parameter</param>
        public void AddPostParam(string name, string value)
        {
            AddParam(_postParams, name, value);
        }

        private static void AddParam(ICollection<KeyValuePair<string, string>> list, string name, string value)
        {
            list.Add(new KeyValuePair<string, string> (name, value));
        }

        /// <summary>
        /// Compare request
        /// </summary>
        /// <param name="obj">object to compare to</param>
        /// <returns>true if requests are equal; false otherwise</returns>
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
            

        /// <summary>
        /// Generate hash code for request
        /// </summary>
        /// <returns>generated hash code</returns>
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
