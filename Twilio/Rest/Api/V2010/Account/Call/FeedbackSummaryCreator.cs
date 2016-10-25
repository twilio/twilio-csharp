using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class FeedbackSummaryCreator : Creator<FeedbackSummaryResource> 
    {
        public string accountSid { get; }
        public DateTime? startDate { get; }
        public DateTime? endDate { get; }
        public bool? includeSubaccounts { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new FeedbackSummaryCreator
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="includeSubaccounts"> The include_subaccounts </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        public FeedbackSummaryCreator(DateTime? startDate, DateTime? endDate, string accountSid=null, bool? includeSubaccounts=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null)
        {
            this.endDate = endDate;
            this.statusCallbackMethod = statusCallbackMethod;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.includeSubaccounts = includeSubaccounts;
            this.startDate = startDate;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created FeedbackSummaryResource </returns> 
        public override async Task<FeedbackSummaryResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/FeedbackSummary.json"
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
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/FeedbackSummary.json"
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
            if (startDate != null)
            {
                request.AddPostParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null)
            {
                request.AddPostParam("EndDate", endDate.ToString());
            }
            
            if (includeSubaccounts != null)
            {
                request.AddPostParam("IncludeSubaccounts", includeSubaccounts.ToString());
            }
            
            if (statusCallback != null)
            {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}