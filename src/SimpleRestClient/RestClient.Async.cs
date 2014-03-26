using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public virtual RestRequestAsyncHandle ExecuteAsync<T>(RestRequest restrequest, Action<RestResponse<T>> callback)
        {
            return this.ExecuteAsync<T>(restrequest, (restresponse, asyncHandle) => callback(restresponse));
        }

        internal virtual RestRequestAsyncHandle ExecuteAsync<T>(RestRequest restrequest, Action<RestResponse<T>, RestRequestAsyncHandle> callback)
        {
            return ExecuteAsync(restrequest, (restresponse, asyncHandle) => DeserializeResponse(restrequest, callback, restresponse, asyncHandle));
        }

        /// <summary>
        /// Execute an asynchronous HTTP request
        /// </summary>
        /// <param name="restrequest"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteAsync(RestRequest restrequest, Action<RestResponse> callback)
        {
            return this.ExecuteAsync(restrequest, (restresponse, asyncHandle) => callback(restresponse));
        }

        internal RestRequestAsyncHandle ExecuteAsync(RestRequest restrequest, Action<RestResponse, RestRequestAsyncHandle> callback)
        {
            var asyncHandle = new RestRequestAsyncHandle();

            Action<RestResponse> response_cb = r =>
            {
                callback(r, asyncHandle);
            };

            asyncHandle.WebRequest = PutPostInternalAsync(restrequest, response_cb);
            return asyncHandle;

        }

        private HttpWebRequest PutPostInternalAsync(RestRequest restrequest, Action<RestResponse> callback)
        {
            HttpWebRequest webrequest = null;

            try
            {
                webrequest = ConfigureRequest(restrequest);

                IAsyncResult asyncResult;
                _timeoutState = new TimeOutState { Request = webrequest };

                asyncResult = webrequest.BeginGetResponse(r => ResponseCallback(r, callback), webrequest);

                SetTimeout(asyncResult, _timeoutState);
            }
            catch (Exception ex)
            {
                ExecuteCallback(CreateErrorResponse(ex), callback);
            }

            return webrequest;
        }

        private RestResponse CreateErrorResponse(Exception ex)
        {
            var response = new RestResponse();
            var webException = ex as WebException;
            if (webException != null && webException.Status == WebExceptionStatus.RequestCanceled)
            {
                response.ResponseStatus = _timeoutState.TimedOut ? ResponseStatus.TimedOut : ResponseStatus.Aborted;
                return response;
            }

            response.ErrorMessage = ex.Message;
            response.ErrorException = ex;
            response.ResponseStatus = ResponseStatus.Error;
            return response;
        }

        private void DeserializeResponse<T>(RestRequest request, Action<RestResponse<T>, RestRequestAsyncHandle> callback, RestResponse response, RestRequestAsyncHandle asyncHandle)
        {
            RestResponse<T> restresponse;

            try
            {
                restresponse = Deserialize<T>(request, response);
            }
            catch (Exception ex)
            {
                restresponse = new RestResponse<T> { ResponseStatus = ResponseStatus.Error, ErrorMessage = ex.Message, ErrorException = ex };
            }

            callback(restresponse, asyncHandle); 
        }

        private void ResponseCallback(IAsyncResult result, Action<RestResponse> callback)
        {
            var restresponse = new RestResponse() { ResponseStatus = ResponseStatus.None };

            try
            {
                if (_timeoutState.TimedOut)
                {
                    restresponse.ResponseStatus = ResponseStatus.TimedOut;
                    ExecuteCallback(restresponse, callback);
                    return;
                }

                GetRawResponseAsync(result, webresponse =>
                {
                    restresponse.StatusCode = webresponse.StatusCode;
                    restresponse.StatusDescription = webresponse.StatusDescription;
                    
                    var stream = webresponse.GetResponseStream();
                    restresponse.RawBytes = stream.ReadAsBytes();

                    restresponse.ResponseStatus = ResponseStatus.Completed;

                    ExecuteCallback(restresponse, callback);
                });
            }
            catch (Exception ex)
            {
                ExecuteCallback(CreateErrorResponse(ex), callback);
            }
        }

        private static void GetRawResponseAsync(IAsyncResult result, Action<HttpWebResponse> callback)
        {
            HttpWebResponse raw = null;

            try
            {
                var webRequest = (HttpWebRequest)result.AsyncState;
                raw = webRequest.EndGetResponse(result) as HttpWebResponse;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.RequestCanceled)
                {
                    throw ex;
                }

                // Check to see if this is an HTTP error or a transport error.
                // In cases where an HTTP error occurs ( status code >= 400 )
                // return the underlying HTTP response, otherwise assume a
                // transport exception (ex: connection timeout) and
                // rethrow the exception

                if (ex.Response is HttpWebResponse)
                {
                    raw = ex.Response as HttpWebResponse;
                }
                else
                {
                    throw ex;
                }
            }

            callback(raw);
            raw.Close();
        }

        private static void ExecuteCallback(RestResponse response, Action<RestResponse> callback)
        {
            callback(response);
        }

        private void SetTimeout(IAsyncResult asyncResult, TimeOutState timeOutState)
        {
            if (Timeout != 0)
            {
                ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), timeOutState, Timeout, true);
            }
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
