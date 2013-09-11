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
        public void GetMessage(string messageSid, Action<Message> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}.json";
            request.AddUrlSegment("MessageSid", messageSid);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

        /// <summary>
        /// Returns a list of Messages. 
        /// The list includes paging information.
        /// Makes a GET request to the Message List resource.
        /// </summary>
        public void ListMessages(Action<MessageResult> callback)
        {
            ListMessages(new MessageListRequest(), callback);
        }

        /// <summary>
        /// Returns a filtered list of Messages. The list includes paging information.
        /// Makes a GET request to the Messages List resource.
        /// </summary>
        /// <param name="options">The list filters for the request</param>
        public void ListMessages(MessageListRequest options, Action<MessageResult> callback)
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
        /// <param name="to">The phone number to send the message to. If using the Sandbox, this number must be a validated outgoing caller ID</param>
        /// <param name="body">The message to send. Must be 160 characters or less.</param>
        public void SendMessage(string from, string to, string body, string[] mediaUrls, Action<Message> callback)
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
        public void SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, Action<Message> callback)
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
        public void SendMessage(string from, string to, string body, string[] mediaUrls, string statusCallback, string applicationSid, Action<Message> callback)
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

            ExecuteAsync<Message>(request, (response) => callback(response));
        }
    }
}

