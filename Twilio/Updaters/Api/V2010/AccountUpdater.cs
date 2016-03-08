using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010 {

    public class AccountUpdater : Updater<Account> {
        private String sid;
        private String friendlyName;
        private Account.Status status;
    
        /**
         * Construct a new AccountUpdater
         * 
         * @param sid The sid
         */
        public AccountUpdater(String sid) {
            this.sid = sid;
        }
    
        /**
         * Update the human-readable description of this Account
         * 
         * @param friendlyName FriendlyName to update
         * @return this
         */
        public AccountUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Alter the status of this account with a given Status
         * 
         * @param status Status to update the Account with
         * @return this
         */
        public AccountUpdater setStatus(Account.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Account
         */
        [Override]
        public Account execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Account update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Account.fromJson(response.getStream(), client.getObjectMapper());
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
                request.addPostParam("Status", status.toString());
            }
        }
    }
}