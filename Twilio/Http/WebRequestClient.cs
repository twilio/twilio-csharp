using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Twilio.Http
{
	public class WebRequestClient : HttpClient
	{
		public WebRequestClient() {
		}

		public override Response MakeRequest(Request request) {
			System.Net.HttpWebRequest httpRequest = (System.Net.HttpWebRequest) System.Net.WebRequest.Create(request.ConstructURL());
			httpRequest.Method = request.GetMethod().Method;
			httpRequest.Headers["Accept"] = "application/json";
			httpRequest.Headers["Accept-Encoding"] = "utf-8";
			var authBytes = Authentication(request.GetUsername(), request.GetPassword());
			httpRequest.Headers["Authorization"] = "Basic" + authBytes;
			httpRequest.ContentType = "application/x-www-form-urlencoded";
			var stream = httpRequest.EndGetRequestStream(null);
			stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
			System.Net.HttpWebResponse response = (System.Net.HttpWebResponse) httpRequest.EndGetResponse(null);
			var responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream);
			string content = reader.ReadToEnd();
			var statusCode = response.StatusCode;

			return new Response(statusCode, content);
		}
	}
}
