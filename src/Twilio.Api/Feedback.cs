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
        public Feedback GetFeedback(string callSid)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";
            request.AddUrlSegment("CallSid", callSid);

            return Execute<Feedback>(request);
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public Feedback CreateFeedback(string callSid, int qualityScore)
        {
            return CreateFeedback(callSid, qualityScore, string.Empty);
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public Feedback CreateFeedback(string callSid, int qualityScore, string issue)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("QualityScore", qualityScore);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";
            request.AddUrlSegment("CallSid", callSid);

            request.AddParameter("QualityScore", qualityScore);
            if (!string.IsNullOrEmpty(issue)) { request.AddParameter("Issue", issue); }

            return Execute<Feedback>(request);
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public Feedback UpdateFeedback(string callSid, int qualityScore)
        {
            return UpdateFeedback(callSid, qualityScore, string.Empty);
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public Feedback UpdateFeedback(string callSid, int qualityScore, string issue)
        {
            return CreateFeedback(callSid, qualityScore, issue);
        }

        /// <summary>
        /// Deletes a Feedback entry for a specific call
        /// </summary>
        /// <param name="callSid">The Sid of the Call to delete the Feedback entry from</param>
        /// <returns></returns>
        public DeleteStatus DeleteFeedback(string callSid)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";

            request.Method = Method.DELETE;

            request.AddUrlSegment("CallSid", callSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Creates a new feedback summary
        /// </summary>
        public FeedbackSummary CreateFeedbackSummary(DateTime startDate, DateTime endDate, bool includeSubaccounts)
        {
            return CreateFeedbackSummary(startDate, endDate, includeSubaccounts, string.Empty, string.Empty);
        }

        /// <summary>
        /// Creates a new feedback summary
        /// </summary>
        public FeedbackSummary CreateFeedbackSummary(DateTime startDate, DateTime endDate, bool includeSubaccounts, string statusCallback, string statusCallbackMethod)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary.json";

            request.AddParameter("StartDate", startDate);
            request.AddParameter("EndDate", endDate);
            request.AddParameter("IncludeSubaccounts", includeSubaccounts);

            if (!string.IsNullOrEmpty(statusCallback)) { request.AddParameter("StatusCallback", statusCallback); }
            if (!string.IsNullOrEmpty(statusCallbackMethod)) { request.AddParameter("StatusCallbackMethod", statusCallbackMethod); }

            return Execute<FeedbackSummary>(request);
        }

        /// <summary>
        /// Retrieve a Feedback Summary
        /// </summary>
        public FeedbackSummary GetFeedbackSummary(string feedbackSummarySid)
        {
            Require.Argument("FeedbackSummarySid", feedbackSummarySid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummary/{FeedbackSummarySid}.json";
            request.AddUrlSegment("FeedbackSummarySid", feedbackSummarySid);

            return Execute<FeedbackSummary>(request);
        }

        /// <summary>
        /// Deletes a Feedback Summary
        /// </summary>
        /// <param name="feedbackSummarySid">The Sid of the FeedbackSummary to delete</param>
        /// <returns></returns>
        public DeleteStatus DeleteFeedbackSummary(string feedbackSummarySid)
        {
            Require.Argument("FeedbackSummarySid", feedbackSummarySid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Calls/FeedbackSummay/{FeedbackSummarySid}.json";

            request.Method = Method.DELETE;

            request.AddUrlSegment("FeedbackSummarySid", feedbackSummarySid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}
