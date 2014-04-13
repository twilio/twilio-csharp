using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Simple;

namespace Simple
{
#if FX35
    public partial class RestClient
    {
        /// <summary>
        /// Execute a generic synchronous HTTP request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public RestResponse<T> Execute<T>(RestRequest request)
        {
            return Deserialize<T>(request, Execute(request));
        }

        internal RestResponse Execute(RestRequest restrequest)
        {
            var webrequest = this.WebRequest.ConfigureRequest(this, restrequest);
            var restresponse = new RestResponse() { ResponseStatus = ResponseStatus.None };

            try
            {
                var webresponse = (HttpWebResponse)webrequest.GetResponse();
                restresponse = this.WebRequest.ExtractResponse(webresponse);
                webresponse.Close();
            }
            catch (WebException exc)
            {
                restresponse = this.WebRequest.ParseWebException(exc);
            }

            return restresponse;
        }
    }
#endif
}
