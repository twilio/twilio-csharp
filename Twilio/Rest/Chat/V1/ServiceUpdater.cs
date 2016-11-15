using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1 
{

    public class ServiceUpdater : Updater<ServiceResource> 
    {
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public string DefaultServiceRoleSid { get; set; }
        public string DefaultChannelRoleSid { get; set; }
        public string DefaultChannelCreatorRoleSid { get; set; }
        public bool? ReadStatusEnabled { get; set; }
        public int? TypingIndicatorTimeout { get; set; }
        public int? ConsumptionReportInterval { get; set; }
        public Object Webhooks { get; set; }
    
        /// <summary>
        /// Construct a new ServiceUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ServiceUpdater(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ServiceResource </returns> 
        public override async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Chat,
                "/v1/Services/" + Sid + ""
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
        public override ServiceResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Chat,
                "/v1/Services/" + Sid + ""
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
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (DefaultServiceRoleSid != null)
            {
                request.AddPostParam("DefaultServiceRoleSid", DefaultServiceRoleSid);
            }
            
            if (DefaultChannelRoleSid != null)
            {
                request.AddPostParam("DefaultChannelRoleSid", DefaultChannelRoleSid);
            }
            
            if (DefaultChannelCreatorRoleSid != null)
            {
                request.AddPostParam("DefaultChannelCreatorRoleSid", DefaultChannelCreatorRoleSid);
            }
            
            if (ReadStatusEnabled != null)
            {
                request.AddPostParam("ReadStatusEnabled", ReadStatusEnabled.ToString());
            }
            
            if (TypingIndicatorTimeout != null)
            {
                request.AddPostParam("TypingIndicatorTimeout", TypingIndicatorTimeout.ToString());
            }
            
            if (ConsumptionReportInterval != null)
            {
                request.AddPostParam("ConsumptionReportInterval", ConsumptionReportInterval.ToString());
            }
            
            if (Webhooks != null)
            {
                request.AddPostParam("Webhooks", Webhooks.ToString());
            }
        }
    }
}