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
        private string commandMode;
        private string includeSid;
    
        /// <summary>
        /// Construct a new CommandCreator
        /// </summary>
        ///
        /// <param name="device"> The device </param>
        /// <param name="command"> The command </param>
        public CommandCreator(string device, string command) {
            this.device = device;
            this.command = command;
        }
    
        /// <summary>
        /// The callback_method
        /// </summary>
        ///
        /// <param name="callbackMethod"> The callback_method </param>
        /// <returns> this </returns> 
        public CommandCreator setCallbackMethod(string callbackMethod) {
            this.callbackMethod = callbackMethod;
            return this;
        }
    
        /// <summary>
        /// The callback_url
        /// </summary>
        ///
        /// <param name="callbackUrl"> The callback_url </param>
        /// <returns> this </returns> 
        public CommandCreator setCallbackUrl(Uri callbackUrl) {
            this.callbackUrl = callbackUrl;
            return this;
        }
    
        /// <summary>
        /// The callback_url
        /// </summary>
        ///
        /// <param name="callbackUrl"> The callback_url </param>
        /// <returns> this </returns> 
        public CommandCreator setCallbackUrl(string callbackUrl) {
            return setCallbackUrl(Promoter.UriFromString(callbackUrl));
        }
    
        /// <summary>
        /// The command_mode
        /// </summary>
        ///
        /// <param name="commandMode"> The command_mode </param>
        /// <returns> this </returns> 
        public CommandCreator setCommandMode(string commandMode) {
            this.commandMode = commandMode;
            return this;
        }
    
        /// <summary>
        /// The include_sid
        /// </summary>
        ///
        /// <param name="includeSid"> The include_sid </param>
        /// <returns> this </returns> 
        public CommandCreator setIncludeSid(string includeSid) {
            this.includeSid = includeSid;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CommandResource </returns> 
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
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CommandResource </returns> 
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
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
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
            
            if (commandMode != null) {
                request.AddPostParam("CommandMode", commandMode);
            }
            
            if (includeSid != null) {
                request.AddPostParam("IncludeSid", includeSid);
            }
        }
    }
}