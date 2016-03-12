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

        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListEvents(string workspaceSid, Action<EventResult> callback)
        {
            ListEvents(workspaceSid, new EventListRequest(), callback);
        }

        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
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

