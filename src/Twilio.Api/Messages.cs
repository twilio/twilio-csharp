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
        public virtual Message GetMessage(string messageSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
            request.AddUrlSegment("MessageSid", messageSid);

            return Execute<Message>(request);
        }

		/// <summary>
		/// Deletes the single Message resource specified by messageSid.
		/// </summary>
		/// <param name="messageSid">The Sid of the message to delete</param>
        public virtual DeleteStatus DeleteMessage(string messageSid)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
			request.AddUrlSegment("MessageSid", messageSid);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}

		public virtual Message RedactMessage(string messageSid)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
			request.AddUrlSegment("MessageSid", messageSid);

			request.AddParameter("Body", "");
			return Execute<Message>(request);
		}

        /// <summary>
        /// Returns a list of Messages.
        /// The list includes paging information.
        /// Makes a GET request to the Message List resource.
        /// </summary>
        public virtual MessageResult ListMessages()
        {
            return ListMessages(new MessageListRequest());
        }

        /// <summary>
        /// Returns a list of Messages.
        /// The list includes paging information.
        /// Makes a GET request to the Message List resource.
        /// </summary>
        /// <param name="To"></param>
		public virtual MessageResult ListMessages(string To)
        {
            return ListMessages(new MessageListRequest() { To = To } );
        }

        /// <summary>
        /// Returns a filtered list of Messages. The list includes paging information.
        /// Makes a GET request to the Messages List resource.
        /// </summary>
        /// <param name="options">The list filters for the request</param>
		public virtual MessageResult ListMessages(MessageListRequest options)
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
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public virtual Message SendMessage(string from, string to, string body)
        {
            return SendMessage(from, to, body, new string[0], string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual Message SendMessage(string from, string to, string body, string statusCallback)
        {
            return SendMessage(from, to, body, new string[0], statusCallback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        public virtual Message SendMessage(string from, string to, string[] mediaUrls)
        {
            return SendMessage(from, to, String.Empty, mediaUrls, string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        public virtual Message SendMessage(string from, string to, string body, string[] mediaUrls)
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
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual Message SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback)
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
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        /// <param name="applicationSid"></param>
        public virtual Message SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid)
        {
            return SendMessage(from, to, body, mediaUrls, statusCallback, applicationSid, false);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        /// <param name="applicationSid"></param>
        /// <param name="mmsOnly">Doesn't fallback to SMS if set to true</param>
        public virtual Message SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, bool? mmsOnly)
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
            if (applicationSid.HasValue()) request.AddParameter("ApplicationSid", applicationSid);
            if (mmsOnly.HasValue) request.AddParameter("MmsOnly", mmsOnly.Value);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string body)
        {
            return SendMessageWithService(messagingServiceSid, to, body, new string[0], string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string body, string statusCallback)
        {
            return SendMessageWithService(messagingServiceSid, to, body, new string[0], statusCallback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string[] mediaUrls)
        {
            return SendMessageWithService(messagingServiceSid, to, String.Empty, mediaUrls, string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls)
        {
            return SendMessageWithService(messagingServiceSid, to, body, mediaUrls, string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, string statusCallback)
        {
            return SendMessageWithService(messagingServiceSid, to, body, mediaUrls, statusCallback, string.Empty);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        /// <param name="applicationSid"></param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid)
        {
            return SendMessageWithService(messagingServiceSid, to, body, mediaUrls, statusCallback, applicationSid, false);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The MessagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        /// <param name="applicationSid"></param>
        /// <param name="mmsOnly">Doesn't fallback to SMS if set to true</param>
        public virtual Message SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, bool? mmsOnly)
        {
            Require.Argument("messagingServiceSid", messagingServiceSid);
            Require.Argument("to", to);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Messages.json";
            request.AddParameter("MessagingServiceSid", messagingServiceSid);
            request.AddParameter("To", to);

            if (body.HasValue()) request.AddParameter("Body", body);

            for (int i = 0; i < mediaUrls.Length; i++)
            {
                request.AddParameter("MediaUrl", mediaUrls[i]);
            }

            if (statusCallback.HasValue()) request.AddParameter("StatusCallback", statusCallback);
            if (applicationSid.HasValue()) request.AddParameter("ApplicationSid", applicationSid);
            if (mmsOnly.HasValue) request.AddParameter("MmsOnly", mmsOnly.Value);

            return Execute<Message>(request);
        }
    }
}
