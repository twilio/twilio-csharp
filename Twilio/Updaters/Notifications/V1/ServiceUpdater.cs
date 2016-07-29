using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Notifications.V1;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Updaters.Notifications.V1 {

    public class ServiceUpdater : Updater<ServiceResource> {
        private string sid;
        private string friendlyName;
        private string apnCredentialSid;
        private string gcmCredentialSid;
        private string messagingServiceSid;
        private string facebookMessengerPageId;
        private string defaultApnNotificationProtocolVersion;
        private string defaultGcmNotificationProtocolVersion;
    
        /**
         * Construct a new ServiceUpdater
         * 
         * @param sid The sid
         */
        public ServiceUpdater(string sid) {
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ServiceUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The apn_credential_sid
         * 
         * @param apnCredentialSid The apn_credential_sid
         * @return this
         */
        public ServiceUpdater setApnCredentialSid(string apnCredentialSid) {
            this.apnCredentialSid = apnCredentialSid;
            return this;
        }
    
        /**
         * The gcm_credential_sid
         * 
         * @param gcmCredentialSid The gcm_credential_sid
         * @return this
         */
        public ServiceUpdater setGcmCredentialSid(string gcmCredentialSid) {
            this.gcmCredentialSid = gcmCredentialSid;
            return this;
        }
    
        /**
         * The messaging_service_sid
         * 
         * @param messagingServiceSid The messaging_service_sid
         * @return this
         */
        public ServiceUpdater setMessagingServiceSid(string messagingServiceSid) {
            this.messagingServiceSid = messagingServiceSid;
            return this;
        }
    
        /**
         * The facebook_messenger_page_id
         * 
         * @param facebookMessengerPageId The facebook_messenger_page_id
         * @return this
         */
        public ServiceUpdater setFacebookMessengerPageId(string facebookMessengerPageId) {
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
        public ServiceUpdater setDefaultApnNotificationProtocolVersion(string defaultApnNotificationProtocolVersion) {
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
        public ServiceUpdater setDefaultGcmNotificationProtocolVersion(string defaultGcmNotificationProtocolVersion) {
            this.defaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ServiceResource
         */
        public override async Task<ServiceResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFICATIONS,
                "/v1/Services/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return ServiceResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ServiceResource
         */
        public override ServiceResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFICATIONS,
                "/v1/Services/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return ServiceResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (string.IsNullOrEmpty(friendlyName)) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (string.IsNullOrEmpty(apnCredentialSid)) {
                request.AddPostParam("ApnCredentialSid", apnCredentialSid);
            }
            
            if (string.IsNullOrEmpty(gcmCredentialSid)) {
                request.AddPostParam("GcmCredentialSid", gcmCredentialSid);
            }
            
            if (string.IsNullOrEmpty(messagingServiceSid)) {
                request.AddPostParam("MessagingServiceSid", messagingServiceSid);
            }
            
            if (string.IsNullOrEmpty(facebookMessengerPageId)) {
                request.AddPostParam("FacebookMessengerPageId", facebookMessengerPageId);
            }
            
            if (string.IsNullOrEmpty(defaultApnNotificationProtocolVersion)) {
                request.AddPostParam("DefaultApnNotificationProtocolVersion", defaultApnNotificationProtocolVersion);
            }
            
            if (string.IsNullOrEmpty(defaultGcmNotificationProtocolVersion)) {
                request.AddPostParam("DefaultGcmNotificationProtocolVersion", defaultGcmNotificationProtocolVersion);
            }
        }
    }
}