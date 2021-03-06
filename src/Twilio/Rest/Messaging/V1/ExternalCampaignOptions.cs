/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Messaging.V1
{

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// CreateExternalCampaignOptions
    /// </summary>
    public class CreateExternalCampaignOptions : IOptions<ExternalCampaignResource>
    {
        /// <summary>
        /// ID of the preregistered campaign.
        /// </summary>
        public string CampaignId { get; }
        /// <summary>
        /// The SID of the Messaging Service the resource is associated with
        /// </summary>
        public string MessagingServiceSid { get; }

        /// <summary>
        /// Construct a new CreateExternalCampaignOptions
        /// </summary>
        /// <param name="campaignId"> ID of the preregistered campaign. </param>
        /// <param name="messagingServiceSid"> The SID of the Messaging Service the resource is associated with </param>
        public CreateExternalCampaignOptions(string campaignId, string messagingServiceSid)
        {
            CampaignId = campaignId;
            MessagingServiceSid = messagingServiceSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CampaignId != null)
            {
                p.Add(new KeyValuePair<string, string>("CampaignId", CampaignId));
            }

            if (MessagingServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid.ToString()));
            }

            return p;
        }
    }

}