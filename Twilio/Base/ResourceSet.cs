using System.Collections.Generic;
using Twilio.Clients;

namespace Twilio.Base
{
	public class ResourceSet<T> : IEnumerable<T> where T : Resource
	{
	    private readonly Reader<T> _reader;
	    private readonly ITwilioRestClient _client;

	    private bool AutoPaging { get; set; }
	    private long _pages;
	    private long _pageLimit;
	    private long _processed;
	    private Page<T> _page;
		private IEnumerator<T> _iterator;

	    public ResourceSet(Reader<T> reader, ITwilioRestClient client, Page<T> page)
	    {
	        _reader = reader;
	        _client = client;
	        _page = page;

	        _iterator = page.Records.GetEnumerator();
	        _processed = 0;
	        _pages = 1;
	        _pageLimit = long.MaxValue;
	    }

	    protected void FetchNextPage()
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

	    public int GetPageSize()
	    {
	        return _page.PageSize;
	    }

	    public void SetPageSize(int pageSize)
	    {
	        _reader.PageSize = pageSize;
	    }

	    public IEnumerator<T> GetEnumerator() {
			while (_page != null)
			{
				_iterator.Reset();
				while (_iterator.MoveNext())
				{
				    _processed++;
					yield return _iterator.Current;
				}

				if (AutoPaging && _page.HasNextPage())
				{
					FetchNextPage();
				}
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
    }
}