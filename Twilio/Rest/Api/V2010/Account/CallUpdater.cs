using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallUpdater : Updater<CallResource> 
    {
        public string accountSid { get; }
        public string sid { get; }
        public Uri url { get; set; }
        public Twilio.Http.HttpMethod method { get; set; }
        public CallResource.Status status { get; set; }
        public Uri fallbackUrl { get; set; }
        public Twilio.Http.HttpMethod fallbackMethod { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new CallUpdater
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="url"> URL that returns TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="status"> Status to update the Call with </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        public CallUpdater(string sid, string accountSid=null, Uri url=null, Twilio.Http.HttpMethod method=null, CallResource.Status status=null, Uri fallbackUrl=null, Twilio.Http.HttpMethod fallbackMethod=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null)
        {
            this.sid = sid;
            this.url = url;
            this.statusCallbackMethod = statusCallbackMethod;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.status = status;
            this.method = method;
            this.fallbackMethod = fallbackMethod;
            this.fallbackUrl = fallbackUrl;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CallResource </returns> 
        public override async Task<CallResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.sid + ".json"
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
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.sid + ".json"
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
            if (url != null)
            {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (method != null)
            {
                request.AddPostParam("Method", method.ToString());
            }
            
            if (status != null)
            {
                request.AddPostParam("Status", status.ToString());
            }
            
            if (fallbackUrl != null)
            {
                request.AddPostParam("FallbackUrl", fallbackUrl.ToString());
            }
            
            if (fallbackMethod != null)
            {
                request.AddPostParam("FallbackMethod", fallbackMethod.ToString());
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