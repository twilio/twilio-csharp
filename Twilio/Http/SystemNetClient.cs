#if !NET40
using System;
using System.Text;
using System.Threading.Tasks;

namespace Twilio.Http
{
	public class SystemNetClient : HttpClient
	{
		public SystemNetClient () {
		}

		public override Response MakeRequest(Request request) {
			var httpClient = new System.Net.Http.HttpClient();
            var httpRequest = new System.Net.Http.HttpRequestMessage();
            httpRequest.Method = request.GetMethod();
            httpRequest.RequestUri = request.ConstructURL();
            httpRequest.Properties.Add("Accept", "application/json");
			httpRequest.Properties.Add("Accept-Encoding", "utf-8");
			var authBytes = Authentication(request.GetUsername(), request.GetPassword());
			httpRequest.Properties.Add("Authorization", "Basic" + authBytes);
			httpRequest.Content = request.EncodePostParams();
			var responseTask = httpClient.SendAsync(httpRequest);
			responseTask.Wait();
			var response = responseTask.Result;
			var contentTask = response.Content.ReadAsStringAsync();
			contentTask.Wait();
			var content = contentTask.Result;

			var statusCode = response.StatusCode;

			return new Response(statusCode, content);
		}
	}
}
#endif