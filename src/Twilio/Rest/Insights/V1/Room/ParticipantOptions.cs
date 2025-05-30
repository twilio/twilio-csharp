/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Insights
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




namespace Twilio.Rest.Insights.V1.Room
{
    /// <summary> Get Video Log Analyzer data for a Room Participant. </summary>
    public class FetchParticipantOptions : IOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the Room resource. </summary> 
        public string PathRoomSid { get; }

        ///<summary> The SID of the Participant resource. </summary> 
        public string PathParticipantSid { get; }



        /// <summary> Construct a new FetchVideoParticipantSummaryOptions </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        /// <param name="pathParticipantSid"> The SID of the Participant resource. </param>
        public FetchParticipantOptions(string pathRoomSid, string pathParticipantSid)
        {
            PathRoomSid = pathRoomSid;
            PathParticipantSid = pathParticipantSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Get a list of room participants. </summary>
    public class ReadParticipantOptions : ReadOptions<ParticipantResource>
    {
    
        ///<summary> The SID of the Room resource. </summary> 
        public string PathRoomSid { get; }



        /// <summary> Construct a new ListVideoParticipantSummaryOptions </summary>
        /// <param name="pathRoomSid"> The SID of the Room resource. </param>
        public ReadParticipantOptions(string pathRoomSid)
        {
            PathRoomSid = pathRoomSid;
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

}

