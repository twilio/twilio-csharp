using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Message
    {
        public XElement Element { get; }
    
        public Message(
            string to=null,
            string from=null,
            string method=null,
            string action=null,
            string statusCallback=null
        )
        {
            Element = new XElement("Message");
            if (!string.IsNullOrEmpty(to))
            {
                Element.Add(new XAttribute("to", to));
            }
            
            if (!string.IsNullOrEmpty(from))
            {
                Element.Add(new XAttribute("from", from));
            }
            
            if (!string.IsNullOrEmpty(method))
            {
                Element.Add(new XAttribute("method", method));
            }
            
            if (!string.IsNullOrEmpty(action))
            {
                Element.Add(new XAttribute("action", action));
            }
            
            if (!string.IsNullOrEmpty(statusCallback))
            {
                Element.Add(new XAttribute("statusCallback", statusCallback));
            }
        }

        public Message Body(string body)
        {
            Element.Add(new XElement("Body", body));
            return this;
        }

        public Message Media(string media)
        {
            Element.Add(new XElement("Media", media));
            return this;
        }
        
    }
}

