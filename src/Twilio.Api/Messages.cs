using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve the details for a specific Message instance.
        /// Makes a GET request to an Message Instance resource.
        /// </summary>
        /// <param name="messageSid">The Sid of the message to retrieve</param>
        public Message GetMessage(string messageSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
            request.AddUrlSegment("MessageSid", messageSid);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Returns a list of Messages. 
        /// The list includes paging information.
        /// Makes a GET request to the Message List resource.
        /// </summary>
        public MessageResult ListMessages()
        {
            return ListMessages(new MessageListRequest());
        }

        /// <summary>
        /// Returns a filtered list of Messages. The list includes paging information.
        /// Makes a GET request to the Messages List resource.
        /// </summary>
        /// <param name="options">The list filters for the request</param>
        public MessageResult ListMessages(MessageListRequest options) 
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages.json";
            AddMessageListOptions(options, request);
            return Execute<MessageResult>(request);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public Message SendMessage(string from, string to, string body, string[] mediaUrls)
        {
            return SendMessage(from, to, body, mediaUrls, string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
        public Message SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback)
        {
            return SendMessage(from, to, body, mediaUrls, statusCallback, string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
        /// <param name="applicationSid"></param>
        public Message SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid)
        {
            Require.Argument("from", from);
            Require.Argument("to", to);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Messages.json";
            request.AddParameter("From", from);
            request.AddParameter("To", to);
            
            if (body.HasValue()) request.AddParameter("Body", body);

            for (int i = 0; i < mediaUrls.Length; i++)
            {
                request.AddParameter("MediaUrl", mediaUrls[i]);
            }

            if (statusCallback.HasValue()) request.AddParameter("StatusCallback", statusCallback);
            if (applicationSid.HasValue()) request.AddParameter("ApplicationSid", statusCallback);

            return Execute<Message>(request);
        }
    }
}
