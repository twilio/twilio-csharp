using System;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1;
using Twilio.Updaters;

namespace Twilio.Updaters.IpMessaging.V1 {

    public class ServiceUpdater : Updater<ServiceResource> {
        private string sid;
        private string friendlyName;
        private string defaultServiceRoleSid;
        private string defaultChannelRoleSid;
        private string defaultChannelCreatorRoleSid;
        private bool readStatusEnabled;
        private int typingIndicatorTimeout;
        private int consumptionReportInterval;
        private Object webhooks;
    
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
         * The default_service_role_sid
         * 
         * @param defaultServiceRoleSid The default_service_role_sid
         * @return this
         */
        public ServiceUpdater setDefaultServiceRoleSid(string defaultServiceRoleSid) {
            this.defaultServiceRoleSid = defaultServiceRoleSid;
            return this;
        }
    
        /**
         * The default_channel_role_sid
         * 
         * @param defaultChannelRoleSid The default_channel_role_sid
         * @return this
         */
        public ServiceUpdater setDefaultChannelRoleSid(string defaultChannelRoleSid) {
            this.defaultChannelRoleSid = defaultChannelRoleSid;
            return this;
        }
    
        /**
         * The default_channel_creator_role_sid
         * 
         * @param defaultChannelCreatorRoleSid The default_channel_creator_role_sid
         * @return this
         */
        public ServiceUpdater setDefaultChannelCreatorRoleSid(string defaultChannelCreatorRoleSid) {
            this.defaultChannelCreatorRoleSid = defaultChannelCreatorRoleSid;
            return this;
        }
    
        /**
         * The read_status_enabled
         * 
         * @param readStatusEnabled The read_status_enabled
         * @return this
         */
        public ServiceUpdater setReadStatusEnabled(bool readStatusEnabled) {
            this.readStatusEnabled = readStatusEnabled;
            return this;
        }
    
        /**
         * The typing_indicator_timeout
         * 
         * @param typingIndicatorTimeout The typing_indicator_timeout
         * @return this
         */
        public ServiceUpdater setTypingIndicatorTimeout(int typingIndicatorTimeout) {
            this.typingIndicatorTimeout = typingIndicatorTimeout;
            return this;
        }
    
        /**
         * The consumption_report_interval
         * 
         * @param consumptionReportInterval The consumption_report_interval
         * @return this
         */
        public ServiceUpdater setConsumptionReportInterval(int consumptionReportInterval) {
            this.consumptionReportInterval = consumptionReportInterval;
            return this;
        }
    
        /**
         * The webhooks
         * 
         * @param webhooks The webhooks
         * @return this
         */
        public ServiceUpdater setWebhooks(Object webhooks) {
            this.webhooks = webhooks;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated ServiceResource
         */
        public override ServiceResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
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
            
            return ServiceResource.fromJson(response.GetContent());
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
            
            if (defaultServiceRoleSid != null) {
                request.addPostParam("DefaultServiceRoleSid", defaultServiceRoleSid);
            }
            
            if (defaultChannelRoleSid != null) {
                request.addPostParam("DefaultChannelRoleSid", defaultChannelRoleSid);
            }
            
            if (defaultChannelCreatorRoleSid != null) {
                request.addPostParam("DefaultChannelCreatorRoleSid", defaultChannelCreatorRoleSid);
            }
            
            if (readStatusEnabled != null) {
                request.addPostParam("ReadStatusEnabled", readStatusEnabled.ToString());
            }
            
            if (typingIndicatorTimeout != null) {
                request.addPostParam("TypingIndicatorTimeout", typingIndicatorTimeout.ToString());
            }
            
            if (consumptionReportInterval != null) {
                request.addPostParam("ConsumptionReportInterval", consumptionReportInterval.ToString());
            }
            
            if (webhooks != null) {
                request.addPostParam("Webhooks", webhooks.ToString());
            }
        }
    }
}