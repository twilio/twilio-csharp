using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Wireless {

    public class DeviceUpdater : Updater<DeviceResource> {
        private string sid;
        private string alias;
        private string callbackMethod;
        private Uri callbackUrl;
        private string friendlyName;
        private string ratePlan;
        private string simIdentifier;
        private string status;
        private string commandsCallbackMethod;
        private Uri commandsCallbackUrl;
    
        /// <summary>
        /// Construct a new DeviceUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeviceUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// The alias
        /// </summary>
        ///
        /// <param name="alias"> The alias </param>
        /// <returns> this </returns> 
        public DeviceUpdater setAlias(string alias) {
            this.alias = alias;
            return this;
        }
    
        /// <summary>
        /// The callback_method
        /// </summary>
        ///
        /// <param name="callbackMethod"> The callback_method </param>
        /// <returns> this </returns> 
        public DeviceUpdater setCallbackMethod(string callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /// <summary>
        /// The callback_url
        /// </summary>
        ///
        /// <param name="callbackUrl"> The callback_url </param>
        /// <returns> this </returns> 
        public DeviceUpdater setCallbackUrl(Uri callbackUrl) {
            this.callbackUrl = callbackUrl;
            return this;
        }
    
        /// <summary>
        /// The callback_url
        /// </summary>
        ///
        /// <param name="callbackUrl"> The callback_url </param>
        /// <returns> this </returns> 
        public DeviceUpdater setCallbackUrl(string callbackUrl) {
            return setCallbackUrl(Promoter.UriFromString(callbackUrl));
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public DeviceUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The rate_plan
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <returns> this </returns> 
        public DeviceUpdater setRatePlan(string ratePlan) {
            this.ratePlan = ratePlan;
            return this;
        }
    
        /// <summary>
        /// The sim_identifier
        /// </summary>
        ///
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <returns> this </returns> 
        public DeviceUpdater setSimIdentifier(string simIdentifier) {
            this.simIdentifier = simIdentifier;
            return this;
        }
    
        /// <summary>
        /// The status
        /// </summary>
        ///
        /// <param name="status"> The status </param>
        /// <returns> this </returns> 
        public DeviceUpdater setStatus(string status) {
            this.status = status;
            return this;
        }
    
        /// <summary>
        /// The commands_callback_method
        /// </summary>
        ///
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <returns> this </returns> 
        public DeviceUpdater setCommandsCallbackMethod(string commandsCallbackMethod) {
            this.commandsCallbackMethod = commandsCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The commands_callback_url
        /// </summary>
        ///
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <returns> this </returns> 
        public DeviceUpdater setCommandsCallbackUrl(Uri commandsCallbackUrl) {
            this.commandsCallbackUrl = commandsCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The commands_callback_url
        /// </summary>
        ///
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <returns> this </returns> 
        public DeviceUpdater setCommandsCallbackUrl(string commandsCallbackUrl) {
            return setCommandsCallbackUrl(Promoter.UriFromString(commandsCallbackUrl));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DeviceResource </returns> 
        public override async Task<DeviceResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Devices/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource update failed: Unable to connect to server");
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
            
            return DeviceResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DeviceResource </returns> 
        public override DeviceResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Devices/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource update failed: Unable to connect to server");
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
            
            return DeviceResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (alias != null) {
                request.AddPostParam("Alias", alias);
            }
            
            if (callbackMethod != null) {
                request.AddPostParam("CallbackMethod", callbackMethod);
            }
            
            if (callbackUrl != null) {
                request.AddPostParam("CallbackUrl", callbackUrl.ToString());
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (ratePlan != null) {
                request.AddPostParam("RatePlan", ratePlan);
            }
            
            if (simIdentifier != null) {
                request.AddPostParam("SimIdentifier", simIdentifier);
            }
            
            if (status != null) {
                request.AddPostParam("Status", status);
            }
            
            if (commandsCallbackMethod != null) {
                request.AddPostParam("CommandsCallbackMethod", commandsCallbackMethod);
            }
            
            if (commandsCallbackUrl != null) {
                request.AddPostParam("CommandsCallbackUrl", commandsCallbackUrl.ToString());
            }
        }
    }
}