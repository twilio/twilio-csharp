/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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




namespace Twilio.Rest.Api.V2010.Account
{
    /// <summary> Delete the caller-id specified from the account </summary>
    public class DeleteOutgoingCallerIdOptions : IOptions<OutgoingCallerIdResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to delete. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteOutgoingCallerIdOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to delete. </param>

        public DeleteOutgoingCallerIdOptions(string pathSid)
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


    /// <summary> Fetch an outgoing-caller-id belonging to the account used to make the request </summary>
    public class FetchOutgoingCallerIdOptions : IOptions<OutgoingCallerIdResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchOutgoingCallerIdOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to fetch. </param>

        public FetchOutgoingCallerIdOptions(string pathSid)
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


    /// <summary> Retrieve a list of outgoing-caller-ids belonging to the account used to make the request </summary>
    public class ReadOutgoingCallerIdOptions : ReadOptions<OutgoingCallerIdResource>
    {
    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The phone number of the OutgoingCallerId resources to read. </summary> 
        public Types.PhoneNumber PhoneNumber { get; set; }

        ///<summary> The string that identifies the OutgoingCallerId resources to read. </summary> 
        public string FriendlyName { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
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

    /// <summary> Updates the caller-id </summary>
    public class UpdateOutgoingCallerIdOptions : IOptions<OutgoingCallerIdResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to update. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }



        /// <summary> Construct a new UpdateOutgoingCallerIdOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to update. </param>

        public UpdateOutgoingCallerIdOptions(string pathSid)
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
            return p;
        }
        

    }


}

