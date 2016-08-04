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
                number.Add("sendDigits", sendDigits);
            }
            if (!String.IsNullOrEmpty(url)) {
                number.Add("url", url);
            }
            if (!String.IsNullOrEmpty(method)) {
                number.Add("method", method);
            }
            if (!String.IsNullOrEmpty(statusCallbackEvent)) {
                number.Add("statusCallbackEvent", statusCallbackEvent);
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                number.Add("statusCallback", statusCallback);
            }
            if (!String.IsNullOrEmpty(statusCallbackMethod)) {
                number.Add("statusCallbackMethod", statusCallbackMethod);
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
                client.Add("method", method);
            }
            if (!String.IsNullOrEmpty(url)) {
                client.Add("url", url);
            }
            if (!String.IsNullOrEmpty(statusCallbackEvent)) {
                client.Add("statusCallbackEvent", statusCallbackEvent);
            }
            if (!String.IsNullOrEmpty(statusCallbackMethod)) {
                client.Add("statusCallbackMethod", statusCallbackMethod);
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                client.Add("statusCallback", statusCallback);
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
                sip.Add("username", username);
            }
            if (!String.IsNullOrEmpty(password)) {
                sip.Add("password", password);
            }
            if (!String.IsNullOrEmpty(url)) {
                sip.Add("url", url);
            }
            if (!String.IsNullOrEmpty(method)) {
                sip.Add("method", method);
            }
            if (!String.IsNullOrEmpty(statusCallbackEvent)) {
                sip.Add("statusCallbackEvent", statusCallbackEvent);
            }
            if (!String.IsNullOrEmpty(statusCallback)) {
                sip.Add("statusCallback", statusCallback);
            }
            if (!String.IsNullOrEmpty(statusCallbackMethod)) {
                sip.Add("statusCallbackMethod", statusCallbackMethod);
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
                conference.Add("muted", muted);
            }
            if (startConferenceOnEnter != null) {
                conference.Add("startConferenceOnEnter", startConferenceOnEnter);
            }
            if (endConferenceOnExit != null) {
                conference.Add("endConferenceOnExit", endConferenceOnExit);
            }
            if (maxParticipants != null) {
                conference.Add("maxParticipants", maxParticipants);
            }
            if (!String.IsNullOrEmpty(beep)) {
                conference.Add("beep", beep);
            }
            if (!String.IsNullOrEmpty(record)) {
                conference.Add("record", record);
            }
            if (!String.IsNullOrEmpty(trim)) {
                conference.Add("trim", trim);
            }
            if (!String.IsNullOrEmpty(waitMethod)) {
                conference.Add("waitMethod", waitMethod);
            }
            if (!String.IsNullOrEmpty(waitUrl)) {
                conference.Add("waitUrl", waitUrl);
            }
            if (!String.IsNullOrEmpty(eventCallbackUrl)){
                conference.Add("eventCallbackUrl", eventCallbackUrl);
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
                queue.Add("url", url);
            }
            if (!String.IsNullOrEmpty(method)) {
                queue.Add("method", method);
            }
            if (!String.IsNullOrEmpty(reservationSid)) {
                queue.Add("reservationSid", reservationSid);
            }
            if (!String.IsNullOrEmpty(postWorkActivitySid)) {
                queue.Add("postWorkActivitySid", postWorkActivitySid);
            }

            dial.Add(queue);
            return this;
        }
    }
}

