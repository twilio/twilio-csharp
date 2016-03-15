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
        /// Gets an alert by unique ID.
        /// </summary>
        /// <param name="alertSid">Alert sid</param>
        /// <param name="callback"></param>
        public virtual void GetAlert(string alertSid, Action<Alert> callback)
        {
            Require.Argument("AlertSid", alertSid);

            var request = new RestRequest();
            request.Resource = "Alerts/{AlertSid}";

            request.AddUrlSegment("AlertSid", alertSid);

            ExecuteAsync<Alert>(request, (response) => { callback(response); });
        }

		public virtual void ListAlerts(Action<AlertResult> callback)
        {
            ListAlerts(null, null, null, callback);
        }

		public virtual void ListAlerts(string logLevel, DateTime? startDate, DateTime? endDate, Action<AlertResult> callback)
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
            ExecuteAsync<AlertResult>(request, (response) => { callback(response); });
        }

        public virtual void DeleteAlert(string alertSid, Action<DeleteStatus> callback)
        {
            Require.Argument("AlertSid", alertSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Alerts/{AlertSid}";
            request.AddParameter("AlertSid", alertSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
		}
    }
}
