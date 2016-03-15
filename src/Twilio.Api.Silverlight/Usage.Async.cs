using System;
using RestSharp;
using RestSharp.Validation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Returns a list of all usage resources
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsage(Action<UsageResult> callback)
        {
            ListUsage("", callback);
        }

        /// <summary>
        /// Returns a list of usage resources for a specific usage category
        /// </summary>
        /// <param name="category">The category used to filter the usage data</param>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsage(string category, Action<UsageResult> callback)
        {
            ListUsage(category, "", callback);
        }

        /// <summary>
        /// Returns a list of usage resources for a specific category, where the data grouped using a specific interval
        /// </summary>
        /// <param name="category">The category used to filter the usage data</param>
        /// <param name="interval">The time interval used to group the usage data</param>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsage(string category, string interval, Action<UsageResult> callback)
        {
            ListUsage(category, interval, null, null, callback);
        }

        /// <summary>
        /// Returns a list of usage resources for a specific category, within a specific date range
        /// </summary>
        /// <param name="category">The category used to filter the usage data</param>
        /// <param name="startDate">The start date of the filter range</param>
        /// <param name="endDate">The end date of the filter range</param>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsage(string category, DateTime? startDate, DateTime? endDate, Action<UsageResult> callback)
        {
            ListUsage(category, "", startDate, endDate, callback);
        }

        /// <summary>
        /// Returns a list of usage resources for a specific category, within a specific date range, grouped by a specific time interval
        /// </summary>
        /// <param name="category">The category used to filter the usage data</param>
        /// <param name="interval">The time interval used to group the usage data</param>
        /// <param name="startDate">The start date of the filter range</param>
        /// <param name="endDate">The end date of the filter range</param>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsage(string category, string interval, DateTime? startDate, DateTime? endDate, Action<UsageResult> callback)
        {
            ListUsage(category, interval, startDate, endDate, null, null, callback);
        }

        /// <summary>
        /// Returns a list of usage resources for a specific category, within a specific date range, grouped by a specific time interval
        /// </summary>
        /// <param name="category">The category used to filter the usage data</param>
        /// <param name="interval">The time interval used to group the usage data</param>
        /// <param name="startDate">The start date of the filter range</param>
        /// <param name="endDate">The end date of the filter range</param>
        /// <param name="pageNumber">(Optional) The page to start retrieving results from</param>
        /// <param name="count">(Optional) The number of results to retrieve</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListUsage(string category, string interval, DateTime? startDate, DateTime? endDate, int? pageNumber, int? count, Action<UsageResult> callback)
        {
            var request = new RestRequest();
            string resourceUrlRoot = "Accounts/{{AccountSid}}/Usage/Records{0}";

            if (!string.IsNullOrEmpty(interval))
            {
                request.Resource = string.Format(resourceUrlRoot, "/{Interval}.json");
                request.AddUrlSegment("Interval", interval);
            }
            else
            {
                request.Resource = string.Format(resourceUrlRoot, ".json");
            }

            if (!string.IsNullOrEmpty(category)) { request.AddParameter("Category", category.ToLower()); }
            if (startDate.HasValue) { request.AddParameter("StartDate", startDate.Value.ToString("yyyy-MM-dd")); }
            if (endDate.HasValue) { request.AddParameter("EndDate", endDate.Value.ToString("yyyy-MM-dd")); }
            if (pageNumber.HasValue) { request.AddParameter("Page", pageNumber.Value); }
            if (count.HasValue) { request.AddParameter("PageSize", count.Value); }

            ExecuteAsync<UsageResult>(request, (response) => callback(response));
        }
        /// <summary>
        /// Returns a list of usage triggers
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsageTriggers(Action<UsageTriggerResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Usage/Triggers.json";

            ExecuteAsync<UsageTriggerResult>(request, response => callback(response));
        }

        /// <summary>
        /// Returns a list of usage triggers
        /// </summary>
        /// <param name="recurring">A string defining the recurrance interval for this trigger</param>
        /// <param name="usageCategory">The usage category this trigger watches</param>
        /// <param name="triggerBy">The value at which the trigger will fire</param>
        /// <param name="callback"></param>
        /// <returns></returns>
		public virtual void ListUsageTriggers(string recurring, string usageCategory, string triggerBy, Action<UsageTriggerResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Usage/Triggers.json";

            if (!string.IsNullOrEmpty(recurring)) { request.AddParameter("Recurring", recurring); }
            if (!string.IsNullOrEmpty(usageCategory)) { request.AddParameter("UsageCategory", usageCategory); }
            if (!string.IsNullOrEmpty(triggerBy)) { request.AddParameter("TriggerBy", triggerBy); }

            ExecuteAsync<UsageTriggerResult>(request, response => callback(response));
        }

        /// <summary>
        /// Locates and returns a specific Usage Trigger resource
        /// </summary>
        /// <param name="usageTriggerSid">The Sid of the Usage Trigger to locate</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual void GetUsageTrigger(string usageTriggerSid, Action<UsageTrigger> callback)
        {
            Require.Argument("UsageTriggerSid", usageTriggerSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Usage/Triggers/{UsageTriggerSid}.json";

            request.AddUrlSegment("UsageTriggerSid", usageTriggerSid);

            ExecuteAsync<UsageTrigger>(request, response => callback(response));
        }

        /// <summary>
        /// Creates a new Usage Trigger resource
        /// </summary>
        /// <param name="usageCategory">The usage category to trigger on</param>
        /// <param name="triggerValue">The the value to trigger on</param>
        /// <param name="callbackUrl">The URL to call once a trigger value has been met</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual void CreateUsageTrigger(string usageCategory, string triggerValue, string callbackUrl, Action<UsageTrigger> callback)
        {
            var options = new UsageTriggerOptions();
            options.UsageCategory = usageCategory;
            options.TriggerValue = triggerValue;
            options.CallbackUrl = callbackUrl;

            CreateUsageTrigger(options, callback);
        }

        /// <summary>
        /// Creates a new Usage Trigger resource
        /// </summary>
        /// <param name="options">A UsageTriggerOption object that defines the different trigger options</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual void CreateUsageTrigger(UsageTriggerOptions options, Action<UsageTrigger> callback)
        {
            Require.Argument("UsageCategory", options.UsageCategory);
            Require.Argument("TriggerValue", options.TriggerValue);
            Require.Argument("CallbackUrl", options.CallbackUrl);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Usage/Triggers.json";

            request.Method = Method.POST;

            request.AddParameter("UsageCategory", options.UsageCategory);
            request.AddParameter("TriggerValue", options.TriggerValue);
            request.AddParameter("CallbackUrl", options.CallbackUrl);

            if (!string.IsNullOrEmpty(options.CallbackMethod)) { request.AddParameter("CallbackMethod", options.CallbackMethod); }
            if (!string.IsNullOrEmpty(options.FriendlyName)) { request.AddParameter("FriendlyName", options.FriendlyName); }
            if (!string.IsNullOrEmpty(options.Recurring)) { request.AddParameter("Recurring", options.Recurring); }
            if (!string.IsNullOrEmpty(options.TriggerBy)) { request.AddParameter("TriggerBy", options.TriggerBy); }

            ExecuteAsync<UsageTrigger>(request, response => callback(response));
        }

        /// <summary>
        /// Updates a specific UsageTrigger resource
        /// </summary>
        /// <param name="usageTriggerSid">The Sid of the UsageTrigger to update</param>
        /// <param name="friendlyName">The friendly name of the trigger</param>
        /// <param name="callbackUrl">The URL to call once a trigger value has been met</param>
        /// <param name="callbackMethod">The HTTP method used when requesting the callback URL</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual void UpdateUsageTrigger(string usageTriggerSid, string friendlyName, string callbackUrl, string callbackMethod, Action<UsageTrigger> callback)
        {
            Require.Argument("UsageTriggerSid", usageTriggerSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Usage/Triggers/{UsageTriggerSid}.json";

            request.Method = Method.POST;

            request.AddUrlSegment("UsageTriggerSid", usageTriggerSid);

            if (!string.IsNullOrEmpty(friendlyName)) { request.AddParameter("FriendlyName", friendlyName); }
            if (!string.IsNullOrEmpty(callbackUrl)) { request.AddParameter("CallbackUrl", callbackUrl); }
            if (!string.IsNullOrEmpty(callbackMethod)) { request.AddParameter("CallbackMethod", callbackMethod); }

            ExecuteAsync<UsageTrigger>(request, response => callback(response));
        }

        /// <summary>
        /// Deletes a UsageTrigger resource
        /// </summary>
        /// <param name="usageTriggerSid">The Sid of the UsageTrigger to delete</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual void DeleteUsageTrigger(string usageTriggerSid, Action<DeleteStatus> callback)
        {
            Require.Argument("UsageTriggerSid", usageTriggerSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Usage/Triggers/{UsageTriggerSid}.json";

            request.Method = Method.DELETE;

            request.AddUrlSegment("UsageTriggerSid", usageTriggerSid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }
    }
}

