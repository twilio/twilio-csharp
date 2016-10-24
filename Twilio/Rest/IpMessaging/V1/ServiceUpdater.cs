using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1 {

    public class ServiceUpdater : Updater<ServiceResource> {
        public string sid { get; }
        public string friendlyName { get; set; }
        public string defaultServiceRoleSid { get; set; }
        public string defaultChannelRoleSid { get; set; }
        public string defaultChannelCreatorRoleSid { get; set; }
        public bool? readStatusEnabled { get; set; }
        public int? typingIndicatorTimeout { get; set; }
        public int? consumptionReportInterval { get; set; }
        public Object webhooks { get; set; }
    
        /// <summary>
        /// Construct a new ServiceUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ServiceUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public ServiceUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The default_service_role_sid
        /// </summary>
        ///
        /// <param name="defaultServiceRoleSid"> The default_service_role_sid </param>
        /// <returns> this </returns> 
        public ServiceUpdater setDefaultServiceRoleSid(string defaultServiceRoleSid) {
            this.defaultServiceRoleSid = defaultServiceRoleSid;
            return this;
        }
    
        /// <summary>
        /// The default_channel_role_sid
        /// </summary>
        ///
        /// <param name="defaultChannelRoleSid"> The default_channel_role_sid </param>
        /// <returns> this </returns> 
        public ServiceUpdater setDefaultChannelRoleSid(string defaultChannelRoleSid) {
            this.defaultChannelRoleSid = defaultChannelRoleSid;
            return this;
        }
    
        /// <summary>
        /// The default_channel_creator_role_sid
        /// </summary>
        ///
        /// <param name="defaultChannelCreatorRoleSid"> The default_channel_creator_role_sid </param>
        /// <returns> this </returns> 
        public ServiceUpdater setDefaultChannelCreatorRoleSid(string defaultChannelCreatorRoleSid) {
            this.defaultChannelCreatorRoleSid = defaultChannelCreatorRoleSid;
            return this;
        }
    
        /// <summary>
        /// The read_status_enabled
        /// </summary>
        ///
        /// <param name="readStatusEnabled"> The read_status_enabled </param>
        /// <returns> this </returns> 
        public ServiceUpdater setReadStatusEnabled(bool? readStatusEnabled) {
            this.readStatusEnabled = readStatusEnabled;
            return this;
        }
    
        /// <summary>
        /// The typing_indicator_timeout
        /// </summary>
        ///
        /// <param name="typingIndicatorTimeout"> The typing_indicator_timeout </param>
        /// <returns> this </returns> 
        public ServiceUpdater setTypingIndicatorTimeout(int? typingIndicatorTimeout) {
            this.typingIndicatorTimeout = typingIndicatorTimeout;
            return this;
        }
    
        /// <summary>
        /// The consumption_report_interval
        /// </summary>
        ///
        /// <param name="consumptionReportInterval"> The consumption_report_interval </param>
        /// <returns> this </returns> 
        public ServiceUpdater setConsumptionReportInterval(int? consumptionReportInterval) {
            this.consumptionReportInterval = consumptionReportInterval;
            return this;
        }
    
        /// <summary>
        /// The webhooks
        /// </summary>
        ///
        /// <param name="webhooks"> The webhooks </param>
        /// <returns> this </returns> 
        public ServiceUpdater setWebhooks(Object webhooks) {
            this.webhooks = webhooks;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ServiceResource </returns> 
        public override async Task<ServiceResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ServiceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ServiceResource </returns> 
        public override ServiceResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ServiceResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ServiceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (defaultServiceRoleSid != null) {
                request.AddPostParam("DefaultServiceRoleSid", defaultServiceRoleSid);
            }
            
            if (defaultChannelRoleSid != null) {
                request.AddPostParam("DefaultChannelRoleSid", defaultChannelRoleSid);
            }
            
            if (defaultChannelCreatorRoleSid != null) {
                request.AddPostParam("DefaultChannelCreatorRoleSid", defaultChannelCreatorRoleSid);
            }
            
            if (readStatusEnabled != null) {
                request.AddPostParam("ReadStatusEnabled", readStatusEnabled.ToString());
            }
            
            if (typingIndicatorTimeout != null) {
                request.AddPostParam("TypingIndicatorTimeout", typingIndicatorTimeout.ToString());
            }
            
            if (consumptionReportInterval != null) {
                request.AddPostParam("ConsumptionReportInterval", consumptionReportInterval.ToString());
            }
            
            if (webhooks != null) {
                request.AddPostParam("Webhooks", webhooks.ToString());
            }
        }
    }
}