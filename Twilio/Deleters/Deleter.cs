using System.Threading.Tasks;
using Twilio.Resources;
using Twilio.Clients;

namespace Twilio.Deleters
{
    public abstract class Deleter<T> where T : Resource
    {
		public abstract Task ExecuteAsync(ITwilioRestClient client);
		public abstract void Execute(ITwilioRestClient client);
    }
}