using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Wireless {

    public class CommandCreator : Creator<CommandResource> {
        public string device { get; }
        public string command { get; }
        public string callbackMethod { get; set; }
        public Uri callbackUrl { get; set; }
        public string commandMode { get; set; }
        public string includeSid { get; set; }
    
        /// <summary>
        /// Construct a new CommandCreator
        /// </summary>
        ///
        /// <param name="device"> The device </param>
        /// <param name="command"> The command </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="commandMode"> The command_mode </param>
        /// <param name="includeSid"> The include_sid </param>
        public CommandCreator(string device, string command, string callbackMethod=null, Uri callbackUrl=null, string commandMode=null, string includeSid=null) {
            this.callbackMethod = callbackMethod;
            this.device = device;
            this.callbackUrl = callbackUrl;
            this.command = command;
            this.includeSid = includeSid;
            this.commandMode = commandMode;
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
                HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Commands"
            );
            
            AddPostParams(request);
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
                HttpMethod.POST,
                Domains.PREVIEW,
                "/wireless/Commands"
            );
            
            AddPostParams(request);
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
        private void AddPostParams(Request request) {
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