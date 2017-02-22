using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Message TwiML verb
    /// </summary>
    public class Message
    {
        /// <summary>
        /// XML representation
        /// </summary>
        public XElement Element { get; }
    
        /// <summary>
        /// Create a message
        /// </summary>
        /// <param name="to">recipient</param>
        /// <param name="from">sender</param>
        /// <param name="method">Action URL method</param>
        /// <param name="action">Action URL</param>
        /// <param name="statusCallback">Status callback URL</param>
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

        /// <summary>
        /// Add a body to the message
        /// </summary>
        /// <param name="body">Message body</param>
        /// <returns>Message element</returns>
        public Message Body(string body)
        {
            Element.Add(new XElement("Body", body));
            return this;
        }

        /// <summary>
        /// Add media to the message
        /// </summary>
        /// <param name="media">Media URL</param>
        /// <returns>Message element</returns>
        public Message Media(string media)
        {
            Element.Add(new XElement("Media", media));
            return this;
        }
        
    }
}

