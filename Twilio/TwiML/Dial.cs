using System;
using System.Xml.Linq;

namespace Twilio
{
    public class Dial
    {
        public XElement dial {get;}

        public Dial(bool? hangupOnStar=null,
            int? timeout=null,
            int? timeLimit=null,
            string action=null,
            string method=null,
            string callerId=null,
            string record=null)
        {
            dial = new XElement("Dial");
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
        }

        public Dial Number(string phoneNumber,
            string sendDigits=null,
            string url=null,
            string method=null,
            string statusCallbackEvent=null,
            string statusCallback=null,
            string statusCallbackMethod=null)
        {
            XElement number = new XElement("Number", phoneNumber);
            if (!String.IsNullOrEmpty(sendDigits)) {
                number.Add(new XAttribute("sendDigits", sendDigits));
            }
            if (!String.IsNullOrEmpty(url)) {
                number.Add(new XAttribute("url", url));
            }
            if (!String.IsNullOrEmpty(method)) {
                number.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(statusCallbackEvent)) {
                number.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                number.Add(new XAttribute("statusCallback", statusCallback));
            }
            if (!String.IsNullOrEmpty(statusCallbackMethod)) {
                number.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }

            dial.Add(number);
            return this;
        }

        public Dial Client(string name,
            string method=null,
            string url=null,
            string statusCallbackEvent=null,
            string statusCallbackMethod=null,
            string statusCallback=null)
        {
            XElement client = new XElement("Client", name);
            if (!String.IsNullOrEmpty(method)) {
                client.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(url)) {
                client.Add(new XAttribute("url", url));
            }
            if (!String.IsNullOrEmpty(statusCallbackEvent)) {
                client.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!String.IsNullOrEmpty(statusCallbackMethod)) {
                client.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                client.Add(new XAttribute("statusCallback", statusCallback));
            }

            dial.Add(client);
            return this;
        }

        public Dial Sip(string address,
            string username=null,
            string password=null,
            string url=null,
            string method=null,
            string statusCallbackEvent=null,
            string statusCallback=null,
            string statusCallbackMethod=null)
        {
            XElement sip = new XElement("Sip", address);
            if (!String.IsNullOrEmpty(username)) {
                sip.Add(new XAttribute("username", username));
            }
            if (!String.IsNullOrEmpty(password)) {
                sip.Add(new XAttribute("password", password));
            }
            if (!String.IsNullOrEmpty(url)) {
                sip.Add(new XAttribute("url", url));
            }
            if (!String.IsNullOrEmpty(method)) {
                sip.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(statusCallbackEvent)) {
                sip.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                sip.Add(new XAttribute("statusCallback", statusCallback));
            }
            if (!String.IsNullOrEmpty(statusCallbackMethod)) {
                sip.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }

            dial.Add(sip);
            return this;
        }

        public Dial Conference(string name,
            bool? muted=null,
            bool? startConferenceOnEnter=null,
            bool? endConferenceOnExit=null,
            int? maxParticipants=null,
            string beep=null,
            string record=null,
            string trim=null,
            string waitMethod=null,
            string waitUrl=null,
            string eventCallbackUrl=null)
        {
            XElement conference = new XElement("Conference", name);
            if (muted != null) {
                conference.Add(new XAttribute("muted", muted));
            }
            if (startConferenceOnEnter != null) {
                conference.Add(new XAttribute("startConferenceOnEnter", startConferenceOnEnter));
            }
            if (endConferenceOnExit != null) {
                conference.Add(new XAttribute("endConferenceOnExit", endConferenceOnExit));
            }
            if (maxParticipants != null) {
                conference.Add(new XAttribute("maxParticipants", maxParticipants));
            }
            if (!String.IsNullOrEmpty(beep)) {
                conference.Add(new XAttribute("beep", beep));
            }
            if (!String.IsNullOrEmpty(record)) {
                conference.Add(new XAttribute("record", record));
            }
            if (!String.IsNullOrEmpty(trim)) {
                conference.Add(new XAttribute("trim", trim));
            }
            if (!String.IsNullOrEmpty(waitMethod)) {
                conference.Add(new XAttribute("waitMethod", waitMethod));
            }
            if (!String.IsNullOrEmpty(waitUrl)) {
                conference.Add(new XAttribute("waitUrl", waitUrl));
            }
            if (!String.IsNullOrEmpty(eventCallbackUrl)){
                conference.Add(new XAttribute("eventCallbackUrl", eventCallbackUrl));
            }

            dial.Add(conference);
            return this;
        }

        public Dial Queue(string name,
            string url=null,
            string method=null,
            string reservationSid=null,
            string postWorkActivitySid=null)
        {
            XElement queue = new XElement("Queue", name);
            if (!String.IsNullOrEmpty(url)) {
                queue.Add(new XAttribute("url", url));
            }
            if (!String.IsNullOrEmpty(method)) {
                queue.Add(new XAttribute("method", method));
            }
            if (!String.IsNullOrEmpty(reservationSid)) {
                queue.Add(new XAttribute("reservationSid", reservationSid));
            }
            if (!String.IsNullOrEmpty(postWorkActivitySid)) {
                queue.Add(new XAttribute("postWorkActivitySid", postWorkActivitySid));
            }

            dial.Add(queue);
            return this;
        }
    }
}

