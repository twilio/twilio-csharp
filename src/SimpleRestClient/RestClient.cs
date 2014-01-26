using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Reflection;
using System.IO;

namespace Twilio
{
    public class RestClient
    {
        public RestClient()
        {
            this.DefaultParameters = new List<Parameter>();
        }

        public IWebProxy Proxy { get; set; }

        public string BaseUrl { get; set; }
        public int Timeout { get; set; }
        public string UserAgent { get; set; }

        public List<Parameter> DefaultParameters { get; set; }

        public RestResponse<T> Execute<T>(RestRequest restrequest)
        {
            foreach (var param in this.DefaultParameters)
            {
                if (!restrequest.Parameters.Any(p=>p.Name==param.Name)) {
                    restrequest.Parameters.Add(param);
                }
            }

            var webrequest = (HttpWebRequest)WebRequest.Create(UriBuilder.Build(this.BaseUrl, restrequest));
            webrequest.Timeout = this.Timeout;
            webrequest.Proxy = this.Proxy;
            webrequest.UserAgent = this.UserAgent;
            webrequest.Method = restrequest.Method;
            webrequest.Accept = "application/json";
            

            foreach (var param in restrequest.Parameters.Where(p=>p.Type==ParameterType.HttpHeader))
            {
                webrequest.Headers.Add(param.Name, param.Value.ToString());
            }

            if (restrequest.Method == "POST" || restrequest.Method == "PUT")
            {
                webrequest.ContentType = "application/x-www-form-urlencoded";
                
                //This code is duplicated in the UriBuilder class
			    var querystring = new StringBuilder();
                foreach (var param in restrequest.Parameters.Where(p => p.Type == ParameterType.GetOrPost))
			    {
                    if (querystring.Length > 1)
                    {
                        querystring.Append("&");
                    }
				    querystring.AppendFormat("{0}={1}", param.Name.UrlEncode(), param.Value.ToString().UrlEncode());
			    }

                var bytes = Encoding.UTF8.GetBytes(querystring.ToString());

                webrequest.ContentLength = bytes.Length;

                using (var requestStream = webrequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }

            var restresponse = new RestResponse<T>();            

            try
            {
                var webresponse = (HttpWebResponse)webrequest.GetResponse();

                restresponse.ContentEncoding = webresponse.ContentEncoding;
                restresponse.ContentLength = webresponse.ContentLength;
                restresponse.ContentType = webresponse.ContentType;
                restresponse.ResponseUri = webresponse.ResponseUri;
                restresponse.Server = webresponse.Server;
                restresponse.StatusCode = webresponse.StatusCode;
                restresponse.StatusDescription = webresponse.StatusDescription;

                var stream = webresponse.GetResponseStream();
                restresponse.RawBytes = stream.ReadAsBytes();
            }
            catch (WebException exc)
            {
                // Check to see if this is an HTTP error or a transport error.
                // In cases where an HTTP error occurs ( status code >= 400 )
                // return the underlying HTTP response, otherwise assume a
                // transport exception (ex: connection timeout) and
                // rethrow the exception

                if (exc.Response is HttpWebResponse)
                {
                    var errorresponse = exc.Response as HttpWebResponse;
                    restresponse.ContentEncoding = errorresponse.ContentEncoding;
                    restresponse.ContentLength = errorresponse.ContentLength;
                    restresponse.ContentType = errorresponse.ContentType;
                    restresponse.ResponseUri = errorresponse.ResponseUri;
                    restresponse.Server = errorresponse.Server;
                    restresponse.StatusCode = errorresponse.StatusCode;
                    restresponse.StatusDescription = errorresponse.StatusDescription;

                    var stream = errorresponse.GetResponseStream();
                    restresponse.RawBytes = stream.ReadAsBytes();
                }
                else
                {
                    restresponse.ErrorException = exc;
                    restresponse.ErrorMessage = exc.Message;
                    restresponse.ResponseStatus = ResponseStatus.Error;
                }
            }

            restrequest.OnBeforeDeserialization(restresponse);

            if (restresponse.ErrorException == null)
            {
                JsonDeserializer deserializer = new JsonDeserializer();
                restresponse.Data = deserializer.Deserialize<T>(restresponse);
            }

            return restresponse;
        }

        //private IRestResponse<T> Deserialize<T>(IRestRequest request, IRestResponse raw)
        //{
        //    request.OnBeforeDeserialization(raw);

        //    IRestResponse<T> response = new RestResponse<T>();
        //    try
        //    {
        //        response = raw.toAsyncResponse<T>();
        //        response.Request = request;

        //        // Only attempt to deserialize if the request has not errored due
        //        // to a transport or framework exception.  HTTP errors should attempt to 
        //        // be deserialized 

        //        if (response.ErrorException == null)
        //        {
        //            IDeserializer handler = GetHandler(raw.ContentType);
        //            handler.RootElement = request.RootElement;
        //            handler.DateFormat = request.DateFormat;
        //            handler.Namespace = request.XmlNamespace;

        //            response.Data = handler.Deserialize<T>(raw);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ResponseStatus = ResponseStatus.Error;
        //        response.ErrorMessage = ex.Message;
        //        response.ErrorException = ex;
        //    }

        //    return response;
        //}
    }
}
