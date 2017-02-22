using System.IO;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Messaging TwiML response
    /// </summary>
    public class MessagingResponse
    {
        private readonly XElement _response;

        /// <summary>
        /// Create a new MessagingResponse
        /// </summary>
        public MessagingResponse()
        {
            _response = new XElement("Response");
        }

        /// <summary>
        /// Redirect to a URL
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="url">URL to redirect to</param>
        /// <returns>TwiML</returns>
        public MessagingResponse Redirect(string method=null, string url=null)
        {
            var redirect = new XElement("Redirect");
            if (!string.IsNullOrEmpty(method))
            {
                redirect.Add(new XAttribute("method", method));
            }

            if (!string.IsNullOrEmpty(url))
            {
                redirect.Add(new XAttribute("url", url));
            }
            
            _response.Add(redirect);
            return this;
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="body">Message body</param>
        /// <param name="to">Recipient</param>
        /// <param name="from">Sender</param>
        /// <param name="method">Action URL method</param>
        /// <param name="action">Action URL</param>
        /// <param name="statusCallback">Status callback URL</param>
        /// <returns>TwiML</returns>
        public MessagingResponse Message(string body, string to=null, string from=null, string method=null, string action=null, string statusCallback=null)
        {
            var message = new XElement("Message", body);
            if (!string.IsNullOrEmpty(to))
            {
                message.Add(new XAttribute("to", to));
            }

            if (!string.IsNullOrEmpty(from))
            {
                message.Add(new XAttribute("from", from));
            }

            if (!string.IsNullOrEmpty(method))
            {
                message.Add(new XAttribute("method", method));
            }
            
            if (!string.IsNullOrEmpty(action))
            {
                message.Add(new XAttribute("action", action));
            }

            if (!string.IsNullOrEmpty(statusCallback))
            {
                message.Add(new XAttribute("statusCallback", statusCallback));
            }

            _response.Add(message);
            return this;
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <returns>TwiML</returns>
        public MessagingResponse Message(Message message)
        {
            _response.Add(message.Element);
            return this;
        }

        /// <summary>
        /// Generate XML for TwiML
        /// </summary>
        /// <returns>TwiML XML</returns>
        public override string ToString()
        {
            var declaration = new XDeclaration("1.0", "utf-8", null);
            var document = new XDocument(declaration, _response);

            var wr = new Utf8StringWriter();
            document.Save(wr);
            return wr.GetStringBuilder().ToString();
        }
    }
}

