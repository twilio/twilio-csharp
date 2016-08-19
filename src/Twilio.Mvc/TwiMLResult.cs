using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;
using System.Xml.Linq;

namespace Twilio.TwiML.Mvc
{
    public class TwiMLResult : ActionResult
    {
        public XDocument Data { get; protected set; }

        public TwiMLResult()
        {
        }

        public TwiMLResult(string twiml)
        {
            var stream = new MemoryStream(Encoding.Default.GetBytes(twiml));

            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Prohibit;

            var reader = XmlReader.Create(stream, settings);

            Data = XDocument.Load(reader);
        }

        public TwiMLResult(XDocument twiml)
        {
            Data = twiml;
        }

        public TwiMLResult(TwilioResponse response)
        {
            if (response != null)
                Data = response.ToXDocument();
        }

        public override void ExecuteResult(ControllerContext controllerContext)
        {
            var context = controllerContext.RequestContext.HttpContext;
            context.Response.ContentType = "application/xml";

            if (Data == null)
            {
                Data = new XDocument(new XElement("Response"));
            }

            Data.Save(context.Response.Output);
        }
    }
}
