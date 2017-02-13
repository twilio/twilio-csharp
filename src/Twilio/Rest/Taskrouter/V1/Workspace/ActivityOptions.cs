using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class FetchActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchActivityOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchActivityOptions(string workspaceSid, string sid)
        {
            WorkspaceSid = workspaceSid;
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

    public class UpdateActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateActivityOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateActivityOptions(string workspaceSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            Sid = sid;
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
            
            return p;
        }
    }

    public class DeleteActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteActivityOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteActivityOptions(string workspaceSid, string sid)
        {
            WorkspaceSid = workspaceSid;
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

    public class ReadActivityOptions : ReadOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The available
        /// </summary>
        public string Available { get; set; }
    
        /// <summary>
        /// Construct a new ReadActivityOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public ReadActivityOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
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
            
            if (Available != null)
            {
                p.Add(new KeyValuePair<string, string>("Available", Available));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class CreateActivityOptions : IOptions<ActivityResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The available
        /// </summary>
        public bool? Available { get; set; }
    
        /// <summary>
        /// Construct a new CreateActivityOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateActivityOptions(string workspaceSid, string friendlyName)
        {
            WorkspaceSid = workspaceSid;
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
            
            if (Available != null)
            {
                p.Add(new KeyValuePair<string, string>("Available", Available.Value.ToString()));
            }
            
            return p;
        }
    }

}