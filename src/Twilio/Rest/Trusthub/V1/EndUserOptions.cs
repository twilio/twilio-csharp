/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trusthub
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




namespace Twilio.Rest.Trusthub.V1
{

    /// <summary> Create a new End User. </summary>
    public class CreateEndUserOptions : IOptions<EndUserResource>
    {
        
        ///<summary> The string that you assigned to describe the resource. </summary> 
        public string FriendlyName { get; }

        ///<summary> The type of end user of the Bundle resource - can be `individual` or `business`. </summary> 
        public string Type { get; }

        ///<summary> The set of parameters that are the attributes of the End User resource which are derived End User Types. </summary> 
        public object Attributes { get; set; }


        /// <summary> Construct a new CreateEndUserOptions </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="type"> The type of end user of the Bundle resource - can be `individual` or `business`. </param>

        public CreateEndUserOptions(string friendlyName, string type)
        {
            FriendlyName = friendlyName;
            Type = type;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type));
            }
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Serializers.JsonObject(Attributes)));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific End User. </summary>
    public class DeleteEndUserOptions : IOptions<EndUserResource>
    {
        
        ///<summary> The unique string created by Twilio to identify the End User resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteEndUserOptions </summary>
        /// <param name="pathSid"> The unique string created by Twilio to identify the End User resource. </param>

        public DeleteEndUserOptions(string pathSid)
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


    /// <summary> Fetch specific End User Instance. </summary>
    public class FetchEndUserOptions : IOptions<EndUserResource>
    {
    
        ///<summary> The unique string created by Twilio to identify the End User resource. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchEndUserOptions </summary>
        /// <param name="pathSid"> The unique string created by Twilio to identify the End User resource. </param>

        public FetchEndUserOptions(string pathSid)
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


    /// <summary> Retrieve a list of all End User for an account. </summary>
    public class ReadEndUserOptions : ReadOptions<EndUserResource>
    {
    



        
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

    /// <summary> Update an existing End User. </summary>
    public class UpdateEndUserOptions : IOptions<EndUserResource>
    {
    
        ///<summary> The unique string created by Twilio to identify the End User resource. </summary> 
        public string PathSid { get; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The set of parameters that are the attributes of the End User resource which are derived End User Types. </summary> 
        public object Attributes { get; set; }



        /// <summary> Construct a new UpdateEndUserOptions </summary>
        /// <param name="pathSid"> The unique string created by Twilio to identify the End User resource. </param>

        public UpdateEndUserOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Serializers.JsonObject(Attributes)));
            }
            return p;
        }
        

    }


}

