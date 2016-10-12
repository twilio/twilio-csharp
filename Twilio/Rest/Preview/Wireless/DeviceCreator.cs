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

    public class DeviceCreator : Creator<DeviceResource> {
        private string ratePlan;
        private string alias;
        private string callbackMethod;
        private Uri callbackUrl;
        private string friendlyName;
        private string simIdentifier;
        private string status;
        private string commandsCallbackMethod;
        private Uri commandsCallbackUrl;
    
        /**
         * Construct a new DeviceCreator
         * 
         * @param ratePlan The rate_plan
         */
        public DeviceCreator(string ratePlan) {
            this.ratePlan = ratePlan;
        }
    
        /**
         * The alias
         * 
         * @param alias The alias
         * @return this
         */
        public DeviceCreator setAlias(string alias) {
            this.alias = alias;
            return this;
        }
    
        /**
         * The callback_method
         * 
         * @param callbackMethod The callback_method
         * @return this
         */
        public DeviceCreator setCallbackMethod(string callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /**
         * The callback_url
         * 
         * @param callbackUrl The callback_url
         * @return this
         */
        public DeviceCreator setCallbackUrl(Uri callbackUrl) {
            this.callbackUrl = callbackUrl;
            return this;
        }
    
        /**
         * The callback_url
         * 
         * @param callbackUrl The callback_url
         * @return this
         */
        public DeviceCreator setCallbackUrl(string callbackUrl) {
            return setCallbackUrl(Promoter.UriFromString(callbackUrl));
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public DeviceCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The sim_identifier
         * 
         * @param simIdentifier The sim_identifier
         * @return this
         */
        public DeviceCreator setSimIdentifier(string simIdentifier) {
            this.simIdentifier = simIdentifier;
            return this;
        }
    
        /**
         * The status
         * 
         * @param status The status
         * @return this
         */
        public DeviceCreator setStatus(string status) {
            this.status = status;
            return this;
        }
    
        /**
         * The commands_callback_method
         * 
         * @param commandsCallbackMethod The commands_callback_method
         * @return this
         */
        public DeviceCreator setCommandsCallbackMethod(string commandsCallbackMethod) {
            this.commandsCallbackMethod = commandsCallbackMethod;
            return this;
        }
    
        /**
         * The commands_callback_url
         * 
         * @param commandsCallbackUrl The commands_callback_url
         * @return this
         */
        public DeviceCreator setCommandsCallbackUrl(Uri commandsCallbackUrl) {
            this.commandsCallbackUrl = commandsCallbackUrl;
            return this;
        }
    
        /**
         * The commands_callback_url
         * 
         * @param commandsCallbackUrl The commands_callback_url
         * @return this
         */
        public DeviceCreator setCommandsCallbackUrl(string commandsCallbackUrl) {
            return setCommandsCallbackUrl(Promoter.UriFromString(commandsCallbackUrl));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created DeviceResource
         */
        public override async Task<DeviceResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Devices"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return DeviceResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created DeviceResource
         */
        public override DeviceResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Devices"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return DeviceResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (ratePlan != null) {
                request.AddPostParam("RatePlan", ratePlan);
            }
            
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