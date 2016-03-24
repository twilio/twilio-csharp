using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.Domain;

namespace Twilio.Deleters.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMappingDeleter : Deleter<IpAccessControlListMappingResource> {
        private string accountSid;
        private string domainSid;
        private string sid;
    
        /**
         * Construct a new IpAccessControlListMappingDeleter
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         */
        public IpAccessControlListMappingDeleter(string accountSid, string domainSid, string sid) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        public override void execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/IpAccessControlListMappings/" + this.sid + ".json"
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListMappingResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
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
        }
    }
}