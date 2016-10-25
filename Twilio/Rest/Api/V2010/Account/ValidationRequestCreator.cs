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

    public class ValidationRequestCreator : Creator<ValidationRequestResource> 
    {
        public string accountSid { get; }
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        public string friendlyName { get; set; }
        public int? callDelay { get; set; }
        public string extension { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new ValidationRequestCreator
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="callDelay"> The call_delay </param>
        /// <param name="extension"> The extension </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        public ValidationRequestCreator(Twilio.Types.PhoneNumber phoneNumber, string accountSid=null, string friendlyName=null, int? callDelay=null, string extension=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null)
        {
            this.statusCallbackMethod = statusCallbackMethod;
            this.statusCallback = statusCallback;
            this.callDelay = callDelay;
            this.accountSid = accountSid;
            this.extension = extension;
            this.friendlyName = friendlyName;
            this.phoneNumber = phoneNumber;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ValidationRequestResource </returns> 
        public override async Task<ValidationRequestResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/OutgoingCallerIds.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ValidationRequestResource creation failed: Unable to connect to server");
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
            
            return ValidationRequestResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ValidationRequestResource </returns> 
        public override ValidationRequestResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/OutgoingCallerIds.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ValidationRequestResource creation failed: Unable to connect to server");
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
            
            return ValidationRequestResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (phoneNumber != null)
            {
                request.AddPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (callDelay != null)
            {
                request.AddPostParam("CallDelay", callDelay.ToString());
            }
            
            if (extension != null)
            {
                request.AddPostParam("Extension", extension);
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