using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Dial
    {
        public XElement Element { get; }

        public Dial(bool? hangupOnStar=null,
            int? timeout=null,
            int? timeLimit=null,
            string action=null,
            string method=null,
            string callerId=null,
            string record=null)
        {
            Element = new XElement("Dial");
            if (hangupOnStar != null)
            {
                Element.Add(new XAttribute("hangupOnStar", hangupOnStar));
            }            
            if (timeout != null)
            {
                Element.Add(new XAttribute("timeout", timeout));
            }
            if (timeLimit != null)
            {
                Element.Add(new XAttribute("timeLimit", timeLimit));
            }
            if (!string.IsNullOrEmpty(action))
            {
                Element.Add(new XAttribute("action", action));
            }
            if (!string.IsNullOrEmpty(method))
            {
                Element.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(callerId))
            {
                Element.Add(new XAttribute("callerId", callerId));
            }
            if (!string.IsNullOrEmpty(record))
            {
                Element.Add(new XAttribute("record", record));
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
            var number = new XElement("Number", phoneNumber);
            if (!string.IsNullOrEmpty(sendDigits))
            {
                number.Add(new XAttribute("sendDigits", sendDigits));
            }
            if (!string.IsNullOrEmpty(url))
            {
                number.Add(new XAttribute("url", url));
            }
            if (!string.IsNullOrEmpty(method))
            {
                number.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(statusCallbackEvent))
            {
                number.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!string.IsNullOrEmpty(statusCallback))
            {
                number.Add(new XAttribute("statusCallback", statusCallback));
            }
            if (!string.IsNullOrEmpty(statusCallbackMethod))
            {
                number.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }

            Element.Add(number);
            return this;
        }

        public Dial Client(string name,
            string method=null,
            string url=null,
            string statusCallbackEvent=null,
            string statusCallbackMethod=null,
            string statusCallback=null)
        {
            var client = new XElement("Client", name);
            if (!string.IsNullOrEmpty(method))
            {
                client.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(url))
            {
                client.Add(new XAttribute("url", url));
            }
            if (!string.IsNullOrEmpty(statusCallbackEvent))
            {
                client.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!string.IsNullOrEmpty(statusCallbackMethod))
            {
                client.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }
            if (!string.IsNullOrEmpty(statusCallback))
            {
                client.Add(new XAttribute("statusCallback", statusCallback));
            }

            Element.Add(client);
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
            var sip = new XElement("Sip", address);
            if (!string.IsNullOrEmpty(username))
            {
                sip.Add(new XAttribute("username", username));
            }
            if (!string.IsNullOrEmpty(password))
            {
                sip.Add(new XAttribute("password", password));
            }
            if (!string.IsNullOrEmpty(url))
            {
                sip.Add(new XAttribute("url", url));
            }
            if (!string.IsNullOrEmpty(method))
            {
                sip.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(statusCallbackEvent))
            {
                sip.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!string.IsNullOrEmpty(statusCallback))
            {
                sip.Add(new XAttribute("statusCallback", statusCallback));
            }
            if (!string.IsNullOrEmpty(statusCallbackMethod))
            {
                sip.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }

            Element.Add(sip);
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
            var conference = new XElement("Conference", name);
            if (muted != null)
            {
                conference.Add(new XAttribute("muted", muted));
            }
            if (startConferenceOnEnter != null)
            {
                conference.Add(new XAttribute("startConferenceOnEnter", startConferenceOnEnter));
            }
            if (endConferenceOnExit != null)
            {
                conference.Add(new XAttribute("endConferenceOnExit", endConferenceOnExit));
            }
            if (maxParticipants != null)
            {
                conference.Add(new XAttribute("maxParticipants", maxParticipants));
            }
            if (!string.IsNullOrEmpty(beep))
            {
                conference.Add(new XAttribute("beep", beep));
            }
            if (!string.IsNullOrEmpty(record))
            {
                conference.Add(new XAttribute("record", record));
            }
            if (!string.IsNullOrEmpty(trim))
            {
                conference.Add(new XAttribute("trim", trim));
            }
            if (!string.IsNullOrEmpty(waitMethod))
            {
                conference.Add(new XAttribute("waitMethod", waitMethod));
            }
            if (!string.IsNullOrEmpty(waitUrl))
            {
                conference.Add(new XAttribute("waitUrl", waitUrl));
            }
            if (!string.IsNullOrEmpty(eventCallbackUrl))
            {
                conference.Add(new XAttribute("eventCallbackUrl", eventCallbackUrl));
            }

            Element.Add(conference);
            return this;
        }

        public Dial Queue(string name,
            string url=null,
            string method=null,
            string reservationSid=null,
            string postWorkActivitySid=null)
        {
            var queue = new XElement("Queue", name);
            if (!string.IsNullOrEmpty(url))
            {
                queue.Add(new XAttribute("url", url));
            }
            if (!string.IsNullOrEmpty(method))
            {
                queue.Add(new XAttribute("method", method));
            }
            if (!string.IsNullOrEmpty(reservationSid))
            {
                queue.Add(new XAttribute("reservationSid", reservationSid));
            }
            if (!string.IsNullOrEmpty(postWorkActivitySid))
            {
                queue.Add(new XAttribute("postWorkActivitySid", postWorkActivitySid));
            }

            Element.Add(queue);
            return this;
        }
    }
}

