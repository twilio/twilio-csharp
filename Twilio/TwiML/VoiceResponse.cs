using System;
using System.IO;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class VoiceResponse
    {
        private XDocument document;
        private XElement response;

        public VoiceResponse()
        {
            response = new XElement("Response");
            document = new XDocument(
                new XDeclaration ("1.0", "utf-16", "yes"),
                response
            );
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
            XElement dial = new XElement("Dial", number);
            if (hangupOnStar != null) {
                dial.Add(new XAttribute("hangupOnStar", hangupOnStar));
            }            
            if (timeout != null) {
                dial.Add(new XAttribute("timeout", timeout));
            }
            if (timeLimit != null) {
                dial.Add(new XAttribute("timeLimit", timeLimit));
            }
            if (!String.IsNullOrEmpty(action)) {
                dial.Add(new XAttribute("action", action));
            }
            if (!String.IsNullOrEmpty(method)) {
                dial.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(callerId)) {
                dial.Add(new XAttribute("callerId", callerId));
            }
            if (!String.IsNullOrEmpty(record)) {
                dial.Add(new XAttribute("record", record));
            }

            response.Add(dial);
            return this;
        }

        public VoiceResponse Dial(Dial dial)
        {
            response.Add(dial.dial);
            return this;
        }

        public VoiceResponse Enqueue(String name,
            string action=null,
            string method=null,
            string waitUrl=null,
            String waitUrlMethod=null,
            string workflowSid=null)
        {
            XElement enqueue = new XElement("Enqueue", name);
            if (!String.IsNullOrEmpty(action)) {
                enqueue.Add(new XAttribute("action", action));
            }
            if (!String.IsNullOrEmpty(method)) {
                enqueue.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(waitUrl)) {
                enqueue.Add(new XAttribute("waitUrl", waitUrl));
            }
            if (!String.IsNullOrEmpty(waitUrlMethod)) {
                enqueue.Add(new XAttribute("waitUrlMethod", waitUrlMethod));
            }
            if (!String.IsNullOrEmpty(workflowSid)) {
                enqueue.Add(new XAttribute("workflowSid", workflowSid));
            }

            response.Add(enqueue);
            return this;
        }

        public VoiceResponse Gather(int? timeout=null,
            int? numDigits=null,
            string action=null,
            string method=null,
            string finishOnKey=null)
        {
            XElement gather = new XElement("Gather");
            if (timeout != null) {
                gather.Add(new XAttribute("timeout", timeout));
            }
            if (numDigits != null) {
                gather.Add(new XAttribute("numDigits", numDigits));
            }
            if (!String.IsNullOrEmpty(action)) {
                gather.Add(new XAttribute("action", action));
            }
            if (!String.IsNullOrEmpty(method)) {
                gather.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(finishOnKey)) {
                gather.Add(new XAttribute("finishOnKey", finishOnKey));
            }

            response.Add(gather);
            return this;
        }

        public VoiceResponse Gather(Gather gather)
        {
            response.Add(gather.gather);
            return this;
        }

        public VoiceResponse Hangup()
        {
            response.Add(new XElement("Hangup"));
            return this;
        }

        public VoiceResponse Leave()
        {
            response.Add(new XElement("Leave"));
            return this;
        }

        public VoiceResponse Pause(int? length=null)
        {
            XElement pause = new XElement("Pause");
            if (length == null) {
                pause.Add(new XAttribute("length", length));
            }

            response.Add(pause);
            return this;
        }

        public VoiceResponse Play(string url,
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

            response.Add(play);
            return this;
        }

        public VoiceResponse Record(bool? transcribe=null,
            bool? playBeep=null,
            int? tiemout=null,
            int? maxLength=null,
            string action=null,
            string method=null,
            string finishOnKey=null,
            string transcribeCallback=null,
            string trim=null)
        {
            XElement record = new XElement("Record");
            if (transcribe != null) {
                record.Add(new XAttribute("transcribe", transcribe));
            }
            if (playBeep != null) {
                record.Add(new XAttribute("playBeep", playBeep));
            }
            if (tiemout != null) {
                record.Add(new XAttribute("tiemout", tiemout));
            }
            if (maxLength != null) {
                record.Add(new XAttribute("maxLength", maxLength));
            }
            if (!String.IsNullOrEmpty(action)) {
                record.Add(new XAttribute("action", action));
            }
            if (!String.IsNullOrEmpty(method)) {
                record.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(finishOnKey)) {
                record.Add(new XAttribute("finishOnKey", finishOnKey));
            }
            if (!String.IsNullOrEmpty(transcribeCallback)) {
                record.Add(new XAttribute("transcribeCallback", transcribeCallback));
            }
            if (!String.IsNullOrEmpty(trim)) {
                record.Add(new XAttribute("trim", trim));
            }

            response.Add(record);
            return this;
        }

        public VoiceResponse Redirect(string url,
            string method=null)
        {
            XElement redirect = new XElement("Redirect", url);
            if (!String.IsNullOrEmpty(method)) {
                redirect.Add(new XAttribute("method", method));
            }

            response.Add(redirect);
            return this;
        }

        public VoiceResponse Reject(string reason=null)
        {
            XElement reject = new XElement("Reject");
            if (!String.IsNullOrEmpty(reason)) {
                reject.Add(new XAttribute("reason", reason));
            }

            response.Add(reject);
            return this;
        }

        public VoiceResponse Say(string body,
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

            response.Add(say);
            return this;
        }

        public VoiceResponse Sms(string body,
            string to=null,
            string from=null,
            string method=null,
            string action=null,
            string statusCallback=null)
        {
            XElement sms = new XElement("Sms", body);
            if (!String.IsNullOrEmpty(to)) {
                sms.Add(new XAttribute("to", to));
            }
            if (!String.IsNullOrEmpty(from)) {
                sms.Add(new XAttribute("from", from));
            }
            if (!String.IsNullOrEmpty(method)) {
                sms.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(action)) {
                sms.Add(new XAttribute("action", action));
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                sms.Add(new XAttribute("statusCallback", statusCallback));
            }

            response.Add(sms);
            return this;
        }

        public override string ToString()
        {
            StringWriter wr = new StringWriter();
            response.Save(wr);
            return wr.GetStringBuilder().ToString();
        }
    }
}

