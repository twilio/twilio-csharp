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

    /// <summary> Add a Phone Number to a Service's Proxy Number Pool. </summary>
    public class CreatePhoneNumberOptions : IOptions<PhoneNumberResource>
    {
        
        ///<summary> The SID parent [Service](https://www.twilio.com/docs/proxy/api/service) resource of the new PhoneNumber resource. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of a Twilio [IncomingPhoneNumber](https://www.twilio.com/docs/phone-numbers/api/incomingphonenumber-resource) resource that represents the Twilio Number you would like to assign to your Proxy Service. </summary> 
        public string Sid { get; set; }

        ///<summary> The phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format.  E.164 phone numbers consist of a + followed by the country code and subscriber number without punctuation characters. For example, +14155551234. </summary> 
        public Types.PhoneNumber PhoneNumber { get; set; }

        ///<summary> Whether the new phone number should be reserved and not be assigned to a participant using proxy pool logic. See [Reserved Phone Numbers](https://www.twilio.com/docs/proxy/reserved-phone-numbers) for more information. </summary> 
        public bool? IsReserved { get; set; }


        /// <summary> Construct a new CreatePhoneNumberOptions </summary>
        /// <param name="pathServiceSid"> The SID parent [Service](https://www.twilio.com/docs/proxy/api/service) resource of the new PhoneNumber resource. </param>
        public CreatePhoneNumberOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Sid != null)
            {
                p.Add(new KeyValuePair<string, string>("Sid", Sid));
            }
            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            if (IsReserved != null)
            {
                p.Add(new KeyValuePair<string, string>("IsReserved", IsReserved.Value.ToString().ToLower()));
            }
            return p;
        }

        

    }
    /// <summary> Delete a specific Phone Number from a Service. </summary>
    public class DeletePhoneNumberOptions : IOptions<PhoneNumberResource>
    {
        
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resource to delete. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the PhoneNumber resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeletePhoneNumberOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resource to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PhoneNumber resource to delete. </param>
        public DeletePhoneNumberOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Fetch a specific Phone Number. </summary>
    public class FetchPhoneNumberOptions : IOptions<PhoneNumberResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resource to fetch. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the PhoneNumber resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchPhoneNumberOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PhoneNumber resource to fetch. </param>
        public FetchPhoneNumberOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of all Phone Numbers in the Proxy Number Pool for a Service. A maximum of 100 records will be returned per page. </summary>
    public class ReadPhoneNumberOptions : ReadOptions<PhoneNumberResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resources to read. </summary> 
        public string PathServiceSid { get; }



        /// <summary> Construct a new ListPhoneNumberOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resources to read. </param>
        public ReadPhoneNumberOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
        }

        
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

    /// <summary> Update a specific Proxy Number. </summary>
    public class UpdatePhoneNumberOptions : IOptions<PhoneNumberResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resource to update. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the PhoneNumber resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> Whether the phone number should be reserved and not be assigned to a participant using proxy pool logic. See [Reserved Phone Numbers](https://www.twilio.com/docs/proxy/reserved-phone-numbers) for more information. </summary> 
        public bool? IsReserved { get; set; }



        /// <summary> Construct a new UpdatePhoneNumberOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the PhoneNumber resource to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PhoneNumber resource to update. </param>
        public UpdatePhoneNumberOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
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

