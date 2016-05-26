using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Queue;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Queue {

    public class MemberUpdater : Updater<MemberResource> {
        private string accountSid;
        private string queueSid;
        private string callSid;
        private Uri url;
        private System.Net.Http.HttpMethod method;
    
        /**
         * Construct a new MemberUpdater
         * 
         * @param accountSid The account_sid
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         * @param url The url
         * @param method The method
         */
        public MemberUpdater(string accountSid, string queueSid, string callSid, Uri url, System.Net.Http.HttpMethod method) {
            this.accountSid = accountSid;
            this.queueSid = queueSid;
            this.callSid = callSid;
            this.url = url;
            this.method = method;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated MemberResource
         */
        public override async Task<MemberResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues/" + this.queueSid + "/Members/" + this.callSid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("MemberResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            return MemberResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated MemberResource
         */
        public override MemberResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues/" + this.queueSid + "/Members/" + this.callSid + ".json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MemberResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            return MemberResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (url != null) {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (method != null) {
                request.AddPostParam("Method", method.ToString());
            }
        }
    }
}