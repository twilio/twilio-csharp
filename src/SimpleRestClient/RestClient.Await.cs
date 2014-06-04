using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple;

#if (PCL)
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
#endif

namespace Simple
{
#if (PCL)
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
            HttpClient httpclient;
            if (this.MessageHandler != null)
                httpclient = new HttpClient(this.MessageHandler);
            else
                httpclient = new HttpClient();
           
            httpclient.Timeout = new TimeSpan(0,0,this.Timeout);

            if (!string.IsNullOrWhiteSpace(this.UserAgent))
            {
                httpclient.DefaultRequestHeaders.Add("User-Agent", this.UserAgent);
            }

            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpclient.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");

            var handler = new HttpClientHandler();
            if (this.Proxy != null) { handler.Proxy = this.Proxy; }

            var request = ConfigureRequestMessage(restrequest);

            var restresponse = new RestResponse() { ResponseStatus = ResponseStatus.None };

            try
            {
                var response = await httpclient.SendAsync(request);

                restresponse.StatusCode = response.StatusCode;
                restresponse.StatusDescription = response.ReasonPhrase;

                if (response.Content!=null)
                    restresponse.RawBytes = await response.Content.ReadAsByteArrayAsync();

                restresponse.ResponseStatus = ResponseStatus.Completed;
            }
            catch (TaskCanceledException exc)
            {
                restresponse.ErrorException = exc;
                restresponse.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                restresponse.ErrorException = exc;
                restresponse.ErrorMessage = exc.Message;

                Debug.WriteLine(exc.Message);
            }

            return restresponse;
        }

        public HttpRequestMessage ConfigureRequestMessage(RestRequest restrequest)
        {
            foreach (var param in this.DefaultParameters)
            {
                if (!restrequest.Parameters.Any(p => p.Name == param.Name))
                {
                    restrequest.Parameters.Add(param);
                }
            }

            var request = new HttpRequestMessage(new HttpMethod(restrequest.Method), Simple.UriBuilder.Build(this.BaseUrl, restrequest));

            foreach (var param in restrequest.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
            {
                request.Headers.Add(param.Name, param.Value.ToString());
            }

            var @params = restrequest.Parameters
                                .Where(p => p.Type == ParameterType.GetOrPost && p.Value != null)
                                .Select(p => new KeyValuePair<string, string>(p.Name, p.Value.ToString()));

            if (restrequest.Method == "POST" || restrequest.Method == "PUT")
            {
                request.Content = new FormUrlEncodedContent(@params);
            }

            return request;
        }
    }
#endif
}
