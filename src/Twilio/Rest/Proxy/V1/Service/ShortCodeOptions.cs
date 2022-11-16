/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Proxy
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




namespace Twilio.Rest.Proxy.V1.Service
{

    /// <summary> Add a Short Code to the Proxy Number Pool for the Service. </summary>
    public class CreateShortCodeOptions : IOptions<ShortCodeResource>
    {
        
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of a Twilio [ShortCode](https://www.twilio.com/docs/sms/api/short-code) resource that represents the short code you would like to assign to your Proxy Service. </summary> 
        public string Sid { get; }


        /// <summary> Construct a new CreateShortCodeOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </param>
        /// <param name="sid"> The SID of a Twilio [ShortCode](https://www.twilio.com/docs/sms/api/short-code) resource that represents the short code you would like to assign to your Proxy Service. </param>

        public CreateShortCodeOptions(string pathServiceSid, string sid)
        {
            PathServiceSid = pathServiceSid;
            Sid = sid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Sid != null)
            {
                p.Add(new KeyValuePair<string, string>("Sid", Sid));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific Short Code from a Service. </summary>
    public class DeleteShortCodeOptions : IOptions<ShortCodeResource>
    {
        
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource to delete the ShortCode resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the ShortCode resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteShortCodeOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource to delete the ShortCode resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to delete. </param>

        public DeleteShortCodeOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch a specific Short Code. </summary>
    public class FetchShortCodeOptions : IOptions<ShortCodeResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) to fetch the resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the ShortCode resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchShortCodeOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) to fetch the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to fetch. </param>

        public FetchShortCodeOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Short Codes in the Proxy Number Pool for the Service. A maximum of 100 records will be returned per page. </summary>
    public class ReadShortCodeOptions : ReadOptions<ShortCodeResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) to read the resources from. </summary> 
        public string PathServiceSid { get; }



        /// <summary> Construct a new ListShortCodeOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) to read the resources from. </param>

        public ReadShortCodeOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
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

    /// <summary> Update a specific Short Code. </summary>
    public class UpdateShortCodeOptions : IOptions<ShortCodeResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to update. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the ShortCode resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> Whether the short code should be reserved and not be assigned to a participant using proxy pool logic. See [Reserved Phone Numbers](https://www.twilio.com/docs/proxy/reserved-phone-numbers) for more information. </summary> 
        public bool? IsReserved { get; set; }



        /// <summary> Construct a new UpdateShortCodeOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to update. </param>

        public UpdateShortCodeOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (IsReserved != null)
            {
                p.Add(new KeyValuePair<string, string>("IsReserved", IsReserved.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


}

