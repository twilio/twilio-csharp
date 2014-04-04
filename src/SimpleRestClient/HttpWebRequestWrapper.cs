using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Simple
{
    public class HttpWebRequestWrapper
    {
        public RestResponse ParseWebException(WebException exc)
        {
            return ParseWebException(exc, null);
        }

        public RestResponse ParseWebException(WebException exc, TimeOutState timeoutstate) 
        {
            var restresponse = new RestResponse();

            // Check to see if this is an HTTP error or a transport error.
            // In cases where an HTTP error occurs ( status code >= 400 )
            // return the underlying HTTP response, otherwise assume a
            // transport exception (ex: connection timeout) and
            // rethrow the exception
            if (exc.Response is HttpWebResponse)
            {
                var errorresponse = exc.Response as HttpWebResponse;
                restresponse = ExtractResponse(errorresponse);
            }
            else
            {
                restresponse.ErrorException = exc;
                restresponse.ErrorMessage = exc.Message;

                if (timeoutstate != null && exc.Status == WebExceptionStatus.RequestCanceled)
                {
                    restresponse.ResponseStatus = timeoutstate.TimedOut ? ResponseStatus.TimedOut : ResponseStatus.Aborted;
                }
                else
                {
                    restresponse.ResponseStatus = ResponseStatus.Error;
                }
            }

            return restresponse;
        }

        public RestResponse ExtractResponse(HttpWebResponse webresponse)
        {
            var restresponse = new RestResponse();

            restresponse.StatusCode = webresponse.StatusCode;
            restresponse.StatusDescription = webresponse.StatusDescription;

            var stream = webresponse.GetResponseStream();
            restresponse.RawBytes = stream.ReadAsBytes();

            restresponse.ResponseStatus = ResponseStatus.Completed;

            return restresponse;
        }

        public Type HttpWebRequestType { get; set; }

        public HttpWebRequest HttpWebRequestFactory(Uri uri)
        {
            if (HttpWebRequestType != null)
            {
                return (HttpWebRequest)Activator.CreateInstance(HttpWebRequestType);
            }

            return (HttpWebRequest)WebRequest.Create(uri);
        }

        public HttpWebRequest ConfigureRequest(RestClient client, RestRequest restrequest)
        {
            foreach (var param in client.DefaultParameters)
            {
                if (!restrequest.Parameters.Any(p => p.Name == param.Name))
                {
                    restrequest.Parameters.Add(param);
                }
            }

            var webrequest = HttpWebRequestFactory(Simple.UriBuilder.Build(client.BaseUrl, restrequest));

            webrequest.Timeout = client.Timeout;
            if (client.Proxy != null) { webrequest.Proxy = client.Proxy; }
            webrequest.Headers.Add("Accept-charset", "utf-8");
            webrequest.UserAgent = client.UserAgent;

            webrequest.Method = restrequest.Method;
            webrequest.Accept = "application/json";
            webrequest.KeepAlive = true;

            foreach (var param in restrequest.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
            {
                webrequest.Headers.Add(param.Name, param.Value.ToString());
            }

            if (restrequest.Method == "POST" || restrequest.Method == "PUT")
            {
                webrequest.ContentType = "application/x-www-form-urlencoded";

                var querystring = Utilities.EncodeParameters(restrequest.Parameters);
                var bytes = Encoding.UTF8.GetBytes(querystring.ToString());

                webrequest.ContentLength = bytes.Length;

                var requestStream = webrequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
            }

            return webrequest;
        }
    }
}
