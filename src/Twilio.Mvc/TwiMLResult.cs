using System.Web.Mvc;
using System.Xml.Linq;

namespace Twilio.TwiML.Mvc
{
	public class TwiMLResult : ActionResult
	{
		XDocument data;

		public TwiMLResult()
		{
		}

		public TwiMLResult(string twiml)
		{
			data = XDocument.Parse(twiml);
		}

		public TwiMLResult(XDocument twiml)
		{
			data = twiml;
		}

		public TwiMLResult(TwilioResponse response)
		{
			if (response != null)
				data = response.ToXDocument();
		}

		public override void ExecuteResult(ControllerContext controllerContext)
		{
			var context = controllerContext.RequestContext.HttpContext;
			context.Response.ContentType = "application/xml";

			if (data == null)
			{
				data = new XDocument(new XElement("Response"));
			}

			data.Save(context.Response.Output);
		}

		public override string ToString()
		{
			return data.ToString();
		}
		
		public XDocument GetTwiMLDocument()
		{
			return data;
		}
	}
}
