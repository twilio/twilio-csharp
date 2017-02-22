using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Voice TwiML response
    /// </summary>
    public class VoiceResponse
    {
        private readonly XElement _response;

        /// <summary>
        /// Create new VoiceResponse
        /// </summary>
        public VoiceResponse()
        {
            _response = new XElement("Response");
        }

        /// <summary>
        /// Dial a phone number
        /// </summary>
        /// <param name="number">Number to dial</param>
        /// <param name="hangupOnStar">Hangup call on *</param>
        /// <param name="timeout">Timeout to wait for answer</param>
        /// <param name="timeLimit">Max time of call</param>
        /// <param name="action">Action URL</param>
        /// <param name="method">Action URL method</param>
        /// <param name="callerId">Caller ID to display</param>
        /// <param name="record">Record the call</param>
        /// <returns>VoiceResponse TwiML</returns>
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

        /// <summary>
        /// Dial a resource
        /// </summary>
        /// <param name="dial">Dial TwiML</param>
        /// <returns>VoiceResponse</returns>
        public VoiceResponse Dial(Dial dial)
        {
            _response.Add(dial.Element);
            return this;
        }

        /// <summary>
        /// Enqueue an action
        /// </summary>
        /// <param name="name">Queue name</param>
        /// <param name="action">Action URL</param>
        /// <param name="method">Action URL method</param>
        /// <param name="waitUrl">Wait URL</param>
        /// <param name="waitUrlMethod">Wait URL method</param>
        /// <param name="workflowSid">TaskRouter workflow SID</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Gather data
        /// </summary>
        /// <param name="timeout">Timeout to wait for data</param>
        /// <param name="numDigits">Number of digits to collect</param>
        /// <param name="action">Action URL</param>
        /// <param name="method">Action URL method</param>
        /// <param name="finishOnKey">Finish gather on key</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Gather data
        /// </summary>
        /// <param name="gather">Gather TwiML</param>
        /// <returns>VoiceResponse</returns>
        public VoiceResponse Gather(Gather gather)
        {
            _response.Add(gather.Element);
            return this;
        }

        /// <summary>
        /// Hangup call
        /// </summary>
        /// <returns>VoiceResponse</returns>
        public VoiceResponse Hangup()
        {
            _response.Add(new XElement("Hangup"));
            return this;
        }

        /// <summary>
        /// Leave call queue
        /// </summary>
        /// <returns>VoiceResponse</returns>
        public VoiceResponse Leave()
        {
            _response.Add(new XElement("Leave"));
            return this;
        }

        /// <summary>
        /// Pause call
        /// </summary>
        /// <param name="length">seconds to pause</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Play a recording
        /// </summary>
        /// <param name="url">URL of recording</param>
        /// <param name="loop">times to loop</param>
        /// <param name="digits">Play DTMF tones</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Record call
        /// </summary>
        /// <param name="transcribe">Transcribe the recording</param>
        /// <param name="playBeep">Play beep before recording</param>
        /// <param name="timeout">Timeout recording after silence</param>
        /// <param name="maxLength">Max length of recording</param>
        /// <param name="action">Action URL</param>
        /// <param name="method">Action URL method</param>
        /// <param name="finishOnKey">Finish recording on digit</param>
        /// <param name="transcribeCallback">Transcrible the callback</param>
        /// <param name="trim">Trim recording</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Redirect call
        /// </summary>
        /// <param name="url">TwiML URL</param>
        /// <param name="method">TwiML URL method</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Reject call 
        /// </summary>
        /// <param name="reason">Rejection reason</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Say something
        /// </summary>
        /// <param name="body">Message to read</param>
        /// <param name="loop">Times to loop</param>
        /// <param name="language">Language of message body</param>
        /// <param name="voice">Voice to use</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Send an SMS
        /// </summary>
        /// <param name="body">Body of text message</param>
        /// <param name="to">Recipient</param>
        /// <param name="from">Sender</param>
        /// <param name="method">Action URL method</param>
        /// <param name="action">Action URL</param>
        /// <param name="statusCallback">Status callback URL</param>
        /// <returns>VoiceResponse</returns>
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

        /// <summary>
        /// Generate XML
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

