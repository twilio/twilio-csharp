/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
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
using System.Linq;



namespace Twilio.Rest.Verify.V2.Service.Entity
{

    /// <summary> Create a new Challenge for the Factor </summary>
    public class CreateChallengeOptions : IOptions<ChallengeResource>
    {
        
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </summary> 
        public string PathIdentity { get; }

        ///<summary> The unique SID identifier of the Factor. </summary> 
        public string FactorSid { get; }

        ///<summary> The date-time when this Challenge expires, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. The default value is five (5) minutes after Challenge creation. The max value is sixty (60) minutes after creation. </summary> 
        public DateTime? ExpirationDate { get; set; }

        ///<summary> Shown to the user when the push notification arrives. Required when `factor_type` is `push`. Can be up to 256 characters in length </summary> 
        public string DetailsMessage { get; set; }

        ///<summary> A list of objects that describe the Fields included in the Challenge. Each object contains the label and value of the field, the label can be up to 36 characters in length and the value can be up to 128 characters in length. Used when `factor_type` is `push`. There can be up to 20 details fields. </summary> 
        public List<object> DetailsFields { get; set; }

        ///<summary> Details provided to give context about the Challenge. Not shown to the end user. It must be a stringified JSON with only strings values eg. `{\\\"ip\\\": \\\"172.168.1.234\\\"}`. Can be up to 1024 characters in length </summary> 
        public object HiddenDetails { get; set; }

        ///<summary> Optional payload used to verify the Challenge upon creation. Only used with a Factor of type `totp` to carry the TOTP code that needs to be verified. For `TOTP` this value must be between 3 and 8 characters long. </summary> 
        public string AuthPayload { get; set; }


        /// <summary> Construct a new CreateChallengeOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="factorSid"> The unique SID identifier of the Factor. </param>
        public CreateChallengeOptions(string pathServiceSid, string pathIdentity, string factorSid)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
            FactorSid = factorSid;
            DetailsFields = new List<object>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FactorSid != null)
            {
                p.Add(new KeyValuePair<string, string>("FactorSid", FactorSid));
            }
            if (ExpirationDate != null)
            {
                p.Add(new KeyValuePair<string, string>("ExpirationDate", Serializers.DateTimeIso8601(ExpirationDate)));
            }
            if (DetailsMessage != null)
            {
                p.Add(new KeyValuePair<string, string>("Details.Message", DetailsMessage));
            }
            if (DetailsFields != null)
            {
                p.AddRange(DetailsFields.Select(DetailsFields => new KeyValuePair<string, string>("Details.Fields", Serializers.JsonObject(DetailsFields))));
            }
            if (HiddenDetails != null)
            {
                p.Add(new KeyValuePair<string, string>("HiddenDetails", Serializers.JsonObject(HiddenDetails)));
            }
            if (AuthPayload != null)
            {
                p.Add(new KeyValuePair<string, string>("AuthPayload", AuthPayload));
            }
            return p;
        }

        

    }
    /// <summary> Fetch a specific Challenge. </summary>
    public class FetchChallengeOptions : IOptions<ChallengeResource>
    {
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> Customer unique identity for the Entity owner of the Challenges. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </summary> 
        public string PathIdentity { get; }

        ///<summary> A 34 character string that uniquely identifies this Challenge. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchChallengeOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenges. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Challenge. </param>
        public FetchChallengeOptions(string pathServiceSid, string pathIdentity, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of all Challenges for a Factor. </summary>
    public class ReadChallengeOptions : ReadOptions<ChallengeResource>
    {
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </summary> 
        public string PathIdentity { get; }

        ///<summary> The unique SID identifier of the Factor. </summary> 
        public string FactorSid { get; set; }

        ///<summary> The Status of the Challenges to fetch. One of `pending`, `expired`, `approved` or `denied`. </summary> 
        public ChallengeResource.ChallengeStatusesEnum Status { get; set; }

        ///<summary> The desired sort order of the Challenges list. One of `asc` or `desc` for ascending and descending respectively. Defaults to `asc`. </summary> 
        public ChallengeResource.ListOrdersEnum Order { get; set; }



        /// <summary> Construct a new ListChallengeOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        public ReadChallengeOptions(string pathServiceSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FactorSid != null)
            {
                p.Add(new KeyValuePair<string, string>("FactorSid", FactorSid));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Order != null)
            {
                p.Add(new KeyValuePair<string, string>("Order", Order.ToString()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> Verify a specific Challenge. </summary>
    public class UpdateChallengeOptions : IOptions<ChallengeResource>
    {
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string PathServiceSid { get; }

        ///<summary> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </summary> 
        public string PathIdentity { get; }

        ///<summary> A 34 character string that uniquely identifies this Challenge. </summary> 
        public string PathSid { get; }

        ///<summary> The optional payload needed to verify the Challenge. E.g., a TOTP would use the numeric code. For `TOTP` this value must be between 3 and 8 characters long. For `Push` this value can be up to 5456 characters in length </summary> 
        public string AuthPayload { get; set; }

        ///<summary> Custom metadata associated with the challenge. This is added by the Device/SDK directly to allow for the inclusion of device information. It must be a stringified JSON with only strings values eg. `{\\\"os\\\": \\\"Android\\\"}`. Can be up to 1024 characters in length. </summary> 
        public object Metadata { get; set; }



        /// <summary> Construct a new UpdateChallengeOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Challenge. </param>
        public UpdateChallengeOptions(string pathServiceSid, string pathIdentity, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (AuthPayload != null)
            {
                p.Add(new KeyValuePair<string, string>("AuthPayload", AuthPayload));
            }
            if (Metadata != null)
            {
                p.Add(new KeyValuePair<string, string>("Metadata", Serializers.JsonObject(Metadata)));
            }
            return p;
        }

        

    }


}

