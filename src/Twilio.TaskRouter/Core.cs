using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// REST API wrapper.
    /// </summary>
    public partial class TaskRouterClient : TwilioClient
    {
        private const string STATISTICS_DATE_FORMAT = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        public TaskRouterClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid) { }

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        public TaskRouterClient(string accountSid, string authToken, string accountResourceSid) : base(accountSid, authToken, accountResourceSid, "v1", "https://taskrouter.twilio.com/") 
        {
            DateFormat = null;
        }

        private void AddStatisticsDateOptions(StatisticsRequest options, RestRequest request)
        {
            if (options.Minutes.HasValue)
            {
                request.AddParameter("Minutes", options.Minutes.Value);
            }
            if (options.StartDate.HasValue)
            {
                request.AddParameter("StartDate", options.StartDate.Value.ToUniversalTime().ToString(STATISTICS_DATE_FORMAT));
            }
            if (options.EndDate.HasValue)
            {
                request.AddParameter("EndDate", options.EndDate.Value.ToUniversalTime().ToString(STATISTICS_DATE_FORMAT));
            }
        }
    }
}
