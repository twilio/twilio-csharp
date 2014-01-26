using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Twilio
{
    public interface IRestResponse 
    {
        HttpStatusCode StatusCode { get; set; }

        byte[] RawBytes { get; set; }

        string Content { get; set; }
    }

    public class RestResponse<T> : IRestResponse
    {
        public T Data { get; set; }

        private string _content;

        public string Content
        {
            get
            {
                if (_content == null)
                {
                    _content = this._rawBytes.AsString();
                }
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        private ResponseStatus _responseStatus = ResponseStatus.None;
        /// <summary>
        /// Status of the request. Will return Error for transport errors.
        /// HTTP errors will still return ResponseStatus.Completed, check StatusCode instead
        /// </summary>
        public ResponseStatus ResponseStatus
        {
            get
            {
                return _responseStatus;
            }
            set
            {
                _responseStatus = value;
            }
        }

        /// <summary>
        /// MIME content type of response
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// Length in bytes of the response content
        /// </summary>
        public long ContentLength { get; set; }
        /// <summary>
        /// Encoding of the response content
        /// </summary>
        public string ContentEncoding { get; set; }
        /// <summary>
        /// The URL that actually responded to the content (different from request if redirected)
        /// </summary>
        public Uri ResponseUri { get; set; }
        /// <summary>
        /// HttpWebResponse.Server
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Transport or other non-HTTP error generated while attempting request
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// The exception thrown during the request, if any
        /// </summary>
        public Exception ErrorException { get; set; }
        /// <summary>
        /// HTTP response status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Description of HTTP status returned
        /// </summary>
        public string StatusDescription { get; set; }
        /// <summary>
        /// Response content
        /// </summary>
        byte[] _rawBytes;
        public byte[] RawBytes { 
            get { 
                return this._rawBytes; 
            } 
            set { 
                this._rawBytes = value; 
                this._content = null;
            } 
        }
    }
}
