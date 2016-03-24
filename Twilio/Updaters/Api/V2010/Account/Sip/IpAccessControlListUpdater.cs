using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Sip {

    public class IpAccessControlListUpdater : Updater<IpAccessControlListResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
    
        /**
         * Construct a new IpAccessControlListUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @param friendlyName A human readable description of this resource
         */
        public IpAccessControlListUpdater(string accountSid, string sid, string friendlyName) {
            this.accountSid = accountSid;
            this.sid = sid;
            this.friendlyName = friendlyName;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated IpAccessControlListResource
         */
        public override IpAccessControlListResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/IpAccessControlLists/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource update failed: Unable to connect to server");
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
            
            return IpAccessControlListResource.fromJson(response.GetContent());
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