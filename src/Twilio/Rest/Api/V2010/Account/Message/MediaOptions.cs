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




namespace Twilio.Rest.Api.V2010.Account.Message
{
    /// <summary> Delete media from your account. Once delete, you will no longer be billed </summary>
    public class DeleteMediaOptions : IOptions<MediaResource>
    {
        
        ///<summary> The SID of the Message resource that this Media resource belongs to. </summary> 
        public string PathMessageSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Media resource to delete </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Media resource(s) to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteMediaOptions </summary>
        /// <param name="pathMessageSid"> The SID of the Message resource that this Media resource belongs to. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Media resource to delete </param>
        public DeleteMediaOptions(string pathMessageSid, string pathSid)
        {
            PathMessageSid = pathMessageSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch a single media instance belonging to the account used to make the request </summary>
    public class FetchMediaOptions : IOptions<MediaResource>
    {
    
        ///<summary> The SID of the Message resource that this Media resource belongs to. </summary> 
        public string PathMessageSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Media resource to fetch </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Media resource(s) to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchMediaOptions </summary>
        /// <param name="pathMessageSid"> The SID of the Message resource that this Media resource belongs to. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Media resource to fetch </param>
        public FetchMediaOptions(string pathMessageSid, string pathSid)
        {
            PathMessageSid = pathMessageSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of Media resources belonging to the account used to make the request </summary>
    public class ReadMediaOptions : ReadOptions<MediaResource>
    {
    
        ///<summary> The SID of the Message resource that this Media resource belongs to. </summary> 
        public string PathMessageSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Media resource(s) to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Only include media that was created on this date. Specify a date as `YYYY-MM-DD` in GMT, for example: `2009-07-06`, to read media that was created on this date. You can also specify an inequality, such as `StartTime<=YYYY-MM-DD`, to read media that was created on or before midnight of this date, and `StartTime>=YYYY-MM-DD` to read media that was created on or after midnight of this date. </summary> 
        public DateTime? DateCreated { get; set; }

        ///<summary> Only include media that was created on this date. Specify a date as `YYYY-MM-DD` in GMT, for example: `2009-07-06`, to read media that was created on this date. You can also specify an inequality, such as `StartTime<=YYYY-MM-DD`, to read media that was created on or before midnight of this date, and `StartTime>=YYYY-MM-DD` to read media that was created on or after midnight of this date. </summary> 
        public DateTime? DateCreatedBefore { get; set; }

        ///<summary> Only include media that was created on this date. Specify a date as `YYYY-MM-DD` in GMT, for example: `2009-07-06`, to read media that was created on this date. You can also specify an inequality, such as `StartTime<=YYYY-MM-DD`, to read media that was created on or before midnight of this date, and `StartTime>=YYYY-MM-DD` to read media that was created on or after midnight of this date. </summary> 
        public DateTime? DateCreatedAfter { get; set; }



        /// <summary> Construct a new ListMediaOptions </summary>
        /// <param name="pathMessageSid"> The SID of the Message resource that this Media resource belongs to. </param>
        public ReadMediaOptions(string pathMessageSid)
        {
            PathMessageSid = pathMessageSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", Serializers.DateTimeIso8601(DateCreated)));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated<", Serializers.DateTimeIso8601(DateCreatedBefore)));
                }
                if (DateCreatedAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated>", Serializers.DateTimeIso8601(DateCreatedAfter)));
                }

            }
            if (DateCreatedBefore != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated<", Serializers.DateTimeIso8601(DateCreatedBefore)));
            }
            if (DateCreatedAfter != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated>", Serializers.DateTimeIso8601(DateCreatedAfter)));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}

