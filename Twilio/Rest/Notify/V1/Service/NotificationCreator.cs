using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service {

    public class NotificationCreator : Creator<NotificationResource> {
        public string serviceSid { get; }
        public List<string> identity { get; set; }
        public List<string> tag { get; set; }
        public string body { get; set; }
        public NotificationResource.Priority priority { get; set; }
        public int? ttl { get; set; }
        public string title { get; set; }
        public string sound { get; set; }
        public string action { get; set; }
        public string data { get; set; }
        public string apn { get; set; }
        public string gcm { get; set; }
        public string sms { get; set; }
        public Object facebookMessenger { get; set; }
    
        /// <summary>
        /// Construct a new NotificationCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        /// <param name="tag"> The tag </param>
        /// <param name="body"> The body </param>
        /// <param name="priority"> The priority </param>
        /// <param name="ttl"> The ttl </param>
        /// <param name="title"> The title </param>
        /// <param name="sound"> The sound </param>
        /// <param name="action"> The action </param>
        /// <param name="data"> The data </param>
        /// <param name="apn"> The apn </param>
        /// <param name="gcm"> The gcm </param>
        /// <param name="sms"> The sms </param>
        /// <param name="facebookMessenger"> The facebook_messenger </param>
        public NotificationCreator(string serviceSid, List<string> identity=null, List<string> tag=null, string body=null, NotificationResource.Priority priority=null, int? ttl=null, string title=null, string sound=null, string action=null, string data=null, string apn=null, string gcm=null, string sms=null, Object facebookMessenger=null) {
            this.facebookMessenger = facebookMessenger;
            this.data = data;
            this.apn = apn;
            this.sound = sound;
            this.body = body;
            this.serviceSid = serviceSid;
            this.action = action;
            this.identity = identity;
            this.sms = sms;
            this.priority = priority;
            this.ttl = ttl;
            this.title = title;
            this.gcm = gcm;
            this.tag = tag;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created NotificationResource </returns> 
        public override async Task<NotificationResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Notifications"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource creation failed: Unable to connect to server");
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
            
            return NotificationResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created NotificationResource </returns> 
        public override NotificationResource Create(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Notifications"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource creation failed: Unable to connect to server");
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
            
            return NotificationResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (identity != null) {
                request.AddPostParam("Identity", identity.ToString());
            }
            
            if (tag != null) {
                request.AddPostParam("Tag", tag.ToString());
            }
            
            if (body != null) {
                request.AddPostParam("Body", body);
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (ttl != null) {
                request.AddPostParam("Ttl", ttl.ToString());
            }
            
            if (title != null) {
                request.AddPostParam("Title", title);
            }
            
            if (sound != null) {
                request.AddPostParam("Sound", sound);
            }
            
            if (action != null) {
                request.AddPostParam("Action", action);
            }
            
            if (data != null) {
                request.AddPostParam("Data", data);
            }
            
            if (apn != null) {
                request.AddPostParam("Apn", apn);
            }
            
            if (gcm != null) {
                request.AddPostParam("Gcm", gcm);
            }
            
            if (sms != null) {
                request.AddPostParam("Sms", sms);
            }
            
            if (facebookMessenger != null) {
                request.AddPostParam("FacebookMessenger", facebookMessenger.ToString());
            }
        }
    }
}