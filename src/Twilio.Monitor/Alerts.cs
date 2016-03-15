using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.Monitor.Model;

namespace Twilio.Monitor
{
    public partial class MonitorClient
    {
        /// <summary>
        /// Gets an alert by its unique ID.
        /// </summary>
        /// <param name="eventSid">Alert sid.</param>
        public virtual Alert GetAlert(string alertSid)
        {
            Require.Argument("AlertSid", alertSid);

            var request = new RestRequest();
            request.Resource = "Alerts/{AlertSid}";

            request.AddUrlSegment("AlertSid", alertSid);

            return Execute<Alert>(request);
        }

        /// <summary>
        /// Lists the alerts.
        /// </summary>
        public virtual AlertResult ListAlerts()
        {
            return ListAlerts(null, null, null);
        }

        /// <summary>
        /// List alerts, with filters.
        /// </summary>
        /// <param name="logLevel">The log level to filter alerts by. One of "error", "warning", "notice", or "debug".</param>
        /// <param name="startDate">Only return alerts that occurred at or after this datetime.</param>
        /// <param name="endDate">Only return alerts that occurred at or before this datetime.</param>
        /// <returns></returns>
		public virtual AlertResult ListAlerts(string logLevel, DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest();
            request.Resource = "Alerts";

            if (logLevel.HasValue())
            {
                request.AddParameter("LogLevel", logLevel);
            }
            if (startDate.HasValue)
            {
                request.AddParameter("StartDate", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"));
            }
            if (endDate.HasValue)
            {
                request.AddParameter("EndDate", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"));
            }
            return Execute<AlertResult>(request);
        }

        public virtual DeleteStatus DeleteAlert(string alertSid)
        {
            Require.Argument("AlertSid", alertSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Alerts/{AlertSid}";

            request.AddParameter("AlertSid", alertSid, ParameterType.UrlSegment);
            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}
