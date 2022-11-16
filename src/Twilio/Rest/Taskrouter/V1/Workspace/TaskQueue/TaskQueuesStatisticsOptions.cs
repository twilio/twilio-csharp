/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Taskrouter
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




namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue
{
    /// <summary> read </summary>
    public class ReadTaskQueuesStatisticsOptions : ReadOptions<TaskQueuesStatisticsResource>
    {
    
        ///<summary> The SID of the Workspace with the TaskQueues to read. </summary> 
        public string PathWorkspaceSid { get; }

        ///<summary> Only calculate statistics from this date and time and earlier, specified in GMT as an [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date-time. </summary> 
        public DateTime? EndDate { get; set; }

        ///<summary> The `friendly_name` of the TaskQueue statistics to read. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Only calculate statistics since this many minutes in the past. The default is 15 minutes. </summary> 
        public int? Minutes { get; set; }

        ///<summary> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        public DateTime? StartDate { get; set; }

        ///<summary> Only calculate statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </summary> 
        public string TaskChannel { get; set; }

        ///<summary> A comma separated list of values that describes the thresholds, in seconds, to calculate statistics on. For each threshold specified, the number of Tasks canceled and reservations accepted above and below the specified thresholds in seconds are computed. </summary> 
        public string SplitByWaitTime { get; set; }



        /// <summary> Construct a new ListTaskQueuesStatisticsOptions </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the TaskQueues to read. </param>

        public ReadTaskQueuesStatisticsOptions(string pathWorkspaceSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", Serializers.DateTimeIso8601(EndDate)));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (Minutes != null)
            {
                p.Add(new KeyValuePair<string, string>("Minutes", Minutes.ToString()));
            }
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", Serializers.DateTimeIso8601(StartDate)));
            }
            if (TaskChannel != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskChannel", TaskChannel));
            }
            if (SplitByWaitTime != null)
            {
                p.Add(new KeyValuePair<string, string>("SplitByWaitTime", SplitByWaitTime));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}

