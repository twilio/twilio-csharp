using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.OutgoingCallerId;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account {

    public class OutgoingCallerIdUpdater : Updater<OutgoingCallerId> {
        private string accountSid;
        private string sid;
        private string friendlyName;
    
        /**
         * Construct a new OutgoingCallerIdUpdater
         * 
         * @param accountSid The account_sid
         * @param sid Update by unique outgoing-caller-id Sid
         */
        public OutgoingCallerIdUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * A human readable description of the caller ID
         * 
         * @param friendlyName A human readable description of the caller ID
         * @return this
         */
        public OutgoingCallerIdUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated OutgoingCallerId
         */
        [Override]
        public OutgoingCallerId execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerId update failed: Unable to connect to server");
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
            
            return OutgoingCallerId.fromJson(response.getStream(), client.getObjectMapper());
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
        }
    }
}