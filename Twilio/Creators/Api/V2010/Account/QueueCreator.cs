using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Creators.Api.V2010.Account {

    public class QueueCreator : Creator<QueueResource> {
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
         * @return Created QueueResource
         */
        public override async Task<QueueResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues.json"
            );
            
            addPostParams(request);
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("QueueResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return QueueResource.FromJson(response.GetContent());
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
            
            if (maxSize != null) {
                request.AddPostParam("MaxSize", maxSize.ToString());
            }
        }
    }
}