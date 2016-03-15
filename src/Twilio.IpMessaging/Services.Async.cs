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
		public virtual void ListServices(Action<ServiceResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services";

            ExecuteAsync<ServiceResult>(request, (response) =>
                callback(response));
        }

        /// <summary>
        /// Retrieves a Service by Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        public virtual void GetService(string serviceSid,
            Action<Service> callback)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            ExecuteAsync<Service>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Service.
        /// </summary>
        /// <param name="friendlyName">Friendly Name for the Service</param>
        public virtual void CreateService(string friendlyName,
            Action<Service> callback)
        {
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services";

            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<Service>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a Service.<br/>
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
        public virtual void UpdateService(string serviceSid, string friendlyName,
            string defaultServiceRoleSid, string defaultChannelRoleSid,
            string defaultChannelCreatorRoleSid, int typingIndicatorTimeout,
            Dictionary<string, string> webhooksParams, Action<Service> callback)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("DefaultServiceRoleSid", defaultServiceRoleSid);
            request.AddParameter("DefaultChannelRoleSid", defaultChannelRoleSid);
            request.AddParameter("DefaultChannelCreatorRoleSid", defaultChannelCreatorRoleSid);
            request.AddParameter("TypingIndicatorTimeout", typingIndicatorTimeout);

            if (webhooksParams != null && webhooksParams.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in webhooksParams)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
            }

            ExecuteAsync<Service>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Service identified by Service Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        public virtual void DeleteService(string serviceSid,
            Action<DeleteStatus> callback)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            ExecuteAsync(request, (response) => { callback(
                response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}
