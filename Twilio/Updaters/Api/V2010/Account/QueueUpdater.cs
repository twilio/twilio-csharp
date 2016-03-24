using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account {

    public class QueueUpdater : Updater<QueueResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
        private int maxSize;
    
        /**
         * Construct a new QueueUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public QueueUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * A human readable description of the queue
         * 
         * @param friendlyName A human readable description of the queue
         * @return this
         */
        public QueueUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The maximum number of members that can be in the queue at a time
         * 
         * @param maxSize The max number of members allowed in the queue
         * @return this
         */
        public QueueUpdater setMaxSize(int maxSize) {
            this.maxSize = maxSize;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated QueueResource
         */
        public override QueueResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("QueueResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return QueueResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (maxSize != null) {
                request.addPostParam("MaxSize", maxSize.ToString());
            }
        }
    }
}