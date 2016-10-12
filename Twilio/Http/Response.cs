using System.Net;

namespace Twilio.Http
{
	public class Response
	{
		public HttpStatusCode StatusCode { get; }
		public string Content { get; }

		public Response (HttpStatusCode statusCode, string content)
		{
			StatusCode = statusCode;
			Content = content;
		}
	}
}
