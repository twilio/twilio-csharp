namespace Twilio
{
	public class Response
	{
		private System.Net.HttpStatusCode statusCode;
		private System.Net.Http.HttpContent content;

		public Response (System.Net.HttpStatusCode statusCode, System.Net.Http.HttpContent content)
		{
			this.statusCode = statusCode;
			this.content = content;
		}
	}
}
