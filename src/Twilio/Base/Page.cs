using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twilio.Rest;
using static System.String;

namespace Twilio.Base
{
    /// <summary>
    /// Page of resources
    /// </summary>
    /// <typeparam name="T">Resource type</typeparam>
    public class Page<T> where T : Resource
    {
        /// <summary>
        /// Records for this page
        /// </summary>
        public List<T> Records { get; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; }

        private readonly string _uri;
        private readonly string _url;
        private readonly string _firstPageUri;
        private readonly string _firstPageUrl;
        private readonly string _nextPageUri;
        private readonly string _nextPageUrl;
        private readonly string _previousPageUri;
        private readonly string _previousPageUrl;

        private Page(
            List<T> records,
            int pageSize,
            string uri=null,
            string url=null,
            string firstPageUri=null,
            string firstPageUrl=null,
            string previousPageUri=null,
            string previousPageUrl=null,
            string nextPageUri=null,
            string nextPageUrl=null
        )
        {
            Records = records;
            PageSize = pageSize;
            _uri = uri;
            _url = url;
            _firstPageUri = firstPageUri;
            _firstPageUrl = firstPageUrl;
            _nextPageUri = nextPageUri;
            _nextPageUrl = nextPageUrl;
            _previousPageUri = previousPageUri;
            _previousPageUrl = previousPageUrl;
        }

        private static string UrlFromUri(Domain domain, string region, string uri)
        {
            var b = new StringBuilder();
            b.Append("https://").Append(domain);
            
            if (!IsNullOrEmpty(region))
            {
                b.Append(".").Append(region);
            }

            b.Append(".twilio.com").Append(uri);
            return b.ToString();
        }

        /// <summary>
        /// Generate the first page URL
        /// </summary>
        /// <param name="domain">Twilio subdomain</param>
        /// <param name="region">Twilio region</param>
        /// <returns>URL for the first page of results</returns>
        public string GetFirstPageUrl(Domain domain, string region)
        {
            return _firstPageUrl ?? UrlFromUri(domain, region, _firstPageUri);
        }

        /// <summary>
        /// Get the next page URL
        /// </summary>
        /// <param name="domain">Twilio subdomain</param>
        /// <param name="region">Twilio region</param>
        /// <returns>URL for the next page of results</returns>
        public string GetNextPageUrl(Domain domain, string region)
        {
            return _nextPageUrl ?? UrlFromUri(domain, region, _nextPageUri);
        }

        /// <summary>
        /// Get the previous page URL
        /// </summary>
        /// <param name="domain">Twilio subdomain</param>
        /// <param name="region">Twilio region</param>
        /// <returns>URL for the previous page of results</returns>
        public string GetPreviousPageUrl(Domain domain, string region)
        {
            return _previousPageUrl ?? UrlFromUri(domain, region, _previousPageUri);
        }

        /// <summary>
        /// Get the URL for the current page
        /// </summary>
        /// <param name="domain">Twilio subdomain</param>
        /// <param name="region">Twilio region</param>
        /// <returns>URL for the current page of results</returns>
        public string GetUrl(Domain domain, string region)
        {
            return _url ?? UrlFromUri(domain, region, _uri);
        }

        /// <summary>
        /// Determines if there is another page of results
        /// </summary>
        /// <returns>true if there is a next page; false otherwise</returns>
        public bool HasNextPage()
        {
            return !IsNullOrEmpty(_nextPageUrl) || !IsNullOrEmpty(_nextPageUri);
        }

        /// <summary>
        /// Converts a JSON payload to a Page of results
        /// </summary>
        /// <param name="recordKey">JSON key where the records are</param>
        /// <param name="json">JSON payload</param>
        /// <returns>Page of results</returns>
        public static Page<T> FromJson(string recordKey, string json)
        {
            var root = JObject.Parse(json);
            var records = root[recordKey];
            var parsedRecords = records.Children().Select(
                record => JsonConvert.DeserializeObject<T>(record.ToString())
            ).ToList();

            var uriNode = root["uri"];
            if (uriNode != null)
            {
                JToken pageSize;
                JToken firstPageUri;
                JToken nextPageUri;
                JToken previousPageUri;

                // v2010 API
                return new Page<T>(
                    parsedRecords,
                    root.TryGetValue("page_size", out pageSize) ? root["page_size"].Value<int>() : parsedRecords.Count,
                    uri: uriNode.Value<string>(),
                    firstPageUri: root.TryGetValue("first_page_uri", out firstPageUri) ? root["first_page_uri"].Value<string>() : null,
                    nextPageUri: root.TryGetValue("next_page_uri", out nextPageUri) ? root["next_page_uri"].Value<string>() : null,
                    previousPageUri: root.TryGetValue("previous_page_uri", out previousPageUri) ? root["previous_page_uri"].Value<string>() : null
                );
            }

            // next-gen API
            var meta = root["meta"];
            return new Page<T>(
                parsedRecords,
                meta["page_size"].Value<int>(),
                url: meta["url"].Value<string>(),
                firstPageUrl: meta["first_page_url"].Value<string>(),
                nextPageUrl: meta["next_page_url"].Value<string>(),
                previousPageUrl: meta["previous_page_url"].Value<string>()
            );
        }
    }
}