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
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}";
            request.AddUrlSegment("ServiceSid", serviceSid);

            ExecuteAsync<Service>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Service.
        /// </summary>
        /// <param name="friendlyName">Friendly Name for the Service</param>
        public virtual void CreateService(string type, string friendlyName,
          Action<Service> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services";

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Service>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a Service.
        /// TODO - Figureout how to pass the webhoooks (Dictionary?)
        /// </summary>
        /// <param name="friendlyName">Friendly Name</param>
        /// <param name="defaultServiceRoleSid">Default Service Role Sid</param>
        /// <param name="defaultChannelRoleSid">Default channel Role Sid</param>
        /// <param name="typingIndicatorTimeout">Typing indicator timeout</param>
        public virtual void UpdateService(string friendlyName,
          string defaultServiceRoleSid, string defaultChannelRoleSid,
          int typingIndicatorTimeout, Action<Service> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}";

            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Service>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Service identified by Service Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        public virtual void DeleteService(string serviceSid,
          Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}";
            request.AddUrlSegment("ServiceSid", serviceSid);

            var response = Execute(request);
            ExecuteAsync(request, (response) => { callback(
              response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}
