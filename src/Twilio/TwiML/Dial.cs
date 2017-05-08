using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Dial TwiML Verb
    /// </summary>
    public class Dial
    {
        /// <summary>
        /// XML Element for Dial Verb
        /// </summary>
        public XElement Element { get; }

        /// <summary>
        /// Create new Dial verb
        /// </summary>
        /// <param name="hangupOnStar">Hang up call on press of *</param>
        /// <param name="timeout">Dial timeout</param>
        /// <param name="timeLimit">Max duration of call</param>
        /// <param name="action">TwiML URL</param>
        /// <param name="method">HTTP Method</param>
        /// <param name="callerId">Caller ID to display</param>
        /// <param name="record">Record value</param>
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

        /// <summary>
        /// Dial a Number
        /// </summary>
        /// <param name="phoneNumber">Number to dial</param>
        /// <param name="sendDigits">Play DTMF tones when call answered</param>
        /// <param name="url">TwiML URL</param>
        /// <param name="method">HTTP method for the TwiML URL</param>
        /// <param name="statusCallbackEvent">Status callback events</param>
        /// <param name="statusCallback">Status callback URL</param>
        /// <param name="statusCallbackMethod">Status callback URL method</param>
        /// <returns>Dial element</returns>
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

        /// <summary>
        /// Dial a client
        /// </summary>
        /// <param name="name">Client name</param>
        /// <param name="method">TwiML URL</param>
        /// <param name="url">TwiML URL method</param>
        /// <param name="statusCallbackEvent">Status callback events</param>
        /// <param name="statusCallbackMethod">Status callback URL method</param>
        /// <param name="statusCallback">Status callback URL</param>
        /// <returns>Dial element</returns>
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

        /// <summary>
        /// Dial a SIP address
        /// </summary>
        /// <param name="address">SIP address</param>
        /// <param name="username">SIP username</param>
        /// <param name="password">SIP password</param>
        /// <param name="url">TwiML URL</param>
        /// <param name="method">TwiML URL method</param>
        /// <param name="statusCallbackEvent">status callback events</param>
        /// <param name="statusCallback">Status callback URL</param>
        /// <param name="statusCallbackMethod">Status callback URL method</param>
        /// <returns>Dial element</returns>
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

        /// <summary>
        /// Dial a conference
        /// </summary>
        /// <param name="name">Conference name</param>
        /// <param name="muted">Join conferenced muted</param>
        /// <param name="startConferenceOnEnter">Start conference on enter</param>
        /// <param name="endConferenceOnExit">End the conference on exit</param>
        /// <param name="maxParticipants">Max number of people in the conference</param>
        /// <param name="beep">Notification sound</param>
        /// <param name="record">Recording the conference</param>
        /// <param name="trim">Trim recording</param>
        /// <param name="waitMethod">Wait URL method</param>
        /// <param name="waitUrl">Wait TwiML URL</param>
        /// <param name="eventCallbackUrl">URL to hit on conference events, deprecated in favor of 'recordingStatusCallback', providing a 'recordingStatusCallback' will ignore 'eventCallbackUrl' if provided</param>
        /// <param name="region">Where Twilio should mix the conference</param>
        /// <param name="statusCallbackEvent">Specify which conference state changes should generate a webhook to the URL specified in the 'statusCallback'</param>
        /// <param name="statusCallback">URL to hit on conference events</param>
        /// <param name="statusCallbackMethod">Method to use when hitting 'statusCallback' url</param>
        /// <param name="recordingStatusCallback">If a conference recording was requested via the record attribute, Twilio will make a request to this URL when the recording is available to access</param>
        /// <param name="recordingStatusCallbackMethod">Method to use when hitting 'recordingStatusCallback'</param>
        /// <returns>Dial element</returns>
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
            string eventCallbackUrl=null,
            string region=null,
            string statusCallbackEvent=null,
            string statusCallback=null,
            string statusCallbackMethod=null,
            string recordingStatusCallback=null,
            string recordingStatusCallbackMethod=null)
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
            if (!string.IsNullOrEmpty(eventCallbackUrl) && string.IsNullOrEmpty(recordingStatusCallback))
            {
                conference.Add(new XAttribute("eventCallbackUrl", eventCallbackUrl));
            }
            if (!string.IsNullOrEmpty(region))
            {
                conference.Add(new XAttribute("region", region));
            }
            if (!string.IsNullOrEmpty(statusCallbackEvent))
            {
                conference.Add(new XAttribute("statusCallbackEvent", statusCallbackEvent));
            }
            if (!string.IsNullOrEmpty(statusCallback))
            {
                conference.Add(new XAttribute("statusCallback", statusCallback));
            }
            if (!string.IsNullOrEmpty(statusCallbackMethod))
            {
                conference.Add(new XAttribute("statusCallbackMethod", statusCallbackMethod));
            }
            if (!string.IsNullOrEmpty(recordingStatusCallback))
            {
                conference.Add(new XAttribute("recordingStatusCallback", recordingStatusCallback));
            }
            if (!string.IsNullOrEmpty(recordingStatusCallbackMethod))
            {
                conference.Add(new XAttribute("recordingStatusCallbackMethod", recordingStatusCallbackMethod));
            }

            Element.Add(conference);
            return this;
        }

        /// <summary>
        /// Dial a Queue
        /// </summary>
        /// <param name="name">Queue name</param>
        /// <param name="url">TwiML URL</param>
        /// <param name="method">TwiML URL method</param>
        /// <param name="reservationSid">TaskRouter reservation SID</param>
        /// <param name="postWorkActivitySid">TaskRouter activity SID</param>
        /// <returns></returns>
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

