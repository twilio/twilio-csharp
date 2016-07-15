using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Twilio.Http
{
	public class SystemNetClient : HttpClient
	{
		public SystemNetClient () {
		}

        public override Response MakeRequest(Request request)
        {
            var task = this.MakeRequestAsync(request);
            task.RunSynchronously();
            return task.Result;
        }

        public override async Task<Response> MakeRequestAsync(Request request)
        {
            var httpRequest = new System.Net.Http.HttpRequestMessage();
            httpRequest.RequestUri = request.ConstructURL();
            httpRequest.Method = (System.Net.Http.HttpMethod) Enum.Parse(typeof(Twilio.Http.HttpMethod), request.GetMethod().ToString());
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", Authentication(request.GetUsername(), request.GetPassword()));
			httpRequest.Content = new ByteArrayContent(request.EncodePostParams());

            var httpClient = new System.Net.Http.HttpClient();
            var response = await httpClient.SendAsync(httpRequest);

            var content = await response.Content.ReadAsStringAsync();

            var statusCode = response.StatusCode;

			return new Response(statusCode, content);
		}
	}
}