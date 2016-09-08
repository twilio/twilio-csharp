#if NET40
using System.Threading.Tasks;
#endif
using Twilio.Clients;

namespace Twilio.Base
{
    public abstract class Updater<T> where T : Resource
    {
		#if NET40
		public async Task<T> ExecuteAsync() {
			return await ExecuteAsync(TwilioClient.GetRestClient());
		}
        public abstract Task<T> ExecuteAsync(ITwilioRestClient client);
		#endif
		public T Execute() {
			return Execute(TwilioClient.GetRestClient());
		}
        public abstract T Execute(ITwilioRestClient client);
    }
}