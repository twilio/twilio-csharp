using System;
using System.Collections.Generic;
using Twilio.Clients;

namespace Twilio.Base
{
    /// <summary>
    /// A collection of resources of type T
    /// </summary>
    ///
    /// <typeparam name="T">Resource Type</typeparam>
	public class ResourceSet<T> : IEnumerable<T> where T : Resource
	{
	    public bool AutoPaging { get; set; }
	    public int? PageSize
	    {
	        get { return _reader.PageSize; }
	        set { _reader.PageSize = value; }
	    }

	    private readonly Reader<T> _reader;
	    private readonly ITwilioRestClient _client;
	    private readonly long _pageLimit;

	    private long _pages;
	    private long _processed;
	    private Page<T> _page;
		private IEnumerator<T> _iterator;

	    /// <summary>
	    /// Create a new resource set
	    /// </summary>
	    ///
	    /// <param name="reader">Reader of resources</param>
	    /// <param name="client">Client to make requests</param>
	    /// <param name="page">Page of resources</param>
	    public ResourceSet(Reader<T> reader, ITwilioRestClient client, Page<T> page)
	    {
	        _reader = reader;
	        _client = client;
	        _page = page;

	        _iterator = page.Records.GetEnumerator();
	        _processed = 0;
	        _pages = 1;
	        _pageLimit = long.MaxValue;

	        if (reader.Limit != null)
	        {
	            _pageLimit = (long) (Math.Ceiling((double) reader.Limit.Value / page.PageSize));
	        }
	    }

	    private void FetchNextPage()
	    {
	        if (!_page.HasNextPage() || _pages >= _pageLimit)
	        {
	            _page = null;
	            _iterator = null;
	            return;
	        }

            _pages++;
	        _page = _reader.NextPage(_page, _client);
	        _iterator = _page.Records.GetEnumerator();
	    }

	    /// <summary>
	    /// Get iterator for resources
	    /// </summary>
	    ///
	    /// <returns>IEnumerator of resources</returns>
	    public IEnumerator<T> GetEnumerator()
	    {
			while (_page != null)
			{
				_iterator.Reset();
				while (_iterator.MoveNext())
				{
				    // Exit if we've reached item limit
				    if (_reader.Limit != null && _processed > _reader.Limit.Value)
				    {
				        yield break;
				    }

				    _processed++;
					yield return _iterator.Current;
				}

				if (AutoPaging && _page.HasNextPage())
				{
					FetchNextPage();
				}
			}
		}

	    /// <summary>
	    /// Get iterator for resources
	    /// </summary>
	    ///
	    /// <returns>IEnumerator of resources</returns>
	    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
    }
}