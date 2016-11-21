using Twilio.Clients;

namespace Twilio.Base
{
    /// <summary>
    /// Executor for fetching of a resource.
    /// </summary>
    /// <typeparam name="T">Type of the resource</typeparam>
    public abstract class Fetcher<T> where T : Resource
    {
        #if NET40
        /// <summary>
        /// Execute an async request using the default client.
        /// </summary>
        /// <returns>Task that resolves to requested object</returns>
        public async System.Threading.Tasks.Task<T> FetchAsync() {
            return await FetchAsync(TwilioClient.GetRestClient());
        }

        /// <summary>
        /// Execute an async request using a custom client.
        /// </summary>
        /// <param name="client">Custom client to use</param>
        /// <returns>Task that resolves to requested object</returns>
        public abstract System.Threading.Tasks.Task<T> FetchAsync(ITwilioRestClient client);
        #endif

        /// <summary>
        /// Execute a request using the default client.
        /// </summary>
        /// <returns>Requested object</returns>
        public T Fetch() {
            return Fetch(TwilioClient.GetRestClient());
        }

        /// <summary>
        /// Execute a request using a custom client.
        /// </summary>
        /// <param name="client">Custom client to use</param>
        /// <returns>Requested object</returns>
        public abstract T Fetch(ITwilioRestClient client);
    }
}