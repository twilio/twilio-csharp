using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

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
        /// Updates a Service.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="friendlyName">Friendly Name</param>
        /// <param name="defaultServiceRoleSid">Default Service Role Sid</param>
        /// <param name="defaultChannelRoleSid">Default channel Role Sid</param>
        /// <param name="typingIndicatorTimeout">Typing indicator timeout</param>
        public virtual void UpdateService(string serviceSid, string friendlyName,
            string defaultServiceRoleSid, string defaultChannelRoleSid,
            int typingIndicatorTimeout, Action<Service> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("DefaultServiceRoleSid", defaultServiceRoleSid);
            request.AddParameter("DefaultChannelRoleSid", defaultChannelRoleSid);
            request.AddParameter("TypingIndicatorTimeout", typingIndicatorTimeout);

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
