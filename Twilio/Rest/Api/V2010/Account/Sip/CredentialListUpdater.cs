using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class CredentialListUpdater : Updater<CredentialListResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
    
        /**
         * Construct a new CredentialListUpdater.
         * 
         * @param sid The sid
         * @param friendlyName The friendly_name
         */
        public CredentialListUpdater(string sid, string friendlyName) {
            this.sid = sid;
            this.friendlyName = friendlyName;
        }
    
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CredentialListResource
         */
        public override async Task<CredentialListResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/CredentialLists/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialListResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return CredentialListResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CredentialListResource
         */
        public override CredentialListResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/CredentialLists/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialListResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
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