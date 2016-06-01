using System;
using System.Text;
using System.IO;
using System.Net;
using Twilio.Exceptions;
using Newtonsoft.Json;
#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Http
{
	public class WebRequestClient : HttpClient
	{
		public WebRequestClient() {
		}

		public override Response MakeRequest(Request request) {
			System.Net.HttpWebRequest httpRequest = (System.Net.HttpWebRequest) System.Net.WebRequest.Create(request.ConstructURL());
			httpRequest.Method = request.GetMethod().ToString();
			httpRequest.Accept = "application/json";
			httpRequest.Headers["Accept-Encoding"] = "utf-8";
			var authBytes = Authentication(request.GetUsername(), request.GetPassword());
			httpRequest.Headers["Authorization"] = "Basic " + authBytes;
			httpRequest.ContentType = "application/x-www-form-urlencoded";

			if (request.GetMethod() != Twilio.Http.HttpMethod.GET) {
				#if NET40
				var streamTask = Task.Factory.FromAsync<Stream>(httpRequest.BeginGetRequestStream, httpRequest.EndGetRequestStream, null);
				streamTask.Wait();
				var stream = streamTask.Result;
				stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
				#else
				var stream = httpRequest.GetRequestStream();
				stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
				#endif
			}

			try {
				#if NET40
				var responseTask = Task.Factory.FromAsync<System.Net.WebResponse>(httpRequest.BeginGetResponse, httpRequest.EndGetResponse, null);
				responseTask.Wait();
				var response = (System.Net.HttpWebResponse) responseTask.Result;
				var responseStream = response.GetResponseStream();
				#else
				var response = (System.Net.HttpWebResponse) httpRequest.GetResponse();
				var responseStream = response.GetResponseStream();
				#endif

				StreamReader reader = new StreamReader(responseStream);
				string content = reader.ReadToEnd();
				var statusCode = response.StatusCode;

				return new Response(statusCode, content);
			#if NET40
			} catch (AggregateException ae) {
				ae.Handle ((x) => {
					if (x is System.Net.WebException) {
						var e = (System.Net.WebException) x;
						var errorResponse = (HttpWebResponse) e.Response;

						if (errorResponse.StatusCode >= HttpStatusCode.InternalServerError && errorResponse.StatusCode < HttpStatusCode.HttpVersionNotSupported) {
							throw new TwilioException("Internal Server error: " + errorResponse.StatusDescription);
						}

						var responseStream = errorResponse.GetResponseStream();
						StreamReader errorReader = new StreamReader(responseStream);
						string errorContent = errorReader.ReadToEnd();

						try {
							var restEx = RestException.FromJson(errorContent);
							if (restEx == null) {
								throw new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
							}

							throw restEx;
						} catch (JsonReaderException je) {
							throw new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
						}
					}

					return false;
				});
			}
			#else
			} catch (WebException e) {
				var errorResponse = (HttpWebResponse) e.Response;

				if (errorResponse.StatusCode >= HttpStatusCode.InternalServerError && errorResponse.StatusCode < HttpStatusCode.HttpVersionNotSupported) {
					throw new TwilioException("Internal Server error: " + errorResponse.StatusDescription);
				}

				var responseStream = errorResponse.GetResponseStream();
				StreamReader errorReader = new StreamReader(responseStream);
				string errorContent = errorReader.ReadToEnd();

				try {
					var restEx = RestException.FromJson(errorContent);
					if (restEx == null) {
						throw new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
					}

					throw restEx;
				} catch (JsonReaderException je) {
					throw new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
				}
			}
			#endif

			return null;
		}
	}
}
