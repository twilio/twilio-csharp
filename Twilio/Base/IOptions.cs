using System;
using System.Collections.Generic;

namespace Twilio.Base
{
    public interface IOptions<T> where T : Resource
    {
        List<KeyValuePair<string, string>> GetParams();
    }

    public abstract class ReadOptions<T> : IOptions<T> where T : Resource
    {
        private const int MaxPageSize = 1000;

        private int? _pageSize;
        public int? PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value == null)
                {
                    return;
                }

                _pageSize = Math.Min(value.Value, MaxPageSize);
            }
        }

        private long? _limit;
        public long? Limit
        {
            get { return _limit; }
            set
            {
                if (value == null)
                {
                    return;
                }

                _limit = value;
                if (_pageSize == null)
                {
                    _pageSize = (int) Math.Min(value.Value, MaxPageSize);
                }
            }
        }

        public abstract List<KeyValuePair<string, string>> GetParams();
    }
}