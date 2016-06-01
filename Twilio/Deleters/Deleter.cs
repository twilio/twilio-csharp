#if NET40
using System.Threading.Tasks;
#endif
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Deleters
{
    public abstract class Deleter<T> where T : Resource
    {
		#if NET40
		public Task ExecuteAsync() {
			return ExecuteAsync(TwilioClient.GetRestClient());
		}
		public abstract Task ExecuteAsync(ITwilioRestClient client);
		#endif
		public void Execute() {
			Execute(TwilioClient.GetRestClient());
		}
		public abstract void Execute(ITwilioRestClient client);
    }
}