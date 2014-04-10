using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Simple
{
    /// <summary>
    /// An asynchronous handle used to maintain request object state and abort in-progress requests.
    /// </summary>
    public class RestRequestAsyncHandle
    {
        /// <summary>
        /// The current HttpWebRequest
        /// </summary>
        public HttpWebRequest WebRequest;

        /// <summary>
        /// Default public constructor
        /// </summary>
        public RestRequestAsyncHandle()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webRequest"></param>
        public RestRequestAsyncHandle(HttpWebRequest webRequest)
        {
            WebRequest = webRequest;
        }

        /// <summary>
        /// Aborts the current HttpWebRequest
        /// </summary>
        public void Abort()
        {
            if (WebRequest != null)
                WebRequest.Abort();
        }
    }
}
