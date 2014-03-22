using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Simple
{
    public class RestRequestAsyncHandle
    {
        public HttpWebRequest WebRequest;

        public RestRequestAsyncHandle()
        {
        }

        public RestRequestAsyncHandle(HttpWebRequest webRequest)
        {
            WebRequest = webRequest;
        }

        public void Abort()
        {
            if (WebRequest != null)
                WebRequest.Abort();
        }
    }
}
