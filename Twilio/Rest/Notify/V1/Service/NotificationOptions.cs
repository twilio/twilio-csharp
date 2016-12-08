using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class CreateNotificationOptions : IOptions<NotificationResource> 
    {
        public string ServiceSid { get; }
        public List<string> Identity { get; set; }
        public List<string> Tag { get; set; }
        public string Body { get; set; }
        public NotificationResource.PriorityEnum Priority { get; set; }
        public int? Ttl { get; set; }
        public string Title { get; set; }
        public string Sound { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        public string Apn { get; set; }
        public string Gcm { get; set; }
        public string Sms { get; set; }
        public object FacebookMessenger { get; set; }
    
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
            
            return p;
        }
    }

}