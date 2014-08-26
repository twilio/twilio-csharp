using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class Message : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The date that this resource was created
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// The date that the Message was sent
        /// </summary>
        public DateTime DateSent { get; set; }
        /// <summary>
        /// The unique id of the Account that sent this Message.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The phone number that initiated the message in E.164 format. For
        /// incoming messages, this will be the remote phone. For outgoing messages,
        /// this will be one of your Twilio phone numbers.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// The phone number that received the message in E.164 format. For 
        /// incoming messages, this will be one of your Twilio phone numbers. 
        /// For outgoing messages, this will be the remote phone.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// The text body of the Message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The number of body segments associated with this message. In
        /// a common case, an ASCII message of 180 characters will be split into
        /// one segment with 160 characters and one with 20 characters, so
        /// NumSegments would be 2 for that message.
        /// </summary>
        public int NumSegments { get; set; }

        /// <summary>
        /// The number of images associated with this MMS
        /// </summary>
        public int NumImages { get; set; }
        

        /// <summary>
        /// The status of this Message. Either queued, sending, sent, or failed.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The direction of this Message. incoming for incoming messages,
        /// outbound-api for messages initiated via the REST API, outbound-call
        /// for messages initiated during a call or outbound-reply for messages
        /// initiated in response to an incoming Message.
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// The amount billed for the Message.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The version of the Twilio API used to process the Message.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// The error code of this message. If the message was unable to be delivered
        /// this property will contain the error code.  Error codes are listed in
        /// the Message docs: https://www.twilio.com/docs/api/rest/message.
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        /// The error message for this message. If the message was unable to be delivered
        /// this property will contain the error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
