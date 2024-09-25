/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Video
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




namespace Twilio.Rest.Video.V1.Room
{
    /// <summary> fetch </summary>
    public class FetchParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the room with the Participant resource to fetch. </summary> 
        public string PathRoomSid { get; }

        ///<summary> The SID of the RoomParticipant resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchRoomParticipantOptions </summary>
        /// <param name="pathRoomSid"> The SID of the room with the Participant resource to fetch. </param>
        /// <param name="pathSid"> The SID of the RoomParticipant resource to fetch. </param>
        public FetchParticipantOptions(string pathRoomSid, string pathSid)
        {
            PathRoomSid = pathRoomSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> read </summary>
    public class ReadParticipantOptions : ReadOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the room with the Participant resources to read. </summary> 
        public string PathRoomSid { get; }

        ///<summary> Read only the participants with this status. Can be: `connected` or `disconnected`. For `in-progress` Rooms the default Status is `connected`, for `completed` Rooms only `disconnected` Participants are returned. </summary> 
        public ParticipantResource.StatusEnum Status { get; set; }

        ///<summary> Read only the Participants with this [User](https://www.twilio.com/docs/chat/rest/user-resource) `identity` value. </summary> 
        public string Identity { get; set; }

        ///<summary> Read only Participants that started after this date in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#UTC) format. </summary> 
        public DateTime? DateCreatedAfter { get; set; }

        ///<summary> Read only Participants that started before this date in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601#UTC) format. </summary> 
        public DateTime? DateCreatedBefore { get; set; }



        /// <summary> Construct a new ListRoomParticipantOptions </summary>
        /// <param name="pathRoomSid"> The SID of the room with the Participant resources to read. </param>
        public ReadParticipantOptions(string pathRoomSid)
        {
            PathRoomSid = pathRoomSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            if (DateCreatedAfter != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedAfter", Serializers.DateTimeIso8601(DateCreatedAfter)));
            }
            if (DateCreatedBefore != null)
            {
                p.Add(new KeyValuePair<string, string>("DateCreatedBefore", Serializers.DateTimeIso8601(DateCreatedBefore)));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> update </summary>
    public class UpdateParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the room with the participant to update. </summary> 
        public string PathRoomSid { get; }

        ///<summary> The SID of the RoomParticipant resource to update. </summary> 
        public string PathSid { get; }

        
        public ParticipantResource.StatusEnum Status { get; set; }



        /// <summary> Construct a new UpdateRoomParticipantOptions </summary>
        /// <param name="pathRoomSid"> The SID of the room with the participant to update. </param>
        /// <param name="pathSid"> The SID of the RoomParticipant resource to update. </param>
        public UpdateParticipantOptions(string pathRoomSid, string pathSid)
        {
            PathRoomSid = pathRoomSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            return p;
        }

        

    }


}

