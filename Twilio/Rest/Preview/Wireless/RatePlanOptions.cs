using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Preview.Wireless 
{

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

    public class FetchRatePlanOptions : IOptions<RatePlanResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchRatePlanOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchRatePlanOptions(string sid)
        {
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

    public class CreateRatePlanOptions : IOptions<RatePlanResource> 
    {
        public string Alias { get; set; }
        public string FriendlyName { get; set; }
        public List<string> Roaming { get; set; }
        public int? DataLimit { get; set; }
        public string DataMetering { get; set; }
        public bool? CommandsEnabled { get; set; }
        public int? RenewalPeriod { get; set; }
        public string RenewalUnits { get; set; }
    
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
            if (Alias != null)
            {
                p.Add(new KeyValuePair<string, string>("Alias", Alias));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (Roaming != null)
            {
                p.AddRange(Roaming.Select(prop => new KeyValuePair<string, string>("Roaming", prop.ToString())));
            }
            
            if (DataLimit != null)
            {
                p.Add(new KeyValuePair<string, string>("DataLimit", DataLimit.ToString()));
            }
            
            if (DataMetering != null)
            {
                p.Add(new KeyValuePair<string, string>("DataMetering", DataMetering));
            }
            
            if (CommandsEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsEnabled", CommandsEnabled.ToString()));
            }
            
            if (RenewalPeriod != null)
            {
                p.Add(new KeyValuePair<string, string>("RenewalPeriod", RenewalPeriod.ToString()));
            }
            
            if (RenewalUnits != null)
            {
                p.Add(new KeyValuePair<string, string>("RenewalUnits", RenewalUnits));
            }
            
            return p;
        }
    }

    public class UpdateRatePlanOptions : IOptions<RatePlanResource> 
    {
        public string Sid { get; }
        public string Alias { get; set; }
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateRatePlanOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateRatePlanOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Alias != null)
            {
                p.Add(new KeyValuePair<string, string>("Alias", Alias));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

}