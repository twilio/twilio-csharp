using System;
using System.Collections.Generic;

namespace Twilio.Base
{
    /// <summary>
    /// Interface to wrap parameters of a resource
    /// </summary>
    /// <typeparam name="T">Resource type</typeparam>
    public interface IOptions<T> where T : Resource
    {
        /// <summary>
        /// Generate the list of parameters for the request
        /// </summary>
        ///
        /// <returns>List of parameters for the request</returns>
        List<KeyValuePair<string, string>> GetParams();
    }

    /// <summary>
    /// Parameters that are passed when reading resources
    /// </summary>
    /// <typeparam name="T">Resource type</typeparam>
    public abstract class ReadOptions<T> : IOptions<T> where T : Resource
    {
        private int? _pageSize;

        /// <summary>
        /// Page size to read
        /// </summary>
        public int? PageSize
        {
            get { return _pageSize; }
            set
            {
                if (value == null)
                {
                    return;
                }

                _pageSize = value.Value;
            }
        }

        private long? _limit;

        /// <summary>
        /// Maximum number of records to read
        /// </summary>
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
                    _pageSize = (int) value.Value;
                }
            }
        }

        /// <summary>
        /// Generate the list of parameters for the request
        /// </summary>
        ///
        /// <returns>List of parameters for the request</returns>
        public abstract List<KeyValuePair<string, string>> GetParams();
    }
}
