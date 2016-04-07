using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account {

    public class OutgoingCallerIdUpdater : Updater<OutgoingCallerIdResource> {
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
         * @param client ITwilioRestClient with which to make the request
         * @return Updated OutgoingCallerIdResource
         */
        public override async Task<OutgoingCallerIdResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.FromJson(response.GetContent());
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
            
            return OutgoingCallerIdResource.FromJson(response.GetContent());
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