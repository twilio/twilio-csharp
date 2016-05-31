#if NET40
using System.Threading.Tasks;
#endif
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Updaters
{
    public abstract class Updater<T> where T : Resource
    {
		#if NET40
        public abstract Task<T> ExecuteAsync(ITwilioRestClient client);
		#endif
        public abstract T Execute(ITwilioRestClient client);
    }
}