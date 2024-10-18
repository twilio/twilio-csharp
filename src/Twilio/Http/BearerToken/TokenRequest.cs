using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.Constant;
using Twilio.Rest;
using Twilio.Annotations;

#if !NET35
using System.Net;
#else
using System.Web;
#endif

namespace Twilio.Http.BearerToken
{
    /// <summary>
    /// Twilio request object with bearer token authentication
    /// </summary>
    [Deprecated]
    public class TokenRequest
    {
        private static readonly string DEFAULT_REGION = "us1";

        /// <summary>
        /// HTTP Method
        /// </summary>
        public HttpMethod Method { get; }

        public Uri Uri { get; private set; }

        /// <summary>
        /// Auth username
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Twilio region
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Twilio edge
        /// </summary>
        public string Edge { get; set; }

        /// <summary>
        /// Additions to the user agent string
        /// </summary>
        public string[] UserAgentExtensions { get; set; }

        /// <summary>
        /// Query params
        /// </summary>
        public List<KeyValuePair<string, string>> QueryParams { get; private set; }

        /// <summary>
        /// Post params
        /// </summary>
        public List<KeyValuePair<string, string>> PostParams { get; private set; }

        /// <summary>
        /// Header params
        /// </summary>
        public List<KeyValuePair<string, string>> HeaderParams { get; private set; }
        
        /// <summary>
        /// Content Type
        /// </summary>
        public EnumConstants.ContentTypeEnum ContentType { get; set; }
        
        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Create a new Twilio request
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="url">Request URL</param>
        public TokenRequest(HttpMethod method, string url)
        {
            Method = method;
            Uri = new Uri(url);
            QueryParams = new List<KeyValuePair<string, string>>();
            PostParams = new List<KeyValuePair<string, string>>();
            HeaderParams = new List<KeyValuePair<string, string>>();
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
        /// <param name="edge">Twilio edge</param>
        /// <param name="headerParams">Custom header data</param>
        /// <param name="contentType">Content Type</param>
        /// <param name="body">Request Body</param>
        public TokenRequest(
            HttpMethod method,
            Domain domain,
            string uri,
            string region = null,
            List<KeyValuePair<string, string>> queryParams = null,
            List<KeyValuePair<string, string>> postParams = null,
            string edge = null,
            List<KeyValuePair<string, string>> headerParams = null,
            EnumConstants.ContentTypeEnum contentType = null,
            string body = null
        )
        {
            Method = method;
            Uri = new Uri("https://" + domain + ".twilio.com" + uri);
            Region = region;
            Edge = edge;

            QueryParams = queryParams ?? new List<KeyValuePair<string, string>>();
            PostParams = postParams ?? new List<KeyValuePair<string, string>>();
            HeaderParams = headerParams ?? new List<KeyValuePair<string, string>>();

            ContentType = contentType;
            Body = body;
        }

        /// <summary>
        /// Construct the request URL
        /// </summary>
        /// <returns>Built URL including query parameters</returns>
        public Uri ConstructUrl()
        {
            var uri = buildUri();
            return QueryParams.Count > 0 ?
                new Uri(uri.AbsoluteUri + "?" + EncodeParameters(QueryParams)) :
                new Uri(uri.AbsoluteUri);
        }

        public Uri buildUri()
        {
            if (Region != null || Edge != null)
            {
                var uriBuilder = new UriBuilder(Uri);
                var pieces = uriBuilder.Host.Split('.');
                var product = pieces[0];
                var domain = String.Join(".", pieces.Skip(pieces.Length - 2).ToArray());

                var region = Region;
                var edge = Edge;

                if (pieces.Length == 4) // product.region.twilio.com
                {
                    region = region ?? pieces[1];
                }
                else if (pieces.Length == 5) // product.edge.region.twilio.com
                {
                    edge = edge ?? pieces[1];
                    region = region ?? pieces[2];
                }

                if (edge != null && region == null)
                    region = DEFAULT_REGION;

                string[] parts = { product, edge, region, domain };

                uriBuilder.Host = String.Join(".", Array.FindAll(parts, part => !string.IsNullOrEmpty(part)));
                return uriBuilder.Uri;
            }

            return Uri;
        }

        /// <summary>
        /// Set auth for the request
        /// </summary>
        /// <param name="accessToken">Auth accessToken</param>
        public void SetAuth(string accessToken)
        {
            AccessToken = accessToken;
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
            return Encoding.UTF8.GetBytes(EncodeParameters(PostParams));
        }

        /// <summary>
        /// Add query parameter to request
        /// </summary>
        /// <param name="name">name of parameter</param>
        /// <param name="value">value of parameter</param>
        public void AddQueryParam(string name, string value)
        {
            AddParam(QueryParams, name, value);
        }

        /// <summary>
        /// Add a parameter to the request payload
        /// </summary>
        /// <param name="name">name of parameter</param>
        /// <param name="value">value of parameter</param>
        public void AddPostParam(string name, string value)
        {
            AddParam(PostParams, name, value);
        }

        /// <summary>
        /// Add a header parameter
        /// </summary>
        /// <param name="name">name of parameter</param>
        /// <param name="value">value of parameter</param>
        public void AddHeaderParam(string name, string value)
        {
            AddParam(HeaderParams, name, value);
        }

        private static void AddParam(ICollection<KeyValuePair<string, string>> list, string name, string value)
        {
            list.Add(new KeyValuePair<string, string>(name, value));
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
                   buildUri().Equals(other.buildUri()) &&
                   QueryParams.All(other.QueryParams.Contains) &&
                   other.QueryParams.All(QueryParams.Contains) &&
                   PostParams.All(other.PostParams.Contains) &&
                   other.PostParams.All(PostParams.Contains) &&
                   HeaderParams.All(other.HeaderParams.Contains) &&
                   other.HeaderParams.All(HeaderParams.Contains);
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
                       (buildUri()?.GetHashCode() ?? 0) ^
                       (QueryParams?.GetHashCode() ?? 0) ^
                       (PostParams?.GetHashCode() ?? 0) ^
                       (HeaderParams?.GetHashCode() ?? 0);
            }
        }
    }
}
