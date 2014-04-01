using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Validation;
using RestSharp;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve the Feedback for a specific CallSid.
        /// </summary>
        public void GetFeedback(string callSid, Action<Feedback> callback)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";
            request.AddUrlSegment("CallSid", callSid);

            ExecuteAsync<Feedback>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public void CreateFeedback(string callSid, int qualityScore, Action<Feedback> callback)
        {
            CreateFeedback(callSid, qualityScore, string.Empty, callback);
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public void CreateFeedback(string callSid, int qualityScore, string issue, Action<Feedback> callback)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("QualityScore", qualityScore);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";
            request.AddUrlSegment("CallSid", callSid);

            request.AddParameter("QualityScore", qualityScore);
            if (!string.IsNullOrEmpty(issue)) { request.AddParameter("Issue", issue); }

            ExecuteAsync<Feedback>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public void UpdateFeedback(string callSid, int qualityScore, Action<Feedback> callback)
        {
            UpdateFeedback(callSid, qualityScore, string.Empty, callback);
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public void UpdateFeedback(string callSid, int qualityScore, string issue, Action<Feedback> callback)
        {
            CreateFeedback(callSid, qualityScore, issue, callback);
        }

        /// <summary>
        /// Deletes a Feedback entry for a specific call
        /// </summary>
        /// <param name="callSid">The Sid of the Call to delete the Feedback entry from</param>
        /// <returns></returns>
        public void DeleteFeedback(string callSid, Action<DeleteStatus> callback)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";

            request.Method = Method.DELETE;

            request.AddUrlSegment("CallSid", callSid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Creates a new feedback summary
        /// </summary>
        public void CreateFeedbackSummary(DateTime startDate, DateTime endDate, bool includeSubaccounts, Action<FeedbackSummary> callback)
        {
            CreateFeedbackSummary(startDate, endDate, includeSubaccounts, string.Empty, string.Empty, callback);
        }

        /// <summary>
        /// Creates a new feedback summary
        /// </summary>
        public void CreateFeedbackSummary(DateTime startDate, DateTime endDate, bool includeSubaccounts, string statusCallback, string statusCallbackMethod, Action<FeedbackSummary> callback)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary.json";

            request.AddParameter("StartDate", startDate);
            request.AddParameter("EndDate", endDate);
            request.AddParameter("IncludeSubaccounts", includeSubaccounts);

            if (!string.IsNullOrEmpty(statusCallback)) { request.AddParameter("StatusCallback", statusCallback); }
            if (!string.IsNullOrEmpty(statusCallbackMethod)) { request.AddParameter("StatusCallbackMethod", statusCallbackMethod); }

            ExecuteAsync<FeedbackSummary>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Retrieve a Feedback Summary
        /// </summary>
        public void GetFeedbackSummary(string feedbackSummarySid, Action<FeedbackSummary> callback)
        {
            Require.Argument("FeedbackSummarySid", feedbackSummarySid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary/{FeedbackSummarySid}.json";
            request.AddUrlSegment("FeedbackSummarySid", feedbackSummarySid);

            ExecuteAsync<FeedbackSummary>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Deletes a Feedback Summary
        /// </summary>
        /// <param name="feedbackSummarySid">The Sid of the FeedbackSummary to delete</param>
        /// <returns></returns>
        public void DeleteFeedbackSummary(string feedbackSummarySid, Action<DeleteStatus> callback)
        {
            Require.Argument("FeedbackSummarySid", feedbackSummarySid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummay/{FeedbackSummarySid}.json";

            request.Method = Method.DELETE;

            request.AddUrlSegment("FeedbackSummarySid", feedbackSummarySid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }
    }
}
