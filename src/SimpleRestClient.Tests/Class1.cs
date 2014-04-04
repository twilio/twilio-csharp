using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestClient.Tests
{
    class WebRequestFailedCreate : IWebRequestCreate
    {
        HttpStatusCode status;
        String statusDescription;
        
        public WebRequestFailedCreate(HttpStatusCode hsc, String sd)
        {
            status = hsc;
            statusDescription = sd;
        }

        #region IWebRequestCreate Members
        public WebRequest Create(Uri uri)
        {
            return new WebRequestFailed(uri, status, statusDescription);
        }
        #endregion
    }

    class WebRequestFailed : WebRequest
    {
        HttpStatusCode status;
        String statusDescription;
        Uri itemUri;

        public WebRequestFailed(Uri uri, HttpStatusCode status, String statusDescription)
        {
            this.itemUri = uri;
            this.status = status;
            this.statusDescription = statusDescription;
        }

        WebException GetException()
        {
            SerializationInfo si = new SerializationInfo(typeof(HttpWebResponse), new System.Runtime.Serialization.FormatterConverter());
            StreamingContext sc = new StreamingContext();
            WebHeaderCollection headers = new WebHeaderCollection();
            si.AddValue("m_HttpResponseHeaders", headers);
            si.AddValue("m_Uri", itemUri);
            si.AddValue("m_Certificate", null);
            si.AddValue("m_Version", HttpVersion.Version11);
            si.AddValue("m_StatusCode", status);
            si.AddValue("m_ContentLength", 0);
            si.AddValue("m_Verb", "GET");
            si.AddValue("m_StatusDescription", statusDescription);
            si.AddValue("m_MediaType", null);
            WebResponseFailed wr = new WebResponseFailed(si, sc);
            Exception inner = new Exception(statusDescription);
            return new WebException("This request failed", inner, WebExceptionStatus.ProtocolError, wr);
        }

        public override WebResponse GetResponse()
        {
            throw GetException();
        }

        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
        {
            Task<WebResponse> f = Task<WebResponse>.Factory.StartNew(
                _ =>
                {
                    throw GetException();
                },
                state
            );
            if (callback != null) f.ContinueWith((res) => callback(f));
            return f;
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult)
        {
            return ((Task<WebResponse>)asyncResult).Result;
        }
    }

    class WebResponseFailed : HttpWebResponse
    {
        public WebResponseFailed(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
