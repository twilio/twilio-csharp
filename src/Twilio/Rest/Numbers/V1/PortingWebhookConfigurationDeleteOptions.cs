/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Numbers
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




namespace Twilio.Rest.Numbers.V1
{
    /// <summary> Allows the client to delete a webhook configuration. </summary>
    public class DeletePortingWebhookConfigurationDeleteOptions : IOptions<PortingWebhookConfigurationDeleteResource>
    {
        
        ///<summary> The of the webhook type of the configuration to be deleted </summary> 
        public PortingWebhookConfigurationDeleteResource.WebhookTypeEnum PathWebhookType { get; }



        /// <summary> Construct a new DeletePortingWebhookConfigurationDeleteOptions </summary>
        /// <param name="pathWebhookType"> The of the webhook type of the configuration to be deleted </param>
        public DeletePortingWebhookConfigurationDeleteOptions(PortingWebhookConfigurationDeleteResource.WebhookTypeEnum pathWebhookType)
        {
            PathWebhookType = pathWebhookType;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }


}

