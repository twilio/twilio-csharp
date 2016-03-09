using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Queue;

namespace Twilio.Creators.Api.V2010.Account {

    public class QueueCreator : Creator<Queue> {
        private string accountSid;
        private string friendlyName;
        private int maxSize;
    
        /**
         * Construct a new QueueCreator
         * 
         * @param accountSid The account_sid
         */
        public QueueCreator(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * A user-provided string that identifies this queue.
         * 
         * @param friendlyName A user-provided string that identifies this queue.
         * @return this
         */
        public QueueCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The upper limit of calls allowed to be in the queue. The default is 100. The
         * maximum is 1000.
         * 
         * @param maxSize The max number of calls allowed in the queue
         * @return this
         */
        public QueueCreator setMaxSize(int maxSize) {
            this.maxSize = maxSize;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Queue
         */
        [Override]
        public Queue execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Queue creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return Queue.fromJson(response.getStream(), client.getObjectMapper());
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