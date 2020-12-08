/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account.Call
{

    /// <summary>
    /// Create a recording for the call
    /// </summary>
    public class CreateRecordingOptions : IOptions<RecordingResource>
    {
        /// <summary>
        /// The SID of the Account that will create the resource
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The SID of the Call to associate the resource with
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The recording status changes that should generate a callback
        /// </summary>
        public List<string> RecordingStatusCallbackEvent { get; set; }
        /// <summary>
        /// The callback URL on each selected recording event
        /// </summary>
        public Uri RecordingStatusCallback { get; set; }
        /// <summary>
        /// The HTTP method we should use to call `recording_status_callback`
        /// </summary>
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }
        /// <summary>
        /// Whether to trim the silence in the recording
        /// </summary>
        public string Trim { get; set; }
        /// <summary>
        /// The number of channels that the output recording will be configured with
        /// </summary>
        public string RecordingChannels { get; set; }
        /// <summary>
        /// Which track(s) to record
        /// </summary>
        public string RecordingTrack { get; set; }

        /// <summary>
        /// Construct a new CreateRecordingOptions
        /// </summary>
        /// <param name="pathCallSid"> The SID of the Call to associate the resource with </param>
        public CreateRecordingOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
            RecordingStatusCallbackEvent = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (RecordingStatusCallbackEvent != null)
            {
                p.AddRange(RecordingStatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("RecordingStatusCallbackEvent", prop)));
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

    /// <summary>
    /// Changes the status of the recording to paused, stopped, or in-progress. Note: Pass `Twilio.CURRENT` instead of
    /// recording sid to reference current active recording.
    /// </summary>
    public class UpdateRecordingOptions : IOptions<RecordingResource>
    {
        /// <summary>
        /// The SID of the Account that created the resource to update
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The Call SID of the resource to update
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The new status of the recording
        /// </summary>
        public RecordingResource.StatusEnum Status { get; }
        /// <summary>
        /// Whether to record or not during the pause period.
        /// </summary>
        public string PauseBehavior { get; set; }

        /// <summary>
        /// Construct a new UpdateRecordingOptions
        /// </summary>
        /// <param name="pathCallSid"> The Call SID of the resource to update </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="status"> The new status of the recording </param>
        public UpdateRecordingOptions(string pathCallSid, string pathSid, RecordingResource.StatusEnum status)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
            Status = status;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
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

    /// <summary>
    /// Fetch an instance of a recording for a call
    /// </summary>
    public class FetchRecordingOptions : IOptions<RecordingResource>
    {
        /// <summary>
        /// The SID of the Account that created the resource to fetch
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The Call SID of the resource to fetch
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchRecordingOptions
        /// </summary>
        /// <param name="pathCallSid"> The Call SID of the resource to fetch </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        public FetchRecordingOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Delete a recording from your account
    /// </summary>
    public class DeleteRecordingOptions : IOptions<RecordingResource>
    {
        /// <summary>
        /// The SID of the Account that created the resources to delete
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The Call SID of the resources to delete
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteRecordingOptions
        /// </summary>
        /// <param name="pathCallSid"> The Call SID of the resources to delete </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        public DeleteRecordingOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// Retrieve a list of recordings belonging to the call used to make the request
    /// </summary>
    public class ReadRecordingOptions : ReadOptions<RecordingResource>
    {
        /// <summary>
        /// The SID of the Account that created the resources to read
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The Call SID of the resources to read
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The `YYYY-MM-DD` value of the resources to read
        /// </summary>
        public DateTime? DateCreatedBefore { get; set; }
        /// <summary>
        /// The `YYYY-MM-DD` value of the resources to read
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// The `YYYY-MM-DD` value of the resources to read
        /// </summary>
        public DateTime? DateCreatedAfter { get; set; }

        /// <summary>
        /// Construct a new ReadRecordingOptions
        /// </summary>
        /// <param name="pathCallSid"> The Call SID of the resources to read </param>
        public ReadRecordingOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
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

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}