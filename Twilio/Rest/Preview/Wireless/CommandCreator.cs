using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class CommandCreator : Creator<CommandResource> 
    {
        public string Device { get; }
        public string Command { get; }
        public string CallbackMethod { get; set; }
        public Uri CallbackUrl { get; set; }
        public string CommandMode { get; set; }
        public string IncludeSid { get; set; }
    
        /// <summary>
        /// Construct a new CommandCreator
        /// </summary>
        ///
        /// <param name="device"> The device </param>
        /// <param name="command"> The command </param>
        public CommandCreator(string device, string command)
        {
            Device = device;
            Command = command;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CommandResource </returns> 
        public override async System.Threading.Tasks.Task<CommandResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
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
        public override CommandResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
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
        private void AddPostParams(Request request)
        {
            if (Device != null)
            {
                request.AddPostParam("Device", Device);
            }
            
            if (Command != null)
            {
                request.AddPostParam("Command", Command);
            }
            
            if (CallbackMethod != null)
            {
                request.AddPostParam("CallbackMethod", CallbackMethod);
            }
            
            if (CallbackUrl != null)
            {
                request.AddPostParam("CallbackUrl", CallbackUrl.ToString());
            }
            
            if (CommandMode != null)
            {
                request.AddPostParam("CommandMode", CommandMode);
            }
            
            if (IncludeSid != null)
            {
                request.AddPostParam("IncludeSid", IncludeSid);
            }
        }
    }
}