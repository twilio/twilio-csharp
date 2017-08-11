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
        /// <param name="input">list of inputs accepted</param>
        /// <param name="action">Action URL</param>
        /// <param name="method">Aciton URL method</param>
        /// <param name="finishOnKey">Finish gather on key</param>
        /// <param name="partialResultCallback">if provided, Twilio will make requests to your partialResultCallback in real-time as speech is recognized</param>
        /// <param name="partialResultCallbackMethod">GET, POST</param>
        /// <param name="language">The language Twilio should recognize as specified using a BCP-47 language tag</param>
        /// <param name="hints">A list of words or phrases, up to 100 characters each that Twilio should expect during recognition</param>
        /// <param name="profanityFilter">Specifies if Twilio should filter out profanities</param>
        /// <param name="speechTimeout">sets the limit in seconds that Twilio will wait for speech before stopping</param>
        /// <param name="bargeIn">Specifies if Twilio should stop playing media from nested or verbs once Twilio receives speech or DTMF</param>
        public Gather(int? timeout=null,
            int? numDigits=null,
            string input=null,
            string action=null,
            string method=null,
            string finishOnKey=null,
            string partialResultCallback=null,
            string partialResultCallbackMethod=null,
            string language=null,
            string hints=null,
            bool profanityFilter=true,
            int? speechTimeout=null,
            bool bargeIn=true
            
            )
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
            if (input != null)
            {
                Element.Add(new XAttribute("input", input));
            }
            if (action != null)
            {
                Element.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                Element.Add(new XAttribute("method", method));
            }
            if (finishOnKey != null)
            {
                Element.Add(new XAttribute("finishOnKey", finishOnKey));
            }
            
            if (partialResultCallback != null)
            {
                Element.Add(new XAttribute("partialResultCallback", partialResultCallback));
            }
            if (partialResultCallbackMethod != null)
            {
                Element.Add(new XAttribute("partialResultCallbackMethod", partialResultCallbackMethod));
            }
            if (language != null)
            {
                Element.Add(new XAttribute("language", language));
            }
            if (hints != null)
            {
                Element.Add(new XAttribute("hints", hints));
            }
            if (profanityFilter != true)
            {
                Element.Add(new XAttribute("profanityFilter", profanityFilter));
            }
            if (speechTimeout != null)
            {
                Element.Add(new XAttribute("speechTimeout", speechTimeout));
            }
            if (bargeIn != true)
            {
                Element.Add(new XAttribute("bargeIn", bargeIn));
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
            var play = new XElement("Play", url);

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
    }
}
