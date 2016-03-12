using System;
using RestSharp;
using RestSharp.Validation;

namespace Twilio.Monitor
{
    public partial class MonitorClient
    {
        /// <summary>
        /// Gets an event by its unique ID.
        /// </summary>
        /// <param name="eventSid">Event sid.</param>
        public virtual void GetEvent(string eventSid, Action<Event> callback)
        {
            Require.Argument("EventSid", eventSid);

            var request = new RestRequest();
            request.Resource = "Events/{EventSid}";

            request.AddUrlSegment("EventSid", eventSid);

            ExecuteAsync<Event>(request, (response) => {
                callback(response);
            });
        }

        /// <summary>
        /// Lists the events.
        /// </summary>
        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListEvents(Action<EventResult> callback)
        {
            ListEvents(new EventListRequest(), callback);
        }

        /// <summary>
        /// Lists the events.
        /// </summary>
        [System.Obsolete("page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListEvents(EventListRequest options, Action<EventResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Events";

            AddEventListOptions(options, request);

            ExecuteAsync<EventResult>(request, callback);
        }
    }
}

