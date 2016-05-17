using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using System;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve the details for a specific Message instance.
        /// Makes a GET request to an Message Instance resource.
        /// </summary>
        /// <param name="messageSid">The Sid of the message to retrieve</param>
        public virtual void GetMessage(string messageSid, Action<Message> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
            request.AddUrlSegment("MessageSid", messageSid);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

		/// <summary>
		/// Deletes a single Message instance
		/// </summary>
		/// <param name="messageSid">The Sid of the Message to delete</param>
		/// <param name="callback">Method to be called on completion</param>
		public virtual void DeleteMessage(string messageSid, Action<DeleteStatus> callback)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
			request.AddUrlSegment("MessageSid", messageSid);

			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
		}

		public virtual void RedactMessage(string messageSid, Action<Message> callback)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
			request.AddUrlSegment("MessageSid", messageSid);

			request.AddParameter("Body", "");
			ExecuteAsync<Message>(request, (response) => callback(response));
		}

        /// <summary>
        /// Returns a list of Messages.
        /// The list includes paging information.
        /// Makes a GET request to the Message List resource.
        /// </summary>
		public virtual void ListMessages(Action<MessageResult> callback)
        {
            ListMessages(new MessageListRequest(), callback);
        }

        /// <summary>
        /// Returns a filtered list of Messages. The list includes paging information.
        /// Makes a GET request to the Messages List resource.
        /// </summary>
        /// <param name="options">The list filters for the request</param>
		public virtual void ListMessages(MessageListRequest options, Action<MessageResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages.json";
            AddMessageListOptions(options, request);
            ExecuteAsync<MessageResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Add the options to the request
        /// </summary>
        private void AddMessageListOptions(MessageListRequest options, RestRequest request)
        {
            if (options.To.HasValue()) request.AddParameter("To", options.To);
            if (options.From.HasValue()) request.AddParameter("From", options.From);

            // Construct the date filter
            if (options.DateSent.HasValue)
            {
                var dateSentParameterName = GetParameterNameWithEquality(options.DateSentComparison, "DateSent");
                request.AddParameter(dateSentParameterName, options.DateSent.Value.ToString("yyyy-MM-dd"));
            }

            // Paging options
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public virtual void SendMessage(string from, string to, string body, Action<Message> callback)
        {
            SendMessage(from, to, body, new string[0], string.Empty, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual void SendMessage(string from, string to, string body, string statusCallback, Action<Message> callback)
        {
            SendMessage(from, to, body, new string[0], statusCallback, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        public virtual void SendMessage(string from, string to, string[] mediaUrls, Action<Message> callback)
        {
            SendMessage(from, to, String.Empty, mediaUrls, string.Empty, callback);
        }


        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public virtual void SendMessage(string from, string to, string body, string[] mediaUrls, Action<Message> callback)
        {
            SendMessage(from, to, body, mediaUrls, string.Empty, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="from">The phone number to send the message from. Must be a Twilio-provided or ported local (not toll-free) number. Validated outgoing caller IDs cannot be used.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
        public virtual void SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, Action<Message> callback)
        {
            SendMessage(from, to, body, mediaUrls, statusCallback, string.Empty, callback);
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
        public virtual void SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, Action<Message> callback)
        {
            SendMessage(from, to, body, mediaUrls, statusCallback, applicationSid, false, callback);
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
        /// <param name="mmsOnly">Doesn't fallback to SMS if set to true</param>
        public virtual void SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, bool? mmsOnly, Action<Message> callback)
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
            if (mmsOnly.HasValue) request.AddParameter("MmsOnly", mmsOnly.Value);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string body, Action<Message> callback)
        {
            SendMessageWithService(messagingServiceSid, to, body, new string[0], string.Empty, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the MessageSid as well as MessageStatus=sent or MessageStatus=failed</param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string body, string statusCallback, Action<Message> callback)
        {
            SendMessageWithService(messagingServiceSid, to, body, new string[0], statusCallback, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to.</param>
        /// <param name="mediaUrls">An array of URLs where each member of the array points to a media file to be sent with the message.  You can include a maximum of 10 media URLs</param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string[] mediaUrls, Action<Message> callback)
        {
            SendMessageWithService(messagingServiceSid, to, String.Empty, mediaUrls, string.Empty, callback);
        }


        /// <summary>
        /// Send a new Message to the specified recipients.
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, Action<Message> callback)
        {
            SendMessageWithService(messagingServiceSid, to, body, mediaUrls, string.Empty, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, string statusCallback, Action<Message> callback)
        {
            SendMessageWithService(messagingServiceSid, to, body, mediaUrls, statusCallback, string.Empty, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
        /// <param name="applicationSid"></param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, Action<Message> callback)
        {
            SendMessageWithService(messagingServiceSid, to, body, mediaUrls, statusCallback, applicationSid, false, callback);
        }

        /// <summary>
        /// Send a new Message to the specified recipients
        /// Makes a POST request to the Messages List resource.
        /// </summary>
        /// <param name="messagingServiceSid">The messagingServiceSid to send the message from.</param>
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        /// <param name="statusCallback">A URL that Twilio will POST to when your message is processed. Twilio will POST the SmsSid as well as SmsStatus=sent or SmsStatus=failed</param>
        /// <param name="applicationSid"></param>
        /// <param name="mmsOnly">Doesn't fallback to SMS if set to true</param>
        public virtual void SendMessageWithService(string messagingServiceSid, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, bool? mmsOnly, Action<Message> callback)
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
            if (applicationSid.HasValue()) request.AddParameter("ApplicationSid", statusCallback);
            if (mmsOnly.HasValue) request.AddParameter("MmsOnly", mmsOnly.Value);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }
    }
}

