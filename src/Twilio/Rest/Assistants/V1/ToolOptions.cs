/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Assistants
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




namespace Twilio.Rest.Assistants.V1
{

    /// <summary> Create tool </summary>
    public class CreateToolOptions : IOptions<ToolResource>
    {
        
        
        public ToolResource.AssistantsV1ServiceCreateToolRequest AssistantsV1ServiceCreateToolRequest { get; }


        /// <summary> Construct a new CreateToolOptions </summary>
        /// <param name="assistantsV1ServiceCreateToolRequest">  </param>
        public CreateToolOptions(ToolResource.AssistantsV1ServiceCreateToolRequest assistantsV1ServiceCreateToolRequest)
        {
            AssistantsV1ServiceCreateToolRequest = assistantsV1ServiceCreateToolRequest;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (AssistantsV1ServiceCreateToolRequest != null)
            {
                body = ToolResource.ToJson(AssistantsV1ServiceCreateToolRequest);
            }
            return body;
        }
        

    }
    /// <summary> delete a tool </summary>
    public class DeleteToolOptions : IOptions<ToolResource>
    {
        
        ///<summary> The tool ID. </summary> 
        public string PathId { get; }



        /// <summary> Construct a new DeleteToolOptions </summary>
        /// <param name="pathId"> The tool ID. </param>
        public DeleteToolOptions(string pathId)
        {
            PathId = pathId;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Get tool </summary>
    public class FetchToolOptions : IOptions<ToolResource>
    {
    
        
        public string PathId { get; }



        /// <summary> Construct a new FetchToolOptions </summary>
        /// <param name="pathId">  </param>
        public FetchToolOptions(string pathId)
        {
            PathId = pathId;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> List tools </summary>
    public class ReadToolOptions : ReadOptions<ToolResource>
    {
    
        
        public string AssistantId { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (AssistantId != null)
            {
                p.Add(new KeyValuePair<string, string>("AssistantId", AssistantId));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> Update tool </summary>
    public class UpdateToolOptions : IOptions<ToolResource>
    {
    
        
        public string PathId { get; }

        
        public ToolResource.AssistantsV1ServiceUpdateToolRequest AssistantsV1ServiceUpdateToolRequest { get; set; }



        /// <summary> Construct a new UpdateToolOptions </summary>
        /// <param name="pathId">  </param>
        public UpdateToolOptions(string pathId)
        {
            PathId = pathId;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (AssistantsV1ServiceUpdateToolRequest != null)
            {
                body = ToolResource.ToJson(AssistantsV1ServiceUpdateToolRequest);
            }
            return body;
        }
        

    }


}

