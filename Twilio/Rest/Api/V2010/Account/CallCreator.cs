using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallCreator : Creator<CallResource> 
    {
        public string AccountSid { get; set; }
        public IEndpoint To { get; }
        public Types.PhoneNumber From { get; }
        public Uri Url { get; }
        public string ApplicationSid { get; }
        public Twilio.Http.HttpMethod Method { get; set; }
        public Uri FallbackUrl { get; set; }
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }
        public Uri StatusCallback { get; set; }
        public List<string> StatusCallbackEvent { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public string SendDigits { get; set; }
        public string IfMachine { get; set; }
        public int? Timeout { get; set; }
        public bool? Record { get; set; }
        public string RecordingChannels { get; set; }
        public string RecordingStatusCallback { get; set; }
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }
        public string SipAuthUsername { get; set; }
        public string SipAuthPassword { get; set; }
    
        /// <summary>
        /// Construct a new CallCreator
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        public CallCreator(IEndpoint to, Types.PhoneNumber from, Uri url)
        {
            To = to;
            From = from;
            Url = url;
        }
    
        /// <summary>
        /// Construct a new CallCreator
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        public CallCreator(IEndpoint to, Types.PhoneNumber from, string applicationSid)
        {
            To = to;
            From = from;
            ApplicationSid = applicationSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CallResource </returns> 
        public override async System.Threading.Tasks.Task<CallResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Calls.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource creation failed: Unable to connect to server");
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
            
            return CallResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CallResource </returns> 
        public override CallResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Calls.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource creation failed: Unable to connect to server");
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
            
            return CallResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (To != null)
            {
                request.AddPostParam("To", To.ToString());
            }
            
            if (From != null)
            {
                request.AddPostParam("From", From.ToString());
            }
            
            if (Url != null)
            {
                request.AddPostParam("Url", Url.ToString());
            }
            
            if (ApplicationSid != null)
            {
                request.AddPostParam("ApplicationSid", ApplicationSid);
            }
            
            if (Method != null)
            {
                request.AddPostParam("Method", Method.ToString());
            }
            
            if (FallbackUrl != null)
            {
                request.AddPostParam("FallbackUrl", FallbackUrl.ToString());
            }
            
            if (FallbackMethod != null)
            {
                request.AddPostParam("FallbackMethod", FallbackMethod.ToString());
            }
            
            if (StatusCallback != null)
            {
                request.AddPostParam("StatusCallback", StatusCallback.ToString());
            }
            
            if (StatusCallbackEvent != null)
            {
                request.AddPostParam("StatusCallbackEvent", StatusCallbackEvent.ToString());
            }
            
            if (StatusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", StatusCallbackMethod.ToString());
            }
            
            if (SendDigits != null)
            {
                request.AddPostParam("SendDigits", SendDigits);
            }
            
            if (IfMachine != null)
            {
                request.AddPostParam("IfMachine", IfMachine);
            }
            
            if (Timeout != null)
            {
                request.AddPostParam("Timeout", Timeout.ToString());
            }
            
            if (Record != null)
            {
                request.AddPostParam("Record", Record.ToString());
            }
            
            if (RecordingChannels != null)
            {
                request.AddPostParam("RecordingChannels", RecordingChannels);
            }
            
            if (RecordingStatusCallback != null)
            {
                request.AddPostParam("RecordingStatusCallback", RecordingStatusCallback);
            }
            
            if (RecordingStatusCallbackMethod != null)
            {
                request.AddPostParam("RecordingStatusCallbackMethod", RecordingStatusCallbackMethod.ToString());
            }
            
            if (SipAuthUsername != null)
            {
                request.AddPostParam("SipAuthUsername", SipAuthUsername);
            }
            
            if (SipAuthPassword != null)
            {
                request.AddPostParam("SipAuthPassword", SipAuthPassword);
            }
        }
    }
}