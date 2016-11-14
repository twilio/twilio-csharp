using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FeedbackCreator : Creator<FeedbackResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public int? QualityScore { get; }
        public List<FeedbackResource.IssuesEnum> Issue { get; set; }
    
        /// <summary>
        /// Construct a new FeedbackCreator
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="qualityScore"> The quality_score </param>
        public FeedbackCreator(string callSid, int? qualityScore)
        {
            CallSid = callSid;
            QualityScore = qualityScore;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackResource </returns> 
        public override async Task<FeedbackResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Calls/" + this.CallSid + "/Feedback.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackResource </returns> 
        public override FeedbackResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Calls/" + this.CallSid + "/Feedback.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (QualityScore != null)
            {
                request.AddPostParam("QualityScore", QualityScore.ToString());
            }
            
            if (Issue != null)
            {
                request.AddPostParam("Issue", Issue.ToString());
            }
        }
    }
}