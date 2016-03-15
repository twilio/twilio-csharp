using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="eventSid">Event sid.</param>
        public virtual Event GetEvent(string workspaceSid, string eventSid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("EventSid", eventSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events/{EventSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("EventSid", eventSid);

            return Execute<Event>(request);
        }

        /// <summary>
        /// Lists the events.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
		public virtual EventResult ListEvents(string workspaceSid)
        {
            return ListEvents(workspaceSid, new EventListRequest());
        }

        /// <summary>
        /// Lists the events.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="options">Options.</param>
		public virtual EventResult ListEvents(string workspaceSid, EventListRequest options)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddEventListOptions(options, request);

            return Execute<EventResult>(request);
        }

        private void AddEventListOptions(EventListRequest options, RestRequest request)
        {
            if (options.Minutes.HasValue) request.AddParameter("Minutes", options.Minutes.Value);
            if (options.StartDate.HasValue) {
                request.AddParameter("StartDate", options.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"));
            }
            if (options.EndDate.HasValue) {
                request.AddParameter("EndDate", options.EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"));
            }
            if (options.ResourceSid.HasValue()) request.AddParameter("ResourceSid", options.ResourceSid);
            if (options.EventType.HasValue()) request.AddParameter("EventType", options.EventType);

            if (options.PageToken.HasValue()) request.AddParameter("PageToken", options.PageToken);
            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
        }
    }
}

