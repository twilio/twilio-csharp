    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Reflection;
using System.IO;

namespace Simple
{
    public partial class RestClient
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RestClient()
        {
            this.DefaultParameters = new List<Parameter>();
            this.Timeout = 30000; //30 seconds as the default
        }

        /// <summary>
        /// The proxy to use when making HTTP Requests
        /// </summary>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// The Root URL for requests
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// The request timeout value
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// The HTTP UserAgent string to include in the request
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// A collection of parameters to include in all requests
        /// </summary>
        public List<Parameter> DefaultParameters { get; set; }

        /// <summary>
        /// Adds an HTTP header to all requests
        /// </summary>
        /// <param name="name">Header name</param>
        /// <param name="value">Header value</param>
        public void AddDefaultHeader(string name, string value)
        {
            this.AddDefaultParameter(new Parameter() { Name = name, Value = value, Type = ParameterType.HttpHeader });
        }

        /// <summary>
        /// Adds a URL segment to seach and replace in all requests
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddDefaultUrlSegment(string name, string value)
        {
            this.AddDefaultParameter(new Parameter() { Name = name, Value = value, Type = ParameterType.UrlSegment });
        }

        private void AddDefaultParameter(Parameter p)
        {
            this.DefaultParameters.Add(p);
        }   
     
        private HttpWebRequest ConfigureRequest(RestRequest restrequest)
        {
            foreach (var param in this.DefaultParameters)
            {
                if (!restrequest.Parameters.Any(p => p.Name == param.Name))
                {
                    restrequest.Parameters.Add(param);
                }
            }

            var webrequest = (HttpWebRequest)WebRequest.Create(Simple.UriBuilder.Build(this.BaseUrl, restrequest));

            webrequest.Timeout = this.Timeout;
            webrequest.Proxy = this.Proxy;
            webrequest.Headers.Add("Accept-charset", "utf-8");
            webrequest.UserAgent = this.UserAgent;

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

                using (var requestStream = webrequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }

            return webrequest;
        }

        private RestResponse<T> Deserialize<T>(RestRequest request, RestResponse response)
        {
            request.OnBeforeDeserialization(response);

            RestResponse<T> restresponse = new RestResponse<T>
            {
                ErrorMessage = response.ErrorMessage,
                ErrorException = response.ErrorException,
                RawBytes = response.RawBytes,
                ResponseStatus = response.ResponseStatus,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription
            };

            try
            {

                // Only attempt to deserialize if the request has not errored due
                // to a transport or framework exception.  HTTP errors should attempt to 
                // be deserialized 

                if (response.ResponseStatus == ResponseStatus.Completed && response.ErrorException == null && response.RawBytes.Length > 0)
                {
                    JsonDeserializer deserializer = new JsonDeserializer();
                    restresponse.Data = deserializer.Deserialize<T>(response);
                }
            }
            catch (Exception ex)
            {
                restresponse.ResponseStatus = ResponseStatus.Error;
                restresponse.ErrorMessage = ex.Message;
                restresponse.ErrorException = ex;
            }

            return restresponse;
        }
    }
}
