using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallUpdater : Updater<CallResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public Uri Url { get; set; }
        public Twilio.Http.HttpMethod Method { get; set; }
        public CallResource.UpdateStatusEnum Status { get; set; }
        public Uri FallbackUrl { get; set; }
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new CallUpdater
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        public CallUpdater(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CallResource </returns> 
        public override async System.Threading.Tasks.Task<CallResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Calls/" + Sid + ".json",
                client.Region
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CallResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CallResource </returns> 
        public override CallResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Calls/" + Sid + ".json",
                client.Region
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CallResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Url != null)
            {
                request.AddPostParam("Url", Url.ToString());
            }
            
            if (Method != null)
            {
                request.AddPostParam("Method", Method.ToString());
            }
            
            if (Status != null)
            {
                request.AddPostParam("Status", Status.ToString());
            }
            
            if (FallbackUrl != null)
            {
                request.AddPostParam("FallbackUrl", FallbackUrl.ToString());
            }
            
            if (FallbackMethod != null)
            {
                request.AddPostParam("FallbackMethod", FallbackMethod.ToString());
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