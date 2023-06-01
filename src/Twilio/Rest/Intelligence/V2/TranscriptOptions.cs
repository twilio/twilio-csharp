/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Intelligence
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




namespace Twilio.Rest.Intelligence.V2
{

    /// <summary> Create a new Transcript for the service </summary>
    public class CreateTranscriptOptions : IOptions<TranscriptResource>
    {
        
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string ServiceSid { get; }

        ///<summary> JSON object describing Media Channel including Source and Participants </summary> 
        public object Channel { get; }

        ///<summary> Used to store client provided metadata. Maximum of 64 double-byte UTF8 characters. </summary> 
        public string CustomerKey { get; set; }

        ///<summary> The date that this Transcript's media was started, given in ISO 8601 format. </summary> 
        public DateTime? MediaStartTime { get; set; }


        /// <summary> Construct a new CreateTranscriptOptions </summary>
        /// <param name="serviceSid"> The unique SID identifier of the Service. </param>
        /// <param name="channel"> JSON object describing Media Channel including Source and Participants </param>
        public CreateTranscriptOptions(string serviceSid, object channel)
        {
            ServiceSid = serviceSid;
            Channel = channel;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ServiceSid", ServiceSid));
            }
            if (Channel != null)
            {
                p.Add(new KeyValuePair<string, string>("Channel", Serializers.JsonObject(Channel)));
            }
            if (CustomerKey != null)
            {
                p.Add(new KeyValuePair<string, string>("CustomerKey", CustomerKey));
            }
            if (MediaStartTime != null)
            {
                p.Add(new KeyValuePair<string, string>("MediaStartTime", Serializers.DateTimeIso8601(MediaStartTime)));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific Transcript. </summary>
    public class DeleteTranscriptOptions : IOptions<TranscriptResource>
    {
        
        ///<summary> A 34 character string that uniquely identifies this Transcript. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteTranscriptOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Transcript. </param>
        public DeleteTranscriptOptions(string pathSid)
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


    /// <summary> Fetch a specific Transcript. </summary>
    public class FetchTranscriptOptions : IOptions<TranscriptResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this Transcript. </summary> 
        public string PathSid { get; }

        ///<summary> Grant access to PII Redacted/Unredacted Transcript. The default is `true` to access redacted Transcript. </summary> 
        public bool? Redacted { get; set; }



        /// <summary> Construct a new FetchTranscriptOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Transcript. </param>
        public FetchTranscriptOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Redacted != null)
            {
                p.Add(new KeyValuePair<string, string>("Redacted", Redacted.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


    /// <summary> Retrieve a list of Transcripts for a given service. </summary>
    public class ReadTranscriptOptions : ReadOptions<TranscriptResource>
    {
    
        ///<summary> The unique SID identifier of the Service. </summary> 
        public string ServiceSid { get; set; }

        ///<summary> Filter by before StartTime. </summary> 
        public string BeforeStartTime { get; set; }

        ///<summary> Filter by after StartTime. </summary> 
        public string AfterStartTime { get; set; }

        ///<summary> Filter by before DateCreated. </summary> 
        public string BeforeDateCreated { get; set; }

        ///<summary> Filter by after DateCreated. </summary> 
        public string AfterDateCreated { get; set; }

        ///<summary> Filter by status. </summary> 
        public string Status { get; set; }

        ///<summary> Filter by Language Code. </summary> 
        public string LanguageCode { get; set; }

        ///<summary> Filter by SourceSid. </summary> 
        public string SourceSid { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ServiceSid", ServiceSid));
            }
            if (BeforeStartTime != null)
            {
                p.Add(new KeyValuePair<string, string>("BeforeStartTime", BeforeStartTime));
            }
            if (AfterStartTime != null)
            {
                p.Add(new KeyValuePair<string, string>("AfterStartTime", AfterStartTime));
            }
            if (BeforeDateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("BeforeDateCreated", BeforeDateCreated));
            }
            if (AfterDateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("AfterDateCreated", AfterDateCreated));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status));
            }
            if (LanguageCode != null)
            {
                p.Add(new KeyValuePair<string, string>("LanguageCode", LanguageCode));
            }
            if (SourceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SourceSid", SourceSid));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}

