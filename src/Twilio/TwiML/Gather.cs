using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Gather TwiML verb
    /// </summary>
    public class Gather
    {
        /// <summary>
        /// XML representation
        /// </summary>
        public XElement Element { get; }

        /// <summary>
        /// Create a new Gather verb
        /// </summary>
        /// <param name="timeout">Gather timeout</param>
        /// <param name="numDigits">Number of digits to gather</param>
        /// <param name="action">Action URL</param>
        /// <param name="method">Aciton URL method</param>
        /// <param name="finishOnKey">Finish gather on key</param>
        public Gather(int? timeout=null,
            int? numDigits=null,
            string action=null,
            string method=null,
            string finishOnKey=null)
        {
            Element = new XElement("Gather");
            if (timeout != null)
            {
                Element.Add(new XAttribute("timeout", timeout));
            }
            if (numDigits != null)
            {
                Element.Add(new XAttribute("numDigits", numDigits));
            }
            if (action != null)
            {
                Element.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                Element.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(finishOnKey))
            {
                Element.Add(new XAttribute("finishOnKey", finishOnKey));
            }
        }

        /// <summary>
        /// Prompt for the Gather
        /// </summary>
        /// <param name="body">Body of message</param>
        /// <param name="loop">Times to loop</param>
        /// <param name="language">Body language</param>
        /// <param name="voice">Voice to use</param>
        /// <returns>Gather Element</returns>
        public Gather Say(string body, int? loop=null, string language=null, string voice=null)
        {
            var say = new XElement("Say", body);
            if (loop != null)
            {
                say.Add(new XAttribute("loop", loop));
            }
            if (!string.IsNullOrEmpty(language))
            {
                say.Add(new XAttribute("language", language));
            }
            if (!string.IsNullOrEmpty(voice))
            {
                say.Add(new XAttribute("voice", voice));
            }

            Element.Add(say);
            return this;
        }

        /// <summary>
        /// Play recording to prompt for Gather
        /// </summary>
        /// <param name="url">URL of recording</param>
        /// <param name="loop">Times to look</param>
        /// <param name="digits">Play DTMF tones</param>
        /// <returns>Gather Element</returns>
        public Gather Play(string url=null, int? loop=null, string digits=null)
        {
            XElement play = null;

            if (!string.IsNullOrEmpty(url))
            {
                play = new XElement("Play", url);
            }
            else
            {
                play = new XElement("Play");
            }

            if (loop != null)
            {
                play.Add(new XAttribute("loop", loop));
            }
            if (!string.IsNullOrEmpty(digits))
            {
                play.Add(new XAttribute("digits", digits));
            }

            Element.Add(play);
            return this;
        }

        /// <summary>
        /// Pause for Gather
        /// </summary>
        /// <param name="length">seconds to pause</param>
        /// <returns>Gather Element</returns>
        public Gather Pause(int? length=null)
        {
            var pause = new XElement("Pause");
            if (length != null)
            {
                pause.Add(new XAttribute("length", length));
            }

            Element.Add(pause);
            return this;
        }

        /// <summary>
        /// Generate XML for TwiML
        /// </summary>
        /// <returns>TwiML XML</returns>
        public override string ToString()
        {
            var declaration = new XDeclaration("1.0", "utf-8", null);
            var document = new XDocument(declaration, Element);

            var wr = new Utf8StringWriter();
            document.Save(wr);
            return wr.GetStringBuilder().ToString();
        }
    }
}
