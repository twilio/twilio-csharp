using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Deleter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.recording.Transcription;

namespace Twilio.Deleters.Api.V2010.Account.Recording {

    public class TranscriptionDeleter : Deleter<Transcription> {
        private String accountSid;
        private String recordingSid;
        private String sid;
    
        /**
         * Construct a new TranscriptionDeleter
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         */
        public TranscriptionDeleter(String accountSid, String recordingSid, String sid) {
            this.accountSid = accountSid;
            this.recordingSid = recordingSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        [Override]
        public void execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.DELETE,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Recordings/" + this.recordingSid + "/Transcriptions/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Transcription delete failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
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
        }
    }
}