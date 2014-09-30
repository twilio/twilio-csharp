using System;
using RestSharp;
using RestSharp.Validation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Creates a feedback summary.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <param name="callback">Asynchronous callback.</param>
        public void CreateFeedbackSummary(DateTime startDate, DateTime endDate, Action<FeedbackSummary> callback)
        {
            CreateFeedbackSummary(startDate, endDate, false, null, null, callback);
        }

        /// <summary>
        /// Creates a feedback summary.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <param name="includeSubaccounts">If set to <c>true</c> include subaccounts.</param>
        /// <param name="callback">Asynchronous callback.</param>
        public void CreateFeedbackSummary(DateTime startDate, DateTime endDate, bool includeSubaccounts,
                                                     Action<FeedbackSummary> callback)
        {
            CreateFeedbackSummary(startDate, endDate, includeSubaccounts, null, null, callback);
        }

        /// <summary>
        /// Creates a feedback summary.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="endDate">End date.</param>
        /// <param name="includeSubaccounts">If set to <c>true</c> include subaccounts.</param>
        /// <param name="statusCallback">Status callback.</param>
        /// <param name="statusCallbackMethod">Status callback method.</param>
        /// <param name="callback">Asynchronous callback.</param>
        public void CreateFeedbackSummary(DateTime startDate, DateTime endDate, bool includeSubaccounts, string statusCallback,
                                          string statusCallbackMethod, Action<FeedbackSummary> callback)
        {
            Require.Argument("StartDate", startDate.ToString("yyyy-MM-dd"));
            Require.Argument("EndDate", endDate.ToString("yyyy-MM-dd"));

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary.json";

            request.AddParameter("StartDate", startDate);
            request.AddParameter("EndDate", endDate);
            request.AddParameter("IncludeSubaccounts", includeSubaccounts);
            if (!string.IsNullOrEmpty(statusCallback)) {
                request.AddParameter("StatusCallback", statusCallback);
            }
            if (!string.IsNullOrEmpty(statusCallbackMethod)) {
                request.AddParameter("StatusCallbackMethod", statusCallbackMethod);
            }

            ExecuteAsync<FeedbackSummary>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Deletes a feedback summary.
        /// </summary>
        /// <param name="feedbackSummarySid">Feedback summary sid.</param>
        /// <param name="callback">Asynchronous callback.</param>
        public void DeleteFeedbackSummary(string feedbackSummarySid, Action<DeleteStatus> callback)
        {
            Require.Argument("FeedbackSummarySid", feedbackSummarySid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary/{Sid}.json";

            request.Method = Method.DELETE;

            request.AddUrlSegment("Sid", feedbackSummarySid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Gets a feedback summary.
        /// </summary>
        /// <param name="feedbackSummarySid">Feedback summary sid.</param>
        /// <param name="callback">Asynchronous callback.</param>
        public void GetFeedbackSummary(string feedbackSummarySid, Action<FeedbackSummary> callback)
        {
            Require.Argument("FeedbackSummarySid", feedbackSummarySid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary/{Sid}.json";
            request.AddUrlSegment("Sid", feedbackSummarySid);

            ExecuteAsync<FeedbackSummary>(request, (response) => { callback(response); });
        }
    }
}
