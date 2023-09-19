/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Studio
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




namespace Twilio.Rest.Studio.V2
{

    /// <summary> Create a Flow. </summary>
    public class CreateFlowOptions : IOptions<FlowResource>
    {
        
        ///<summary> The string that you assigned to describe the Flow. </summary> 
        public string FriendlyName { get; }

        
        public FlowResource.StatusEnum Status { get; }

        ///<summary> JSON representation of flow definition. </summary> 
        public object Definition { get; }

        ///<summary> Description of change made in the revision. </summary> 
        public string CommitMessage { get; set; }


        /// <summary> Construct a new CreateFlowOptions </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the Flow. </param>
        /// <param name="status">  </param>
        /// <param name="definition"> JSON representation of flow definition. </param>
        public CreateFlowOptions(string friendlyName, FlowResource.StatusEnum status, object definition)
        {
            FriendlyName = friendlyName;
            Status = status;
            Definition = definition;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Definition != null)
            {
                p.Add(new KeyValuePair<string, string>("Definition", Serializers.JsonObject(Definition)));
            }
            if (CommitMessage != null)
            {
                p.Add(new KeyValuePair<string, string>("CommitMessage", CommitMessage));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific Flow. </summary>
    public class DeleteFlowOptions : IOptions<FlowResource>
    {
        
        ///<summary> The SID of the Flow resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteFlowOptions </summary>
        /// <param name="pathSid"> The SID of the Flow resource to delete. </param>
        public DeleteFlowOptions(string pathSid)
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


    /// <summary> Retrieve a specific Flow. </summary>
    public class FetchFlowOptions : IOptions<FlowResource>
    {
    
        ///<summary> The SID of the Flow resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchFlowOptions </summary>
        /// <param name="pathSid"> The SID of the Flow resource to fetch. </param>
        public FetchFlowOptions(string pathSid)
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


    /// <summary> Retrieve a list of all Flows. </summary>
    public class ReadFlowOptions : ReadOptions<FlowResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Update a Flow. </summary>
    public class UpdateFlowOptions : IOptions<FlowResource>
    {
    
        ///<summary> The SID of the Flow resource to fetch. </summary> 
        public string PathSid { get; }

        
        public FlowResource.StatusEnum Status { get; }

        ///<summary> The string that you assigned to describe the Flow. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> JSON representation of flow definition. </summary> 
        public object Definition { get; set; }

        ///<summary> Description of change made in the revision. </summary> 
        public string CommitMessage { get; set; }



        /// <summary> Construct a new UpdateFlowOptions </summary>
        /// <param name="pathSid"> The SID of the Flow resource to fetch. </param>
        /// <param name="status">  </param>
        public UpdateFlowOptions(string pathSid, FlowResource.StatusEnum status)
        {
            PathSid = pathSid;
            Status = status;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Definition != null)
            {
                p.Add(new KeyValuePair<string, string>("Definition", Serializers.JsonObject(Definition)));
            }
            if (CommitMessage != null)
            {
                p.Add(new KeyValuePair<string, string>("CommitMessage", CommitMessage));
            }
            return p;
        }
        

    }


}

