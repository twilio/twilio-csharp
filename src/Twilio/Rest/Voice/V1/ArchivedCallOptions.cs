/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Voice
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




namespace Twilio.Rest.Voice.V1
{
    /// <summary> Delete an archived call record from Bulk Export. Note: this does not also delete the record from the Voice API. </summary>
    public class DeleteArchivedCallOptions : IOptions<ArchivedCallResource>
    {
        
        ///<summary> The date of the Call in UTC. </summary> 
        public DateTime? PathDate { get; }

        ///<summary> The Twilio-provided Call SID that uniquely identifies the Call resource to delete </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteArchivedCallOptions </summary>
        /// <param name="pathDate"> The date of the Call in UTC. </param>
        /// <param name="pathSid"> The Twilio-provided Call SID that uniquely identifies the Call resource to delete </param>
        public DeleteArchivedCallOptions(DateTime? pathDate, string pathSid)
        {
            PathDate = pathDate;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


}

