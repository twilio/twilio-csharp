using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Sip.CredentialList;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList {

    public class CredentialDeleter : Deleter<CredentialResource> {
        private string accountSid;
        private string credentialListSid;
        private string sid;
    
        /**
         * Construct a new CredentialDeleter.
         * 
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         */
        public CredentialDeleter(string credentialListSid, string sid) {
            this.credentialListSid = credentialListSid;
            this.sid = sid;
        }
    
        /**
         * Construct a new CredentialDeleter
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         */
        public CredentialDeleter(string accountSid, string credentialListSid, string sid) {
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override async System.Threading.Tasks.Task DeleteAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return;
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override void Delete(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return;
        }
    }
}