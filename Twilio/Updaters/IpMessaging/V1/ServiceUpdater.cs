using System;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.Service;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.IpMessaging.V1 {

    public class ServiceUpdater : Updater<Service> {
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
         * @return Updated Service
         */
        [Override]
        public Service execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Service update failed: Unable to connect to server");
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
            
            return Service.fromJson(response.getStream(), client.getObjectMapper());
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