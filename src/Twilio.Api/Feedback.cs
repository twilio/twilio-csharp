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
            return CreateFeedback(callSid, qualityScore, new List<string>(0));
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public Feedback CreateFeedback(string callSid, int qualityScore, string issue)
        {
            return CreateFeedback(callSid, qualityScore, new List<string>() { issue });
        }

        /// <summary>
        /// Creates a new feedback entry for a specific CallSid.
        /// </summary>
        public Feedback CreateFeedback(string callSid, int qualityScore, List<string> issues)
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

            return Execute<Feedback>(request);
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public Feedback UpdateFeedback(string callSid, int qualityScore)
        {
            return UpdateFeedback(callSid, qualityScore, new List<string>(0));
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public Feedback UpdateFeedback(string callSid, int qualityScore, string issue)
        {
            return UpdateFeedback(callSid, qualityScore, new List<string>() { issue });
        }

        /// <summary>
        /// Updates the current Feedback entry for a specific CallSid.
        /// </summary>
        public Feedback UpdateFeedback(string callSid, int qualityScore, List<string> issues)
        {
            return CreateFeedback(callSid, qualityScore, issues);
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
    }
}
