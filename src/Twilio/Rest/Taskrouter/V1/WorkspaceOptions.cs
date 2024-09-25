/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Taskrouter
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Taskrouter.V1
{

    /// <summary> create </summary>
    public class CreateWorkspaceOptions : IOptions<WorkspaceResource>
    {
        
        ///<summary> A descriptive string that you create to describe the Workspace resource. It can be up to 64 characters long. For example: `Customer Support` or `2014 Election Campaign`. </summary> 
        public string FriendlyName { get; }

        ///<summary> The URL we should call when an event occurs. If provided, the Workspace will publish events to this URL, for example, to collect data for reporting. See [Workspace Events](https://www.twilio.com/docs/taskrouter/api/event) for more information. This parameter supports Twilio's [Webhooks (HTTP callbacks) Connection Overrides](https://www.twilio.com/docs/usage/webhooks/webhooks-connection-overrides). </summary> 
        public Uri EventCallbackUrl { get; set; }

        ///<summary> The list of Workspace events for which to call event_callback_url. For example, if `EventsFilter=task.created, task.canceled, worker.activity.update`, then TaskRouter will call event_callback_url only when a task is created, canceled, or a Worker activity is updated. </summary> 
        public string EventsFilter { get; set; }

        ///<summary> Whether to enable multi-tasking. Can be: `true` to enable multi-tasking, or `false` to disable it. However, all workspaces should be created as multi-tasking. The default is `true`. Multi-tasking allows Workers to handle multiple Tasks simultaneously. When enabled (`true`), each Worker can receive parallel reservations up to the per-channel maximums defined in the Workers section. In single-tasking mode (legacy mode), each Worker will only receive a new reservation when the previous task is completed. Learn more at [Multitasking](https://www.twilio.com/docs/taskrouter/multitasking). </summary> 
        public bool? MultiTaskEnabled { get; set; }

        ///<summary> An available template name. Can be: `NONE` or `FIFO` and the default is `NONE`. Pre-configures the Workspace with the Workflow and Activities specified in the template. `NONE` will create a Workspace with only a set of default activities. `FIFO` will configure TaskRouter with a set of default activities and a single TaskQueue for first-in, first-out distribution, which can be useful when you are getting started with TaskRouter. </summary> 
        public string Template { get; set; }

        
        public WorkspaceResource.QueueOrderEnum PrioritizeQueueOrder { get; set; }


        /// <summary> Construct a new CreateWorkspaceOptions </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Workspace resource. It can be up to 64 characters long. For example: `Customer Support` or `2014 Election Campaign`. </param>
        public CreateWorkspaceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (EventCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("EventCallbackUrl", Serializers.Url(EventCallbackUrl)));
            }
            if (EventsFilter != null)
            {
                p.Add(new KeyValuePair<string, string>("EventsFilter", EventsFilter));
            }
            if (MultiTaskEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("MultiTaskEnabled", MultiTaskEnabled.Value.ToString().ToLower()));
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
    /// <summary> delete </summary>
    public class DeleteWorkspaceOptions : IOptions<WorkspaceResource>
    {
        
        ///<summary> The SID of the Workspace resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteWorkspaceOptions </summary>
        /// <param name="pathSid"> The SID of the Workspace resource to delete. </param>
        public DeleteWorkspaceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> fetch </summary>
    public class FetchWorkspaceOptions : IOptions<WorkspaceResource>
    {
    
        ///<summary> The SID of the Workspace resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchWorkspaceOptions </summary>
        /// <param name="pathSid"> The SID of the Workspace resource to fetch. </param>
        public FetchWorkspaceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> read </summary>
    public class ReadWorkspaceOptions : ReadOptions<WorkspaceResource>
    {
    
        ///<summary> The `friendly_name` of the Workspace resources to read. For example `Customer Support` or `2014 Election Campaign`. </summary> 
        public string FriendlyName { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
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

    /// <summary> update </summary>
    public class UpdateWorkspaceOptions : IOptions<WorkspaceResource>
    {
    
        ///<summary> The SID of the Workspace resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the Activity that will be used when new Workers are created in the Workspace. </summary> 
        public string DefaultActivitySid { get; set; }

        ///<summary> The URL we should call when an event occurs. See [Workspace Events](https://www.twilio.com/docs/taskrouter/api/event) for more information. This parameter supports Twilio's [Webhooks (HTTP callbacks) Connection Overrides](https://www.twilio.com/docs/usage/webhooks/webhooks-connection-overrides). </summary> 
        public Uri EventCallbackUrl { get; set; }

        ///<summary> The list of Workspace events for which to call event_callback_url. For example if `EventsFilter=task.created,task.canceled,worker.activity.update`, then TaskRouter will call event_callback_url only when a task is created, canceled, or a Worker activity is updated. </summary> 
        public string EventsFilter { get; set; }

        ///<summary> A descriptive string that you create to describe the Workspace resource. For example: `Sales Call Center` or `Customer Support Team`. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Whether to enable multi-tasking. Can be: `true` to enable multi-tasking, or `false` to disable it. However, all workspaces should be maintained as multi-tasking. There is no default when omitting this parameter. A multi-tasking Workspace can't be updated to single-tasking unless it is not a Flex Project and another (legacy) single-tasking Workspace exists. Multi-tasking allows Workers to handle multiple Tasks simultaneously. In multi-tasking mode, each Worker can receive parallel reservations up to the per-channel maximums defined in the Workers section. In single-tasking mode (legacy mode), each Worker will only receive a new reservation when the previous task is completed. Learn more at [Multitasking](https://www.twilio.com/docs/taskrouter/multitasking). </summary> 
        public bool? MultiTaskEnabled { get; set; }

        ///<summary> The SID of the Activity that will be assigned to a Worker when a Task reservation times out without a response. </summary> 
        public string TimeoutActivitySid { get; set; }

        
        public WorkspaceResource.QueueOrderEnum PrioritizeQueueOrder { get; set; }



        /// <summary> Construct a new UpdateWorkspaceOptions </summary>
        /// <param name="pathSid"> The SID of the Workspace resource to update. </param>
        public UpdateWorkspaceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DefaultActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultActivitySid", DefaultActivitySid));
            }
            if (EventCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("EventCallbackUrl", Serializers.Url(EventCallbackUrl)));
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
                p.Add(new KeyValuePair<string, string>("MultiTaskEnabled", MultiTaskEnabled.Value.ToString().ToLower()));
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


}

