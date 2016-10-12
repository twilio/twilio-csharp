using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class CallCreator : Creator<CallResource> {
        private string accountSid;
        private IEndpoint to;
        private Twilio.Types.PhoneNumber from;
        private Uri url;
        private string applicationSid;
        private Twilio.Http.HttpMethod method;
        private Uri fallbackUrl;
        private Twilio.Http.HttpMethod fallbackMethod;
        private Uri statusCallback;
        private List<string> statusCallbackEvent;
        private Twilio.Http.HttpMethod statusCallbackMethod;
        private string sendDigits;
        private string ifMachine;
        private int? timeout;
        private bool? record;
        private string recordingChannels;
        private string recordingStatusCallback;
        private Twilio.Http.HttpMethod recordingStatusCallbackMethod;
        private string sipAuthUsername;
        private string sipAuthPassword;
    
        /// <summary>
        /// Construct a new CallCreator.
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        public CallCreator(IEndpoint to, Twilio.Types.PhoneNumber from, Uri url) {
            this.to = to;
            this.from = from;
            this.url = url;
        }
    
        /// <summary>
        /// Construct a new CallCreator
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="url"> Url from which to fetch TwiML </param>
        public CallCreator(string accountSid, IEndpoint to, Twilio.Types.PhoneNumber from, Uri url) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.url = url;
        }
    
        /// <summary>
        /// Construct a new CallCreator.
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        public CallCreator(IEndpoint to, Twilio.Types.PhoneNumber from, string applicationSid) {
            this.to = to;
            this.from = from;
            this.applicationSid = applicationSid;
        }
    
        /// <summary>
        /// Construct a new CallCreator
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        /// <param name="applicationSid"> ApplicationSid that configures from where to fetch TwiML </param>
        public CallCreator(string accountSid, IEndpoint to, Twilio.Types.PhoneNumber from, string applicationSid) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.applicationSid = applicationSid;
        }
    
        /// <summary>
        /// The HTTP method Twilio should use when requesting the URL. Defaults to `POST`. If an `ApplicationSid` was provided,
        /// this parameter is ignored.
        /// </summary>
        ///
        /// <param name="method"> HTTP method to use to fetch TwiML </param>
        /// <returns> this </returns> 
        public CallCreator setMethod(Twilio.Http.HttpMethod method) {
            this.method = method;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request if an error occurs requesting or executing the TwiML at `Url`. If an `ApplicationSid`
        /// was provided, this parameter is ignored.
        /// </summary>
        ///
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <returns> this </returns> 
        public CallCreator setFallbackUrl(Uri fallbackUrl) {
            this.fallbackUrl = fallbackUrl;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request if an error occurs requesting or executing the TwiML at `Url`. If an `ApplicationSid`
        /// was provided, this parameter is ignored.
        /// </summary>
        ///
        /// <param name="fallbackUrl"> Fallback URL in case of error </param>
        /// <returns> this </returns> 
        public CallCreator setFallbackUrl(string fallbackUrl) {
            return setFallbackUrl(Promoter.UriFromString(fallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method that Twilio should use to request the `FallbackUrl`. Must be either `GET` or `POST`. Defaults to
        /// `POST`. If an `ApplicationSid` was provided, this parameter is ignored.
        /// </summary>
        ///
        /// <param name="fallbackMethod"> HTTP Method to use with FallbackUrl </param>
        /// <returns> this </returns> 
        public CallCreator setFallbackMethod(Twilio.Http.HttpMethod fallbackMethod) {
            this.fallbackMethod = fallbackMethod;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request when the call ends to notify your app. If an `ApplicationSid` was provided, this
        /// parameter is ignored.
        /// </summary>
        ///
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <returns> this </returns> 
        public CallCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// A URL that Twilio will request when the call ends to notify your app. If an `ApplicationSid` was provided, this
        /// parameter is ignored.
        /// </summary>
        ///
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <returns> this </returns> 
        public CallCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The status_callback_event
        /// </summary>
        ///
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <returns> this </returns> 
        public CallCreator setStatusCallbackEvent(List<string> statusCallbackEvent) {
            this.statusCallbackEvent = statusCallbackEvent;
            return this;
        }
    
        /// <summary>
        /// The status_callback_event
        /// </summary>
        ///
        /// <param name="statusCallbackEvent"> The status_callback_event </param>
        /// <returns> this </returns> 
        public CallCreator setStatusCallbackEvent(string statusCallbackEvent) {
            return setStatusCallbackEvent(Promoter.ListOfOne(statusCallbackEvent));
        }
    
        /// <summary>
        /// The HTTP method that Twilio should use to request the `StatusCallback`. Defaults to `POST`. If an `ApplicationSid`
        /// was provided, this parameter is ignored.
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> HTTP Method to use with StatusCallback </param>
        /// <returns> this </returns> 
        public CallCreator setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// A string of keys to dial after connecting to the number. Valid digits in the string include: any digit (`0`-`9`),
        /// '`#`', '`*`' and '`w`' (to insert a half second pause). For example, if you connected to a company phone number, and
        /// wanted to pause for one second, dial extension 1234 and then the pound key, use `ww1234#`.
        /// </summary>
        ///
        /// <param name="sendDigits"> Digits to send </param>
        /// <returns> this </returns> 
        public CallCreator setSendDigits(string sendDigits) {
            this.sendDigits = sendDigits;
            return this;
        }
    
        /// <summary>
        /// Tell Twilio to try and determine if a machine (like voicemail) or a human has answered the call. Possible value are
        /// `Continue` and `Hangup`.
        /// </summary>
        ///
        /// <param name="ifMachine"> Action to take if a machine has answered the call </param>
        /// <returns> this </returns> 
        public CallCreator setIfMachine(string ifMachine) {
            this.ifMachine = ifMachine;
            return this;
        }
    
        /// <summary>
        /// The integer number of seconds that Twilio should allow the phone to ring before assuming there is no answer. Default
        /// is `60` seconds, the maximum is `999` seconds. Note, you could set this to a low value, such as `15`, to hangup
        /// before reaching an answering machine or voicemail.
        /// </summary>
        ///
        /// <param name="timeout"> Number of seconds to wait for an answer </param>
        /// <returns> this </returns> 
        public CallCreator setTimeout(int? timeout) {
            this.timeout = timeout;
            return this;
        }
    
        /// <summary>
        /// Set this parameter to true to record the entirety of a phone call. The RecordingUrl will be sent to the
        /// StatusCallback URL. Defaults to false.
        /// </summary>
        ///
        /// <param name="record"> Whether or not to record the Call </param>
        /// <returns> this </returns> 
        public CallCreator setRecord(bool? record) {
            this.record = record;
            return this;
        }
    
        /// <summary>
        /// The recording_channels
        /// </summary>
        ///
        /// <param name="recordingChannels"> The recording_channels </param>
        /// <returns> this </returns> 
        public CallCreator setRecordingChannels(string recordingChannels) {
            this.recordingChannels = recordingChannels;
            return this;
        }
    
        /// <summary>
        /// The recording_status_callback
        /// </summary>
        ///
        /// <param name="recordingStatusCallback"> The recording_status_callback </param>
        /// <returns> this </returns> 
        public CallCreator setRecordingStatusCallback(string recordingStatusCallback) {
            this.recordingStatusCallback = recordingStatusCallback;
            return this;
        }
    
        /// <summary>
        /// The recording_status_callback_method
        /// </summary>
        ///
        /// <param name="recordingStatusCallbackMethod"> The recording_status_callback_method </param>
        /// <returns> this </returns> 
        public CallCreator setRecordingStatusCallbackMethod(Twilio.Http.HttpMethod recordingStatusCallbackMethod) {
            this.recordingStatusCallbackMethod = recordingStatusCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The sip_auth_username
        /// </summary>
        ///
        /// <param name="sipAuthUsername"> The sip_auth_username </param>
        /// <returns> this </returns> 
        public CallCreator setSipAuthUsername(string sipAuthUsername) {
            this.sipAuthUsername = sipAuthUsername;
            return this;
        }
    
        /// <summary>
        /// The sip_auth_password
        /// </summary>
        ///
        /// <param name="sipAuthPassword"> The sip_auth_password </param>
        /// <returns> this </returns> 
        public CallCreator setSipAuthPassword(string sipAuthPassword) {
            this.sipAuthPassword = sipAuthPassword;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CallResource </returns> 
        public override async Task<CallResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls.json"
            );
            
            addPostParams(request);
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
        public override CallResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls.json"
            );
            
            addPostParams(request);
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
        private void addPostParams(Request request) {
            if (to != null) {
                request.AddPostParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddPostParam("From", from.ToString());
            }
            
            if (url != null) {
                request.AddPostParam("Url", url.ToString());
            }
            
            if (applicationSid != null) {
                request.AddPostParam("ApplicationSid", applicationSid);
            }
            
            if (method != null) {
                request.AddPostParam("Method", method.ToString());
            }
            
            if (fallbackUrl != null) {
                request.AddPostParam("FallbackUrl", fallbackUrl.ToString());
            }
            
            if (fallbackMethod != null) {
                request.AddPostParam("FallbackMethod", fallbackMethod.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackEvent != null) {
                request.AddPostParam("StatusCallbackEvent", statusCallbackEvent.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (sendDigits != null) {
                request.AddPostParam("SendDigits", sendDigits);
            }
            
            if (ifMachine != null) {
                request.AddPostParam("IfMachine", ifMachine);
            }
            
            if (timeout != null) {
                request.AddPostParam("Timeout", timeout.ToString());
            }
            
            if (record != null) {
                request.AddPostParam("Record", record.ToString());
            }
            
            if (recordingChannels != null) {
                request.AddPostParam("RecordingChannels", recordingChannels);
            }
            
            if (recordingStatusCallback != null) {
                request.AddPostParam("RecordingStatusCallback", recordingStatusCallback);
            }
            
            if (recordingStatusCallbackMethod != null) {
                request.AddPostParam("RecordingStatusCallbackMethod", recordingStatusCallbackMethod.ToString());
            }
            
            if (sipAuthUsername != null) {
                request.AddPostParam("SipAuthUsername", sipAuthUsername);
            }
            
            if (sipAuthPassword != null) {
                request.AddPostParam("SipAuthPassword", sipAuthPassword);
            }
        }
    }
}