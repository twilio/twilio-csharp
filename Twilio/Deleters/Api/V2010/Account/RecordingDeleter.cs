using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Deleters.Api.V2010.Account {

    public class RecordingDeleter : Deleter<RecordingResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new RecordingDeleter
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique recording Sid
         */
        public RecordingDeleter(string accountSid, string sid) {
            this.accountSid = accountSid;
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
                "/2010-04-01/Accounts/" + this.accountSid + "/Recordings/" + this.sid + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordingResource delete failed: Unable to connect to server");
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
                "/2010-04-01/Accounts/" + this.accountSid + "/Recordings/" + this.sid + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordingResource delete failed: Unable to connect to server");
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