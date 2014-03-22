using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Simple;

namespace Simple
{
    public partial class RestClient
    {
        public virtual RestResponse<T> Execute<T>(RestRequest request) where T : new()
        {
            return Deserialize<T>(request, Execute(request));
        }

        public RestResponse Execute(RestRequest restrequest)
        {
            var webrequest = ConfigureRequest(restrequest);

            var restresponse = new RestResponse();

            try
            {
                var webresponse = (HttpWebResponse)webrequest.GetResponse();

                restresponse.StatusCode = webresponse.StatusCode;
                restresponse.StatusDescription = webresponse.StatusDescription;

                var stream = webresponse.GetResponseStream();
                restresponse.RawBytes = stream.ReadAsBytes();

                restresponse.ResponseStatus = ResponseStatus.Completed;
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
                    restresponse.StatusCode = errorresponse.StatusCode;
                    restresponse.StatusDescription = errorresponse.StatusDescription;

                    var stream = errorresponse.GetResponseStream();
                    restresponse.RawBytes = stream.ReadAsBytes();

                    restresponse.ResponseStatus = ResponseStatus.Completed;
                }
                else
                {
                    restresponse.ErrorException = exc;
                    restresponse.ErrorMessage = exc.Message;
                    restresponse.ResponseStatus = ResponseStatus.Error;
                }
            }

//            restresponse = Deserialize<T>(restrequest, restresponse);

            return restresponse;
        }

    }
}
