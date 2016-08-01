using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account.Sip {

    public class IpAccessControlListCreator : Creator<IpAccessControlListResource> {
        private string accountSid;
        private string friendlyName;
    
        /**
         * Construct a new IpAccessControlListCreator.
         * 
         * @param friendlyName A human readable description of this resource
         */
        public IpAccessControlListCreator(string friendlyName) {
            this.friendlyName = friendlyName;
        }
    
        /**
         * Construct a new IpAccessControlListCreator
         * 
         * @param accountSid The account_sid
         * @param friendlyName A human readable description of this resource
         */
        public IpAccessControlListCreator(string accountSid, string friendlyName) {
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAccessControlListResource
         */
        public override async Task<IpAccessControlListResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/IpAccessControlLists.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return IpAccessControlListResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IpAccessControlListResource
         */
        public override IpAccessControlListResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/IpAccessControlLists.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return IpAccessControlListResource.FromJson(response.GetContent());
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