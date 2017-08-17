#if NET35
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Twilio.Http.Net35
{
    /// <summary>
    /// These classes exist to wrap MSFT's WebRequest interfaces to enable unit testing of 
    /// WebRequestClient.
    /// </summary>
    
    public class HttpWebRequestFactory
    {
        public virtual IHttpWebRequestWrapper Create(Uri uri)
        {
            return new HttpWebRequestWrapper(uri);
        }
    }

    public interface IHttpWebRequestWrapper
    {
        string UserAgent { get; set; }
        string Method { get; set; }
        string Accept { get; set; }
        string ContentType { get; set; }
        NameValueCollection Headers { get; set; }

        void WriteBody(byte[] content);
        IHttpWebResponseWrapper GetResponse();
    }

    public interface IHttpWebResponseWrapper
    {
        HttpStatusCode StatusCode { get; set; }
        Stream GetResponseStream();
    }

    public class HttpWebRequestWrapper : IHttpWebRequestWrapper
    {
        private HttpWebRequest _httpWebRequest;

        /// <summary>
        /// Primary constructor
        /// </summary>
        public HttpWebRequestWrapper(Uri uri)
        {
            this._httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
        }

        public string UserAgent
        {
            get { return this._httpWebRequest.UserAgent; }
            set
            {
                var property = typeof(HttpWebRequest).GetProperty("UserAgent");
                if (property != null)
                {
                    this._httpWebRequest.UserAgent = value;
                }
            }
        }

        public string Method
        {
            get { return this._httpWebRequest.Method; }
            set { this._httpWebRequest.Method = value; }
        }

        public string Accept
        {
            get { return this._httpWebRequest.Accept; }
            set { this._httpWebRequest.Accept = value; }
        }

        public NameValueCollection Headers
        {
            get { return this._httpWebRequest.Headers; }
            set { throw new ArgumentException("Setting unsupported"); }
        }

        public string ContentType
        {
            get { return this._httpWebRequest.ContentType; }
            set { this._httpWebRequest.ContentType = value; }
        }

        public void WriteBody(byte[] content)
        {
                var stream = this._httpWebRequest.GetRequestStream();
                stream.Write(content, 0, content.Length);
                stream.Close();
        }

        public IHttpWebResponseWrapper GetResponse()
        {
            try
            {
                return new HttpWebResponseWrapper((HttpWebResponse) this._httpWebRequest.GetResponse());
            }
            catch (WebException ex)
            {
                throw new WebExceptionWrapper(ex);
            }
        }
    }

    public class HttpWebResponseWrapper : IHttpWebResponseWrapper
    {
        private HttpWebResponse _httpWebResponse;

        public HttpWebResponseWrapper(HttpWebResponse response)
        {
            this._httpWebResponse = response;
        }

        public HttpStatusCode StatusCode
        {
            get { return this._httpWebResponse.StatusCode; }
            set { throw new ArgumentException("Setting status code not supported"); }
        }

        public Stream GetResponseStream()
        {
            return this._httpWebResponse.GetResponseStream();
        }
    }

    public class WebExceptionWrapper : Exception
    {
        public WebException RealException;

        public WebExceptionWrapper(WebException actualException)
        {
            this.RealException = actualException;
        }

        public virtual IHttpWebResponseWrapper Response
        {
            get {
                if (this.RealException.Response == null)
                {
                    return null;
                }
                return new HttpWebResponseWrapper((HttpWebResponse)this.RealException.Response);
            }
            set { throw new ArgumentException("Setting not supported"); }
        }
    }
}
#endif