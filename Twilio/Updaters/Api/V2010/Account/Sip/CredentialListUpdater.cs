using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Sip {

    public class CredentialListUpdater : Updater<CredentialListResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
    
        /**
         * Construct a new CredentialListUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         */
        public CredentialListUpdater(string accountSid, string sid, string friendlyName) {
            this.accountSid = accountSid;
            this.sid = sid;
            this.friendlyName = friendlyName;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated CredentialListResource
         */
        public override async Task<CredentialListResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/CredentialLists/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return CredentialListResource.FromJson(response.GetContent());
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