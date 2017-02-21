using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Preview.Wireless 
{

    /// <summary>
    /// ReadRatePlanOptions
    /// </summary>
    public class ReadRatePlanOptions : ReadOptions<RatePlanResource> 
    {
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

    /// <summary>
    /// FetchRatePlanOptions
    /// </summary>
    public class FetchRatePlanOptions : IOptions<RatePlanResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new FetchRatePlanOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchRatePlanOptions(string pathSid)
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
    /// CreateRatePlanOptions
    /// </summary>
    public class CreateRatePlanOptions : IOptions<RatePlanResource> 
    {
        /// <summary>
        /// The unique_name
        /// </summary>
        public string UniqueName { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The roaming
        /// </summary>
        public List<string> Roaming { get; set; }
        /// <summary>
        /// The data_limit
        /// </summary>
        public int? DataLimit { get; set; }
        /// <summary>
        /// The data_metering
        /// </summary>
        public string DataMetering { get; set; }
        /// <summary>
        /// The commands_enabled
        /// </summary>
        public bool? CommandsEnabled { get; set; }
        /// <summary>
        /// The renewal
        /// </summary>
        public string Renewal { get; set; }
    
        /// <summary>
        /// Construct a new CreateRatePlanOptions
        /// </summary>
        public CreateRatePlanOptions()
        {
            Roaming = new List<string>();
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
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (Roaming != null)
            {
                p.AddRange(Roaming.Select(prop => new KeyValuePair<string, string>("Roaming", prop)));
            }
            
            if (DataLimit != null)
            {
                p.Add(new KeyValuePair<string, string>("DataLimit", DataLimit.Value.ToString()));
            }
            
            if (DataMetering != null)
            {
                p.Add(new KeyValuePair<string, string>("DataMetering", DataMetering));
            }
            
            if (CommandsEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsEnabled", CommandsEnabled.Value.ToString()));
            }
            
            if (Renewal != null)
            {
                p.Add(new KeyValuePair<string, string>("Renewal", Renewal));
            }
            
            return p;
        }
    }

    /// <summary>
    /// UpdateRatePlanOptions
    /// </summary>
    public class UpdateRatePlanOptions : IOptions<RatePlanResource> 
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
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateRatePlanOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateRatePlanOptions(string pathSid)
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
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

}