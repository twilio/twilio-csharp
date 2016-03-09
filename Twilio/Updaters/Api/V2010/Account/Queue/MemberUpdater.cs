using System;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.queue.Member;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account.Queue {

    public class MemberUpdater : Updater<Member> {
        private string accountSid;
        private string queueSid;
        private string callSid;
        private Uri url;
        private HttpMethod method;
    
        /**
         * Construct a new MemberUpdater
         * 
         * @param accountSid The account_sid
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         * @param url The url
         * @param method The method
         */
        public MemberUpdater(string accountSid, string queueSid, string callSid, Uri url, HttpMethod method) {
            this.accountSid = accountSid;
            this.queueSid = queueSid;
            this.callSid = callSid;
            this.url = url;
            this.method = method;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Member
         */
        [Override]
        public Member execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues/" + this.queueSid + "/Members/" + this.callSid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Member update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return Member.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (url != null) {
                request.addPostParam("Url", url.ToString());
            }
            
            if (method != null) {
                request.addPostParam("Method", method.ToString());
            }
        }
    }
}