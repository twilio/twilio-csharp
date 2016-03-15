using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        public virtual void GetEvent(string workspaceSid, string eventSid, Action<Event> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("EventSid", eventSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events/{EventSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("EventSid", eventSid);

            ExecuteAsync<Event>(request, (response) => { callback(response); });
        }

		public virtual void ListEvents(string workspaceSid, Action<EventResult> callback)
        {
            ListEvents(workspaceSid, new EventListRequest(), callback);
        }

		public virtual void ListEvents(string workspaceSid, EventListRequest options, Action<EventResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddEventListOptions(options, request);

            ExecuteAsync<EventResult>(request, callback);
        }
    }
}

