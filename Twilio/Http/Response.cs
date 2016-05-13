namespace Twilio.Http
{
	public class Response
	{
		private System.Net.HttpStatusCode statusCode;
		private string content;

		public Response (System.Net.HttpStatusCode statusCode, string content)
		{
			this.statusCode = statusCode;
			this.content = content;
		}

		public System.Net.HttpStatusCode GetStatusCode() {
			return statusCode;
		}

		public string GetContent() {
			return content;
		}
	}
}
