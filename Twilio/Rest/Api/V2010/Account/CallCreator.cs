using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallCreator : Creator<CallResource> 
    {
        public string accountSid { get; }
        public IEndpoint to { get; }
        public Twilio.Types.PhoneNumber from { get; }
        public Uri url { get; }
        public string applicationSid { get; }
        public Twilio.Http.HttpMethod method { get; set; }
        public Uri fallbackUrl { get; set; }
        public Twilio.Http.HttpMethod fallbackMethod { get; set; }
        public Uri statusCallback { get; set; }
        public List<string> statusCallbackEvent { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        public string sendDigits { get; set; }
        public string ifMachine { get; set; }
        public int? timeout { get; set; }
        public bool? record { get; set; }
        public string recordingChannels { get; set; }
        public string recordingStatusCallback { get; set; }
        public Twilio.Http.HttpMethod recordingStatusCallbackMethod { get; set; }
        public string sipAuthUsername { get; set; }
        public string sipAuthPassword { get; set; }
    
        /// <summary>
        /// Construct a new CallCreator
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="sendDigits"> Digits to send </param>
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <param name="record"> Whether or not to record the Call </param>
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        public CallCreator(IEndpoint to, Twilio.Types.PhoneNumber from, Uri url, string accountSid=null, string applicationSid=null, Twilio.Http.HttpMethod method=null, Uri fallbackUrl=null, Twilio.Http.HttpMethod fallbackMethod=null, Uri statusCallback=null, List<string> statusCallbackEvent=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string sendDigits=null, string ifMachine=null, int? timeout=null, bool? record=null, string recordingChannels=null, string recordingStatusCallback=null, Twilio.Http.HttpMethod recordingStatusCallbackMethod=null, string sipAuthUsername=null, string sipAuthPassword=null)
        {
            this.sipAuthUsername = sipAuthUsername;
            this.record = record;
            this.url = url;
            this.statusCallbackMethod = statusCallbackMethod;
            this.sendDigits = sendDigits;
            this.recordingStatusCallback = recordingStatusCallback;
            this.from = from;
            this.statusCallbackEvent = statusCallbackEvent;
            this.ifMachine = ifMachine;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.method = method;
            this.applicationSid = applicationSid;
            this.recordingChannels = recordingChannels;
            this.recordingStatusCallbackMethod = recordingStatusCallbackMethod;
            this.timeout = timeout;
            this.sipAuthPassword = sipAuthPassword;
            this.fallbackMethod = fallbackMethod;
            this.fallbackUrl = fallbackUrl;
            this.to = to;
        }
    
        /// <summary>
        /// Construct a new CallCreator
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <param name="sendDigits"> Digits to send </param>
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <param name="record"> Whether or not to record the Call </param>
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        public CallCreator(IEndpoint to, Twilio.Types.PhoneNumber from, string applicationSid, string accountSid=null, Uri url=null, Twilio.Http.HttpMethod method=null, Uri fallbackUrl=null, Twilio.Http.HttpMethod fallbackMethod=null, Uri statusCallback=null, List<string> statusCallbackEvent=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string sendDigits=null, string ifMachine=null, int? timeout=null, bool? record=null, string recordingChannels=null, string recordingStatusCallback=null, Twilio.Http.HttpMethod recordingStatusCallbackMethod=null, string sipAuthUsername=null, string sipAuthPassword=null)
        {
            this.sipAuthUsername = sipAuthUsername;
            this.record = record;
            this.url = url;
            this.statusCallbackMethod = statusCallbackMethod;
            this.sendDigits = sendDigits;
            this.recordingStatusCallback = recordingStatusCallback;
            this.from = from;
            this.statusCallbackEvent = statusCallbackEvent;
            this.ifMachine = ifMachine;
            this.statusCallback = statusCallback;
            this.accountSid = accountSid;
            this.method = method;
            this.applicationSid = applicationSid;
            this.recordingChannels = recordingChannels;
            this.recordingStatusCallbackMethod = recordingStatusCallbackMethod;
            this.timeout = timeout;
            this.sipAuthPassword = sipAuthPassword;
            this.fallbackMethod = fallbackMethod;
            this.fallbackUrl = fallbackUrl;
            this.to = to;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CallResource </returns> 
        public override async Task<CallResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls.json"
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
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls.json"
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
            if (to != null)
            {
                request.AddPostParam("To", to.ToString());
            }
            
            if (from != null)
            {
                request.AddPostParam("From", from.ToString());
            }
            
            if (url != null)
            {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (applicationSid != null)
            {
                request.AddPostParam("ApplicationSid", applicationSid);
            }
            
            if (method != null)
            {
                request.AddPostParam("Method", method.ToString());
            }
            
            if (fallbackUrl != null)
            {
                request.AddPostParam("FallbackUrl", fallbackUrl.ToString());
            }
            
            if (fallbackMethod != null)
            {
                request.AddPostParam("FallbackMethod", fallbackMethod.ToString());
            }
            
            if (statusCallback != null)
            {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackEvent != null)
            {
                request.AddPostParam("StatusCallbackEvent", statusCallbackEvent.ToString());
            }
            
            if (statusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (sendDigits != null)
            {
                request.AddPostParam("SendDigits", sendDigits);
            }
            
            if (ifMachine != null)
            {
                request.AddPostParam("IfMachine", ifMachine);
            }
            
            if (timeout != null)
            {
                request.AddPostParam("Timeout", timeout.ToString());
            }
            
            if (record != null)
            {
                request.AddPostParam("Record", record.ToString());
            }
            
            if (recordingChannels != null)
            {
                request.AddPostParam("RecordingChannels", recordingChannels);
            }
            
            if (recordingStatusCallback != null)
            {
                request.AddPostParam("RecordingStatusCallback", recordingStatusCallback);
            }
            
            if (recordingStatusCallbackMethod != null)
            {
                request.AddPostParam("RecordingStatusCallbackMethod", recordingStatusCallbackMethod.ToString());
            }
            
            if (sipAuthUsername != null)
            {
                request.AddPostParam("SipAuthUsername", sipAuthUsername);
            }
            
            if (sipAuthPassword != null)
            {
                request.AddPostParam("SipAuthPassword", sipAuthPassword);
            }
        }
    }
}