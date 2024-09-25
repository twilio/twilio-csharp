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




namespace Twilio.Rest.Insights.V1.Conference
{
    /// <summary> Get a specific Conference Participant Summary for a Conference. </summary>
    public class FetchConferenceParticipantOptions : IOptions<ConferenceParticipantResource>
    {
    
        ///<summary> The unique SID identifier of the Conference. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The unique SID identifier of the Participant. </summary> 
        public string PathParticipantSid { get; }

        ///<summary> Conference events generated by application or participant activity; e.g. `hold`, `mute`, etc. </summary> 
        public string Events { get; set; }

        ///<summary> Object. Contains participant call quality metrics. </summary> 
        public string Metrics { get; set; }



        /// <summary> Construct a new FetchConferenceParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The unique SID identifier of the Conference. </param>
        /// <param name="pathParticipantSid"> The unique SID identifier of the Participant. </param>
        public FetchConferenceParticipantOptions(string pathConferenceSid, string pathParticipantSid)
        {
            PathConferenceSid = pathConferenceSid;
            PathParticipantSid = pathParticipantSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Events != null)
            {
                p.Add(new KeyValuePair<string, string>("Events", Events));
            }
            if (Metrics != null)
            {
                p.Add(new KeyValuePair<string, string>("Metrics", Metrics));
            }
            return p;
        }

    

    }


    /// <summary> Get a list of Conference Participants Summaries for a Conference. </summary>
    public class ReadConferenceParticipantOptions : ReadOptions<ConferenceParticipantResource>
    {
    
        ///<summary> The unique SID identifier of the Conference. </summary> 
        public string PathConferenceSid { get; }

        ///<summary> The unique SID identifier of the Participant. </summary> 
        public string ParticipantSid { get; set; }

        ///<summary> User-specified label for a participant. </summary> 
        public string Label { get; set; }

        ///<summary> Conference events generated by application or participant activity; e.g. `hold`, `mute`, etc. </summary> 
        public string Events { get; set; }



        /// <summary> Construct a new ListConferenceParticipantOptions </summary>
        /// <param name="pathConferenceSid"> The unique SID identifier of the Conference. </param>
        public ReadConferenceParticipantOptions(string pathConferenceSid)
        {
            PathConferenceSid = pathConferenceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ParticipantSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ParticipantSid", ParticipantSid));
            }
            if (Label != null)
            {
                p.Add(new KeyValuePair<string, string>("Label", Label));
            }
            if (Events != null)
            {
                p.Add(new KeyValuePair<string, string>("Events", Events));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}

