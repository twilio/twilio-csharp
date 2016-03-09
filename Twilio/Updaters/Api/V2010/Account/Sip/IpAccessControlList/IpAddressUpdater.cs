using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sip.ip_access_control_list.IpAddress;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account.Sip.Ipaccesscontrollist {

    public class IpAddressUpdater : Updater<IpAddress> {
        private string accountSid;
        private string ipAccessControlListSid;
        private string sid;
        private string ipAddress;
        private string friendlyName;
    
        /**
         * Construct a new IpAddressUpdater
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param sid The sid
         * @param ipAddress The ip_address
         * @param friendlyName The friendly_name
         */
        public IpAddressUpdater(string accountSid, string ipAccessControlListSid, string sid, string ipAddress, string friendlyName) {
            this.accountSid = accountSid;
            this.ipAccessControlListSid = ipAccessControlListSid;
            this.sid = sid;
            this.ipAddress = ipAddress;
            this.friendlyName = friendlyName;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated IpAddress
         */
        [Override]
        public IpAddress execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/IpAccessControlLists/" + this.ipAccessControlListSid + "/IpAddresses/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAddress update failed: Unable to connect to server");
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
            
            return IpAddress.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (ipAddress != null) {
                request.addPostParam("IpAddress", ipAddress);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
        }
    }
}