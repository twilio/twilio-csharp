using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010 {

    public class AccountUpdater : Updater<AccountResource> {
        private string sid;
        private string friendlyName;
        private AccountResource.Status status;
    
        /**
         * Construct a new AccountUpdater
         * 
         * @param sid The sid
         */
        public AccountUpdater(string sid) {
            this.sid = sid;
        }
    
        /**
         * Update the human-readable description of this Account
         * 
         * @param friendlyName FriendlyName to update
         * @return this
         */
        public AccountUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Alter the status of this account with a given Status
         * 
         * @param status Status to update the Account with
         * @return this
         */
        public AccountUpdater setStatus(AccountResource.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated AccountResource
         */
        public override AccountResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AccountResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return AccountResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (status != null) {
                request.addPostParam("Status", status.ToString());
            }
        }
    }
}