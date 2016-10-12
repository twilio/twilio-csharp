using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service {

    public class NotificationCreator : Creator<NotificationResource> {
        private string serviceSid;
        private List<string> identity;
        private List<string> tag;
        private string body;
        private NotificationResource.Priority priority;
        private int? ttl;
        private string title;
        private string sound;
        private string action;
        private string data;
        private string apn;
        private string gcm;
        private string sms;
        private Object facebookMessenger;
    
        /// <summary>
        /// Construct a new NotificationCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public NotificationCreator(string serviceSid) {
            this.serviceSid = serviceSid;
        }
    
        /// <summary>
        /// The identity
        /// </summary>
        ///
        /// <param name="identity"> The identity </param>
        /// <returns> this </returns> 
        public NotificationCreator setIdentity(List<string> identity) {
            this.identity = identity;
            return this;
        }
    
        /// <summary>
        /// The identity
        /// </summary>
        ///
        /// <param name="identity"> The identity </param>
        /// <returns> this </returns> 
        public NotificationCreator setIdentity(string identity) {
            return setIdentity(Promoter.ListOfOne(identity));
        }
    
        /// <summary>
        /// The tag
        /// </summary>
        ///
        /// <param name="tag"> The tag </param>
        /// <returns> this </returns> 
        public NotificationCreator setTag(List<string> tag) {
            this.tag = tag;
            return this;
        }
    
        /// <summary>
        /// The tag
        /// </summary>
        ///
        /// <param name="tag"> The tag </param>
        /// <returns> this </returns> 
        public NotificationCreator setTag(string tag) {
            return setTag(Promoter.ListOfOne(tag));
        }
    
        /// <summary>
        /// The body
        /// </summary>
        ///
        /// <param name="body"> The body </param>
        /// <returns> this </returns> 
        public NotificationCreator setBody(string body) {
            this.body = body;
            return this;
        }
    
        /// <summary>
        /// The priority
        /// </summary>
        ///
        /// <param name="priority"> The priority </param>
        /// <returns> this </returns> 
        public NotificationCreator setPriority(NotificationResource.Priority priority) {
            this.priority = priority;
            return this;
        }
    
        /// <summary>
        /// The ttl
        /// </summary>
        ///
        /// <param name="ttl"> The ttl </param>
        /// <returns> this </returns> 
        public NotificationCreator setTtl(int? ttl) {
            this.ttl = ttl;
            return this;
        }
    
        /// <summary>
        /// The title
        /// </summary>
        ///
        /// <param name="title"> The title </param>
        /// <returns> this </returns> 
        public NotificationCreator setTitle(string title) {
            this.title = title;
            return this;
        }
    
        /// <summary>
        /// The sound
        /// </summary>
        ///
        /// <param name="sound"> The sound </param>
        /// <returns> this </returns> 
        public NotificationCreator setSound(string sound) {
            this.sound = sound;
            return this;
        }
    
        /// <summary>
        /// The action
        /// </summary>
        ///
        /// <param name="action"> The action </param>
        /// <returns> this </returns> 
        public NotificationCreator setAction(string action) {
            this.action = action;
            return this;
        }
    
        /// <summary>
        /// The data
        /// </summary>
        ///
        /// <param name="data"> The data </param>
        /// <returns> this </returns> 
        public NotificationCreator setData(string data) {
            this.data = data;
            return this;
        }
    
        /// <summary>
        /// The apn
        /// </summary>
        ///
        /// <param name="apn"> The apn </param>
        /// <returns> this </returns> 
        public NotificationCreator setApn(string apn) {
            this.apn = apn;
            return this;
        }
    
        /// <summary>
        /// The gcm
        /// </summary>
        ///
        /// <param name="gcm"> The gcm </param>
        /// <returns> this </returns> 
        public NotificationCreator setGcm(string gcm) {
            this.gcm = gcm;
            return this;
        }
    
        /// <summary>
        /// The sms
        /// </summary>
        ///
        /// <param name="sms"> The sms </param>
        /// <returns> this </returns> 
        public NotificationCreator setSms(string sms) {
            this.sms = sms;
            return this;
        }
    
        /// <summary>
        /// The facebook_messenger
        /// </summary>
        ///
        /// <param name="facebookMessenger"> The facebook_messenger </param>
        /// <returns> this </returns> 
        public NotificationCreator setFacebookMessenger(Object facebookMessenger) {
            this.facebookMessenger = facebookMessenger;
            return this;
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
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Notifications"
            );
            
            addPostParams(request);
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
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Notifications"
            );
            
            addPostParams(request);
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
        private void addPostParams(Request request) {
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