using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Twilio.Rest;
using static System.String;

namespace Twilio.Base
{
	public class Page<T> where T : Resource
	{
	    public List<T> Records { get; }
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

	    private static string UrlFromUri(Domain domain, string uri)
	    {
	        return "https://" + domain + ".twilio.com" + uri;
	    }

	    public string GetFirstPageUrl(Domain domain)
	    {
	        return _firstPageUrl ?? UrlFromUri(domain, _firstPageUri);
	    }

	    public string GetNextPageUrl(Domain domain)
	    {
	        return _nextPageUrl ?? UrlFromUri(domain, _nextPageUri);
	    }

	    public string GetPreviousPageUrl(Domain domain)
	    {
	        return _previousPageUrl ?? UrlFromUri(domain, _previousPageUri);
	    }

	    public string GetUrl(Domain domain)
	    {
	        return _url ?? UrlFromUri(domain, _uri);
	    }

	    public bool HasNextPage()
	    {
	        return !IsNullOrEmpty(_nextPageUrl) || !IsNullOrEmpty(_nextPageUri);
	    }

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
	            // v2010 API
	            return new Page<T>(
	                parsedRecords,
	                root["page_size"].Value<int>(),
	                uri: uriNode.Value<string>(),
	                firstPageUri: root["first_page_uri"].Value<string>(),
	                nextPageUri: root["next_page_uri"].Value<string>(),
	                previousPageUri: root["previous_page_uri"].Value<string>()
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