using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Gather
    {
        public XElement Element { get; }

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

        public Gather Play(string url, int? loop=null, int? digits=null)
        {
            var play = new XElement("Play", url);

            if (loop != null)
            {
                play.Add(new XAttribute("loop", loop));
            }
            if (digits != null)
            {
                play.Add(new XAttribute("digits", digits));
            }

            Element.Add(play);
            return this;
        }

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

