/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
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



namespace Twilio.Rest.Verify.V2.Service
{

    /// <summary> Create a new Webhook for the Service </summary>
    public class CreateWebhookOptions : IOptions<WebhookResource>
    {
        
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The string that you assigned to describe the webhook. **This value should not contain PII.** </summary> 
        public string FriendlyName { get; }

        ///<summary> The array of events that this Webhook is subscribed to. Possible event types: `*, factor.deleted, factor.created, factor.verified, challenge.approved, challenge.denied` </summary> 
        public List<string> EventTypes { get; }

        ///<summary> The URL associated with this Webhook. </summary> 
        public string WebhookUrl { get; }

        
        public WebhookResource.StatusEnum Status { get; set; }

        
        public WebhookResource.VersionEnum Version { get; set; }


        /// <summary> Construct a new CreateWebhookOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the webhook. **This value should not contain PII.** </param>
        /// <param name="eventTypes"> The array of events that this Webhook is subscribed to. Possible event types: `*, factor.deleted, factor.created, factor.verified, challenge.approved, challenge.denied` </param>
        /// <param name="webhookUrl"> The URL associated with this Webhook. </param>
        public CreateWebhookOptions(string pathServiceSid, string friendlyName, List<string> eventTypes, string webhookUrl)
        {
            PathServiceSid = pathServiceSid;
            FriendlyName = friendlyName;
            EventTypes = eventTypes;
            WebhookUrl = webhookUrl;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (EventTypes != null)
            {
                p.AddRange(EventTypes.Select(EventTypes => new KeyValuePair<string, string>("EventTypes", EventTypes)));
            }
            if (WebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookUrl", WebhookUrl));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Version != null)
            {
                p.Add(new KeyValuePair<string, string>("Version", Version.ToString()));
            }
            return p;
        }

        

    }
    /// <summary> Delete a specific Webhook. </summary>
    public class DeleteWebhookOptions : IOptions<WebhookResource>
    {
        
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Webhook resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteWebhookOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Webhook resource to delete. </param>
        public DeleteWebhookOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }


    /// <summary> Fetch a specific Webhook. </summary>
    public class FetchWebhookOptions : IOptions<WebhookResource>
    {
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Webhook resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchWebhookOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Webhook resource to fetch. </param>
        public FetchWebhookOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }


    /// <summary> Retrieve a list of all Webhooks for a Service. </summary>
    public class ReadWebhookOptions : ReadOptions<WebhookResource>
    {
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }



        /// <summary> Construct a new ListWebhookOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        public ReadWebhookOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
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
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Webhook resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The string that you assigned to describe the webhook. **This value should not contain PII.** </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The array of events that this Webhook is subscribed to. Possible event types: `*, factor.deleted, factor.created, factor.verified, challenge.approved, challenge.denied` </summary> 
        public List<string> EventTypes { get; set; }

        ///<summary> The URL associated with this Webhook. </summary> 
        public string WebhookUrl { get; set; }

        
        public WebhookResource.StatusEnum Status { get; set; }

        
        public WebhookResource.VersionEnum Version { get; set; }



        /// <summary> Construct a new UpdateWebhookOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Webhook resource to update. </param>
        public UpdateWebhookOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
            EventTypes = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (EventTypes != null)
            {
                p.AddRange(EventTypes.Select(EventTypes => new KeyValuePair<string, string>("EventTypes", EventTypes)));
            }
            if (WebhookUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("WebhookUrl", WebhookUrl));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Version != null)
            {
                p.Add(new KeyValuePair<string, string>("Version", Version.ToString()));
            }
            return p;
        }

        

    }


}

