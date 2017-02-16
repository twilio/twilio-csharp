using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Notify.V1.Service 
{

    /// <summary>
    /// CreateNotificationOptions
    /// </summary>
    public class CreateNotificationOptions : IOptions<NotificationResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public List<string> Identity { get; set; }
        /// <summary>
        /// The tag
        /// </summary>
        public List<string> Tag { get; set; }
        /// <summary>
        /// The body
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// The priority
        /// </summary>
        public NotificationResource.PriorityEnum Priority { get; set; }
        /// <summary>
        /// The ttl
        /// </summary>
        public int? Ttl { get; set; }
        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The sound
        /// </summary>
        public string Sound { get; set; }
        /// <summary>
        /// The action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// The data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// The apn
        /// </summary>
        public string Apn { get; set; }
        /// <summary>
        /// The gcm
        /// </summary>
        public string Gcm { get; set; }
        /// <summary>
        /// The sms
        /// </summary>
        public string Sms { get; set; }
        /// <summary>
        /// The facebook_messenger
        /// </summary>
        public object FacebookMessenger { get; set; }
        /// <summary>
        /// The fcm
        /// </summary>
        public string Fcm { get; set; }
    
        /// <summary>
        /// Construct a new CreateNotificationOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public CreateNotificationOptions(string serviceSid)
        {
            ServiceSid = serviceSid;
            Identity = new List<string>();
            Tag = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.AddRange(Identity.Select(prop => new KeyValuePair<string, string>("Identity", prop)));
            }
            
            if (Tag != null)
            {
                p.AddRange(Tag.Select(prop => new KeyValuePair<string, string>("Tag", prop)));
            }
            
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
            }
            
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.Value.ToString()));
            }
            
            if (Title != null)
            {
                p.Add(new KeyValuePair<string, string>("Title", Title));
            }
            
            if (Sound != null)
            {
                p.Add(new KeyValuePair<string, string>("Sound", Sound));
            }
            
            if (Action != null)
            {
                p.Add(new KeyValuePair<string, string>("Action", Action));
            }
            
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Data));
            }
            
            if (Apn != null)
            {
                p.Add(new KeyValuePair<string, string>("Apn", Apn));
            }
            
            if (Gcm != null)
            {
                p.Add(new KeyValuePair<string, string>("Gcm", Gcm));
            }
            
            if (Sms != null)
            {
                p.Add(new KeyValuePair<string, string>("Sms", Sms));
            }
            
            if (FacebookMessenger != null)
            {
                p.Add(new KeyValuePair<string, string>("FacebookMessenger", FacebookMessenger.ToString()));
            }
            
            if (Fcm != null)
            {
                p.Add(new KeyValuePair<string, string>("Fcm", Fcm));
            }
            
            return p;
        }
    }

}