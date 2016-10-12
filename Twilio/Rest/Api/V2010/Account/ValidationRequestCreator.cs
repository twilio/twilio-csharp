using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ValidationRequestCreator : Creator<ValidationRequestResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string friendlyName;
        private int? callDelay;
        private string extension;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
    
        /// <summary>
        /// Construct a new ValidationRequestCreator.
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public ValidationRequestCreator(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// Construct a new ValidationRequestCreator
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="phoneNumber"> The phone_number </param>
        public ValidationRequestCreator(string accountSid, Twilio.Types.PhoneNumber phoneNumber) {
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public ValidationRequestCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The call_delay
        /// </summary>
        ///
        /// <param name="callDelay"> The call_delay </param>
        /// <returns> this </returns> 
        public ValidationRequestCreator setCallDelay(int? callDelay) {
            this.callDelay = callDelay;
            return this;
        }
    
        /// <summary>
        /// The extension
        /// </summary>
        ///
        /// <param name="extension"> The extension </param>
        /// <returns> this </returns> 
        public ValidationRequestCreator setExtension(string extension) {
            this.extension = extension;
            return this;
        }
    
        /// <summary>
        /// The status_callback
        /// </summary>
        ///
        /// <param name="statusCallback"> The status_callback </param>
        /// <returns> this </returns> 
        public ValidationRequestCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// The status_callback
        /// </summary>
        ///
        /// <param name="statusCallback"> The status_callback </param>
        /// <returns> this </returns> 
        public ValidationRequestCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The status_callback_method
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <returns> this </returns> 
        public ValidationRequestCreator setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ValidationRequestResource </returns> 
        public override async Task<ValidationRequestResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/OutgoingCallerIds.json"
            );
            
            addPostParams(request);
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
        public override ValidationRequestResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/OutgoingCallerIds.json"
            );
            
            addPostParams(request);
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
        private void addPostParams(Request request) {
            if (phoneNumber != null) {
                request.AddPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (callDelay != null) {
                request.AddPostParam("CallDelay", callDelay.ToString());
            }
            
            if (extension != null) {
                request.AddPostParam("Extension", extension);
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}