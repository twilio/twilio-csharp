using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Conference;

namespace Twilio.Deleters.Api.V2010.Account.Conference {

    public class ParticipantDeleter : Deleter<ParticipantResource> {
        private string accountSid;
        private string conferenceSid;
        private string callSid;
    
        /**
         * Construct a new ParticipantDeleter
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         */
        public ParticipantDeleter(string accountSid, string conferenceSid, string callSid) {
            this.accountSid = accountSid;
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
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
                "/2010-04-01/Accounts/" + this.accountSid + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource delete failed: Unable to connect to server");
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
                "/2010-04-01/Accounts/" + this.accountSid + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource delete failed: Unable to connect to server");
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