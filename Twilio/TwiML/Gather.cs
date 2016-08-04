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
            if (numDigits != null) {
                gather.Add("numDigits", numDigits);
            }
            if (action != null) {
                gather.Add("action", action);
            }
            if (!String.IsNullOrEmpty(method)) {
                gather.Add("method", method);
            }
            if (!String.IsNullOrEmpty(finishOnKey)) {
                gather.Add("finishOnKey", finishOnKey);
            }
        }

        public Gather Say(string body,
            int? loop=null,
            string language=null,
            string voice=null)
        {
            XElement say = new XElement("Say", body);
            if (loop != null) {
                say.Add("loop", loop);
            }
            if (!String.IsNullOrEmpty(language)) {
                say.Add("language", language);
            }
            if (!String.IsNullOrEmpty(voice)) {
                say.Add("voice", voice);
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
                play.Add("loop", loop);
            }
            if (digits != null) {
                play.Add("digits", digits);
            }

            gather.Add(play);
            return this;
        }

        public Gather Pause(int? length=null)
        {
            XElement pause = new XElement("Pause");
            if (length != null) {
                pause.Add("length", length);
            }

            gather.Add(pause);
            return this;
        }

    }
}

