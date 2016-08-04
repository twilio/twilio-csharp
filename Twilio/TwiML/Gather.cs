using System;
using System.Xml.Linq;

namespace Twilio
{
    public class Gather
    {
        public XElement gather {get;}

        public Gather(int? timeout=null,
            int? numDigits=null,
            string action=null,
            string method=null,
            string finishOnKey=null)
        {
            gather = new XElement("Gather");
            if (timeout != null) {
                gather.Add(new XAttribute("timeout", timeout));
            }
            if (numDigits != null) {
                gather.Add(new XAttribute("numDigits", numDigits));
            }
            if (action != null) {
                gather.Add(new XAttribute("action", action));
            }
            if (!String.IsNullOrEmpty(method)) {
                gather.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(finishOnKey)) {
                gather.Add(new XAttribute("finishOnKey", finishOnKey));
            }
        }

        public Gather Say(string body,
            int? loop=null,
            string language=null,
            string voice=null)
        {
            XElement say = new XElement("Say", body);
            if (loop != null) {
                say.Add(new XAttribute("loop", loop));
            }
            if (!String.IsNullOrEmpty(language)) {
                say.Add(new XAttribute("language", language));
            }
            if (!String.IsNullOrEmpty(voice)) {
                say.Add(new XAttribute("voice", voice));
            }          

            gather.Add(say);
            return this;
        }

        public Gather Play(string url,
            int? loop=null,
            int? digits=null)
        {
            XElement play = new XElement("Play", url);

            if (loop != null) {
                play.Add(new XAttribute("loop", loop));
            }
            if (digits != null) {
                play.Add(new XAttribute("digits", digits));
            }

            gather.Add(play);
            return this;
        }

        public Gather Pause(int? length=null)
        {
            XElement pause = new XElement("Pause");
            if (length != null) {
                pause.Add(new XAttribute("length", length));
            }

            gather.Add(pause);
            return this;
        }

    }
}

