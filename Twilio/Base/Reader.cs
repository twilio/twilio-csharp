#if NET40
using System.Threading.Tasks;
#endif

using Twilio.Clients;

namespace Twilio.Base
{
    /// <summary>
    /// Executor for reading resources.
    /// </summary>
    /// <typeparam name="T">Type of the resource</typeparam>
    public abstract class Reader<T> where T : Resource
    {
        private const int MaxPageSize = 1000;

		private int pageSize = 50;

		#if NET40
        /// <summary>
        /// Execute an async request using the default client.
        /// </summary>
        /// <returns>Task that resolves to requested object</returns>
        public async Task<ResourceSet<T>> ReadAsync() {
			return await ReadAsync(TwilioClient.GetRestClient());
		}

        /// <summary>
        /// Execute an async request using a custom client.
        /// </summary>
        /// <param name="client">Custom client to use</param>
        /// <returns>Task that resolves to requested object</returns>
        public abstract Task<ResourceSet<T>> ReadAsync(ITwilioRestClient client);
		#endif

        /// <summary>
        /// Execute a request using the default client.
        /// </summary>
        /// <returns>Requested object</returns>
        public ResourceSet<T> Read() {
			return Read(TwilioClient.GetRestClient());
		}

        /// <summary>
        /// Execute a request using a custom client.
        /// </summary>
        /// <param name="client">Custom client to use</param>
        /// <returns>Requested object</returns>
        public abstract ResourceSet<T> Read(ITwilioRestClient client);

		public abstract Page<T> NextPage(string nextPageUri, ITwilioRestClient client);

		public int GetPageSize() {
			return this.pageSize;
		}

		public Reader<T> SetPageSize(int pageSize) {
			this.pageSize = System.Math.Min(pageSize, MaxPageSize);
			return this;
		}
    }
}