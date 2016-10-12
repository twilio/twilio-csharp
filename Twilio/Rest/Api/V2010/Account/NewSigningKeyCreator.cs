using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class NewSigningKeyCreator : Creator<NewSigningKeyResource> {
        private string accountSid;
        private string friendlyName;
    
        /**
         * Construct a new NewSigningKeyCreator.
         */
        public NewSigningKeyCreator() {
        }
    
        /**
         * Construct a new NewSigningKeyCreator
         * 
         * @param accountSid The account_sid
         */
        public NewSigningKeyCreator(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public NewSigningKeyCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created NewSigningKeyResource
         */
        public override async Task<NewSigningKeyResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SigningKeys.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("NewSigningKeyResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return NewSigningKeyResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created NewSigningKeyResource
         */
        public override NewSigningKeyResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SigningKeys.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("NewSigningKeyResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return NewSigningKeyResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}