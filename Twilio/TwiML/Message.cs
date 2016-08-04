using System;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Message
    {
        public XElement message {get;}
    
        public Message(string to=null, string from=null, string method=null, string action=null, string statusCallback=null)
        {
            message = new XElement("Message");
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
        }

        public Message Body(string body)
        {
            message.Add(new XElement("Body", body));
            return this;
        }

        public Message Media(string media)
        {
            message.Add(new XElement("Media", media));
            return this;
        }
        
    }
}

