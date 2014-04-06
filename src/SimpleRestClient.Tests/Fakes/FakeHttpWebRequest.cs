using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestClient.Tests
{
    public class FakeHttpWebResponse : HttpWebResponse
    {
        private static SerializationInfo SerializationInfo;
        private readonly MemoryStream _responseStream;

        public static void InitializeHttpWebResponse(HttpStatusCode status, string statusDescription)
        {
            InitializeHttpWebResponse(status, statusDescription, 0);
        }

        public static void InitializeHttpWebResponse(HttpStatusCode status, string statusDescription, int contentLength)
        {
            SerializationInfo = new SerializationInfo(typeof(HttpWebResponse), new FormatterConverter());
            //StreamingContext sc = new StreamingContext();
            WebHeaderCollection headers = new WebHeaderCollection();
            SerializationInfo.AddValue("m_HttpResponseHeaders", headers);
            SerializationInfo.AddValue("m_Uri", new Uri("http://example.com"));
            SerializationInfo.AddValue("m_Certificate", null);
            SerializationInfo.AddValue("m_Version", HttpVersion.Version11);
            SerializationInfo.AddValue("m_StatusCode", status);
            SerializationInfo.AddValue("m_ContentLength", contentLength);
            SerializationInfo.AddValue("m_Verb", "GET");
            SerializationInfo.AddValue("m_StatusDescription", statusDescription);
            SerializationInfo.AddValue("m_MediaType", null);
            SerializationInfo.AddValue("m_ConnectStream", null, typeof(Stream));
        }

#pragma warning disable 618
        public FakeHttpWebResponse()
            : base(SerializationInfo, new StreamingContext())
        {

        }
#pragma warning restore 618

        public FakeHttpWebResponse(Stream response)
            : this()
        {
            _responseStream = (MemoryStream)response;
        }

        public override Stream GetResponseStream()
        {
            return this._responseStream;
        }
    }
}
