using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Wireless 
{

    /// <summary>
    /// FetchSimOptions
    /// </summary>
    public class FetchSimOptions : IOptions<SimResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new FetchSimOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchSimOptions(string pathSid)
        {
            PathSid = pathSid;
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

    /// <summary>
    /// ReadSimOptions
    /// </summary>
    public class ReadSimOptions : ReadOptions<SimResource> 
    {
        /// <summary>
        /// The status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The iccid
        /// </summary>
        public string Iccid { get; set; }
        /// <summary>
        /// The rate_plan
        /// </summary>
        public string RatePlan { get; set; }
        /// <summary>
        /// The e_id
        /// </summary>
        public string EId { get; set; }
        /// <summary>
        /// The sim_registration_code
        /// </summary>
        public string SimRegistrationCode { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }
            
            if (Iccid != null)
            {
                p.Add(new KeyValuePair<string, string>("Iccid", Iccid));
            }
            
            if (RatePlan != null)
            {
                p.Add(new KeyValuePair<string, string>("RatePlan", RatePlan));
            }
            
            if (EId != null)
            {
                p.Add(new KeyValuePair<string, string>("EId", EId));
            }
            
            if (SimRegistrationCode != null)
            {
                p.Add(new KeyValuePair<string, string>("SimRegistrationCode", SimRegistrationCode));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    /// <summary>
    /// UpdateSimOptions
    /// </summary>
    public class UpdateSimOptions : IOptions<SimResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The unique_name
        /// </summary>
        public string UniqueName { get; set; }
        /// <summary>
        /// The callback_method
        /// </summary>
        public string CallbackMethod { get; set; }
        /// <summary>
        /// The callback_url
        /// </summary>
        public Uri CallbackUrl { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The rate_plan
        /// </summary>
        public string RatePlan { get; set; }
        /// <summary>
        /// The status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The commands_callback_method
        /// </summary>
        public Twilio.Http.HttpMethod CommandsCallbackMethod { get; set; }
        /// <summary>
        /// The commands_callback_url
        /// </summary>
        public Uri CommandsCallbackUrl { get; set; }
    
        /// <summary>
        /// Construct a new UpdateSimOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateSimOptions(string pathSid)
        {
            PathSid = pathSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            
            if (CallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackMethod", CallbackMethod));
            }
            
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", CallbackUrl.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (RatePlan != null)
            {
                p.Add(new KeyValuePair<string, string>("RatePlan", RatePlan.ToString()));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }
            
            if (CommandsCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackMethod", CommandsCallbackMethod.ToString()));
            }
            
            if (CommandsCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackUrl", CommandsCallbackUrl.ToString()));
            }
            
            return p;
        }
    }

}