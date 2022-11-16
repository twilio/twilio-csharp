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
using System.Linq;



namespace Twilio.Rest.Api.V2010.Account.Call
{

    /// <summary> Create a recording for the call </summary>
    public class CreateRecordingOptions : IOptions<RecordingResource>
    {
        
        ///<summary> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) to associate the resource with. </summary> 
        public string PathCallSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The recording status events on which we should call the `recording_status_callback` URL. Can be: `in-progress`, `completed` and `absent` and the default is `completed`. Separate multiple event values with a space. </summary> 
        public List<string> RecordingStatusCallbackEvent { get; set; }

        ///<summary> The URL we should call using the `recording_status_callback_method` on each recording event specified in  `recording_status_callback_event`. For more information, see [RecordingStatusCallback parameters](https://www.twilio.com/docs/voice/api/recording#recordingstatuscallback). </summary> 
        public Uri RecordingStatusCallback { get; set; }

        ///<summary> The HTTP method we should use to call `recording_status_callback`. Can be: `GET` or `POST` and the default is `POST`. </summary> 
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }

        ///<summary> Whether to trim any leading and trailing silence in the recording. Can be: `trim-silence` or `do-not-trim` and the default is `do-not-trim`. `trim-silence` trims the silence from the beginning and end of the recording and `do-not-trim` does not. </summary> 
        public string Trim { get; set; }

        ///<summary> The number of channels used in the recording. Can be: `mono` or `dual` and the default is `mono`. `mono` records all parties of the call into one channel. `dual` records each party of a 2-party call into separate channels. </summary> 
        public string RecordingChannels { get; set; }

        ///<summary> The audio track to record for the call. Can be: `inbound`, `outbound` or `both`. The default is `both`. `inbound` records the audio that is received by Twilio. `outbound` records the audio that is generated from Twilio. `both` records the audio that is received and generated by Twilio. </summary> 
        public string RecordingTrack { get; set; }


        /// <summary> Construct a new CreateCallRecordingOptions </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) to associate the resource with. </param>

        public CreateRecordingOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
            RecordingStatusCallbackEvent = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (RecordingStatusCallbackEvent != null)
            {
                p.AddRange(RecordingStatusCallbackEvent.Select(RecordingStatusCallbackEvent => new KeyValuePair<string, string>("RecordingStatusCallbackEvent", RecordingStatusCallbackEvent)));
            }
            if (RecordingStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallback", Serializers.Url(RecordingStatusCallback)));
            }
            if (RecordingStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallbackMethod", RecordingStatusCallbackMethod.ToString()));
            }
            if (Trim != null)
            {
                p.Add(new KeyValuePair<string, string>("Trim", Trim));
            }
            if (RecordingChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingChannels", RecordingChannels));
            }
            if (RecordingTrack != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingTrack", RecordingTrack));
            }
            return p;
        }
        

    }
    /// <summary> Delete a recording from your account </summary>
    public class DeleteRecordingOptions : IOptions<RecordingResource>
    {
        
        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resources to delete. </summary> 
        public string PathCallSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Recording resource to delete. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording resources to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteCallRecordingOptions </summary>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resources to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording resource to delete. </param>

        public DeleteRecordingOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch an instance of a recording for a call </summary>
    public class FetchRecordingOptions : IOptions<RecordingResource>
    {
    
        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource to fetch. </summary> 
        public string PathCallSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Recording resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchCallRecordingOptions </summary>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording resource to fetch. </param>

        public FetchRecordingOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of recordings belonging to the call used to make the request </summary>
    public class ReadRecordingOptions : ReadOptions<RecordingResource>
    {
    
        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resources to read. </summary> 
        public string PathCallSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording resources to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The `date_created` value, specified as `YYYY-MM-DD`, of the resources to read. You can also specify inequality: `DateCreated<=YYYY-MM-DD` will return recordings generated at or before midnight on a given date, and `DateCreated>=YYYY-MM-DD` returns recordings generated at or after midnight on a date. </summary> 
        public DateTime? DateCreated { get; set; }

        ///<summary> The `date_created` value, specified as `YYYY-MM-DD`, of the resources to read. You can also specify inequality: `DateCreated<=YYYY-MM-DD` will return recordings generated at or before midnight on a given date, and `DateCreated>=YYYY-MM-DD` returns recordings generated at or after midnight on a date. </summary> 
        public DateTime? DateCreatedBefore { get; set; }

        ///<summary> The `date_created` value, specified as `YYYY-MM-DD`, of the resources to read. You can also specify inequality: `DateCreated<=YYYY-MM-DD` will return recordings generated at or before midnight on a given date, and `DateCreated>=YYYY-MM-DD` returns recordings generated at or after midnight on a date. </summary> 
        public DateTime? DateCreatedAfter { get; set; }



        /// <summary> Construct a new ListCallRecordingOptions </summary>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resources to read. </param>

        public ReadRecordingOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DateCreated != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreated", DateCreated.Value.ToString("yyyy-MM-dd")));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated<", DateCreatedBefore.Value.ToString("yyyy-MM-dd")));
                }
                if (DateCreatedAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateCreated>", DateCreatedAfter.Value.ToString("yyyy-MM-dd")));
                }

            }
            if (DateCreatedBefore != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedBefore", DateCreatedBefore.Value.ToString("yyyy-MM-dd")));
            }
            if (DateCreatedAfter != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedAfter", DateCreatedAfter.Value.ToString("yyyy-MM-dd")));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Changes the status of the recording to paused, stopped, or in-progress. Note: Pass `Twilio.CURRENT` instead of recording sid to reference current active recording. </summary>
    public class UpdateRecordingOptions : IOptions<RecordingResource>
    {
    
        ///<summary> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource to update. </summary> 
        public string PathCallSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Recording resource to update. </summary> 
        public string PathSid { get; }

        
        public RecordingResource.StatusEnum Status { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording resource to update. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Whether to record during a pause. Can be: `skip` or `silence` and the default is `silence`. `skip` does not record during the pause period, while `silence` will replace the actual audio of the call with silence during the pause period. This parameter only applies when setting `status` is set to `paused`. </summary> 
        public string PauseBehavior { get; set; }



        /// <summary> Construct a new UpdateCallRecordingOptions </summary>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording resource to update. </param>
        /// <param name="status">  </param>

        public UpdateRecordingOptions(string pathCallSid, string pathSid, RecordingResource.StatusEnum status)
        {
            PathCallSid = pathCallSid;
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
            if (PauseBehavior != null)
            {
                p.Add(new KeyValuePair<string, string>("PauseBehavior", PauseBehavior));
            }
            return p;
        }
        

    }


}

