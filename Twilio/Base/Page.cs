using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
	        this.Records = records;
	        this.PageSize = pageSize;
	        this._uri = uri;
	        this._url = url;
	        this._firstPageUri = firstPageUri;
	        this._firstPageUrl = firstPageUrl;
	        this._nextPageUri = nextPageUri;
	        this._nextPageUrl = nextPageUrl;
	        this._previousPageUri = previousPageUri;
	        this._previousPageUrl = previousPageUrl;
	    }

	    private static string UrlFromUri(string domain, string uri)
	    {
	        return "https://" + domain + ".twilio.com" + uri;
	    }

	    public string GetFirstPageUrl(string domain)
	    {
	        return _firstPageUrl ?? UrlFromUri(domain, _firstPageUri);
	    }

	    public string GetNextPageUrl(string domain)
	    {
	        return _nextPageUrl ?? UrlFromUri(domain, _nextPageUri);
	    }

	    public string GetPreviousPageUrl(string domain)
	    {
	        return _previousPageUrl ?? UrlFromUri(domain, _previousPageUri);
	    }

	    public string GetUrl(string domain)
	    {
	        return _url ?? UrlFromUri(domain, _uri);
	    }

	    public bool HasNextPage()
	    {
	        return !String.IsNullOrEmpty(_nextPageUrl) || !String.IsNullOrEmpty(_nextPageUri);
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