using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1 
{

    public class FetchWorkspaceOptions : IOptions<WorkspaceResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchWorkspaceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchWorkspaceOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class UpdateWorkspaceOptions : IOptions<WorkspaceResource> 
    {
        public string Sid { get; }
        public string DefaultActivitySid { get; set; }
        public Uri EventCallbackUrl { get; set; }
        public string EventsFilter { get; set; }
        public string FriendlyName { get; set; }
        public bool? MultiTaskEnabled { get; set; }
        public string TimeoutActivitySid { get; set; }
        public WorkspaceResource.QueueOrderEnum PrioritizeQueueOrder { get; set; }
    
        /// <summary>
        /// Construct a new UpdateWorkspaceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateWorkspaceOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DefaultActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultActivitySid", DefaultActivitySid));
            }
            
            if (EventCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("EventCallbackUrl", EventCallbackUrl.ToString()));
            }
            
            if (EventsFilter != null)
            {
                p.Add(new KeyValuePair<string, string>("EventsFilter", EventsFilter));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (MultiTaskEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("MultiTaskEnabled", MultiTaskEnabled.ToString()));
            }
            
            if (TimeoutActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("TimeoutActivitySid", TimeoutActivitySid));
            }
            
            if (PrioritizeQueueOrder != null)
            {
                p.Add(new KeyValuePair<string, string>("PrioritizeQueueOrder", PrioritizeQueueOrder.ToString()));
            }
            
            return p;
        }
    }

    public class ReadWorkspaceOptions : ReadOptions<WorkspaceResource> 
    {
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class CreateWorkspaceOptions : IOptions<WorkspaceResource> 
    {
        public string FriendlyName { get; }
        public Uri EventCallbackUrl { get; set; }
        public string EventsFilter { get; set; }
        public bool? MultiTaskEnabled { get; set; }
        public string Template { get; set; }
        public WorkspaceResource.QueueOrderEnum PrioritizeQueueOrder { get; set; }
    
        /// <summary>
        /// Construct a new CreateWorkspaceOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateWorkspaceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (EventCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("EventCallbackUrl", EventCallbackUrl.ToString()));
            }
            
            if (EventsFilter != null)
            {
                p.Add(new KeyValuePair<string, string>("EventsFilter", EventsFilter));
            }
            
            if (MultiTaskEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("MultiTaskEnabled", MultiTaskEnabled.ToString()));
            }
            
            if (Template != null)
            {
                p.Add(new KeyValuePair<string, string>("Template", Template));
            }
            
            if (PrioritizeQueueOrder != null)
            {
                p.Add(new KeyValuePair<string, string>("PrioritizeQueueOrder", PrioritizeQueueOrder.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteWorkspaceOptions : IOptions<WorkspaceResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteWorkspaceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteWorkspaceOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

}