using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class VoiceResponse
    {
        private readonly XElement _response;

        public VoiceResponse()
        {
            _response = new XElement("Response");
        }

        public VoiceResponse Dial(string number,
            bool? hangupOnStar=null,
            int? timeout=null,
            int? timeLimit=null,
            string action=null,
            string method=null,
            string callerId=null,
            string record=null) 
        {
            var dial = new XElement("Dial", number);
            if (hangupOnStar != null)
            {
                dial.Add(new XAttribute("hangupOnStar", hangupOnStar));
            }            
            if (timeout != null)
            {
                dial.Add(new XAttribute("timeout", timeout));
            }
            if (timeLimit != null)
            {
                dial.Add(new XAttribute("timeLimit", timeLimit));
            }
            if (!string.IsNullOrEmpty(action))
            {
                dial.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                dial.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(callerId))
            {
                dial.Add(new XAttribute("callerId", callerId));
            }
            if (!string.IsNullOrEmpty(record))
            {
                dial.Add(new XAttribute("record", record));
            }

            _response.Add(dial);
            return this;
        }

        public VoiceResponse Dial(Dial dial)
        {
            _response.Add(dial.Element);
            return this;
        }

        public VoiceResponse Enqueue(string name,
            string action=null,
            string method=null,
            string waitUrl=null,
            string waitUrlMethod=null,
            string workflowSid=null)
        {
            var enqueue = new XElement("Enqueue", name);
            if (!string.IsNullOrEmpty(action))
            {
                enqueue.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                enqueue.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(waitUrl))
            {
                enqueue.Add(new XAttribute("waitUrl", waitUrl));
            }
            if (!string.IsNullOrEmpty(waitUrlMethod))
            {
                enqueue.Add(new XAttribute("waitUrlMethod", waitUrlMethod));
            }
            if (!string.IsNullOrEmpty(workflowSid))
            {
                enqueue.Add(new XAttribute("workflowSid", workflowSid));
            }

            _response.Add(enqueue);
            return this;
        }

        public VoiceResponse Gather(int? timeout=null,
            int? numDigits=null,
            string action=null,
            string method=null,
            string finishOnKey=null)
        {
            var gather = new XElement("Gather");
            if (timeout != null)
            {
                gather.Add(new XAttribute("timeout", timeout));
            }
            if (numDigits != null)
            {
                gather.Add(new XAttribute("numDigits", numDigits));
            }
            if (!string.IsNullOrEmpty(action))
            {
                gather.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                gather.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(finishOnKey))
            {
                gather.Add(new XAttribute("finishOnKey", finishOnKey));
            }

            _response.Add(gather);
            return this;
        }

        public VoiceResponse Gather(Gather gather)
        {
            _response.Add(gather.Element);
            return this;
        }

        public VoiceResponse Hangup()
        {
            _response.Add(new XElement("Hangup"));
            return this;
        }

        public VoiceResponse Leave()
        {
            _response.Add(new XElement("Leave"));
            return this;
        }

        public VoiceResponse Pause(int? length=null)
        {
            var pause = new XElement("Pause");
            if (length != null)
            {
                pause.Add(new XAttribute("length", length));
            }

            _response.Add(pause);
            return this;
        }

        public VoiceResponse Play(string url,
            int? loop=null,
            int? digits=null)
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

            _response.Add(play);
            return this;
        }

        public VoiceResponse Record(bool? transcribe=null,
            bool? playBeep=null,
            int? timeout=null,
            int? maxLength=null,
            string action=null,
            string method=null,
            string finishOnKey=null,
            string transcribeCallback=null,
            string trim=null)
        {
            var record = new XElement("Record");
            if (transcribe != null)
            {
                record.Add(new XAttribute("transcribe", transcribe));
            }
            if (playBeep != null)
            {
                record.Add(new XAttribute("playBeep", playBeep));
            }
            if (timeout != null)
            {
                record.Add(new XAttribute("timeout", timeout));
            }
            if (maxLength != null)
            {
                record.Add(new XAttribute("maxLength", maxLength));
            }
            if (!string.IsNullOrEmpty(action))
            {
                record.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                record.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(finishOnKey))
            {
                record.Add(new XAttribute("finishOnKey", finishOnKey));
            }
            if (!string.IsNullOrEmpty(transcribeCallback))
            {
                record.Add(new XAttribute("transcribeCallback", transcribeCallback));
            }
            if (!string.IsNullOrEmpty(trim))
            {
                record.Add(new XAttribute("trim", trim));
            }

            _response.Add(record);
            return this;
        }

        public VoiceResponse Redirect(string url,
            string method=null)
        {
            var redirect = new XElement("Redirect", url);
            if (!string.IsNullOrEmpty(method))
            {
                redirect.Add(new XAttribute("method", method));
            }

            _response.Add(redirect);
            return this;
        }

        public VoiceResponse Reject(string reason=null)
        {
            var reject = new XElement("Reject");
            if (!string.IsNullOrEmpty(reason))
            {
                reject.Add(new XAttribute("reason", reason));
            }

            _response.Add(reject);
            return this;
        }

        public VoiceResponse Say(string body,
            int? loop=null,
            string language=null,
            string voice=null)
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

            _response.Add(say);
            return this;
        }

        public VoiceResponse Sms(string body,
            string to=null,
            string from=null,
            string method=null,
            string action=null,
            string statusCallback=null)
        {
            var sms = new XElement("Sms", body);
            if (!string.IsNullOrEmpty(to))
            {
                sms.Add(new XAttribute("to", to));
            }
            if (!string.IsNullOrEmpty(from))
            {
                sms.Add(new XAttribute("from", from));
            }
            if (!string.IsNullOrEmpty(method))
            {
                sms.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(action))
            {
                sms.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(statusCallback))
            {
                sms.Add(new XAttribute("statusCallback", statusCallback));
            }

            _response.Add(sms);
            return this;
        }

        public override string ToString()
        {
            var declaration = new XDeclaration("1.0", "utf-8", null);
            var document = new XDocument(declaration, _response);

            var wr = new Utf8StringWriter();
            document.Save(wr);
            return wr.GetStringBuilder().ToString().Replace("\r", "");
        }
    }
}

