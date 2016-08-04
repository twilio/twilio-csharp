using System;
using System.IO;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class MessagingResponse
    {
        private XDocument document;
        private XElement response;

        public MessagingResponse()
        {
            response = new XElement("Response");
            document = new XDocument(
                new XDeclaration ("1.0", "utf-16", "yes"),
                response
            );
        }

        public MessagingResponse Redirect(string method=null, string url=null)
        {
            XElement redirect = new XElement("Redirect");
            if (!String.IsNullOrEmpty(method)) {
                redirect.Add(new XAttribute("method", method));
            }

            if (!String.IsNullOrEmpty(url)) {
                redirect.Add(new XAttribute("url", url));
            }
            
            response.Add(redirect);
            return this;
        }

        public MessagingResponse Message(string body, string to=null, string from=null, string method=null, string action=null, string statusCallback=null)
        {
            XElement message = new XElement("Message", body);
            if (!String.IsNullOrEmpty(to)) {
                message.Add(new XAttribute("to", to));
            }

            if (!String.IsNullOrEmpty(from)) {
                message.Add(new XAttribute("from", from));
            }

            if (!String.IsNullOrEmpty(method)) {
                message.Add(new XAttribute("method", method));
            }
            
            if (!String.IsNullOrEmpty(action)) {
                message.Add(new XAttribute("action", action));
            }

            if (!String.IsNullOrEmpty(statusCallback)) {
                message.Add(new XAttribute("statusCallback", statusCallback));
            }

            response.Add(message);
            return this;
        }

        public MessagingResponse Message(Message message)
        {
            response.Add(message.message);
            return this;
        }

        public override string ToString()
        {
            StringWriter wr = new StringWriter();
            response.Save(wr);
            return wr.GetStringBuilder().ToString();
        }
    }
}

