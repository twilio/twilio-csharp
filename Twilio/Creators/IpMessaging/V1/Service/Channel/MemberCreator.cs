using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.Service.Channel;

namespace Twilio.Creators.IpMessaging.V1.Service.Channel {

    public class MemberCreator : Creator<MemberResource> {
        private string serviceSid;
        private string channelSid;
        private string identity;
        private string roleSid;
    
        /**
         * Construct a new MemberCreator
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param identity The identity
         */
        public MemberCreator(string serviceSid, string channelSid, string identity) {
            this.serviceSid = serviceSid;
            this.channelSid = channelSid;
            this.identity = identity;
        }
    
        /**
         * The role_sid
         * 
         * @param roleSid The role_sid
         * @return this
         */
        public MemberCreator setRoleSid(string roleSid) {
            this.roleSid = roleSid;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created MemberResource
         */
        public override MemberResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MemberResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return MemberResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (identity != null) {
                request.addPostParam("Identity", identity);
            }
            
            if (roleSid != null) {
                request.addPostParam("RoleSid", roleSid);
            }
        }
    }
}