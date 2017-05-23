using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Video.V1.Room 
{

    /// <summary>
    /// FetchRoomRecordingOptions
    /// </summary>
    public class FetchRoomRecordingOptions : IOptions<RoomRecordingResource> 
    {
        /// <summary>
        /// The room_sid
        /// </summary>
        public string PathRoomSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchRoomRecordingOptions
        /// </summary>
        ///
        /// <param name="pathRoomSid"> The room_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchRoomRecordingOptions(string pathRoomSid, string pathSid)
        {
            PathRoomSid = pathRoomSid;
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
    /// ReadRoomRecordingOptions
    /// </summary>
    public class ReadRoomRecordingOptions : ReadOptions<RoomRecordingResource> 
    {
        /// <summary>
        /// The room_sid
        /// </summary>
        public string PathRoomSid { get; }

        /// <summary>
        /// Construct a new ReadRoomRecordingOptions
        /// </summary>
        ///
        /// <param name="pathRoomSid"> The room_sid </param>
        public ReadRoomRecordingOptions(string pathRoomSid)
        {
            PathRoomSid = pathRoomSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}