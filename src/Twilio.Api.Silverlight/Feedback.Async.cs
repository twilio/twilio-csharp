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
            CreateFeedback(callSid, qualityScore, new List<string>(0), callback);
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public void CreateFeedback(string callSid, int qualityScore, string issue, Action<Feedback> callback)
        {
            CreateFeedback(callSid, qualityScore, new List<string>() { issue }, callback);
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public void CreateFeedback(string callSid, int qualityScore, List<string> issues, Action<Feedback> callback)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("QualityScore", qualityScore);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json";
            request.AddUrlSegment("CallSid", callSid);

            request.AddParameter("QualityScore", qualityScore);
            if (issues != null) {
                foreach (string issue in issues) {
                    if (!string.IsNullOrEmpty(issue)) {
                        request.AddParameter("Issue", issue);
                    }
                }
            }

            ExecuteAsync<Feedback>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public void UpdateFeedback(string callSid, int qualityScore, Action<Feedback> callback)
        {
            CreateFeedback(callSid, qualityScore, new List<string>(0), callback);
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public void UpdateFeedback(string callSid, int qualityScore, string issue, Action<Feedback> callback)
        {
            CreateFeedback(callSid, qualityScore, new List<string>() { issue }, callback);
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public void UpdateFeedback(string callSid, int qualityScore, List<string> issues, Action<Feedback> callback)
        {
            CreateFeedback(callSid, qualityScore, issues, callback);
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
    }
}
