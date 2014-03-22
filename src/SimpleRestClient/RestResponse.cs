using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Simple
{
    public class RestResponse
    {
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

        public string ErrorMessage { get; set; }

        public Exception ErrorException { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string StatusDescription { get; set; }

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

    public class RestResponse<T> : RestResponse {
        public T Data { get; set; }
    }
}