using System;
using System.Reflection;
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
        /// <summary>
        /// Automatically iterate through pages of results
        /// </summary>
        public bool AutoPaging { get; set; }

        private readonly ITwilioRestClient _client;
        private readonly ReadOptions<T> _options;
        private readonly long _pageLimit;

        private long _pages;
        private long _processed;
        private Page<T> _page;
        private IEnumerator<T> _iterator;

        /// <summary>
        /// Create a new resource set
        /// </summary>
        ///
        /// <param name="page">Page of resources</param>
        /// <param name="options">Read options</param>
        /// <param name="client">Client to make requests</param>
        public ResourceSet(Page<T> page, ReadOptions<T> options, ITwilioRestClient client)
        {
            _page = page;
            _options = options;
            _client = client;

            _iterator = page.Records.GetEnumerator();
            _processed = 0;
            _pages = 1;
            _pageLimit = long.MaxValue;

            AutoPaging = true;

            if (_options.Limit != null)
            {
                _pageLimit = (long) (Math.Ceiling((double) _options.Limit.Value / page.PageSize));
            }
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
                    if (_options.Limit != null && _processed > _options.Limit.Value)
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
                else
                {
                    break;
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

        private void FetchNextPage()
        {
            if (!_page.HasNextPage() || _pages >= _pageLimit)
            {
                _page = null;
                _iterator = null;
                return;
            }

            _pages++;
            _page = (Page<T>)GetNextPage().Invoke(null, new object[]{ _page, _client });
            _iterator = _page.Records.GetEnumerator();
        }

        private static MethodInfo GetNextPage()
        {
#if !NET35
            return typeof(T).GetRuntimeMethod("NextPage", new[]{ typeof(Page<T>), typeof(ITwilioRestClient) });
#else
            return typeof(T).GetMethod("NextPage", new[]{ typeof(Page<T>), typeof(ITwilioRestClient) });
#endif
        }
    }
}
