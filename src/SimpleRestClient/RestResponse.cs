using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Simple
{
    /// <summary>
    /// Contains the response from an HTTP request
    /// </summary>
    public class RestResponse
    {
        private string _content;

        /// <summary>
        /// Gets or sets the HTTP response content encoded as a string
        /// </summary>
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
        /// Gets or sets the status of the HTTP request
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
        /// Gets or sets a request error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets an request exception 
        /// </summary>
        public Exception ErrorException { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response Reason Phrase
        /// </summary>
        public string StatusDescription { get; set; }

        byte[] _rawBytes;

        /// <summary>
        /// Gets or sets the HTTP response as a raw byte array
        /// </summary>
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

    /// <summary>
    /// Contains the response from an HTTP request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestResponse<T> : RestResponse 
    {
        /// <summary>
        /// Gets or sets a generic type that contains the deserialized response data
        /// </summary>
        public T Data { get; set; }
    }
}