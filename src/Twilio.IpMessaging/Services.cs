using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Services.
        /// </summary>
        /// <returns>List of Services</returns>
        public virtual ServiceResult ListServices()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services";

            return Execute<ServiceResult>(request);
        }

        /// <summary>
        /// Retrieves a Service by Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <returns>Service</returns>
        public virtual Service GetService(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            return Execute<Service>(request);
        }

        /// <summary>
        /// Creates a Service.
        /// </summary>
        /// <param name="friendlyName">Friendly Name for the Service</param>
        /// <returns>A new Service</returns>
        public virtual Service CreateService(string friendlyName)
        {
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services";

            request.AddParameter("FriendlyName", friendlyName);

            return Execute<Service>(request);
        }

        /// <summary>
        /// Updates a Service.
        /// Use webhooksParams to set desired Webhooks. Pass null otherwise.
        /// Listed below are the acceptable params<br/>
        /// <list type="bullet">
        /// <item><description>Webhooks.OnMessageSend.Url</description></item>
        /// <item><description>Webhooks.OnMessageSend.Method</description></item>
        /// <item><description>Webhooks.OnMessageSend.Format</description></item>
        /// <item><description>Webhooks.OnChannelAdd.Url</description></item>
        /// <item><description>Webhooks.OnChannelAdd.Method</description></item>
        /// <item><description>Webhooks.OnChannelAdd.Format</description></item>
        /// <item><description>Webhooks.OnChannelDestroy.Url</description></item>
        /// <item><description>Webhooks.OnChannelDestroy.Method</description></item>
        /// <item><description>Webhooks.OnChannelDestroy.Format</description></item>
        /// <item><description>Webhooks.OnChannelUpdate.Url</description></item>
        /// <item><description>Webhooks.OnChannelUpdate.Method</description></item>
        /// <item><description>Webhooks.OnChannelUpdate.Format</description></item>
        /// <item><description>Webhooks.OnMemberAdd.Url</description></item>
        /// <item><description>Webhooks.OnMemberAdd.Method</description></item>
        /// <item><description>Webhooks.OnMemberAdd.Format</description></item>
        /// <item><description>Webhooks.OnMemberRemove.Url</description></item>
        /// <item><description>Webhooks.OnMemberRemove.Method</description></item>
        /// <item><description>Webhooks.OnMemberRemove.Format</description></item>
        /// </list>
        /// <br/>
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="friendlyName">Friendly Name</param>
        /// <param name="defaultServiceRoleSid">Default Service Role Sid</param>
        /// <param name="defaultChannelRoleSid">Default channel Role Sid</param>
        /// <param name="defaultChannelCreatorRoleSid">Default channel creator Role Sid</param>
        /// <param name="webhooksParams">Dictionary of Webhook params</param>
        /// <param name="typingIndicatorTimeout">Typing indicator timeout</param>
        /// <returns>Updated Service</returns>
        public virtual Service UpdateService(string serviceSid, string friendlyName,
            string defaultServiceRoleSid, string defaultChannelRoleSid,
            string defaultChannelCreatorRoleSid, int? typingIndicatorTimeout, 
            Dictionary<string, string> webhooksParams)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            if (friendlyName != null) { request.AddParameter("FriendlyName", friendlyName); }
            if (defaultServiceRoleSid != null) { request.AddParameter("DefaultServiceRoleSid", defaultServiceRoleSid); }
            if (defaultChannelRoleSid != null) { request.AddParameter("DefaultChannelRoleSid", defaultChannelRoleSid); }
            if (defaultChannelCreatorRoleSid != null) { request.AddParameter("DefaultChannelCreatorRoleSid", defaultChannelCreatorRoleSid); }

            if (typingIndicatorTimeout.HasValue) { request.AddParameter("TypingIndicatorTimeout", typingIndicatorTimeout); }

            if (webhooksParams != null && webhooksParams.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in webhooksParams)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
            }

            return Execute<Service>(request);
        }

        /// <summary>
        /// Deletes a Service identified by Service Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <returns>Service deletion status</returns>
        public virtual DeleteStatus DeleteService(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? 
                DeleteStatus.Success : 
                DeleteStatus.Failed;
        }
    }
}
