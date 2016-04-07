using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Sip.IpAccessControlList {

    public class IpAddressUpdater : Updater<IpAddressResource> {
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
         * @param client ITwilioRestClient with which to make the request
         * @return Updated IpAddressResource
         */
        public override async Task<IpAddressResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/IpAccessControlLists/" + this.ipAccessControlListSid + "/IpAddresses/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAddressResource update failed: Unable to connect to server");
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
            
            return IpAddressResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (ipAddress != null) {
                request.AddPostParam("IpAddress", ipAddress);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}