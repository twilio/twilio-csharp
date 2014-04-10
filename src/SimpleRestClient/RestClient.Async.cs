using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Simple
{
    /// <summary>
    /// A simple class for making requests to HTTP API's
    /// </summary>
    public partial class RestClient
    {
        private TimeOutState _timeoutState;

        /// <summary>
        /// Execute a generic asynchronous HTTP request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="restrequest"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync<T>(RestRequest restrequest, Action<RestResponse<T>> callback)
        {
            return this.ExecuteAsync<T>(restrequest, (restresponse, asyncHandle) => callback(restresponse));
        }

        internal RestRequestAsyncHandle ExecuteAsync<T>(RestRequest restrequest, Action<RestResponse<T>, RestRequestAsyncHandle> callback)
        {
            return ExecuteAsync(restrequest, (restresponse, asyncHandle) => DeserializeResponse(restrequest, callback, restresponse, asyncHandle));
        }

        /// <summary>
        /// Execute an asynchronous HTTP request
        /// </summary>
        /// <param name="restrequest"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync(RestRequest restrequest, Action<RestResponse> callback)
        {
            return this.ExecuteAsync(restrequest, (restresponse, asyncHandle) => callback(restresponse));
        }

        internal RestRequestAsyncHandle ExecuteAsync(RestRequest restrequest, Action<RestResponse, RestRequestAsyncHandle> callback)
        {
            var asyncHandle = new RestRequestAsyncHandle();

            Action<RestResponse> responseCallback = r => callback(r, asyncHandle);

            var webrequest = this.WebRequest.ConfigureRequest(this, restrequest);

            _timeoutState = new TimeOutState { Request = webrequest };

            var asyncResult = webrequest.BeginGetResponse(r => ProcessHttpWebResponseCallback(r, responseCallback), webrequest);

            if (Timeout != 0)
            {
                ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), _timeoutState, this.Timeout, true);
            }
            
            asyncHandle.WebRequest = webrequest;
            return asyncHandle;
        }

        private void ProcessHttpWebResponseCallback(IAsyncResult result, Action<RestResponse> callback)
        {
            var restresponse = new RestResponse() { ResponseStatus = ResponseStatus.None };

            try
            {
                var webRequest = (HttpWebRequest)result.AsyncState;
                var webresponse = webRequest.EndGetResponse(result) as HttpWebResponse;
                restresponse = this.WebRequest.ExtractResponse(webresponse);
                webresponse.Close();
            }
            catch (WebException exc)
            {
                restresponse = this.WebRequest.ParseWebException(exc);
            }

            callback(restresponse);
        }

        private void DeserializeResponse<T>(RestRequest request, Action<RestResponse<T>, RestRequestAsyncHandle> callback, RestResponse response, RestRequestAsyncHandle asyncHandle)
        {
            callback(Deserialize<T>(request, response), asyncHandle);
        }

        private static void TimeoutCallback(object state, bool timedOut)
        {
            if (!timedOut)
                return;

            var timeoutState = state as TimeOutState;

            if (timeoutState == null)
            {
                return;
            }

            lock (timeoutState)
            {
                timeoutState.TimedOut = true;
            }

            if (timeoutState.Request != null)
            {
                timeoutState.Request.Abort();
            }
        }
    }

    /// <summary>
    /// Holds the timout state for an individual request
    /// </summary>
    public class TimeOutState
    {
        /// <summary>
        /// Has this request timed out
        /// </summary>
        public bool TimedOut { get; set; }

        /// <summary>
        /// The current HttpWebRequest
        /// </summary>
        public HttpWebRequest Request { get; set; }
    }
}