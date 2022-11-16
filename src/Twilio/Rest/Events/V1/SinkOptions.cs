/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Events
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




namespace Twilio.Rest.Events.V1
{

    /// <summary> Create a new Sink </summary>
    public class CreateSinkOptions : IOptions<SinkResource>
    {
        
        ///<summary> A human readable description for the Sink **This value should not contain PII.** </summary> 
        public string Description { get; }

        ///<summary> The information required for Twilio to connect to the provided Sink encoded as JSON. </summary> 
        public object SinkConfiguration { get; }

        
        public SinkResource.SinkTypeEnum SinkType { get; }


        /// <summary> Construct a new CreateSinkOptions </summary>
        /// <param name="description"> A human readable description for the Sink **This value should not contain PII.** </param>
        /// <param name="sinkConfiguration"> The information required for Twilio to connect to the provided Sink encoded as JSON. </param>
        /// <param name="sinkType">  </param>
        public CreateSinkOptions(string description, object sinkConfiguration, SinkResource.SinkTypeEnum sinkType)
        {
            Description = description;
            SinkConfiguration = sinkConfiguration;
            SinkType = sinkType;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Description != null)
            {
                p.Add(new KeyValuePair<string, string>("Description", Description));
            }
            if (SinkConfiguration != null)
            {
                p.Add(new KeyValuePair<string, string>("SinkConfiguration", Serializers.JsonObject(SinkConfiguration)));
            }
            if (SinkType != null)
            {
                p.Add(new KeyValuePair<string, string>("SinkType", SinkType.ToString()));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific Sink. </summary>
    public class DeleteSinkOptions : IOptions<SinkResource>
    {
        
        ///<summary> A 34 character string that uniquely identifies this Sink. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteSinkOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Sink. </param>
        public DeleteSinkOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch a specific Sink. </summary>
    public class FetchSinkOptions : IOptions<SinkResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this Sink. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchSinkOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Sink. </param>
        public FetchSinkOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a paginated list of Sinks belonging to the account used to make the request. </summary>
    public class ReadSinkOptions : ReadOptions<SinkResource>
    {
    
        ///<summary> A boolean query parameter filtering the results to return sinks used/not used by a subscription. </summary> 
        public bool? InUse { get; set; }

        ///<summary> A String query parameter filtering the results by status `initialized`, `validating`, `active` or `failed`. </summary> 
        public string Status { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (InUse != null)
            {
                p.Add(new KeyValuePair<string, string>("InUse", InUse.Value.ToString().ToLower()));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Update a specific Sink </summary>
    public class UpdateSinkOptions : IOptions<SinkResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this Sink. </summary> 
        public string PathSid { get; }

        ///<summary> A human readable description for the Sink **This value should not contain PII.** </summary> 
        public string Description { get; }



        /// <summary> Construct a new UpdateSinkOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Sink. </param>
        /// <param name="description"> A human readable description for the Sink **This value should not contain PII.** </param>
        public UpdateSinkOptions(string pathSid, string description)
        {
            PathSid = pathSid;
            Description = description;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Description != null)
            {
                p.Add(new KeyValuePair<string, string>("Description", Description));
            }
            return p;
        }
        

    }


}

