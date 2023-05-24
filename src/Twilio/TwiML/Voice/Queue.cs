// This code was generated by
// \ / _    _  _|   _  _
//  | (_)\/(_)(_|\/| |(/_  v1.0.0
//       /       /

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Twilio.Converters;

namespace Twilio.TwiML.Voice
{

    /// <summary>Queue TwiML Noun</summary>
    public class Queue : TwiML
    {
        /// <summary>Queue name</summary>
        public string Name { get; set; }

        /// <summary>Action URL</summary>
        public Uri Url { get; set; }

        /// <summary>Action URL method</summary>
        public Twilio.Http.HttpMethod Method { get; set; }

        /// <summary>TaskRouter Reservation SID</summary>
        public string ReservationSid { get; set; }

        /// <summary>TaskRouter Activity SID</summary>
        public string PostWorkActivitySid { get; set; }

        /// <summary>Create a new Queue</summary>
        /// <param name="name">Queue name, the body of the TwiML Element.</param>
        /// <param name="url">Action URL</param>
        /// <param name="method">Action URL method</param>
        /// <param name="reservationSid">TaskRouter Reservation SID</param>
        /// <param name="postWorkActivitySid">TaskRouter Activity SID</param>
        public Queue(string name = null,
                     Uri url = null,
                     Twilio.Http.HttpMethod method = null,
                     string reservationSid = null,
                     string postWorkActivitySid = null) : base("Queue")
        {
            this.Name = name;
            this.Url = url;
            this.Method = method;
            this.ReservationSid = reservationSid;
            this.PostWorkActivitySid = postWorkActivitySid;
        }

        /// <summary>Return the body of the TwiML tag</summary>
        protected override string GetElementBody()
        {
            return this.Name != null ? this.Name : string.Empty;
        }

        /// <summary>Return the attributes of the TwiML tag</summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            if (this.Url != null)
            {
                attributes.Add(new XAttribute("url", Serializers.Url(this.Url)));
            }
            if (this.Method != null)
            {
                attributes.Add(new XAttribute("method", this.Method.ToString()));
            }
            if (this.ReservationSid != null)
            {
                attributes.Add(new XAttribute("reservationSid", this.ReservationSid));
            }
            if (this.PostWorkActivitySid != null)
            {
                attributes.Add(new XAttribute("postWorkActivitySid", this.PostWorkActivitySid));
            }
            return attributes;
        }

        /// <summary>Append a child TwiML element to this element returning this element to allow chaining.</summary>
        /// <param name="childElem">Child TwiML element to add</param>
        public new Queue Append(TwiML childElem)
        {
            return (Queue) base.Append(childElem);
        }

        /// <summary>Add freeform key-value attributes to the generated xml</summary>
        /// <param name="key">Option key</param>
        /// <param name="value">Option value</param>
        public new Queue SetOption(string key, object value)
        {
            return (Queue) base.SetOption(key, value);
        }
    }

}