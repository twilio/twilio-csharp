/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Flex
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




namespace Twilio.Rest.FlexApi.V1.Interaction
{
    /// <summary> Fetch a Channel for an Interaction. </summary>
    public class FetchInteractionChannelOptions : IOptions<InteractionChannelResource>
    {
    
        ///<summary> The unique string created by Twilio to identify an Interaction resource, prefixed with KD. </summary> 
        public string PathInteractionSid { get; }

        ///<summary> The unique string created by Twilio to identify an Interaction Channel resource, prefixed with UO. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchInteractionChannelOptions </summary>
        /// <param name="pathInteractionSid"> The unique string created by Twilio to identify an Interaction resource, prefixed with KD. </param>
        /// <param name="pathSid"> The unique string created by Twilio to identify an Interaction Channel resource, prefixed with UO. </param>

        public FetchInteractionChannelOptions(string pathInteractionSid, string pathSid)
        {
            PathInteractionSid = pathInteractionSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> List all Channels for an Interaction. </summary>
    public class ReadInteractionChannelOptions : ReadOptions<InteractionChannelResource>
    {
    
        ///<summary> The unique string created by Twilio to identify an Interaction resource, prefixed with KD. </summary> 
        public string PathInteractionSid { get; }



        /// <summary> Construct a new ListInteractionChannelOptions </summary>
        /// <param name="pathInteractionSid"> The unique string created by Twilio to identify an Interaction resource, prefixed with KD. </param>

        public ReadInteractionChannelOptions(string pathInteractionSid)
        {
            PathInteractionSid = pathInteractionSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Update an existing Interaction Channel. </summary>
    public class UpdateInteractionChannelOptions : IOptions<InteractionChannelResource>
    {
    
        ///<summary> The unique string created by Twilio to identify an Interaction resource, prefixed with KD. </summary> 
        public string PathInteractionSid { get; }

        ///<summary> The unique string created by Twilio to identify an Interaction Channel resource, prefixed with UO. </summary> 
        public string PathSid { get; }

        
        public InteractionChannelResource.StatusEnum Status { get; }

        ///<summary> Optional. The state of associated tasks. If not specified, all tasks will be set to `wrapping`. </summary> 
        public object Routing { get; set; }



        /// <summary> Construct a new UpdateInteractionChannelOptions </summary>
        /// <param name="pathInteractionSid"> The unique string created by Twilio to identify an Interaction resource, prefixed with KD. </param>
        /// <param name="pathSid"> The unique string created by Twilio to identify an Interaction Channel resource, prefixed with UO. </param>
        /// <param name="status">  </param>

        public UpdateInteractionChannelOptions(string pathInteractionSid, string pathSid, InteractionChannelResource.StatusEnum status)
        {
            PathInteractionSid = pathInteractionSid;
            PathSid = pathSid;
            Status = status;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Routing != null)
            {
                p.Add(new KeyValuePair<string, string>("Routing", Serializers.JsonObject(Routing)));
            }
            return p;
        }
        

    }


}

