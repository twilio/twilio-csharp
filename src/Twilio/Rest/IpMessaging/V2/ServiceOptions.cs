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



namespace Twilio.Rest.IpMessaging.V2
{

    /// <summary> create </summary>
    public class CreateServiceOptions : IOptions<ServiceResource>
    {
        
        
        public string FriendlyName { get; }


        /// <summary> Construct a new CreateServiceOptions </summary>
        /// <param name="friendlyName">  </param>

        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource>
    {
        
        
        public string PathSid { get; }



        /// <summary> Construct a new DeleteServiceOptions </summary>
        /// <param name="pathSid">  </param>

        public DeleteServiceOptions(string pathSid)
        {
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
    public class FetchServiceOptions : IOptions<ServiceResource>
    {
    
        
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceOptions </summary>
        /// <param name="pathSid">  </param>

        public FetchServiceOptions(string pathSid)
        {
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
    public class ReadServiceOptions : ReadOptions<ServiceResource>
    {
    



        
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
    public class UpdateServiceOptions : IOptions<ServiceResource>
    {
    
        
        public string PathSid { get; }

        
        public string FriendlyName { get; set; }

        
        public string DefaultServiceRoleSid { get; set; }

        
        public string DefaultChannelRoleSid { get; set; }

        
        public string DefaultChannelCreatorRoleSid { get; set; }

        
        public bool? ReadStatusEnabled { get; set; }

        
        public bool? ReachabilityEnabled { get; set; }

        
        public int? TypingIndicatorTimeout { get; set; }

        
        public int? ConsumptionReportInterval { get; set; }

        
        public bool? NotificationsNewMessageEnabled { get; set; }

        
        public string NotificationsNewMessageTemplate { get; set; }

        
        public string NotificationsNewMessageSound { get; set; }

        
        public bool? NotificationsNewMessageBadgeCountEnabled { get; set; }

        
        public bool? NotificationsAddedToChannelEnabled { get; set; }

        
        public string NotificationsAddedToChannelTemplate { get; set; }

        
        public string NotificationsAddedToChannelSound { get; set; }

        
        public bool? NotificationsRemovedFromChannelEnabled { get; set; }

        
        public string NotificationsRemovedFromChannelTemplate { get; set; }

        
        public string NotificationsRemovedFromChannelSound { get; set; }

        
        public bool? NotificationsInvitedToChannelEnabled { get; set; }

        
        public string NotificationsInvitedToChannelTemplate { get; set; }

        
        public string NotificationsInvitedToChannelSound { get; set; }

        
        public Uri PreWebhookUrl { get; set; }

        
        public Uri PostWebhookUrl { get; set; }

        
        public Twilio.Http.HttpMethod WebhookMethod { get; set; }

        
        public List<string> WebhookFilters { get; set; }

        
        public int? LimitsChannelMembers { get; set; }

        
        public int? LimitsUserChannels { get; set; }

        
        public string MediaCompatibilityMessage { get; set; }

        
        public int? PreWebhookRetryCount { get; set; }

        
        public int? PostWebhookRetryCount { get; set; }

        
        public bool? NotificationsLogEnabled { get; set; }



        /// <summary> Construct a new UpdateServiceOptions </summary>
        /// <param name="pathSid">  </param>

        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
            WebhookFilters = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (DefaultServiceRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultServiceRoleSid", DefaultServiceRoleSid));
            }
            if (DefaultChannelRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChannelRoleSid", DefaultChannelRoleSid));
            }
            if (DefaultChannelCreatorRoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultChannelCreatorRoleSid", DefaultChannelCreatorRoleSid));
            }
            if (ReadStatusEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReadStatusEnabled", ReadStatusEnabled.Value.ToString().ToLower()));
            }
            if (ReachabilityEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("ReachabilityEnabled", ReachabilityEnabled.Value.ToString().ToLower()));
            }
            if (TypingIndicatorTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("TypingIndicatorTimeout", TypingIndicatorTimeout.ToString()));
            }
            if (ConsumptionReportInterval != null)
            {
                p.Add(new KeyValuePair<string, string>("ConsumptionReportInterval", ConsumptionReportInterval.ToString()));
            }
            if (NotificationsNewMessageEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageEnabled", NotificationsNewMessageEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsNewMessageTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageTemplate", NotificationsNewMessageTemplate));
            }
            if (NotificationsNewMessageSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageSound", NotificationsNewMessageSound));
            }
            if (NotificationsNewMessageBadgeCountEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsNewMessageBadgeCountEnabled", NotificationsNewMessageBadgeCountEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsAddedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsAddedToChannelEnabled", NotificationsAddedToChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsAddedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsAddedToChannelTemplate", NotificationsAddedToChannelTemplate));
            }
            if (NotificationsAddedToChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsAddedToChannelSound", NotificationsAddedToChannelSound));
            }
            if (NotificationsRemovedFromChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsRemovedFromChannelEnabled", NotificationsRemovedFromChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsRemovedFromChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsRemovedFromChannelTemplate", NotificationsRemovedFromChannelTemplate));
            }
            if (NotificationsRemovedFromChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsRemovedFromChannelSound", NotificationsRemovedFromChannelSound));
            }
            if (NotificationsInvitedToChannelEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsInvitedToChannelEnabled", NotificationsInvitedToChannelEnabled.Value.ToString().ToLower()));
            }
            if (NotificationsInvitedToChannelTemplate != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsInvitedToChannelTemplate", NotificationsInvitedToChannelTemplate));
            }
            if (NotificationsInvitedToChannelSound != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsInvitedToChannelSound", NotificationsInvitedToChannelSound));
            }
            if (PreWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookUrl", Serializers.Url(PreWebhookUrl)));
            }
            if (PostWebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookUrl", Serializers.Url(PostWebhookUrl)));
            }
            if (WebhookMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookMethod", WebhookMethod.ToString()));
            }
            if (WebhookFilters != null)
            {
                p.AddRange(WebhookFilters.Select(WebhookFilters => new KeyValuePair<string, string>("WebhookFilters", WebhookFilters)));
            }
            if (LimitsChannelMembers != null)
            {
                p.Add(new KeyValuePair<string, string>("LimitsChannelMembers", LimitsChannelMembers.ToString()));
            }
            if (LimitsUserChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("LimitsUserChannels", LimitsUserChannels.ToString()));
            }
            if (MediaCompatibilityMessage != null)
            {
                p.Add(new KeyValuePair<string, string>("MediaCompatibilityMessage", MediaCompatibilityMessage));
            }
            if (PreWebhookRetryCount != null)
            {
                p.Add(new KeyValuePair<string, string>("PreWebhookRetryCount", PreWebhookRetryCount.ToString()));
            }
            if (PostWebhookRetryCount != null)
            {
                p.Add(new KeyValuePair<string, string>("PostWebhookRetryCount", PostWebhookRetryCount.ToString()));
            }
            if (NotificationsLogEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationsLogEnabled", NotificationsLogEnabled.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


}

