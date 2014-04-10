using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Twilio
{
    public class RestClient
    {
        public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest restrequest)
        {
            var restresponse = await ExecuteAsync(restrequest);
            return await Deserialize<T>(restrequest, restresponse);
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest restrequest)
        {
            var httpclient = new HttpClient();
            var request = new HttpRequestMessage(restrequest.Method, restrequest.Uri);

            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "");
            //request.Content = new FormUrlEncodedContent();
            
            var response = await httpclient.SendAsync(request);

            //var restresponse = new RestResponse() { ResponseStatus = ResponseStatus.None };
            var restresponse = new RestResponse();
            return restresponse;
            //    var webresponse = (HttpWebResponse)webrequest.GetResponse();
            //    restresponse = this.WebRequest.ExtractResponse(webresponse);
            //    webresponse.Close();

            //restresponse = this.WebRequest.ParseWebException(exc);
        }

        public async Task<RestResponse<T>> Deserialize<T>(RestRequest restrequest, RestResponse restresponse) {
            return new RestResponse<T>();
        }
    }

    public class RestRequest {
        public HttpMethod Method { get; set; }
        public string Uri { get; set; }
    }

    public class RestResponse { }

    public class RestResponse<T> { }
}
