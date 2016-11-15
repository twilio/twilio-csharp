using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class DeviceCreator : Creator<DeviceResource> 
    {
        public string RatePlan { get; }
        public string Alias { get; set; }
        public string CallbackMethod { get; set; }
        public Uri CallbackUrl { get; set; }
        public string FriendlyName { get; set; }
        public string SimIdentifier { get; set; }
        public string Status { get; set; }
        public string CommandsCallbackMethod { get; set; }
        public Uri CommandsCallbackUrl { get; set; }
    
        /// <summary>
        /// Construct a new DeviceCreator
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        public DeviceCreator(string ratePlan)
        {
            RatePlan = ratePlan;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DeviceResource </returns> 
        public override async System.Threading.Tasks.Task<DeviceResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Preview,
                "/wireless/Devices"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return DeviceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DeviceResource </returns> 
        public override DeviceResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Preview,
                "/wireless/Devices"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return DeviceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (RatePlan != null)
            {
                request.AddPostParam("RatePlan", RatePlan);
            }
            
            if (Alias != null)
            {
                request.AddPostParam("Alias", Alias);
            }
            
            if (CallbackMethod != null)
            {
                request.AddPostParam("CallbackMethod", CallbackMethod);
            }
            
            if (CallbackUrl != null)
            {
                request.AddPostParam("CallbackUrl", CallbackUrl.ToString());
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (SimIdentifier != null)
            {
                request.AddPostParam("SimIdentifier", SimIdentifier);
            }
            
            if (Status != null)
            {
                request.AddPostParam("Status", Status);
            }
            
            if (CommandsCallbackMethod != null)
            {
                request.AddPostParam("CommandsCallbackMethod", CommandsCallbackMethod);
            }
            
            if (CommandsCallbackUrl != null)
            {
                request.AddPostParam("CommandsCallbackUrl", CommandsCallbackUrl.ToString());
            }
        }
    }
}