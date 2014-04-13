using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple;

#if PCL
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
#endif

namespace Simple
{
#if PCL
    /// <summary>
    /// A simple class for making requests to HTTP API's
    /// </summary>
    public partial class RestClient
    {

        public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest restrequest)
        {
            var restresponse = await ExecuteAsync(restrequest);
            var data = Deserialize<T>(restrequest, restresponse);
            return data;
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest restrequest)
        {
            var httpclient = new HttpClient();

            var method = (HttpMethod)Enum.Parse(typeof(HttpMethod), restrequest.Method, true);
            var request = new HttpRequestMessage(method, Simple.UriBuilder.Build(this.BaseUrl, restrequest));

            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "");
            //request.Content = new FormUrlEncodedContent(restrequest.Parameters);

            var response = await httpclient.SendAsync(request);

            //var restresponse = new RestResponse() { ResponseStatus = ResponseStatus.None };
            var restresponse = new RestResponse();
            return restresponse;
            //    var webresponse = (HttpWebResponse)webrequest.GetResponse();
            //    restresponse = this.WebRequest.ExtractResponse(webresponse);
            //    webresponse.Close();

            //restresponse = this.WebRequest.ParseWebException(exc);
        }
    }
#endif
}
