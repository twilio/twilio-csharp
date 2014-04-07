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
    public class FakeHttpWebRequest : HttpWebRequest
    {
        private Func<object,WebResponse> _response;
        private static readonly SerializationInfo SerializationInfo;
        private readonly MemoryStream _requestStream;

        static FakeHttpWebRequest()
        {
            SerializationInfo = new SerializationInfo(typeof(HttpWebRequest), new FormatterConverter());
            SerializationInfo.AddValue("_HttpRequestHeaders", new WebHeaderCollection(), typeof(WebHeaderCollection));
            SerializationInfo.AddValue("_Proxy", null, typeof(IWebProxy));
            SerializationInfo.AddValue("_KeepAlive", false);
            SerializationInfo.AddValue("_Pipelined", false);
            SerializationInfo.AddValue("_AllowAutoRedirect", false);
            SerializationInfo.AddValue("_AllowWriteStreamBuffering", false);
            SerializationInfo.AddValue("_HttpWriteMode", 0);
            SerializationInfo.AddValue("_MaximumAllowedRedirections", 0);
            SerializationInfo.AddValue("_AutoRedirects", 0);
            SerializationInfo.AddValue("_Timeout", 500);
            SerializationInfo.AddValue("_ReadWriteTimeout", 500);
            SerializationInfo.AddValue("_MaximumResponseHeadersLength", 128);
            SerializationInfo.AddValue("_ContentLength", 0);
            SerializationInfo.AddValue("_MediaType", 0);
            SerializationInfo.AddValue("_OriginVerb", 0);
            SerializationInfo.AddValue("_ConnectionGroupName", null);
            SerializationInfo.AddValue("_Version", HttpVersion.Version11, typeof(Version));
            SerializationInfo.AddValue("_OriginUri", new Uri("http://example.com"), typeof(Uri));
        }

#pragma warning disable 618
        public FakeHttpWebRequest()
            : base(SerializationInfo, new StreamingContext())
        {
            _requestStream = new MemoryStream();
        }

        public FakeHttpWebRequest(Func<object,WebResponse> response)
            : this()
        {
            _response = response;
        }

        protected FakeHttpWebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
#pragma warning restore 618


        #region Overrides of HttpWebRequest

        /// <summary>
        /// Gets a <see cref="T:System.IO.Stream"/> object to use to write request data.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> to use to write request data.
        /// </returns>
        /// <exception cref="T:System.Net.ProtocolViolationException">The <see cref="P:System.Net.HttpWebRequest.Method"/> property is GET or HEAD.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false, and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT. </exception><exception cref="T:System.InvalidOperationException">The <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> method is called more than once.-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false. </exception><exception cref="T:System.NotSupportedException">The request cache validator indicated that the response for this request can be served from the cache; however, requests that write data must not use the cache. This exception can occur if you are using a custom cache validator that is incorrectly implemented. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- The time-out period for the request expired.-or- An error occurred while processing the request. </exception><exception cref="T:System.ObjectDisposedException">In a .NET Compact Framework application, a request stream with zero content length was not obtained and closed correctly. For more information about handling zero content length requests, see Network Programming in the .NET Compact Framework.</exception><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Net.DnsPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override Stream GetRequestStream()
        {
            return _requestStream;
        }

        public override WebResponse GetResponse()
        {
            return _response(new object());
        }

        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
        {
            Task<WebResponse> f = Task<WebResponse>.Factory.StartNew(_response,state);

            if (callback != null) f.ContinueWith((res) => callback(f));
            return f;
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult)
        {
            var response = ((Task<WebResponse>)asyncResult).Result as HttpWebResponse;

            if ((int)response.StatusCode >= 400)
            {
                var stream = response.GetResponseStream();

                var webexception = new WebException(
               "The remote server returned an error: (400) Bad Request.",
               null,
               WebExceptionStatus.ProtocolError,
               new FakeHttpWebResponse(stream));

               throw webexception;
            }
            
            return ((Task<WebResponse>)asyncResult).Result;
        }

        #endregion
    }

}
