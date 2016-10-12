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

    public class CommandCreator : Creator<CommandResource> {
        private string device;
        private string command;
        private string callbackMethod;
        private Uri callbackUrl;
    
        /**
         * Construct a new CommandCreator
         * 
         * @param device The device
         * @param command The command
         */
        public CommandCreator(string device, string command) {
            this.device = device;
            this.command = command;
        }
    
        /**
         * The callback_method
         * 
         * @param callbackMethod The callback_method
         * @return this
         */
        public CommandCreator setCallbackMethod(string callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /**
         * The callback_url
         * 
         * @param callbackUrl The callback_url
         * @return this
         */
        public CommandCreator setCallbackUrl(Uri callbackUrl) {
            this.callbackUrl = callbackUrl;
            return this;
        }
    
        /**
         * The callback_url
         * 
         * @param callbackUrl The callback_url
         * @return this
         */
        public CommandCreator setCallbackUrl(string callbackUrl) {
            return setCallbackUrl(Promoter.UriFromString(callbackUrl));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CommandResource
         */
        public override async Task<CommandResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Commands"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CommandResource creation failed: Unable to connect to server");
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
            
            return CommandResource.FromJson(response.Content);
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CommandResource
         */
        public override CommandResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Commands"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CommandResource creation failed: Unable to connect to server");
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
            
            return CommandResource.FromJson(response.Content);
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (device != null) {
                request.AddPostParam("Device", device);
            }
            
            if (command != null) {
                request.AddPostParam("Command", command);
            }
            
            if (callbackMethod != null) {
                request.AddPostParam("CallbackMethod", callbackMethod);
            }
            
            if (callbackUrl != null) {
                request.AddPostParam("CallbackUrl", callbackUrl.ToString());
            }
        }
    }
}