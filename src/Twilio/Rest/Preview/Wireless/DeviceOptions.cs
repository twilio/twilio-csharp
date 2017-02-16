using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Wireless 
{

    /// <summary>
    /// FetchDeviceOptions
    /// </summary>
    public class FetchDeviceOptions : IOptions<DeviceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchDeviceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchDeviceOptions(string sid)
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

    /// <summary>
    /// ReadDeviceOptions
    /// </summary>
    public class ReadDeviceOptions : ReadOptions<DeviceResource> 
    {
        /// <summary>
        /// The status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The sim_identifier
        /// </summary>
        public string SimIdentifier { get; set; }
        /// <summary>
        /// The rate_plan
        /// </summary>
        public string RatePlan { get; set; }
    
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
            
            if (SimIdentifier != null)
            {
                p.Add(new KeyValuePair<string, string>("SimIdentifier", SimIdentifier));
            }
            
            if (RatePlan != null)
            {
                p.Add(new KeyValuePair<string, string>("RatePlan", RatePlan));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    /// <summary>
    /// CreateDeviceOptions
    /// </summary>
    public class CreateDeviceOptions : IOptions<DeviceResource> 
    {
        /// <summary>
        /// The rate_plan
        /// </summary>
        public string RatePlan { get; }
        /// <summary>
        /// The alias
        /// </summary>
        public string Alias { get; set; }
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
        /// The sim_identifier
        /// </summary>
        public string SimIdentifier { get; set; }
        /// <summary>
        /// The status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The commands_callback_method
        /// </summary>
        public string CommandsCallbackMethod { get; set; }
        /// <summary>
        /// The commands_callback_url
        /// </summary>
        public Uri CommandsCallbackUrl { get; set; }
    
        /// <summary>
        /// Construct a new CreateDeviceOptions
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        public CreateDeviceOptions(string ratePlan)
        {
            RatePlan = ratePlan;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (RatePlan != null)
            {
                p.Add(new KeyValuePair<string, string>("RatePlan", RatePlan));
            }
            
            if (Alias != null)
            {
                p.Add(new KeyValuePair<string, string>("Alias", Alias));
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
            
            if (SimIdentifier != null)
            {
                p.Add(new KeyValuePair<string, string>("SimIdentifier", SimIdentifier));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }
            
            if (CommandsCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackMethod", CommandsCallbackMethod));
            }
            
            if (CommandsCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackUrl", CommandsCallbackUrl.ToString()));
            }
            
            return p;
        }
    }

    /// <summary>
    /// UpdateDeviceOptions
    /// </summary>
    public class UpdateDeviceOptions : IOptions<DeviceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The alias
        /// </summary>
        public string Alias { get; set; }
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
        /// The sim_identifier
        /// </summary>
        public string SimIdentifier { get; set; }
        /// <summary>
        /// The status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The commands_callback_method
        /// </summary>
        public string CommandsCallbackMethod { get; set; }
        /// <summary>
        /// The commands_callback_url
        /// </summary>
        public Uri CommandsCallbackUrl { get; set; }
    
        /// <summary>
        /// Construct a new UpdateDeviceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateDeviceOptions(string sid)
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
            
            if (SimIdentifier != null)
            {
                p.Add(new KeyValuePair<string, string>("SimIdentifier", SimIdentifier));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }
            
            if (CommandsCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackMethod", CommandsCallbackMethod));
            }
            
            if (CommandsCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CommandsCallbackUrl", CommandsCallbackUrl.ToString()));
            }
            
            return p;
        }
    }

}