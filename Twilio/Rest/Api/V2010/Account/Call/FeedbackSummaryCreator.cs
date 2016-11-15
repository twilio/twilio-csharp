using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FeedbackSummaryCreator : Creator<FeedbackSummaryResource> 
    {
        public string AccountSid { get; set; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public bool? IncludeSubaccounts { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new FeedbackSummaryCreator
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        public FeedbackSummaryCreator(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackSummaryResource </returns> 
        public override async System.Threading.Tasks.Task<FeedbackSummaryResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Calls/FeedbackSummary.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackSummaryResource creation failed: Unable to connect to server");
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
            
            return FeedbackSummaryResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackSummaryResource </returns> 
        public override FeedbackSummaryResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Calls/FeedbackSummary.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackSummaryResource creation failed: Unable to connect to server");
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
            
            return FeedbackSummaryResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (StartDate != null)
            {
                request.AddPostParam("StartDate", StartDate.ToString());
            }
            
            if (EndDate != null)
            {
                request.AddPostParam("EndDate", EndDate.ToString());
            }
            
            if (IncludeSubaccounts != null)
            {
                request.AddPostParam("IncludeSubaccounts", IncludeSubaccounts.ToString());
            }
            
            if (StatusCallback != null)
            {
                request.AddPostParam("StatusCallback", StatusCallback.ToString());
            }
            
            if (StatusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", StatusCallbackMethod.ToString());
            }
        }
    }
}