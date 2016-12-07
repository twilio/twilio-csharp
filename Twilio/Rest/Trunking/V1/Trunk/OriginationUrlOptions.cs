using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class FetchOriginationUrlOptions : IOptions<OriginationUrlResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchOriginationUrlOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchOriginationUrlOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class DeleteOriginationUrlOptions : IOptions<OriginationUrlResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteOriginationUrlOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteOriginationUrlOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class CreateOriginationUrlOptions : IOptions<OriginationUrlResource> 
    {
        public string TrunkSid { get; }
        public int? Weight { get; }
        public int? Priority { get; }
        public bool? Enabled { get; }
        public string FriendlyName { get; }
        public Uri SipUrl { get; }
    
        /// <summary>
        /// Construct a new CreateOriginationUrlOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="weight"> The weight </param>
        /// <param name="priority"> The priority </param>
        /// <param name="enabled"> The enabled </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="sipUrl"> The sip_url </param>
        public CreateOriginationUrlOptions(string trunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl)
        {
            TrunkSid = trunkSid;
            Weight = weight;
            Priority = priority;
            Enabled = enabled;
            FriendlyName = friendlyName;
            SipUrl = sipUrl;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Weight != null)
            {
                p.Add(new KeyValuePair<string, string>("Weight", Weight.ToString()));
            }
            
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            
            if (Enabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Enabled", Enabled.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (SipUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SipUrl", SipUrl.ToString()));
            }
            
            return p;
        }
    }

    public class ReadOriginationUrlOptions : ReadOptions<OriginationUrlResource> 
    {
        public string TrunkSid { get; }
    
        /// <summary>
        /// Construct a new ReadOriginationUrlOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        public ReadOriginationUrlOptions(string trunkSid)
        {
            TrunkSid = trunkSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateOriginationUrlOptions : IOptions<OriginationUrlResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
        public int? Weight { get; set; }
        public int? Priority { get; set; }
        public bool? Enabled { get; set; }
        public string FriendlyName { get; set; }
        public Uri SipUrl { get; set; }
    
        /// <summary>
        /// Construct a new UpdateOriginationUrlOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateOriginationUrlOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Weight != null)
            {
                p.Add(new KeyValuePair<string, string>("Weight", Weight.ToString()));
            }
            
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            
            if (Enabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Enabled", Enabled.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (SipUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SipUrl", SipUrl.ToString()));
            }
            
            return p;
        }
    }

}