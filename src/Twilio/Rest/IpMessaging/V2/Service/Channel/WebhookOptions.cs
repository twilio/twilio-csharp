/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Ip_messaging
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using System.Linq;



namespace Twilio.Rest.IpMessaging.V2.Service.Channel
{

    /// <summary> create </summary>
    public class CreateWebhookOptions : IOptions<WebhookResource>
    {
        
        
        public string PathServiceSid { get; }

        
        public string PathChannelSid { get; }

        
        public WebhookResource.TypeEnum Type { get; }

        
        public string ConfigurationUrl { get; set; }

        
        public WebhookResource.MethodEnum ConfigurationMethod { get; set; }

        
        public List<string> ConfigurationFilters { get; set; }

        
        public List<string> ConfigurationTriggers { get; set; }

        
        public string ConfigurationFlowSid { get; set; }

        
        public int? ConfigurationRetryCount { get; set; }


        /// <summary> Construct a new CreateChannelWebhookOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="type">  </param>
        public CreateWebhookOptions(string pathServiceSid, string pathChannelSid, WebhookResource.TypeEnum type)
        {
            PathServiceSid = pathServiceSid;
            PathChannelSid = pathChannelSid;
            Type = type;
            ConfigurationFilters = new List<string>();
            ConfigurationTriggers = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
            }
            if (ConfigurationUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.Url", ConfigurationUrl));
            }
            if (ConfigurationMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.Method", ConfigurationMethod.ToString()));
            }
            if (ConfigurationFilters != null)
            {
                p.AddRange(ConfigurationFilters.Select(prop => new KeyValuePair<string, string>("Configuration.Filters", prop.ToString())));
            }
            if (ConfigurationTriggers != null)
            {
                p.AddRange(ConfigurationTriggers.Select(prop => new KeyValuePair<string, string>("Configuration.Triggers", prop.ToString())));
            }
            if (ConfigurationFlowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.FlowSid", ConfigurationFlowSid));
            }
            if (ConfigurationRetryCount != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.RetryCount", ConfigurationRetryCount.ToString()));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteWebhookOptions : IOptions<WebhookResource>
    {
        
        
        public string PathServiceSid { get; }

        
        public string PathChannelSid { get; }

        
        public string PathSid { get; }



        /// <summary> Construct a new DeleteChannelWebhookOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="pathSid">  </param>
        public DeleteWebhookOptions(string pathServiceSid, string pathChannelSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathChannelSid = pathChannelSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> fetch </summary>
    public class FetchWebhookOptions : IOptions<WebhookResource>
    {
    
        
        public string PathServiceSid { get; }

        
        public string PathChannelSid { get; }

        
        public string PathSid { get; }



        /// <summary> Construct a new FetchChannelWebhookOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="pathSid">  </param>
        public FetchWebhookOptions(string pathServiceSid, string pathChannelSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathChannelSid = pathChannelSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadWebhookOptions : ReadOptions<WebhookResource>
    {
    
        
        public string PathServiceSid { get; }

        
        public string PathChannelSid { get; }



        /// <summary> Construct a new ListChannelWebhookOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathChannelSid">  </param>
        public ReadWebhookOptions(string pathServiceSid, string pathChannelSid)
        {
            PathServiceSid = pathServiceSid;
            PathChannelSid = pathChannelSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> update </summary>
    public class UpdateWebhookOptions : IOptions<WebhookResource>
    {
    
        
        public string PathServiceSid { get; }

        
        public string PathChannelSid { get; }

        
        public string PathSid { get; }

        
        public string ConfigurationUrl { get; set; }

        
        public WebhookResource.MethodEnum ConfigurationMethod { get; set; }

        
        public List<string> ConfigurationFilters { get; set; }

        
        public List<string> ConfigurationTriggers { get; set; }

        
        public string ConfigurationFlowSid { get; set; }

        
        public int? ConfigurationRetryCount { get; set; }



        /// <summary> Construct a new UpdateChannelWebhookOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="pathSid">  </param>
        public UpdateWebhookOptions(string pathServiceSid, string pathChannelSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathChannelSid = pathChannelSid;
            PathSid = pathSid;
            ConfigurationFilters = new List<string>();
            ConfigurationTriggers = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ConfigurationUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.Url", ConfigurationUrl));
            }
            if (ConfigurationMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.Method", ConfigurationMethod.ToString()));
            }
            if (ConfigurationFilters != null)
            {
                p.AddRange(ConfigurationFilters.Select(prop => new KeyValuePair<string, string>("Configuration.Filters", prop.ToString())));
            }
            if (ConfigurationTriggers != null)
            {
                p.AddRange(ConfigurationTriggers.Select(prop => new KeyValuePair<string, string>("Configuration.Triggers", prop.ToString())));
            }
            if (ConfigurationFlowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.FlowSid", ConfigurationFlowSid));
            }
            if (ConfigurationRetryCount != null)
            {
                p.Add(new KeyValuePair<string, string>("Configuration.RetryCount", ConfigurationRetryCount.ToString()));
            }
            return p;
        }
        

    }


}

