using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.Domain;

namespace Twilio.Deleters.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingDeleter : Deleter<CredentialListMappingResource> {
        private string accountSid;
        private string domainSid;
        private string sid;
    
        /**
         * Construct a new CredentialListMappingDeleter
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         */
        public CredentialListMappingDeleter(string accountSid, string domainSid, string sid) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override async Task ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings/" + this.sid + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListMappingResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_NO_CONTENT) {
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
            
            return;
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override void Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings/" + this.sid + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListMappingResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_NO_CONTENT) {
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
            
            return;
        }
        #endif
    }
}