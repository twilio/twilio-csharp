using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1 {

    public class ServiceCreator : Creator<ServiceResource> {
        private string friendlyName;
        private string apnCredentialSid;
        private string gcmCredentialSid;
        private string messagingServiceSid;
        private string facebookMessengerPageId;
        private string defaultApnNotificationProtocolVersion;
        private string defaultGcmNotificationProtocolVersion;
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ServiceCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The apn_credential_sid
         * 
         * @param apnCredentialSid The apn_credential_sid
         * @return this
         */
        public ServiceCreator setApnCredentialSid(string apnCredentialSid) {
            this.apnCredentialSid = apnCredentialSid;
            return this;
        }
    
        /**
         * The gcm_credential_sid
         * 
         * @param gcmCredentialSid The gcm_credential_sid
         * @return this
         */
        public ServiceCreator setGcmCredentialSid(string gcmCredentialSid) {
            this.gcmCredentialSid = gcmCredentialSid;
            return this;
        }
    
        /**
         * The messaging_service_sid
         * 
         * @param messagingServiceSid The messaging_service_sid
         * @return this
         */
        public ServiceCreator setMessagingServiceSid(string messagingServiceSid) {
            this.messagingServiceSid = messagingServiceSid;
            return this;
        }
    
        /**
         * The facebook_messenger_page_id
         * 
         * @param facebookMessengerPageId The facebook_messenger_page_id
         * @return this
         */
        public ServiceCreator setFacebookMessengerPageId(string facebookMessengerPageId) {
            this.facebookMessengerPageId = facebookMessengerPageId;
            return this;
        }
    
        /**
         * The default_apn_notification_protocol_version
         * 
         * @param defaultApnNotificationProtocolVersion The
         *                                              default_apn_notification_protocol_version
         * @return this
         */
        public ServiceCreator setDefaultApnNotificationProtocolVersion(string defaultApnNotificationProtocolVersion) {
            this.defaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion;
            return this;
        }
    
        /**
         * The default_gcm_notification_protocol_version
         * 
         * @param defaultGcmNotificationProtocolVersion The
         *                                              default_gcm_notification_protocol_version
         * @return this
         */
        public ServiceCreator setDefaultGcmNotificationProtocolVersion(string defaultGcmNotificationProtocolVersion) {
            this.defaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ServiceResource
         */
        public override async Task<ServiceResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to create record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return ServiceResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ServiceResource
         */
        public override ServiceResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to create record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return ServiceResource.FromJson(response.GetContent());
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
            
            if (apnCredentialSid != null) {
                request.AddPostParam("ApnCredentialSid", apnCredentialSid);
            }
            
            if (gcmCredentialSid != null) {
                request.AddPostParam("GcmCredentialSid", gcmCredentialSid);
            }
            
            if (messagingServiceSid != null) {
                request.AddPostParam("MessagingServiceSid", messagingServiceSid);
            }
            
            if (facebookMessengerPageId != null) {
                request.AddPostParam("FacebookMessengerPageId", facebookMessengerPageId);
            }
            
            if (defaultApnNotificationProtocolVersion != null) {
                request.AddPostParam("DefaultApnNotificationProtocolVersion", defaultApnNotificationProtocolVersion);
            }
            
            if (defaultGcmNotificationProtocolVersion != null) {
                request.AddPostParam("DefaultGcmNotificationProtocolVersion", defaultGcmNotificationProtocolVersion);
            }
        }
    }
}